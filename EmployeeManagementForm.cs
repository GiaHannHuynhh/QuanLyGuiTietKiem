using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TreeView;

namespace QuanLyGuiTietKiem
{

    public partial class EmployeeManagementForm : Form
    {
        public EmployeeManagementForm()
        {
            InitializeComponent();
            LoadEmployees(); // Tải danh sách nhân viên khi form mở
        }

        private void LoadEmployees(string employeeID = null)
        {
            try
            {
                using (SqlConnection conn = DatabaseHelper.GetConnection())
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("sp_TimKiemNhanVien", conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    if (string.IsNullOrEmpty(employeeID))
                        cmd.Parameters.AddWithValue("@MaNV", DBNull.Value);
                    else
                        cmd.Parameters.AddWithValue("@MaNV", employeeID);
                    cmd.Parameters.AddWithValue("@HoTen", DBNull.Value);
                    cmd.Parameters.AddWithValue("@MaSoCCCD", DBNull.Value);
                    cmd.Parameters.AddWithValue("@ChucVu", DBNull.Value);
                    cmd.Parameters.AddWithValue("@MaCN", DBNull.Value);
                    cmd.Parameters.AddWithValue("@TinhTrang", DBNull.Value);

                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    dgvEmployees.DataSource = dt;

                    // Tùy chỉnh tiêu đề cột
                    if (dgvEmployees.Columns.Contains("MaNV")) dgvEmployees.Columns["MaNV"].HeaderText = "Mã Nhân Viên";
                    if (dgvEmployees.Columns.Contains("HoTen")) dgvEmployees.Columns["HoTen"].HeaderText = "Họ Tên";
                    if (dgvEmployees.Columns.Contains("NgaySinh")) dgvEmployees.Columns["NgaySinh"].HeaderText = "Ngày Sinh";
                    if (dgvEmployees.Columns.Contains("SDT")) dgvEmployees.Columns["SDT"].HeaderText = "Số Điện Thoại";
                    if (dgvEmployees.Columns.Contains("DiaChi")) dgvEmployees.Columns["DiaChi"].HeaderText = "Địa Chỉ";
                    if (dgvEmployees.Columns.Contains("ChucVu")) dgvEmployees.Columns["ChucVu"].HeaderText = "Chức Vụ";
                    if (dgvEmployees.Columns.Contains("TinhTrang")) dgvEmployees.Columns["TinhTrang"].HeaderText = "Tình Trạng";
                    if (dgvEmployees.Columns.Contains("MaCN")) dgvEmployees.Columns["MaCN"].HeaderText = "Mã Chi Nhánh";
                    if (dgvEmployees.Columns.Contains("TenCN")) dgvEmployees.Columns["TenCN"].HeaderText = "Tên Chi Nhánh";

                    lblMessage.Text = dt.Rows.Count > 0 ? $"Tìm thấy {dt.Rows.Count} nhân viên." : "Không tìm thấy nhân viên!";
                }
            }
            catch (Exception ex)
            {
                lblMessage.Text = "Lỗi khi tải danh sách nhân viên: " + ex.Message;
            }
        }

