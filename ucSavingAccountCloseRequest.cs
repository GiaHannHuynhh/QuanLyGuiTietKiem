using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyGuiTietKiem
{
    public partial class ucSavingAccountCloseRequest : UserControl
    {
        public ucSavingAccountCloseRequest()
        {
            InitializeComponent();
        }

        private string maSoTK;

        // Constructor nhận MaKH
        public ucSavingAccountCloseRequest(string maSoTK)
        {
            InitializeComponent();
            this.maSoTK = maSoTK;
        }



        private string connectionString = "Server=DESKTOP-87AFJH3;Database=QuanLyGuiTietKiem;Integrated Security=True;";

        private DataTable ExecuteQuery(string query)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                conn.Open();
                da.Fill(dt);
                return dt;
            }
        }

        private string GenerateMaYC()
        {
            return "YC" + DateTime.Now.ToString("yyyyMMddHHmmss");
        }

        private void ucSavingAccountCloseRequest_Load(object sender, EventArgs e)
        {
     
            txtAccount.Text = "Sổ tiết kiệm: " + maSoTK;
            decimal SoDu = LaySoDuHienTai(maSoTK);
            txtSoDuHienTai.Text = SoDu.ToString();
        }

        private void btnSubmitCloseRequest_Click(object sender, EventArgs e)
        {
            string maYC = GenerateMaYC();
            decimal soTien = LaySoDuHienTai(maSoTK); // Tự động lấy số dư sổ tiết kiệm
            
            // Kiểm tra số dư có hợp lệ không
            if (soTien <= 0)
            {
                MessageBox.Show("Số dư không hợp lệ!");
                return;
            }

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("sp_YeuCauTatToan", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@MaYC", maYC);
                    cmd.Parameters.AddWithValue("@MaSoTK", maSoTK);
                    cmd.Parameters.AddWithValue("@SoTien", soTien);

                    try
                    {
                        conn.Open();
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Gửi yêu cầu tất toán thành công!");
                    }
                    catch (SqlException ex)
                    {
                        MessageBox.Show("Lỗi: " + ex.Message);
                    }
                }
            }
        }

        private decimal LaySoDuHienTai(string maSoTK)
        {
            decimal soDu = 0;

            string query = $"SELECT SoDuHienTai FROM TAI_KHOAN_TIET_KIEM WHERE MaSoTK = '{maSoTK}'";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    conn.Open();
                    var result = cmd.ExecuteScalar();
                    if (result != null)
                    {
                        soDu = Convert.ToDecimal(result);
                    }
                }
            }

            return soDu;
        }

    }
}
