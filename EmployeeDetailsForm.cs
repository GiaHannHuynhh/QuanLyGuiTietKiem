using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TreeView;

namespace QuanLyGuiTietKiem
{
    public partial class EmployeeDetailsForm : Form
    {
        // Thuộc tính để lưu thông tin nhân viên
        public string EmployeeID { get; set; }
        public string FullName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string CCCD { get; set; }
        public DateTime IssueDate { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public string Position { get; set; }
        public string BranchID { get; set; }
        public EmployeeDetailsForm(string employeeID = null)
        {

            InitializeComponent();
            if (!string.IsNullOrEmpty(employeeID))
            {
                EmployeeID = employeeID;
                txtEmployeeID.Text = employeeID;
                txtEmployeeID.ReadOnly = true;
            }
            else
            {
                txtEmployeeID.Visible = false; // Ẩn khi thêm mới
                lblEmployeeID.Visible = false;
            }
            LoadBranches();
        }
        private void LoadBranches()
        {
            try
            {
                using (SqlConnection conn = DatabaseHelper.GetConnection())
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("SELECT MaCN, TenCN FROM CHI_NHANH ORDER BY MaCN", conn);
                    SqlDataReader reader = cmd.ExecuteReader();
                    cmbBranchID.Items.Clear(); // Xóa danh sách cũ
                    while (reader.Read())
                    {
                        string maCN = reader["MaCN"].ToString();
                        string tenCN = reader["TenCN"].ToString();
                        cmbBranchID.Items.Add(new { MaCN = maCN, TenCN = tenCN }); // Lưu cả MaCN và TenCN
                        cmbBranchID.DisplayMember = "MaCN"; // Hiển thị MaCN
                    }
                    reader.Close();
                }
                if (cmbBranchID.Items.Count > 0)
                {
                    cmbBranchID.SelectedIndex = 0; // Chọn chi nhánh đầu tiên mặc định
                }
            }
            catch (Exception ex)
            {
                lblMessage.Text = "Lỗi khi tải danh sách chi nhánh: " + ex.Message;
            }
        }
        private void EmployeeDetailsForm_Load(object sender, EventArgs e)
        {

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            // Kiểm tra đầu vào
            if (string.IsNullOrEmpty(txtFullName.Text) || string.IsNullOrEmpty(txtCCCD.Text) ||
                string.IsNullOrEmpty(txtPhoneNumber.Text) || string.IsNullOrEmpty(txtAddress.Text) ||
                cmbPosition.SelectedItem == null || cmbBranchID.SelectedItem == null)
            {
                lblMessage.Text = "Vui lòng điền đầy đủ thông tin!";
                return;
            }

            if (!System.Text.RegularExpressions.Regex.IsMatch(txtCCCD.Text, @"^\d{12}$"))
            {
                lblMessage.Text = "Mã CCCD phải là 12 chữ số!";
                return;
            }

            if (!System.Text.RegularExpressions.Regex.IsMatch(txtPhoneNumber.Text, @"^\d{10,11}$"))
            {
                lblMessage.Text = "Số điện thoại không hợp lệ!";
                return;
            }

            if (dtpDateOfBirth.Value > DateTime.Now.AddYears(-18))
            {
                lblMessage.Text = "Nhân viên phải từ 18 tuổi trở lên!";
                return;
            }

            // Gán giá trị
            EmployeeID = txtEmployeeID.Text;
            FullName = txtFullName.Text;
            DateOfBirth = dtpDateOfBirth.Value;
            CCCD = txtCCCD.Text;
            IssueDate = dtpIssueDate.Value;
            PhoneNumber = txtPhoneNumber.Text;
            Address = txtAddress.Text;
            Position = cmbPosition.SelectedItem.ToString();
            BranchID = ((dynamic)cmbBranchID.SelectedItem).MaCN; // Lấy MaCN từ đối tượng

            DialogResult = DialogResult.OK;
            Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
        public void LoadEmployeeData(string employeeID, string fullName, DateTime dateOfBirth, string cccd, DateTime issueDate, string phoneNumber, string address, string position, string branchID)
        {
            txtEmployeeID.Text = employeeID;
            txtFullName.Text = fullName;
            dtpDateOfBirth.Value = dateOfBirth;
            txtCCCD.Text = cccd;
            dtpIssueDate.Value = issueDate;
            txtPhoneNumber.Text = phoneNumber;
            txtAddress.Text = address;
            cmbPosition.SelectedItem = position;
            // Tìm và chọn chi nhánh theo MaCN
            foreach (var item in cmbBranchID.Items)
            {
                if (((dynamic)item).MaCN == branchID)
                {
                    cmbBranchID.SelectedItem = item;
                    break;
                }
            }
        }

        private void txtBranchID_TextChanged(object sender, EventArgs e)
        {

        }

        private void cmbBranchID_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
