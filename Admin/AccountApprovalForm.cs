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
    public partial class AccountApprovalForm: Form
    {
        private string connectionString = ConfigurationManager.ConnectionStrings["QuanLyGuiTietKiemConnection"].ConnectionString;
        public AccountApprovalForm()
        {
            InitializeComponent();
            dgvRequests.ReadOnly = true;
            dgvRequests.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvRequests.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            LoadRequests();
        }

        private void LoadRequests()
        {
            ProgressForm.ShowProgress(this, () =>
            {
                try
                {
                    using (SqlConnection conn = new SqlConnection(connectionString))
                    {
                        conn.Open();
                        SqlCommand cmd = new SqlCommand("sp_XemDanhSachYeuCauDangKy", conn);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@TenDangNhapAdmin", UserSession.Username);
                        cmd.Parameters.Add("@KetQua", SqlDbType.Bit).Direction = ParameterDirection.Output;
                        cmd.Parameters.Add("@ThongBao", SqlDbType.NVarChar, 255).Direction = ParameterDirection.Output;

                        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);

                        dgvRequests.DataSource = dt;

                        // Đặt tiêu đề cột bằng tiếng Việt
                        if (dgvRequests.Columns["MaYC"] != null)
                            dgvRequests.Columns["MaYC"].HeaderText = "Mã yêu cầu";
                        if (dgvRequests.Columns["HoTen"] != null)
                            dgvRequests.Columns["HoTen"].HeaderText = "Họ tên";
                        if (dgvRequests.Columns["NgaySinh"] != null)
                            dgvRequests.Columns["NgaySinh"].HeaderText = "Ngày sinh";
                        if (dgvRequests.Columns["MaSoCCCD"] != null)
                            dgvRequests.Columns["MaSoCCCD"].HeaderText = "Số CCCD";
                        if (dgvRequests.Columns["NgayCap"] != null)
                            dgvRequests.Columns["NgayCap"].HeaderText = "Ngày cấp";
                        if (dgvRequests.Columns["SDT"] != null)
                            dgvRequests.Columns["SDT"].HeaderText = "Số điện thoại";
                        if (dgvRequests.Columns["DiaChi"] != null)
                            dgvRequests.Columns["DiaChi"].HeaderText = "Địa chỉ";
                        if (dgvRequests.Columns["Email"] != null)
                            dgvRequests.Columns["Email"].HeaderText = "Email";
                        if (dgvRequests.Columns["TenDangNhap"] != null)
                            dgvRequests.Columns["TenDangNhap"].HeaderText = "Tên đăng nhập";
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            });
        }
        private void btnApprove_Click(object sender, EventArgs e)
        {
            ProcessRequest("Đã xác nhận");
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn từ chối yêu cầu này không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                ProcessRequest("Từ chối");
            }
        }


        private void ProcessRequest(string trangThai)
        {
            if (dgvRequests.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn một yêu cầu để xử lý!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Lấy hàng được chọn
            DataGridViewRow selectedRow = dgvRequests.SelectedRows[0];

            // Kiểm tra giá trị của các cột trước khi truy cập
            if (selectedRow.Cells["MaYC"] == null || selectedRow.Cells["MaYC"].Value == null)
            {
                MessageBox.Show("Không tìm thấy mã yêu cầu (MaYC) trong hàng được chọn!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (selectedRow.Cells["Email"] == null || selectedRow.Cells["Email"].Value == null)
            {
                MessageBox.Show("Không tìm thấy email trong hàng được chọn!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (selectedRow.Cells["TenDangNhap"] == null || selectedRow.Cells["TenDangNhap"].Value == null)
            {
                MessageBox.Show("Không tìm thấy tên đăng nhập trong hàng được chọn!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Lấy mã yêu cầu, email và tên đăng nhập từ hàng được chọn
            string maYC = selectedRow.Cells["MaYC"].Value.ToString();
            string email = selectedRow.Cells["Email"].Value.ToString();
            string tenDangNhap = selectedRow.Cells["TenDangNhap"].Value.ToString();

            ProgressForm.ShowProgress(this, () =>
            {
                try
                {
                    using (SqlConnection conn = new SqlConnection(connectionString))
                    {
                        conn.Open();
                        SqlCommand cmd = new SqlCommand("sp_XuLyYeuCauDangKyTaiKhoan", conn);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@MaYC", maYC);
                        cmd.Parameters.AddWithValue("@TrangThai", trangThai);
                        cmd.Parameters.AddWithValue("@TenDangNhapAdmin", UserSession.Username);
                        cmd.Parameters.Add("@KetQua", SqlDbType.Bit).Direction = ParameterDirection.Output;
                        cmd.Parameters.Add("@ThongBao", SqlDbType.NVarChar, 255).Direction = ParameterDirection.Output;

                        cmd.ExecuteNonQuery();

                        bool ketQua = (bool)cmd.Parameters["@KetQua"].Value;
                        string thongBao = cmd.Parameters["@ThongBao"].Value.ToString();

                        if (ketQua)
                        {
                            // Gửi email thông báo
                            string emailSubject = trangThai == "Đã xác nhận" ? "Tài khoản của bạn đã được phê duyệt" : "Yêu cầu đăng ký của bạn đã bị từ chối";
                            string emailBody = trangThai == "Đã xác nhận"
                                ? $"Chúc mừng! Tài khoản của bạn đã được phê duyệt. Bạn có thể đăng nhập với tên đăng nhập: {tenDangNhap}."
                                : "Rất tiếc, yêu cầu đăng ký tài khoản của bạn đã bị từ chối. Vui lòng liên hệ quản trị viên để biết thêm chi tiết.";
                            EmailService.SendEmail(email, emailSubject, emailBody);
                        }

                        MessageBox.Show(thongBao, "Thông báo", MessageBoxButtons.OK, ketQua ? MessageBoxIcon.Information : MessageBoxIcon.Error);
                        LoadRequests(); // Làm mới danh sách sau khi xử lý
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
