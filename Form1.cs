using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace QuanLyGuiTietKiem
{
    public partial class Form1 : Form
    {
        private string connectionString = ConfigurationManager.ConnectionStrings["QuanLyGuiTietKiemConnection"].ConnectionString;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Tạo role và tài khoản admin mặc định khi ứng dụng khởi động
            InitializeSystem();
            // Hiển thị form đăng nhập
            new LoginForm().Show();
            this.Hide();
        }

        private void InitializeSystem()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    // Tạo role
                    SqlCommand cmdCreateRoles = new SqlCommand("sp_CreateRoles", conn);
                    cmdCreateRoles.CommandType = CommandType.StoredProcedure;
                    cmdCreateRoles.ExecuteNonQuery();

                    // Tạo tài khoản admin mặc định
                    SqlCommand cmdCreateAdmin = new SqlCommand("sp_CreateLoginAndUser", conn);
                    cmdCreateAdmin.CommandType = CommandType.StoredProcedure;
                    cmdCreateAdmin.Parameters.AddWithValue("@TenDangNhap", "admin");
                    cmdCreateAdmin.Parameters.AddWithValue("@MatKhau", "admin123");
                    cmdCreateAdmin.Parameters.AddWithValue("@VaiTro", "ADMIN");
                    cmdCreateAdmin.Parameters.Add("@KetQua", SqlDbType.Bit).Direction = ParameterDirection.Output;
                    cmdCreateAdmin.Parameters.Add("@ThongBao", SqlDbType.NVarChar, 255).Direction = ParameterDirection.Output;
                    cmdCreateAdmin.ExecuteNonQuery();

                    bool ketQua = (bool)cmdCreateAdmin.Parameters["@KetQua"].Value;
                    string thongBao = cmdCreateAdmin.Parameters["@ThongBao"].Value.ToString();
                    if (!ketQua)
                    {
                        MessageBox.Show($"Lỗi khi tạo tài khoản admin: {thongBao}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    // Cấp quyền cho các role
                    SqlCommand cmdGrantPermissions = new SqlCommand("sp_GrantPermissions", conn);
                    cmdGrantPermissions.CommandType = CommandType.StoredProcedure;
                    cmdGrantPermissions.ExecuteNonQuery();

                    // Thêm tài khoản admin vào bảng TAI_KHOAN_DANG_NHAP nếu chưa có
                    SqlCommand cmdInsertAdmin = new SqlCommand(
                        "IF NOT EXISTS (SELECT 1 FROM TAI_KHOAN_DANG_NHAP WHERE TenDangNhap = 'admin') " +
                        "INSERT INTO TAI_KHOAN_DANG_NHAP (TenDangNhap, MatKhau, MaNV, MaKH) VALUES ('admin', 'admin123', NULL, NULL);",
                        conn);
                    cmdInsertAdmin.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi khởi tạo hệ thống: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}