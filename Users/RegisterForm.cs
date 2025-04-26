using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyGuiTietKiem
{
    public partial class RegisterForm : Form
    {
        private string connectionString = ConfigurationManager.ConnectionStrings["QuanLyGuiTietKiemConnection"].ConnectionString;
        private string generatedOTP;
        private DateTime otpGeneratedTime;

        public RegisterForm()
        {
            InitializeComponent();
            txtPassword.PasswordChar = '*';
            txtRePassword.PasswordChar = '*';
        }

        private void btnSendCode_Click(object sender, EventArgs e)
        {
            string email = txtEmail.Text.Trim();
            if (string.IsNullOrEmpty(email))
            {
                MessageBox.Show("Vui lòng nhập email!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Kiểm tra định dạng email
            if (!Regex.IsMatch(email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
            {
                MessageBox.Show("Email không hợp lệ!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            ProgressForm.ShowProgress(this, () =>
            {
                try
                {
                    generatedOTP = EmailService.GenerateOTP();
                    otpGeneratedTime = DateTime.Now;
                    EmailService.SendEmail(email, "Mã OTP Đăng Ký Tài Khoản", $"Mã OTP của bạn là: {generatedOTP}. Mã có hiệu lực trong 5 phút.");
                    MessageBox.Show("Mã OTP đã được gửi đến email của bạn!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    btnSendCode.Enabled = false;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            });
        }

        private void btnSignUp_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrEmpty(txtHoTen.Text.Trim()) ||
                       string.IsNullOrEmpty(txtCCCD.Text.Trim()) ||
                       string.IsNullOrEmpty(txtSDT.Text.Trim()) ||
                       string.IsNullOrEmpty(richtxtDiaChi.Text.Trim()) ||
                       string.IsNullOrEmpty(txtEmail.Text.Trim()) ||
                       string.IsNullOrEmpty(txtUsername.Text.Trim()) ||
                       string.IsNullOrEmpty(txtPassword.Text.Trim()) ||
                       string.IsNullOrEmpty(txtRePassword.Text.Trim()))
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Kiểm tra định dạng
            if (!Regex.IsMatch(txtCCCD.Text.Trim(), @"^\d{12}$"))
            {
                MessageBox.Show("Số CCCD phải gồm 12 chữ số!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!Regex.IsMatch(txtSDT.Text.Trim(), @"^0\d{9}$"))
            {
                MessageBox.Show("Số điện thoại phải bắt đầu bằng 0 và gồm 10 chữ số!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!Regex.IsMatch(txtUsername.Text.Trim(), @"^[a-zA-Z0-9]{3,20}$"))
            {
                MessageBox.Show("Tên đăng nhập chỉ được chứa chữ cái và số, độ dài từ 3 đến 20 ký tự!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (txtPassword.Text.Trim().Length < 6)
            {
                MessageBox.Show("Mật khẩu phải có ít nhất 6 ký tự!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Kiểm tra mật khẩu nhập lại
            if (txtPassword.Text.Trim() != txtRePassword.Text.Trim())
            {
                MessageBox.Show("Mật khẩu nhập lại không khớp!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Kiểm tra mã OTP
            if (string.IsNullOrEmpty(txtCode.Text.Trim()))
            {
                MessageBox.Show("Vui lòng nhập mã OTP!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (txtCode.Text.Trim() != generatedOTP)
            {
                MessageBox.Show("Mã OTP không đúng!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (DateTime.Now > otpGeneratedTime.AddMinutes(5))
            {
                MessageBox.Show("Mã OTP đã hết hạn!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                btnSendCode.Enabled = true;
                return;
            }

            ProgressForm.ShowProgress(this, () =>
            {
                try
                {
                    using (SqlConnection conn = new SqlConnection(connectionString))
                    {
                        conn.Open();
                        SqlCommand cmd = new SqlCommand("sp_DangKyTaiKhoanDangNhapKhachHang", conn);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@HoTen", txtHoTen.Text.Trim());
                        cmd.Parameters.AddWithValue("@NgaySinh", DateHelper.ParseDate(dtpNgaySinh.Value.ToString("dd/MM/yyyy")));
                        cmd.Parameters.AddWithValue("@MaSoCCCD", txtCCCD.Text.Trim());
                        cmd.Parameters.AddWithValue("@NgayCap", DateHelper.ParseDate(dtpNgayCap.Value.ToString("dd/MM/yyyy")));
                        cmd.Parameters.AddWithValue("@SDT", txtSDT.Text.Trim());
                        cmd.Parameters.AddWithValue("@DiaChi", richtxtDiaChi.Text.Trim());
                        cmd.Parameters.AddWithValue("@Email", txtEmail.Text.Trim());
                        cmd.Parameters.AddWithValue("@TenDangNhap", txtUsername.Text.Trim());
                        cmd.Parameters.AddWithValue("@MatKhau", txtPassword.Text.Trim());
                        cmd.Parameters.Add("@MaKH", SqlDbType.VarChar, 10).Direction = ParameterDirection.Output;

                        cmd.ExecuteNonQuery();

                        string maKH = cmd.Parameters["@MaKH"].Value.ToString();
                        MessageBox.Show($"Yêu cầu đăng ký đã được gửi thành công! Mã khách hàng: {maKH}. Vui lòng chờ quản trị viên phê duyệt trước khi đăng nhập.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Invoke((MethodInvoker)delegate { this.Close(); });
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            });




        }
    
        
    
    
    
    
    }
}
