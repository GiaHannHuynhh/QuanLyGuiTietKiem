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
    public partial class LoginForm: Form
    {
        private string connectionString = ConfigurationManager.ConnectionStrings["QuanLyGuiTietKiemConnection"].ConnectionString;
        public LoginForm()
        {
            InitializeComponent();
            txtPassword.PasswordChar = '*';
        }

        private void btn_Login_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text.Trim();

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Vui lòng nhập tên đăng nhập và mật khẩu!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }



            ProgressForm.ShowProgress(this, () =>
            {
                try
                {
                    using (SqlConnection conn = new SqlConnection(connectionString))
                    {
                        conn.Open();
                        SqlCommand cmd = new SqlCommand("sp_DangNhap", conn);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@TenDangNhap", username);
                        cmd.Parameters.AddWithValue("@MatKhau", password);
                        cmd.Parameters.Add("@KetQua", SqlDbType.Bit).Direction = ParameterDirection.Output;
                        cmd.Parameters.Add("@ThongBao", SqlDbType.NVarChar, 255).Direction = ParameterDirection.Output;
                        cmd.Parameters.Add("@VaiTro", SqlDbType.NVarChar, 20).Direction = ParameterDirection.Output;
                        cmd.Parameters.Add("@MaKH", SqlDbType.VarChar, 10).Direction = ParameterDirection.Output;
                        cmd.Parameters.Add("@MaNV", SqlDbType.VarChar, 10).Direction = ParameterDirection.Output;

                        cmd.ExecuteNonQuery();

                        bool ketQua = (bool)cmd.Parameters["@KetQua"].Value;
                        string thongBao = cmd.Parameters["@ThongBao"].Value.ToString();
                        string vaiTro = cmd.Parameters["@VaiTro"].Value.ToString();
                        string maKH = cmd.Parameters["@MaKH"].Value == DBNull.Value ? null : cmd.Parameters["@MaKH"].Value.ToString();
                        string maNV = cmd.Parameters["@MaNV"].Value == DBNull.Value ? null : cmd.Parameters["@MaNV"].Value.ToString();

                        if (ketQua)
                        {
                            UserSession.Username = username;
                            UserSession.Role = vaiTro;
                            UserSession.MaKH = maKH;
                            UserSession.MaNV = maNV;

                            if (vaiTro == "ADMIN")
                                new AdminMainForm().Show();
                            else if (vaiTro == "NV")
                                new StaffMainForm().Show();
                            else if (vaiTro == "KH")
                                new CustomerMainForm().Show();

                            this.Invoke((MethodInvoker)delegate { this.Hide(); });
                        }
                        else
                        {
                            MessageBox.Show(thongBao, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            });
        }



        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void linkLabel_newUser_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            new RegisterForm().ShowDialog();
        }

        private void linkLabel_forgetPassword_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            new ForgotPasswordForm().ShowDialog();
        }
    }
}
