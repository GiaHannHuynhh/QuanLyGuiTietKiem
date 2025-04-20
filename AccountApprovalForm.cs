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
    public partial class AccountApprovalForm : Form
    {
        private string selectedAccountID = null; // Lưu mã tài khoản được chọn
        public AccountApprovalForm()
        {
            InitializeComponent();
            
        }
        private void AccountApprovalForm_Load(object sender, EventArgs e)
        {
            LoadPendingAccounts(); // Tải danh sách tài khoản chờ phê duyệt khi form mở
        }

        private void LoadPendingAccounts()
        {
            try
            {
                using (SqlConnection conn = DatabaseHelper.GetConnection())
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("sp_DanhSachTaiKhoanChoPheDuyet", conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    dgvPendingAccounts.DataSource = dt;

                    // Tùy chỉnh tiêu đề cột
                    if (dgvPendingAccounts.Columns.Contains("MaSo")) dgvPendingAccounts.Columns["MaSo"].HeaderText = "Mã Sổ";
                    if (dgvPendingAccounts.Columns.Contains("MaKH")) dgvPendingAccounts.Columns["MaKH"].HeaderText = "Mã Khách Hàng";
                    if (dgvPendingAccounts.Columns.Contains("HoTen")) dgvPendingAccounts.Columns["HoTen"].HeaderText = "Họ Tên";
                    if (dgvPendingAccounts.Columns.Contains("MaLoaiSo")) dgvPendingAccounts.Columns["MaLoaiSo"].HeaderText = "Mã Loại Sổ";
                    if (dgvPendingAccounts.Columns.Contains("TenLoaiSo")) dgvPendingAccounts.Columns["TenLoaiSo"].HeaderText = "Tên Loại Sổ";
                    if (dgvPendingAccounts.Columns.Contains("SoTienGui")) dgvPendingAccounts.Columns["SoTienGui"].HeaderText = "Số Tiền Gửi";
                    if (dgvPendingAccounts.Columns.Contains("NgayMoSo")) dgvPendingAccounts.Columns["NgayMoSo"].HeaderText = "Ngày Mở Sổ";
                    if (dgvPendingAccounts.Columns.Contains("TinhTrang")) dgvPendingAccounts.Columns["TinhTrang"].HeaderText = "Tình Trạng";
                    if (dgvPendingAccounts.Columns.Contains("MaCN")) dgvPendingAccounts.Columns["MaCN"].HeaderText = "Mã Chi Nhánh";
                    if (dgvPendingAccounts.Columns.Contains("TenCN")) dgvPendingAccounts.Columns["TenCN"].HeaderText = "Tên Chi Nhánh";

                    lblMessage.Text = dt.Rows.Count > 0 ? $"Tìm thấy {dt.Rows.Count} tài khoản chờ phê duyệt." : "Không có tài khoản chờ phê duyệt!";
                }
            }
            catch (Exception ex)
            {
                lblMessage.Text = "Lỗi khi tải danh sách tài khoản: " + ex.Message;
            }
        }
        private void panel5_Paint(object sender, PaintEventArgs e)
        {

        }

        private void lblMessage_Click(object sender, EventArgs e)
        {

        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            dgvPendingAccounts.DataSource = null; // Làm sạch DataGridView
            lblMessage.Text = string.Empty;
            selectedAccountID = null; // Reset lựa chọn
        }

        private void btnApprove_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(selectedAccountID))
            {
                lblMessage.Text = "Vui lòng chọn một tài khoản để phê duyệt!";
                return;
            }

            try
            {
                using (SqlConnection conn = DatabaseHelper.GetConnection())
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("sp_PheDuyetTaiKhoan", conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@MaSo", selectedAccountID);

                    cmd.ExecuteNonQuery();
                    lblMessage.Text = "Phê duyệt tài khoản thành công!";
                    LoadPendingAccounts(); // Làm mới DataGridView
                    selectedAccountID = null; // Reset lựa chọn
                }
            }
            catch (Exception ex)
            {
                lblMessage.Text = "Lỗi khi phê duyệt tài khoản: " + ex.Message;
            }
        }

        private void btnReject_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(selectedAccountID))
            {
                lblMessage.Text = "Vui lòng chọn một tài khoản để từ chối!";
                return;
            }

            if (MessageBox.Show("Bạn có chắc muốn từ chối tài khoản này?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    using (SqlConnection conn = DatabaseHelper.GetConnection())
                    {
                        conn.Open();
                        SqlCommand cmd = new SqlCommand("sp_TuChoiTaiKhoan", conn);
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@MaSo", selectedAccountID);

                        cmd.ExecuteNonQuery();
                        lblMessage.Text = "Từ chối tài khoản thành công!";
                        LoadPendingAccounts(); // Làm mới DataGridView
                        selectedAccountID = null; // Reset lựa chọn
                    }
                }
                catch (Exception ex)
                {
                    lblMessage.Text = "Lỗi khi từ chối tài khoản: " + ex.Message;
                }
            }
        }

        private void dgvPendingAccounts_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Lấy mã tài khoản khi người dùng click vào một hàng trong DataGridView
            if (e.RowIndex >= 0) // Đảm bảo click vào hàng hợp lệ
            {
                DataGridViewRow row = dgvPendingAccounts.Rows[e.RowIndex];
                selectedAccountID = row.Cells["MaSo"].Value?.ToString();
                lblMessage.Text = $"Đã chọn tài khoản: {selectedAccountID}";
            }
        }

        private void AccountApprovalForm_Load_1(object sender, EventArgs e)
        {

        }
    }
}
