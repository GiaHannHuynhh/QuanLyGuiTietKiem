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
    public partial class TransactionProcess : Form
    {

        private string currentEmployeeID = "NV002"; /// Mặc định hoặc được gán khi khởi tạo form
        public TransactionProcess()
        {
            InitializeComponent();
        }

        private void btnCreateTransaction_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtAccountID.Text))
            {
                MessageBox.Show("Vui lòng nhập mã sổ tiết kiệm!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string maSoTK = txtAccountID.Text;
            string loaiGD = cmbTransactionType.SelectedItem?.ToString();

            if (string.IsNullOrEmpty(loaiGD))
            {
                MessageBox.Show("Vui lòng chọn loại giao dịch!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            decimal soTien = 0;
            if (loaiGD != "Tất toán")
            {
                if (string.IsNullOrWhiteSpace(txtAmount.Text) || !decimal.TryParse(txtAmount.Text, out soTien) || soTien <= 0)
                {
                    MessageBox.Show("Số tiền không hợp lệ! Vui lòng nhập số tiền lớn hơn 0.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }

            try
            {
                using (SqlConnection conn = DatabaseHelper.GetConnection())
                {
                    conn.Open();

                    if (loaiGD == "Tất toán")
                    {
                        using (SqlCommand cmd = new SqlCommand("sp_TatToanSoTietKiem", conn))
                        {
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.AddWithValue("@MaSoTK", maSoTK);
                            cmd.Parameters.AddWithValue("@MaNV", currentEmployeeID);
                            cmd.Parameters.Add(new SqlParameter("@KetQua", SqlDbType.Bit) { Direction = ParameterDirection.Output });
                            cmd.Parameters.Add(new SqlParameter("@ThongBao", SqlDbType.NVarChar, 255) { Direction = ParameterDirection.Output });

                            cmd.ExecuteNonQuery();

                            bool ketQua = Convert.ToBoolean(cmd.Parameters["@KetQua"].Value);
                            string thongBao = cmd.Parameters["@ThongBao"].Value?.ToString() ?? "Không có thông báo";

                            lblMessage.Text = thongBao;
                            if (ketQua)
                            {
                                MessageBox.Show(thongBao, "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                LoadTransactions(maSoTK);
                            }
                            else
                            {
                                MessageBox.Show(thongBao, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
                    else
                    {
                        string maGD = GenerateTransactionID();
                        if (maGD == null)
                            return;

                        using (SqlCommand cmd = new SqlCommand("sp_TaoGiaoDich", conn))
                        {
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.AddWithValue("@MaGD", maGD);
                            cmd.Parameters.AddWithValue("@MaSoTK", maSoTK);
                            cmd.Parameters.AddWithValue("@LoaiGD", loaiGD);
                            cmd.Parameters.AddWithValue("@SoTien", soTien);
                            cmd.Parameters.AddWithValue("@NgayGD", DateTime.Now);
                            cmd.Parameters.AddWithValue("@MaNV", currentEmployeeID);
                            cmd.Parameters.Add(new SqlParameter("@KetQua", SqlDbType.Bit) { Direction = ParameterDirection.Output });
                            cmd.Parameters.Add(new SqlParameter("@ThongBao", SqlDbType.NVarChar, 255) { Direction = ParameterDirection.Output });

                            cmd.ExecuteNonQuery();

                            bool ketQua = Convert.ToBoolean(cmd.Parameters["@KetQua"].Value);
                            string thongBao = cmd.Parameters["@ThongBao"].Value?.ToString() ?? "Không có thông báo";

                            lblMessage.Text = thongBao;
                            if (ketQua)
                            {
                                MessageBox.Show(thongBao, "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                LoadTransactions(maSoTK);
                                txtAmount.Clear();
                            }
                            else
                            {
                                MessageBox.Show(thongBao, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
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
        private void LoadTransactions(string maSoTK)
        {
            try
            {
                using (SqlConnection conn = DatabaseHelper.GetConnection())
                {
                    string query = "SELECT MaGD, MaSoTK, LoaiGD, SoTien, NgayGD, MaNV FROM GIAO_DICH WHERE MaSoTK = @MaSoTK ORDER BY NgayGD DESC";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@MaSoTK", maSoTK);
                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        conn.Open();
                        da.Fill(dt);

                        dgvTransactions.DataSource = dt;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải danh sách giao dịch: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private string GenerateTransactionID()
        {
            try
            {
                using (SqlConnection conn = DatabaseHelper.GetConnection())
                {
                    string query = "SELECT ISNULL(MAX(CAST(SUBSTRING(MaGD, 3, 4) AS INT)), 0) + 1 FROM GIAO_DICH";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        conn.Open();
                        int nextID = Convert.ToInt32(cmd.ExecuteScalar());
                        return "GD" + nextID.ToString("D4");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi sinh mã giao dịch: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        private void TransactionProcess_Load(object sender, EventArgs e)
        {
            if (cmbTransactionType.Items.Count > 0)
                cmbTransactionType.SelectedIndex = 0;
            cmbTransactionType.SelectedIndexChanged += new EventHandler(cmbTransactionType_SelectedIndexChanged);
        }
        private void cmbTransactionType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbTransactionType.SelectedItem.ToString() == "Tất toán")
            {
                txtAmount.Enabled = false;
                txtAmount.Text = "Tự động tính toán";
            }
            else
            {
                txtAmount.Enabled = true;
                txtAmount.Text = "";
                txtAmount.ForeColor = Color.Gray; // Đặt màu sắc của văn bản placeholder
                txtAmount.Text = "Nhập số tiền"; // Thiết lập văn bản placeholder
            }
        }

        private void txtAmount_Enter(object sender, EventArgs e)
        {
            // Xóa placeholder khi người dùng bắt đầu nhập liệu
            if (txtAmount.Text == "Nhập số tiền")
            {
                txtAmount.Text = "";
                txtAmount.ForeColor = Color.Black; // Màu sắc của văn bản khi người dùng nhập
            }
        }

        private void txtAmount_Leave(object sender, EventArgs e)
        {
            // Nếu người dùng không nhập gì, hiển thị lại placeholder
            if (string.IsNullOrWhiteSpace(txtAmount.Text))
            {
                txtAmount.Text = "Nhập số tiền";
                txtAmount.ForeColor = Color.Gray; // Màu sắc của placeholder
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
