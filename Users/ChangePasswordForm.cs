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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace QuanLyGuiTietKiem
{
    public partial class ChangePasswordForm : Form
    {
        private string connectionString = ConfigurationManager.ConnectionStrings["QuanLyGuiTietKiemConnection"].ConnectionString;
        private string userEmail;
        public ChangePasswordForm(string email)
        {
            InitializeComponent();
            userEmail = email;
            txtNewPassword.PasswordChar = '*';
            txtConfirmPassword.PasswordChar = '*';
        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
            new LoginForm().Show();
        }

        private void btn_Reset_Click(object sender, EventArgs e)
        {
            string newPassword = txtNewPassword.Text.Trim();
            string confirmPassword = txtConfirmPassword.Text.Trim();

            if (string.IsNullOrEmpty(newPassword) || string.IsNullOrEmpty(confirmPassword))
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (newPassword.Length < 6)
            {
                MessageBox.Show("Mật khẩu mới phải có ít nhất 6 ký tự!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (newPassword != confirmPassword)
            {
                MessageBox.Show("Mật khẩu xác nhận không khớp!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            ProgressForm.ShowProgress(this, () =>
            {
                try
                {
                    using (SqlConnection conn = new SqlConnection(connectionString))
                    {
                        conn.Open();
                        SqlCommand cmd = new SqlCommand("sp_QuenMatKhau", conn);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Email", userEmail);
                        cmd.Parameters.AddWithValue("@MatKhauMoi", newPassword);
                        cmd.Parameters.Add("@KetQua", SqlDbType.Bit).Direction = ParameterDirection.Output;
                        cmd.Parameters.Add("@ThongBao", SqlDbType.NVarChar, 255).Direction = ParameterDirection.Output;

                        cmd.ExecuteNonQuery();

                        bool ketQua = (bool)cmd.Parameters["@KetQua"].Value;
                        string thongBao = cmd.Parameters["@ThongBao"].Value.ToString();

                        MessageBox.Show(thongBao, "Thông báo", MessageBoxButtons.OK, ketQua ? MessageBoxIcon.Information : MessageBoxIcon.Error);
                        if (ketQua)
                        {
                            this.Invoke((MethodInvoker)delegate
                            {
                                this.Close();
                                new LoginForm().Show();
                            });
                        }
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
