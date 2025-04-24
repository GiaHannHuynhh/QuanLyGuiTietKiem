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
    public partial class ucTransaction : UserControl
    {
        public ucTransaction()
        {
            InitializeComponent();
        }
        private string connectionString = "Data Source=DESKTOP-87AFJH3;Initial Catalog=QuanLyGuiTietKiem;Integrated Security=True";

        private string maKH = "KH001";
        private void btnViewHistory_Click(object sender, EventArgs e)
        {
            DateTime? tuNgay = dtpFromDate.Checked ? dtpFromDate.Value.Date : (DateTime?)null;
            DateTime? denNgay = dtpToDate.Checked ? dtpToDate.Value.Date : (DateTime?)null;

            // Debug thông tin về các tham số ngày
            MessageBox.Show($"DEBUG - Từ ngày: {tuNgay}, Đến ngày: {denNgay}");

            using (SqlConnection conn = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand("sp_TraCuuLichSuGiaoDich_KhachHang", conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@MaKH", maKH);

                // Chắc chắn sử dụng đúng tham số cho ngày
                cmd.Parameters.Add("@TuNgay", SqlDbType.Date).Value = (object)tuNgay ?? DBNull.Value;
                cmd.Parameters.Add("@DenNgay", SqlDbType.Date).Value = (object)denNgay ?? DBNull.Value;

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adapter.Fill(dt);

                // Debug số dòng trả về
                MessageBox.Show("Số dòng lấy được: " + dt.Rows.Count);

                dgvTransactions.DataSource = dt;

                lblMessage.Text = dt.Rows.Count == 0 ? "Không có giao dịch nào trong khoảng thời gian này." : "";
            }
        }

        private void btnStatement_Click(object sender, EventArgs e)
        {
            DateTime? tuNgay = dtpFromDate.Checked ? dtpFromDate.Value.Date : (DateTime?)null;
            DateTime? denNgay = dtpToDate.Checked ? dtpToDate.Value.Date : (DateTime?)null;

            // Tạo một biến để chứa kết quả báo cáo
            StringBuilder reportContent = new StringBuilder();
            reportContent.AppendLine($"Báo cáo sao kê giao dịch khách hàng {maKH} từ {tuNgay} đến {denNgay}");

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("sp_BaoCaoSaoKeGiaoDich_KhachHang", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@MaKH", maKH);
                cmd.Parameters.AddWithValue("@TuNgay", tuNgay.HasValue ? (object)tuNgay.Value : DBNull.Value);
                cmd.Parameters.AddWithValue("@DenNgay", denNgay.HasValue ? (object)denNgay.Value : DBNull.Value);

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();

                try
                {
                    conn.Open();
                    da.Fill(ds); // ds.Tables[0]: Chi tiết, ds.Tables[1]: Tổng hợp

                    // Kiểm tra bảng chi tiết và thêm dữ liệu vào báo cáo
                    if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                    {
                        reportContent.AppendLine("\nChi tiết giao dịch:");

                        foreach (DataRow row in ds.Tables[0].Rows)
                        {
                            string maGD = row["MaGD"].ToString();
                            string maSoTK = row["MaSoTK"].ToString();
                            string loaiGD = row["LoaiGD"].ToString();
                            decimal soTien = Convert.ToDecimal(row["SoTien"]);
                            DateTime ngayGD = Convert.ToDateTime(row["NgayGD"]);
                            string maNV = row["MaNV"].ToString();
                            string tenNhanVien = row["TenNhanVien"].ToString();

                            reportContent.AppendLine($"Mã GD: {maGD}, Mã Sổ TK: {maSoTK}, Loại GD: {loaiGD}, " +
                                $"Số Tiền: {soTien:N0}, Ngày GD: {ngayGD:dd/MM/yyyy}, Nhân viên: {tenNhanVien}");
                        }

                        // Thêm thông tin tổng hợp vào báo cáo nếu có
                        if (ds.Tables.Count > 1 && ds.Tables[1].Rows.Count > 0)
                        {
                            DataRow row = ds.Tables[1].Rows[0];
                            int tongGD = Convert.ToInt32(row["TongSoGiaoDich"]);
                            decimal tongNap = Convert.ToDecimal(row["TongTienNap"]);
                            decimal tongRut = Convert.ToDecimal(row["TongTienRut"]);

                            reportContent.AppendLine($"\nTổng giao dịch: {tongGD}, Tổng tiền nạp: {tongNap:N0}, Tổng tiền rút: {tongRut:N0}");
                        }
                    }
                    else
                    {
                        reportContent.AppendLine("\nKhông có giao dịch trong khoảng thời gian đã chọn.");
                    }

                    // Hiển thị báo cáo trong MessageBox
                    MessageBox.Show(reportContent.ToString(), "Báo cáo sao kê giao dịch");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi: " + ex.Message);
                }
            }
        }

        private void ucTransaction_Load(object sender, EventArgs e)
        {
            // Thiết lập màu chữ
            dgvTransactions.DefaultCellStyle.ForeColor = Color.Black;

            // Nếu muốn, có thể set màu nền nữa (optional)
            dgvTransactions.DefaultCellStyle.BackColor = Color.White;
        }
    }
}
