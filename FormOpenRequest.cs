using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyGuiTietKiem
{
    public partial class FormOpenRequest : Form
    {
        public FormOpenRequest()
        {
            InitializeComponent();
        }

        private string maKH;

        // Constructor nhận MaKH
        public FormOpenRequest(string maKH)
        {
            InitializeComponent();
            this.maKH = maKH;
        }


        private void btnMinimize_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // Khai báo để di chuyển form
        // Import các hàm từ user32.dll
        [DllImport("user32.dll")]
        public static extern bool ReleaseCapture();

        [DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);

        // Các hằng số dùng để kéo form
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HTCAPTION = 0x2;

        private void LoadLoaiTietKiem()
        {
            string query = "SELECT MaLoaiTK, TenLoaiTK FROM LOAI_TIET_KIEM"; // Truy vấn để lấy danh sách loại tiết kiệm
            DataTable dt = ExecuteQuery(query);

            if (dt.Rows.Count > 0)
            {
                cmbLoaiTK.DataSource = dt;
                cmbLoaiTK.DisplayMember = "TenLoaiTK"; // Cột cần hiển thị trong combobox
                cmbLoaiTK.ValueMember = "MaLoaiTK";   // Cột chứa giá trị của item khi chọn
            }
            else
            {
                MessageBox.Show("Không có loại tiết kiệm nào trong hệ thống.");
            }
        }

        private DataTable ExecuteQuery(string query)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlDataAdapter dataAdapter = new SqlDataAdapter(query, connection);
                DataTable dataTable = new DataTable();
                try
                {
                    connection.Open();
                    dataAdapter.Fill(dataTable);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi kết nối cơ sở dữ liệu: " + ex.Message);
                }
                return dataTable;
            }
        }


        private void FormOpenRequest_Load(object sender, EventArgs e)
        {
            panelHeader.MouseDown += panelHeader_MouseDown;
            LoadLoaiTietKiem();  // Gọi hàm load dữ liệu vào combobox loại tiết kiệm

        }
        private void panelHeader_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(this.Handle, 0xA1, 0x2, 0);
            }
        }
        private string GenerateMaYC()
        {
            return "YC" + DateTime.Now.ToString("yyyyMMddHHmmss");
        }

        private string connectionString = "Server=DESKTOP-87AFJH3;Database=QuanLyGuiTietKiem;Integrated Security=True;";

        private void btnGuiYeuCau_Click(object sender, EventArgs e)
        {
            string maYC = GenerateMaYC();
            string maLoaiTK = cmbLoaiTK.SelectedValue.ToString();
            decimal soTien;
            if (!decimal.TryParse(txtSoTien.Text, out soTien))
            {
                MessageBox.Show("Số tiền không hợp lệ!");
                return;
            }
            DateTime ngayYeuCau = dtpNgayYeuCau.Value;

            string query = "EXEC sp_YeuCauMoSo @MaYC, @MaKH, @MaLoaiTK, @SoTien, @NgayYeuCau";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@MaYC", maYC);
                    cmd.Parameters.AddWithValue("@MaKH", maKH); // dùng MaKH đã lưu
                    cmd.Parameters.AddWithValue("@MaLoaiTK", maLoaiTK);
                    cmd.Parameters.AddWithValue("@SoTien", soTien);
                    cmd.Parameters.AddWithValue("@NgayYeuCau", ngayYeuCau);

                    try
                    {
                        conn.Open();
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Gửi yêu cầu mở sổ thành công!");
                        this.Close();
                    }
                    catch (SqlException ex)
                    {
                        MessageBox.Show("Lỗi: " + ex.Message);
                    }
                }
            }


        }
    }
}
