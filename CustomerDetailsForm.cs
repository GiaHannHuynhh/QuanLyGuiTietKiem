using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace QuanLyGuiTietKiem
{
    public partial class CustomerDetailsForm : Form
    {
        public string CustomerID { get; set; }
        public string FullName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string CCCD { get; set; }
        public DateTime NgayCap { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public CustomerDetailsForm(string customerID = null)
        {
            InitializeComponent();
            if (!string.IsNullOrEmpty(customerID))
            {
                CustomerID = customerID;
                txtCustomerID.Text = customerID;
                txtCustomerID.ReadOnly = true;
            }
            else
            {
                txtCustomerID.Visible = false; // Ẩn khi thêm mới
                lblCustomerID.Visible = false;
            }
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            // Kiểm tra đầu vào
            if (string.IsNullOrEmpty(txtFullName.Text) || string.IsNullOrEmpty(txtCCCD.Text) ||
                string.IsNullOrEmpty(txtPhoneNumber.Text) || string.IsNullOrEmpty(txtAddress.Text) ||
                string.IsNullOrEmpty(txtEmail.Text))
            {
                lblMessage.Text = "Vui lòng điền đầy đủ thông tin!";
                return;
            }

            if (!System.Text.RegularExpressions.Regex.IsMatch(txtCCCD.Text, @"^\d{12}$"))
            {
                lblMessage.Text = "Mã CCCD phải là 12 chữ số!";
                return;
            }

            if (!System.Text.RegularExpressions.Regex.IsMatch(txtEmail.Text, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
            {
                lblMessage.Text = "Email không hợp lệ!";
                return;
            }

            if (!System.Text.RegularExpressions.Regex.IsMatch(txtPhoneNumber.Text, @"^\d{10,11}$"))
            {
                lblMessage.Text = "Số điện thoại không hợp lệ!";
                return;
            }

            if (dtpDateOfBirth.Value > DateTime.Now.AddYears(-18))
            {
                lblMessage.Text = "Khách hàng phải từ 18 tuổi trở lên!";
                return;
            }

            // Gán giá trị
            CustomerID = txtCustomerID.Text;
            FullName = txtFullName.Text;
            DateOfBirth = dtpDateOfBirth.Value;
            CCCD = txtCCCD.Text;
            NgayCap = dtpNgayCap.Value;
            PhoneNumber = txtPhoneNumber.Text;
            Address = txtAddress.Text;
            Email = txtEmail.Text;

            DialogResult = DialogResult.OK;
            Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
        public void LoadCustomerData(string customerID, string fullName, DateTime dateOfBirth, string phoneNumber,
            string address, string cccd, DateTime ngayCap, string email)
        {
            txtCustomerID.Text = customerID;
            txtFullName.Text = fullName;
            dtpDateOfBirth.Value = dateOfBirth;
            txtCCCD.Text = cccd;
            dtpNgayCap.Value = ngayCap;
            txtPhoneNumber.Text = phoneNumber;
            txtAddress.Text = address;
            txtEmail.Text = email;
        }

        private void CustomerDetailsForm_Load(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
