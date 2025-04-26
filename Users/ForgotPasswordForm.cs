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

namespace QuanLyGuiTietKiem
{
    public partial class ForgotPasswordForm: Form
    {
        private string connectionString = ConfigurationManager.ConnectionStrings["QuanLyGuiTietKiemConnection"].ConnectionString;
        private string generatedOTP;
        private DateTime otpGeneratedTime;
        private string userEmail;
        public ForgotPasswordForm()
        {
            InitializeComponent();

        }

        private void btnSendCode_Click(object sender, EventArgs e)
        {
            userEmail = txtEmail.Text.Trim();
            if (string.IsNullOrEmpty(userEmail))
            {
                MessageBox.Show("Vui lòng nhập email!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            ProgressForm.ShowProgress(this, () =>
            {
                try
                {
                    generatedOTP = EmailService.GenerateOTP();
                    otpGeneratedTime = DateTime.Now;
                    EmailService.SendEmail(userEmail, "Mã OTP Khôi Phục Mật Khẩu", $"Mã OTP của bạn là: {generatedOTP}. Mã có hiệu lực trong 5 phút.");
                    MessageBox.Show("Mã OTP đã được gửi đến email của bạn!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    btnSendCode.Enabled = false;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            });
        }

        private void btnVerifyCode_Click(object sender, EventArgs e)
        {
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
                    // Nếu mã OTP đúng, mở ChangePasswordForm và truyền email
                    this.Invoke((MethodInvoker)delegate
                    {
                        this.Hide();
                        new ChangePasswordForm(userEmail).ShowDialog();
                        this.Close();
                    });
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            });
        }

        private void lnkBack_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Close();
            new LoginForm().Show();
        }
    
    }
}
