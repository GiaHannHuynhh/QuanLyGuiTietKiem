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
    public partial class ConfirmOpenSavingAcount : Form
    {

        private string currentEmployeeID = "NV002"; // Mặc định hoặc được gán khi khởi tạo form
        public ConfirmOpenSavingAcount()
        {
            InitializeComponent();
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void ConfirmOpenSavingAcount_Load(object sender, EventArgs e)
        {
            LoadBranches();
            LoadOpenRequests();
            LoadSavingsAccounts();
        }
        private void LoadBranches()
        {
            try
            {
                using (SqlConnection conn = DatabaseHelper.GetConnection())
                {
                    string query = "SELECT MaCN, TenCN FROM CHI_NHANH";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        conn.Open();
                        da.Fill(dt);

                        cmbBranch.DataSource = dt;
                        cmbBranch.DisplayMember = "TenCN";
                        cmbBranch.ValueMember = "MaCN";
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải danh sách chi nhánh: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void LoadOpenRequests()
        {
            try
            {
                using (SqlConnection conn = DatabaseHelper.GetConnection())
                {
                    string query = "SELECT MaYC, MaKH, MaLoaiTK, SoTien, NgayYeuCau, TrangThai FROM YEU_CAU_MO_SO WHERE TrangThai = N'Chờ xác nhận'";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        conn.Open();
                        da.Fill(dt);

                        dgvOpenRequests.DataSource = dt;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải danh sách yêu cầu mở sổ: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void LoadSavingsAccounts()
        {
            try
            {
                using (SqlConnection conn = DatabaseHelper.GetConnection())
                {
                    string query = "SELECT MaSoTK, MaKH, MaLoaiTK, NgayMoSo, SoTien, TrangThai, MaCN FROM TAI_KHOAN_TIET_KIEM";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        conn.Open();
                        da.Fill(dt);

                        dgvSavingsAccounts.DataSource = dt;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải danh sách sổ tiết kiệm: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnConfirmOpen_Click(object sender, EventArgs e)
        {
            if (dgvOpenRequests.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn một yêu cầu để xác nhận!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (cmbBranch.SelectedValue == null)
            {
                MessageBox.Show("Vui lòng chọn chi nhánh!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (SqlConnection conn = DatabaseHelper.GetConnection())
                {
                    using (SqlCommand cmd = new SqlCommand("sp_XacNhanMoSo", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@MaYC", dgvOpenRequests.SelectedRows[0].Cells["MaYC"].Value);
                        cmd.Parameters.AddWithValue("@MaNV", currentEmployeeID);
                        cmd.Parameters.AddWithValue("@MaCN", cmbBranch.SelectedValue);
                        cmd.Parameters.AddWithValue("@TrangThai", "Đã xác nhận");
                        cmd.Parameters.Add(new SqlParameter("@KetQua", SqlDbType.Bit) { Direction = ParameterDirection.Output });
                        cmd.Parameters.Add(new SqlParameter("@ThongBao", SqlDbType.NVarChar, 255) { Direction = ParameterDirection.Output });

                        conn.Open();
                        cmd.ExecuteNonQuery();

                        bool ketQua = Convert.ToBoolean(cmd.Parameters["@KetQua"].Value);
                        string thongBao = cmd.Parameters["@ThongBao"].Value?.ToString() ?? "Không có thông báo";

                        lblMessage.Text = thongBao;
                        if (ketQua)
                        {
                            MessageBox.Show(thongBao, "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            LoadOpenRequests();
                            LoadSavingsAccounts();
                        }
                        else
                        {
                            MessageBox.Show(thongBao, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                lblMessage.Text = $"Lỗi SQL: {ex.Message} (Mã lỗi: {ex.Number})";
                MessageBox.Show($"Lỗi SQL: {ex.Message}\nMã lỗi: {ex.Number}\nNguồn: {ex.Source}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                lblMessage.Text = $"Lỗi hệ thống: {ex.Message}";
                MessageBox.Show($"Lỗi hệ thống: {ex.Message}\nChi tiết: {ex.StackTrace}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnRejectOpen_Click(object sender, EventArgs e)
        {
            if (dgvOpenRequests.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn một yêu cầu để từ chối!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (SqlConnection conn = DatabaseHelper.GetConnection())
                {
                    using (SqlCommand cmd = new SqlCommand("sp_XacNhanMoSo", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@MaYC", dgvOpenRequests.SelectedRows[0].Cells["MaYC"].Value);
                        cmd.Parameters.AddWithValue("@MaNV", currentEmployeeID);
                        cmd.Parameters.AddWithValue("@MaCN", DBNull.Value);
                        cmd.Parameters.AddWithValue("@TrangThai", "Từ chối");
                        cmd.Parameters.Add(new SqlParameter("@KetQua", SqlDbType.Bit) { Direction = ParameterDirection.Output });
                        cmd.Parameters.Add(new SqlParameter("@ThongBao", SqlDbType.NVarChar, 255) { Direction = ParameterDirection.Output });

                        conn.Open();
                        cmd.ExecuteNonQuery();

                        bool ketQua = Convert.ToBoolean(cmd.Parameters["@KetQua"].Value);
                        string thongBao = cmd.Parameters["@ThongBao"].Value?.ToString() ?? "Không có thông báo";

                        lblMessage.Text = thongBao;
                        if (ketQua)
                        {
                            MessageBox.Show(thongBao, "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            LoadOpenRequests();
                        }
                        else
                        {
                            MessageBox.Show(thongBao, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                lblMessage.Text = $"Lỗi SQL: {ex.Message} (Mã lỗi: {ex.Number})";
                MessageBox.Show($"Lỗi SQL: {ex.Message}\nMã lỗi: {ex.Number}\nNguồn: {ex.Source}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                lblMessage.Text = $"Lỗi hệ thống: {ex.Message}";
                MessageBox.Show($"Lỗi hệ thống: {ex.Message}\nChi tiết: {ex.StackTrace}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public static class DatabaseHelper
        {
            public static SqlConnection GetConnection()
            {
                string connectionString = ConfigurationManager.ConnectionStrings["QuanLyGuiTietKiemConnection"].ConnectionString;
                return new SqlConnection(connectionString);
            }
        }

    }
    

}
