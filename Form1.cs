using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace QuanLyGuiTietKiem
{
    public partial class Form1: Form
    {
        private DB_Connect dbConnect;
        public Form1()
        {
            InitializeComponent();
            dbConnect = new DB_Connect();
        }

        private void btnTestConnection_Click(object sender, EventArgs e)
        {
            try
            {
                dbConnect.OpenConnection();
                MessageBox.Show("Kết nối cơ sở dữ liệu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dbConnect.CloseConnection();
                MessageBox.Show("Đóng kết nối thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
