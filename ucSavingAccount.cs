using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyGuiTietKiem
{
    public partial class ucSavingAccount : UserControl
    {
        public ucSavingAccount()
        {
            InitializeComponent();
        }

        private DataTable ExecuteQuery(string query)
        {
            string connectionString = "Server=DESKTOP-87AFJH3;Database=QuanLyGuiTietKiem;Integrated Security=True;";  // Cập nhật chuỗi kết nối của bạn
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlDataAdapter dataAdapter = new SqlDataAdapter(query, connection);
                DataTable dataTable = new DataTable();
                try
                {
                    connection.Open();  // Mở kết nối
                    dataAdapter.Fill(dataTable);  // Điền dữ liệu vào DataTable từ kết quả truy vấn
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi kết nối cơ sở dữ liệu: " + ex.Message);
                }
                return dataTable;
            }
        }
        private void LoadSavingsAccounts()
        {
            // Cập nhật code để kết nối đến database và hiển thị danh sách sổ tiết kiệm
            // Giả sử sử dụng SqlDataAdapter để lấy dữ liệu vào DataGridView.
            string query = "EXEC sp_XemDanhSachSoTietKiem";
            DataTable dt = ExecuteQuery(query); // ExecuteQuery là hàm để thực hiện truy vấn
            dgvSavingsAccounts.DataSource = dt;
        }


        private void btnViewDetails_Click(object sender, EventArgs e)
        {
            string accountId = txtAccountID.Text;
            if (string.IsNullOrEmpty(accountId))
            {
                lblMessage.Text = "Vui lòng nhập mã sổ để xem chi tiết.";
                return;
            }

            // Thực hiện gọi stored procedure để lấy chi tiết sổ
            string query = "EXEC sp_XemChiTietSoTietKiem @MaSoTK = '" + accountId + "'";
            DataTable dt = ExecuteQuery(query);

            if (dt.Rows.Count > 0)
            {
                // Hiển thị chi tiết sổ
                // Ví dụ: Đưa dữ liệu vào form chi tiết
            }
            else
            {
                lblMessage.Text = "Không tìm thấy sổ tiết kiệm với mã này.";
            }
        }

        private void ucSavingAccount_Load(object sender, EventArgs e)
        {
            LoadSavingsAccounts();  // Gọi thủ tục hiển thị danh sách sổ tiết kiệm
        }

        private void btnCalculateInterest_Click(object sender, EventArgs e)
        {
            
                string accountId = txtAccountID.Text;
                if (string.IsNullOrEmpty(accountId))
                {
                    lblMessage.Text = "Vui lòng nhập mã sổ để tính lãi.";
                    return;
                }

                string query = "EXEC sp_TinhLaiDuKien @MaSoTK = '" + accountId + "'";
                DataTable dt = ExecuteQuery(query);

                if (dt.Rows.Count > 0)
                {
                    // Hiển thị lãi dự kiến
                    decimal interest = Convert.ToDecimal(dt.Rows[0]["LaiDuKien"]);
                    lblMessage.Text = "Lãi dự kiến: " + interest.ToString("C");
                }
                else
                {
                    lblMessage.Text = "Không thể tính lãi cho sổ tiết kiệm này.";
                }
            }

        private void btnRequestOpen_Click(object sender, EventArgs e)
        {

        }
    }
    
}
