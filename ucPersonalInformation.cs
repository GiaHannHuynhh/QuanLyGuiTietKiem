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
    public partial class ucPersonalInformation : UserControl
    {
        public ucPersonalInformation()
        {
            InitializeComponent();
        }

        private void PersonalInformation_Load(object sender, EventArgs e)
        {
            HienThiThongTinCaNhan();
        }

        private DB_Connect dbConnect = new DB_Connect();

        

        private void HienThiThongTinCaNhan()
        {
            using (SqlCommand cmd = new SqlCommand("sp_LayThongTinKhachHang", dbConnect.GetConnection()))
            {
                cmd.CommandType = CommandType.StoredProcedure;


                cmd.Parameters.AddWithValue("@MaKH", "KH001");
                cmd.Parameters.AddWithValue("@TenDangNhapNguoiThucHien", "khachhang01");

                SqlParameter ketQuaParam = new SqlParameter("@KetQua", SqlDbType.Bit)
                {
                    Direction = ParameterDirection.Output
                };
                cmd.Parameters.Add(ketQuaParam);

                SqlParameter thongBaoParam = new SqlParameter("@ThongBao", SqlDbType.NVarChar, 255)
                {
                    Direction = ParameterDirection.Output
                };
                cmd.Parameters.Add(thongBaoParam);

                try
                {
                    dbConnect.OpenConnection(); // mở kết nối đúng cách
                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        txtFullName.Text = reader["HoTen"].ToString();
                        dtpBirthDate.Value = Convert.ToDateTime(reader["NgaySinh"]);
                        txtPhone.Text = reader["SDT"].ToString();
                        txtAddress.Text = reader["DiaChi"].ToString();
                        txtEmail.Text = reader["Email"].ToString();
                    }

                    reader.Close();
                    dbConnect.CloseConnection();

                    bool ketQua = (bool)ketQuaParam.Value;
                    string thongBao = thongBaoParam.Value.ToString();

                    lblMessage.Text = thongBao;
                    lblMessage.ForeColor = ketQua ? Color.Green : Color.Red;
                }
                catch (Exception ex)
                {
                    lblMessage.Text = "Lỗi: " + ex.Message;
                    lblMessage.ForeColor = Color.Red;
                }
            }
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }
    }
}
