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
        private string currentCustomerId = "KH001";  // Giả định là lấy được từ đăng nhập. Tạm truyền thẳng

        public ucSavingAccount()
        {
            InitializeComponent();
        }

        private string connectionString = "Server=DESKTOP-87AFJH3;Database=QuanLyGuiTietKiem;Integrated Security=True;";

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
        private void LoadSavingsAccounts()
        {
            
        }

        private void LoadSavingsAccountsForCustomer(string maKH)
        {
            string query = $"SELECT MaSoTK FROM TAI_KHOAN_TIET_KIEM WHERE MaKH = '{maKH}'";
            DataTable dt = ExecuteQuery(query);

            // Kiểm tra xem DataTable có dữ liệu hay không
            if (dt.Rows.Count > 0)
            {
                cmbAccounts.DataSource = dt;
                cmbAccounts.DisplayMember = "MaSoTK"; // Chỉ định cột cần hiển thị
                cmbAccounts.ValueMember = "MaSoTK"; // Cột này dùng để lấy giá trị của item
            }
            else
            {
                MessageBox.Show("Không có tài khoản tiết kiệm nào cho khách hàng này.");
            }
        }



        private void AddUserControl(UserControl userControl)
        {
            userControl.Dock = DockStyle.Fill;
            pnDisplay.Controls.Clear();
            pnDisplay.Controls.Add(userControl);
            userControl.BringToFront();
        }
        private void btnViewDetails_Click(object sender, EventArgs e)
        {
            if (cmbAccounts.SelectedValue == null)
            {
                lblMessage.Text = "Vui lòng chọn một tài khoản để xem chi tiết.";
                return;
            }

            string selectedAccountId = cmbAccounts.SelectedValue.ToString();
            string query = $"EXEC sp_XemChiTietSoTietKiem @MaSoTK = '{selectedAccountId}'";
            DataTable dt = ExecuteQuery(query);

            if (dt.Rows.Count > 0)
            {
                // Tạo 1 instance mới của ucSavingAccountDetail
                ucSavingAccountDetail detailUC = new ucSavingAccountDetail();

                // Gọi hàm load dữ liệu vào UC
                detailUC.LoadAccountDetails(dt.Rows[0]);

                // Thêm UC vào giao diện
                AddUserControl(detailUC);

                // Xóa message lỗi (nếu có)
                lblMessage.Text = "";
            }
            else
            {
                lblMessage.Text = "Không tìm thấy chi tiết cho tài khoản đã chọn.";
            }
        }

        private void ucSavingAccount_Load(object sender, EventArgs e)
        {
            LoadSavingsAccounts();  // Gọi thủ tục hiển thị danh sách sổ tiết kiệm
            LoadSavingsAccountsForCustomer(currentCustomerId);
        }

        private void btnCalculateInterest_Click(object sender, EventArgs e)
        {
            // Kiểm tra có chọn tài khoản chưa
            if (cmbAccounts.SelectedValue == null)
            {
                lblMessage.Text = "Vui lòng chọn một tài khoản để tính lãi.";
                return;
            }

            string selectedAccountId = cmbAccounts.SelectedValue.ToString();
            string query = $"EXEC sp_XemChiTietSoTietKiem @MaSoTK = '{selectedAccountId}'";
            DataTable dt = ExecuteQuery(query);

            if (dt.Rows.Count == 0)
            {
                lblMessage.Text = "Không tìm thấy chi tiết tài khoản.";
                return;
            }

            // Khởi tạo UC mới
            ucSavingAccountTinhLai ucTinhLai = new ucSavingAccountTinhLai();

            // Load dữ liệu vào UC
            ucTinhLai.LoadData(dt.Rows[0]);

            // Hiển thị UC
            AddUserControl(ucTinhLai);


        }

        private void btnRequestOpen_Click(object sender, EventArgs e)
        {
            

            FormOpenRequest openrequest = new FormOpenRequest("KH001");
            openrequest.ShowDialog();
        }

        private void cmbAccounts_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnRequestClose_Click(object sender, EventArgs e)
        {
            string selectedMaSoTK = cmbAccounts.SelectedValue.ToString();
            ucSavingAccountCloseRequest ucSavingAccountCloseRequest = new ucSavingAccountCloseRequest(selectedMaSoTK);
            AddUserControl(ucSavingAccountCloseRequest);
        }
    }
    
}
