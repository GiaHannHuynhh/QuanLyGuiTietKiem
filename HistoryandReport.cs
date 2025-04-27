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
    public partial class HistoryandReport : Form
    {
        private DataTable transactionData; // Lưu dữ liệu giao dịch để xuất báo cáo
        public HistoryandReport()
        {
            InitializeComponent();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string maKH = txtCustomerID.Text.Trim();

            if (string.IsNullOrWhiteSpace(maKH))
            {
                MessageBox.Show("Vui lòng nhập mã khách hàng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DateTime? tuNgay = chkFilterDate.Checked ? (DateTime?)dtpFromDate.Value : null;
            DateTime? denNgay = chkFilterDate.Checked ? (DateTime?)dtpToDate.Value : null;

            if (chkFilterDate.Checked && tuNgay > denNgay)
            {
                MessageBox.Show("Ngày bắt đầu phải nhỏ hơn hoặc bằng ngày kết thúc!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (SqlConnection conn = DatabaseHelper.GetConnection())
                {
                    using (SqlCommand cmd = new SqlCommand("sp_TraCuuLichSuGiaoDich_KhachHang", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@TenDangNhap", "nv002");
                        cmd.Parameters.AddWithValue("@MaKH", maKH);
                        cmd.Parameters.AddWithValue("@TuNgay", (object)tuNgay ?? DBNull.Value);
                        cmd.Parameters.AddWithValue("@DenNgay", (object)denNgay ?? DBNull.Value);
                        cmd.Parameters.Add(new SqlParameter("@KetQua", SqlDbType.Bit) { Direction = ParameterDirection.Output });
                        cmd.Parameters.Add(new SqlParameter("@ThongBao", SqlDbType.NVarChar, 255) { Direction = ParameterDirection.Output });

                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        transactionData = new DataTable();
                        conn.Open();
                        da.Fill(transactionData);

                        bool ketQua = Convert.ToBoolean(cmd.Parameters["@KetQua"].Value);
                        string thongBao = cmd.Parameters["@ThongBao"].Value?.ToString() ?? "Không có thông báo";

                        lblMessage.Text = thongBao;
                        if (ketQua)
                        {
                            dgvTransactionHistory.DataSource = transactionData;
                            if (transactionData.Rows.Count == 0)
                            {
                                lblMessage.Text = "Không tìm thấy giao dịch nào!";
                            }
                        }
                        else
                        {
                            MessageBox.Show(thongBao, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            dgvTransactionHistory.DataSource = null;
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

        private void HistoryandReport_Load(object sender, EventArgs e)
        {
            dtpFromDate.Value = DateTime.Now.AddMonths(-1); // Mặc định 1 tháng trước
            dtpToDate.Value = DateTime.Now;
        }

        private void chkFilterDate_CheckedChanged(object sender, EventArgs e)
        {
            dtpFromDate.Enabled = chkFilterDate.Checked;
            dtpToDate.Enabled = chkFilterDate.Checked;
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            if (dgvTransactionHistory.DataSource == null || transactionData.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu để xuất báo cáo!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                StringBuilder csvContent = new StringBuilder();
                // Tiêu đề cột
                csvContent.AppendLine("Mã giao dịch,Mã sổ tiết kiệm,Loại giao dịch,Số tiền,Ngày giao dịch,Mã nhân viên,Tên nhân viên");

                // Dữ liệu
                foreach (DataRow row in transactionData.Rows)
                {
                    string maGD = row["MaGD"].ToString();
                    string maSoTK = row["MaSoTK"].ToString();
                    string loaiGD = row["LoaiGD"].ToString();
                    string soTien = row["SoTien"].ToString();
                    string ngayGD = Convert.ToDateTime(row["NgayGD"]).ToString("yyyy-MM-dd HH:mm:ss");
                    string maNV = row["MaNV"].ToString();
                    string tenNhanVien = row["TenNhanVien"].ToString();

                    csvContent.AppendLine($"\"{maGD}\",\"{maSoTK}\",\"{loaiGD}\",\"{soTien}\",\"{ngayGD}\",\"{maNV}\",\"{tenNhanVien}\"");
                }

                // Lưu file CSV (giả lập vì không thể lưu file trực tiếp trong môi trường này)
                string fileName = $"TransactionReport_{DateTime.Now:yyyyMMdd_HHmmss}.csv";
                // File.WriteAllText(fileName, csvContent.ToString()); // Bỏ comment nếu chạy trên môi trường hỗ trợ lưu file

                MessageBox.Show($"Báo cáo đã được tạo (giả lập): {fileName}\nNội dung:\n{csvContent.ToString()}", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi xuất báo cáo: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public static class DatabaseHelper
        {
            public static SqlConnection GetConnection()
            {
                string connectionString = ConfigurationManager.ConnectionStrings["QuanLyGuiTietKiemConnection"].ConnectionString;
                if (string.IsNullOrEmpty(connectionString))
                {
                    throw new Exception("Chuỗi kết nối không được tìm thấy trong tệp cấu hình!");
                }
                return new SqlConnection(connectionString);
            }

            public static void LogError(Exception ex, string context)
            {
                string logMessage = $"[{DateTime.Now}] Ngữ cảnh: {context}\nLỗi: {ex.Message}\nChi tiết: {ex.StackTrace}";
                if (ex is SqlException sqlEx)
                {
                    logMessage += $"\nMã lỗi SQL: {sqlEx.Number}\nNguồn: {sqlEx.Source}";
                }
                // File.AppendAllText("error.log", logMessage + "\n"); // Bỏ comment nếu muốn ghi vào file
                MessageBox.Show(logMessage, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
   
}
