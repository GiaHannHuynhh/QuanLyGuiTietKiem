using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace QuanLyGuiTietKiem
{
    public partial class CustomerManagementForm : Form
    {
        public string CustomerID { get; set; }
        public string FullName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string CCCD { get; set; }
        public DateTime NgayCap { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        private string CurrentEmployeeLogin; // Tên đăng nhập nhân viên hiện tại
        public CustomerManagementForm()
        {
            
            InitializeComponent();
            LoadCustomers(); // Tải danh sách khách hàng khi form mở

        }
        private void LoadCustomers(string customerID = null)
        {
            try
            {
                using (SqlConnection conn = DatabaseHelper.GetConnection())
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(
                        @"SELECT kh.MaKH, kh.HoTen, kh.NgaySinh, kh.SDT, kh.DiaChi, kh.Email, 
                                 mdd.MaSoCCCD, mdd.NgayCap
                          FROM KHACH_HANG kh
                          LEFT JOIN MA_DINH_DANH mdd ON kh.MaKH = mdd.MaKH
                          WHERE (@MaKH IS NULL OR kh.MaKH = @MaKH)", conn);
                    if (string.IsNullOrEmpty(customerID))
                    {
                        cmd.Parameters.AddWithValue("@MaKH", DBNull.Value);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@MaKH", customerID);
                    }

                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    dgvCustomers.DataSource = dt;

                    // Tùy chỉnh tiêu đề cột
                    if (dgvCustomers.Columns.Contains("MaKH")) dgvCustomers.Columns["MaKH"].HeaderText = "Mã Khách Hàng";
                    if (dgvCustomers.Columns.Contains("HoTen")) dgvCustomers.Columns["HoTen"].HeaderText = "Họ Tên";
                    if (dgvCustomers.Columns.Contains("NgaySinh")) dgvCustomers.Columns["NgaySinh"].HeaderText = "Ngày Sinh";
                    if (dgvCustomers.Columns.Contains("SDT")) dgvCustomers.Columns["SDT"].HeaderText = "Số Điện Thoại";
                    if (dgvCustomers.Columns.Contains("DiaChi")) dgvCustomers.Columns["DiaChi"].HeaderText = "Địa Chỉ";
                    if (dgvCustomers.Columns.Contains("Email")) dgvCustomers.Columns["Email"].HeaderText = "Email";
                    if (dgvCustomers.Columns.Contains("MaSoCCCD")) dgvCustomers.Columns["MaSoCCCD"].HeaderText = "CCCD";
                    if (dgvCustomers.Columns.Contains("NgayCap")) dgvCustomers.Columns["NgayCap"].HeaderText = "Ngày Cấp";

                    lblMessage.Text = dt.Rows.Count > 0 ? $"Tìm thấy {dt.Rows.Count} khách hàng." : "Không tìm thấy khách hàng!";
                }
            }
            catch (Exception ex)
            {
                lblMessage.Text = "Lỗi khi tải danh sách khách hàng: " + ex.Message;
            }
        }
        private void btnSearch_Click(object sender, EventArgs e)
        {
            LoadCustomers(txtCustomerID.Text.Trim());
        }

        private void txtCustomerID_TextChanged(object sender, EventArgs e)
        {

        }

        private void lblMessage_Click(object sender, EventArgs e)
        {

        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtCustomerID.Clear();
            lblMessage.Text = string.Empty;
            LoadCustomers();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            using (var detailsForm = new CustomerDetailsForm())
            {
                if (detailsForm.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        using (SqlConnection conn = DatabaseHelper.GetConnection())
                        {
                            conn.Open();
                            SqlCommand cmd = new SqlCommand("sp_ThemKhachHangMoi", conn);
                            cmd.CommandType = CommandType.StoredProcedure;

                            cmd.Parameters.AddWithValue("@HoTen", detailsForm.FullName);
                            cmd.Parameters.AddWithValue("@NgaySinh", detailsForm.DateOfBirth);
                            cmd.Parameters.AddWithValue("@MaSoCCCD", detailsForm.CCCD);
                            cmd.Parameters.AddWithValue("@NgayCap", detailsForm.NgayCap);
                            cmd.Parameters.AddWithValue("@SDT", detailsForm.PhoneNumber);
                            cmd.Parameters.AddWithValue("@DiaChi", detailsForm.Address);
                            cmd.Parameters.AddWithValue("@Email", detailsForm.Email);
                            cmd.Parameters.AddWithValue("@TenDangNhapNV", "nv001"); // Giá trị mặc định

                            SqlParameter maKHParam = new SqlParameter("@MaKH", SqlDbType.VarChar, 10) { Direction = ParameterDirection.Output };
                            cmd.Parameters.Add(maKHParam);

                            cmd.ExecuteNonQuery();

                            string newCustomerID = maKHParam.Value.ToString();
                            lblMessage.Text = $"Thêm khách hàng thành công! Mã KH: {newCustomerID}";
                            LoadCustomers();
                        }
                    }
                    catch (Exception ex)
                    {
                        lblMessage.Text = "Lỗi khi thêm khách hàng: " + ex.Message;
                    }
                }
                else
                {
                    lblMessage.Text = "Đã hủy thao tác thêm khách hàng.";
                }
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtCustomerID.Text))
            {
                lblMessage.Text = "Vui lòng nhập mã khách hàng hoặc chọn khách hàng từ danh sách!";
                return;
            }

            try
            {
                using (SqlConnection conn = DatabaseHelper.GetConnection())
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(
                        @"SELECT kh.MaKH, kh.HoTen, kh.NgaySinh, kh.SDT, kh.DiaChi, kh.Email, 
                                 mdd.MaSoCCCD, mdd.NgayCap
                          FROM KHACH_HANG kh
                          LEFT JOIN MA_DINH_DANH mdd ON kh.MaKH = mdd.MaKH
                          WHERE kh.MaKH = @MaKH", conn);
                    cmd.Parameters.AddWithValue("@MaKH", txtCustomerID.Text.Trim());

                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    if (dt.Rows.Count == 0)
                    {
                        lblMessage.Text = "Không tìm thấy khách hàng với mã này!";
                        return;
                    }

                    DataRow row = dt.Rows[0];
                    string customerID = row["MaKH"].ToString();
                    string fullName = row["HoTen"].ToString();
                    DateTime dateOfBirth = Convert.ToDateTime(row["NgaySinh"]);
                    string phoneNumber = row["SDT"].ToString();
                    string address = row["DiaChi"].ToString();
                    string email = row["Email"].ToString();
                    string cccd = row["MaSoCCCD"].ToString();
                    DateTime ngayCap = Convert.ToDateTime(row["NgayCap"]);

                    using (var detailsForm = new CustomerDetailsForm(customerID))
                    {
                        detailsForm.LoadCustomerData(customerID, fullName, dateOfBirth, phoneNumber, address, cccd, ngayCap, email);
                        if (detailsForm.ShowDialog() == DialogResult.OK)
                        {
                            try
                            {
                                using (SqlConnection connUpdate = DatabaseHelper.GetConnection())
                                {
                                    connUpdate.Open();
                                    SqlCommand cmdUpdate = new SqlCommand("sp_CapNhatThongTinKhachHang", connUpdate);
                                    cmdUpdate.CommandType = CommandType.StoredProcedure;

                                    cmdUpdate.Parameters.AddWithValue("@MaKH", detailsForm.CustomerID);
                                    cmdUpdate.Parameters.AddWithValue("@HoTen", detailsForm.FullName);
                                    cmdUpdate.Parameters.AddWithValue("@NgaySinh", detailsForm.DateOfBirth);
                                    cmdUpdate.Parameters.AddWithValue("@SDT", detailsForm.PhoneNumber);
                                    cmdUpdate.Parameters.AddWithValue("@DiaChi", detailsForm.Address);
                                    cmdUpdate.Parameters.AddWithValue("@Email", detailsForm.Email);
                                    cmdUpdate.Parameters.AddWithValue("@TenDangNhapNV", "nv001"); // Giá trị mặc định

                                    SqlParameter ketQuaParam = new SqlParameter("@KetQua", SqlDbType.Bit) { Direction = ParameterDirection.Output };
                                    SqlParameter thongBaoParam = new SqlParameter("@ThongBao", SqlDbType.NVarChar, 255) { Direction = ParameterDirection.Output };
                                    cmdUpdate.Parameters.Add(ketQuaParam);
                                    cmdUpdate.Parameters.Add(thongBaoParam);

                                    cmdUpdate.ExecuteNonQuery();

                                    bool ketQua = Convert.ToBoolean(ketQuaParam.Value);
                                    string thongBao = thongBaoParam.Value?.ToString();

                                    lblMessage.Text = ketQua ? "Cập nhật khách hàng thành công!" : $"Lỗi: {thongBao}";
                                    LoadCustomers();
                                }
                            }
                            catch (Exception ex)
                            {
                                lblMessage.Text = "Lỗi khi cập nhật khách hàng: " + ex.Message;
                            }
                        }
                        else
                        {
                            lblMessage.Text = "Đã hủy thao tác cập nhật khách hàng.";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                lblMessage.Text = "Lỗi khi tải thông tin khách hàng: " + ex.Message;
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtCustomerID.Text))
            {
                lblMessage.Text = "Vui lòng nhập mã khách hàng!";
                return;
            }

            if (MessageBox.Show("Bạn có chắc muốn xóa khách hàng này?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
            {
                return;
            }

            try
            {
                using (SqlConnection conn = DatabaseHelper.GetConnection())
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("sp_XoaKhachHang", conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@MaKH", txtCustomerID.Text.Trim());
                    cmd.Parameters.AddWithValue("@TenDangNhapNV", "nv001"); // Giá trị mặc định

                    SqlParameter ketQuaParam = new SqlParameter("@KetQua", SqlDbType.Bit) { Direction = ParameterDirection.Output };
                    SqlParameter thongBaoParam = new SqlParameter("@ThongBao", SqlDbType.NVarChar, 255) { Direction = ParameterDirection.Output };
                    cmd.Parameters.Add(ketQuaParam);
                    cmd.Parameters.Add(thongBaoParam);

                    cmd.ExecuteNonQuery();

                    bool ketQua = Convert.ToBoolean(ketQuaParam.Value);
                    string thongBao = thongBaoParam.Value?.ToString();

                    lblMessage.Text = ketQua ? "Xóa khách hàng thành công!" : $"Lỗi: {thongBao}";
                    LoadCustomers();
                }
            }
            catch (Exception ex)
            {
                lblMessage.Text = "Lỗi khi xóa khách hàng: " + ex.Message;
            }
        }

        private void dgvCustomers_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvCustomers.Rows[e.RowIndex];
                txtCustomerID.Text = row.Cells["MaKH"].Value?.ToString();
                lblMessage.Text = $"Đã chọn khách hàng: {txtCustomerID.Text}";
            }
        }

        private void CustomerManagementForm_Load(object sender, EventArgs e)
        {

        }
        public static class DatabaseHelper
        {
            public static SqlConnection GetConnection()
            {
                string connectionString = ConfigurationManager.ConnectionStrings["QuanLyGuiTietKiemConnection"].ConnectionString;
                return new SqlConnection(connectionString);
            }
        }

        

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
        

    }

}