        private void dgvEmployees_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvEmployees.Rows[e.RowIndex];
                txtEmployeeID.Text = row.Cells["MaNV"].Value?.ToString();
                lblMessage.Text = $"Đã chọn nhân viên: {txtEmployeeID.Text}";
            }
        }

        private void txtEmployeeID_TextChanged(object sender, EventArgs e)
        {

        }

        private void lblMessage_Click(object sender, EventArgs e)
        {

        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtEmployeeID.Clear();
            lblMessage.Text = string.Empty;
            LoadEmployees();
        }
        private string GenerateEmployeeID()
        {
            try
            {
                using (SqlConnection conn = DatabaseHelper.GetConnection())
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("SELECT ISNULL(MAX(CAST(SUBSTRING(MaNV, 3, 4) AS INT)), 0) FROM NHAN_VIEN", conn);
                    int maxId = Convert.ToInt32(cmd.ExecuteScalar()) + 1;
                    return "NV" + maxId.ToString("D4");
                }
            }
            catch (Exception ex)
            {
                lblMessage.Text = "Lỗi khi sinh mã nhân viên: " + ex.Message;
                return null;
            }
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            using (var detailsForm = new EmployeeDetailsForm())
            {
                if (detailsForm.ShowDialog() == DialogResult.OK)
                {
                    // Kiểm tra dữ liệu đầu vào
                    if (string.IsNullOrEmpty(detailsForm.FullName) || string.IsNullOrEmpty(detailsForm.CCCD) ||
                        string.IsNullOrEmpty(detailsForm.PhoneNumber) || string.IsNullOrEmpty(detailsForm.Address) ||
                        string.IsNullOrEmpty(detailsForm.Position) || string.IsNullOrEmpty(detailsForm.BranchID))
                    {
                        lblMessage.Text = "Dữ liệu đầu vào không hợp lệ!";
                        return;
                    }

                    try
                    {
                        using (SqlConnection conn = DatabaseHelper.GetConnection())
                        {
                            conn.Open();
                            SqlCommand cmd = new SqlCommand("sp_ThemNhanVien", conn);
                            cmd.CommandType = CommandType.StoredProcedure;

                            string newEmployeeID = GenerateEmployeeID();
                            if (newEmployeeID == null) return;

                            cmd.Parameters.AddWithValue("@MaNV", newEmployeeID);
                            cmd.Parameters.AddWithValue("@HoTen", detailsForm.FullName);
                            cmd.Parameters.AddWithValue("@NgaySinh", detailsForm.DateOfBirth);
                            cmd.Parameters.AddWithValue("@MaSoCCCD", detailsForm.CCCD);
                            cmd.Parameters.AddWithValue("@NgayCap", detailsForm.IssueDate);
                            cmd.Parameters.AddWithValue("@SDT", detailsForm.PhoneNumber);
                            cmd.Parameters.AddWithValue("@DiaChi", detailsForm.Address);
                            cmd.Parameters.AddWithValue("@ChucVu", detailsForm.Position);
                            cmd.Parameters.AddWithValue("@MaCN", detailsForm.BranchID);

                            cmd.ExecuteNonQuery();

                            lblMessage.Text = $"Thêm nhân viên thành công! Mã NV: {newEmployeeID}";
                            LoadEmployees();
                        }
                    }
                    catch (Exception ex)
                    {
                        lblMessage.Text = "Lỗi khi thêm nhân viên: " + ex.Message;
                    }
                }
                else
                {
                    lblMessage.Text = "Đã hủy thao tác thêm nhân viên.";
                }
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtEmployeeID.Text))
            {
                lblMessage.Text = "Vui lòng nhập mã nhân viên hoặc chọn nhân viên từ danh sách!";
                return;
            }

            try
            {
                using (SqlConnection conn = DatabaseHelper.GetConnection())
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(
                        @"SELECT nv.MaNV, nv.HoTen, nv.NgaySinh, nv.SDT, nv.DiaChi, nv.ChucVu, nv.MaCN, 
                                 mdd.MaSoCCCD, mdd.NgayCap, nv.TinhTrang
                          FROM NHAN_VIEN nv
                          LEFT JOIN MA_DINH_DANH mdd ON nv.MaNV = mdd.MaNV
                          WHERE nv.MaNV = @MaNV", conn);
                    cmd.Parameters.AddWithValue("@MaNV", txtEmployeeID.Text.Trim());

                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    if (dt.Rows.Count == 0)
                    {
                        lblMessage.Text = "Không tìm thấy nhân viên với mã này!";
                        return;
                    }

                    DataRow row = dt.Rows[0];
                    string employeeID = row["MaNV"].ToString();
                    string fullName = row["HoTen"].ToString();
                    DateTime dateOfBirth = Convert.ToDateTime(row["NgaySinh"]);
                    string cccd = row["MaSoCCCD"]?.ToString() ?? "";
                    DateTime issueDate = row["NgayCap"] != DBNull.Value ? Convert.ToDateTime(row["NgayCap"]) : DateTime.Now;
                    string phoneNumber = row["SDT"]?.ToString() ?? "";
                    string address = row["DiaChi"]?.ToString() ?? "";
                    string position = row["ChucVu"]?.ToString() ?? "";
                    string branchID = row["MaCN"]?.ToString() ?? "";
                    position = new[] { "Giao dịch viên", "Quản lý", "Kế toán" }.Contains(position) ? position : "Giao dịch viên";

                    using (var detailsForm = new EmployeeDetailsForm(employeeID))
                    {
                        detailsForm.LoadEmployeeData(employeeID, fullName, dateOfBirth, cccd, issueDate, phoneNumber, address, position, branchID);
                        if (detailsForm.ShowDialog() == DialogResult.OK)
                        {
                            try
                            {
                                using (SqlConnection connUpdate = DatabaseHelper.GetConnection())
                                {
                                    connUpdate.Open();
                                    SqlCommand cmdUpdate = new SqlCommand("sp_CapNhatNhanVien", connUpdate);
                                    cmdUpdate.CommandType = CommandType.StoredProcedure;

                                    cmdUpdate.Parameters.AddWithValue("@MaNV", detailsForm.EmployeeID);
                                    cmdUpdate.Parameters.AddWithValue("@HoTen", detailsForm.FullName);
                                    cmdUpdate.Parameters.AddWithValue("@NgaySinh", detailsForm.DateOfBirth);
                                    cmdUpdate.Parameters.AddWithValue("@SDT", detailsForm.PhoneNumber);
                                    cmdUpdate.Parameters.AddWithValue("@DiaChi", detailsForm.Address);
                                    cmdUpdate.Parameters.AddWithValue("@ChucVu", detailsForm.Position);
                                    cmdUpdate.Parameters.AddWithValue("@MaCN", detailsForm.BranchID);
                                    cmdUpdate.Parameters.AddWithValue("@TinhTrang", DBNull.Value);

                                    cmdUpdate.ExecuteNonQuery();

                                    lblMessage.Text = "Cập nhật nhân viên thành công!";
                                    LoadEmployees();
                                }
                            }
                            catch (Exception ex)
                            {
                                lblMessage.Text = "Lỗi khi cập nhật nhân viên: " + ex.Message;
                            }
                        }
                        else
                        {
                            lblMessage.Text = "Đã hủy thao tác cập nhật nhân viên.";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                lblMessage.Text = "Lỗi khi tải thông tin nhân viên: " + ex.Message;
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtEmployeeID.Text))
            {
                lblMessage.Text = "Vui lòng nhập mã nhân viên!";
                return;
            }

            if (MessageBox.Show("Bạn có chắc muốn đặt trạng thái nhân viên này thành nghỉ việc?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
            {
                return;
            }

            try
            {
                using (SqlConnection conn = DatabaseHelper.GetConnection())
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("sp_XoaNhanVien", conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@MaNV", txtEmployeeID.Text.Trim());

                    cmd.ExecuteNonQuery();

                    lblMessage.Text = "Đặt trạng thái nhân viên thành nghỉ việc thành công!";
                    LoadEmployees();
                }
            }
            catch (Exception ex)
            {
                lblMessage.Text = "Lỗi khi xóa nhân viên: " + ex.Message;
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtEmployeeID.Text))
            {
                LoadEmployees();
                return;
            }

            LoadEmployees(txtEmployeeID.Text.Trim());
        }

        private void EmployeeManagementForm_Load(object sender, EventArgs e)
        {

        }
    }

    public static class DatabaseHelper
    {
        public static SqlConnection GetConnection()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["QuanLyGuiTietKiemConnection"].ConnectionString;
            return new SqlConnection(connectionString);
        }
    }

}

