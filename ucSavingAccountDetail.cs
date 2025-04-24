using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyGuiTietKiem
{
    public partial class ucSavingAccountDetail : UserControl
    {
        public ucSavingAccountDetail()
        {
            InitializeComponent();
        }

        private void ucSavingAccountDetail_Load(object sender, EventArgs e)
        {

        }

        public void LoadAccountDetails(DataRow row)
        {
            txtMaSoTK.Text = row["MaSoTK"].ToString();
            txtMaKH.Text = row["MaKH"].ToString();
            txtMaLoaiTK.Text = row["MaLoaiTK"].ToString();
            txtNgayMoSo.Text = DateTime.Parse(row["NgayMoSo"].ToString()).ToShortDateString();
            txtNgayTatToan.Text = row["NgayTatToan"] == DBNull.Value ? "Chưa tất toán" : DateTime.Parse(row["NgayTatToan"].ToString()).ToShortDateString();
            txtNgayDaoHan.Text = DateTime.Parse(row["NgayDaoHan"].ToString()).ToShortDateString();
            txtSoDuHienTai.Text = Convert.ToDecimal(row["SoDuHienTai"]).ToString("N0") + " VNĐ";
            txtTrangThai.Text = row["TrangThai"].ToString();
            txtMaCN.Text = row["MaCN"].ToString();
            txtSoLanTaiTuc.Text = row["SoLanTaiTuc"].ToString();
            txtLoaiTienGui.Text = row["LoaiTienGui"].ToString();
        }


        private void lblMaSoTK_Click(object sender, EventArgs e)
        {

        }
    }
}
