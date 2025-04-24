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
    public partial class ucSavingAccountTinhLai : UserControl
    {
        private string connectionString = "Server=DESKTOP-87AFJH3;Database=QuanLyGuiTietKiem;Integrated Security=True;";

        public ucSavingAccountTinhLai()
        {
            InitializeComponent();
        }


        private DataTable ExecuteQuery(string query)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                conn.Open();
                da.Fill(dt);
                return dt;
            }
        }
        private void ucSavingAccountTinhLai_Load(object sender, EventArgs e)
        {

        }

        public void LoadData(DataRow row)
        {
            if (row == null) return;

            txtMaSoTK.Text = row["MaSoTK"].ToString();
            txtSoDuHienTai.Text = Convert.ToDecimal(row["SoDuHienTai"]).ToString("N0") + " VNĐ";
            txtNgayMoSo.Text = DateTime.Parse(row["NgayMoSo"].ToString()).ToShortDateString();
        }

        private void btnTinhLai_Click(object sender, EventArgs e)
        {
            string maSoTK = txtMaSoTK.Text.Trim();
            DateTime denNgay = dateTimePickerDenNgay.Value; // ngày người dùng chọn để tính lãi

            string query = $"SELECT dbo.fn_TinhLaiDuKien('{maSoTK}', '{denNgay:yyyy-MM-dd}') AS LaiDuKien";
            DataTable result = ExecuteQuery(query);

            if (result.Rows.Count > 0)
            {
                txtLaiDuKien.Text = result.Rows[0]["LaiDuKien"].ToString();
            }
        }
    }
}
