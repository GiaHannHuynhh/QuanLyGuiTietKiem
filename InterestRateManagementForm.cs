using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyGuiTietKiem
{
    public partial class InterestRateManagementForm: Form
    {
        private InterestRateManagement interestRateManagement;
        private DataTable interestRatesTable;
        private string currentUserId = "NV001"; // Giả định mã nhân viên, thay bằng logic lấy từ phiên đăng nhập
        private System.Windows.Forms.Button currentBtn;

        public InterestRateManagementForm()
        {
            InitializeComponent();

            this.Text = string.Empty;
            this.DoubleBuffered = true;

            // Khởi tạo InterestRateManagement với chuỗi kết nối
            interestRateManagement = new InterestRateManagement();
            dgvInterestRates.Resize += (s, e) => AdjustDataGridView();
            LoadInterestRates();
        }

        private void InterestRateManagementForm_Load(object sender, EventArgs e)
        {
            AdjustDataGridView();
        }

        private void btnUpdateRate_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBColors.color1);

            // Kiểm tra dữ liệu đầu vào trước
            if (!ValidateInputforUpdate())
            {
                return;
            }
            
            string maLoaiTK = txtMaLoaiTK.Text;

            // Lấy giá trị lãi suất mới (đã được validate trong ValidateInput)
            decimal laiSuatMoi = decimal.Parse(txtNewRate.Text, NumberStyles.Any, CultureInfo.InvariantCulture);
            // Làm tròn lãi suất mới đến 2 chữ số thập phân
            laiSuatMoi = Math.Round(laiSuatMoi, 2);

            // Hiển thị hộp thoại xác nhận
            DialogResult result = MessageBox.Show(
                "Bạn chắc chắn muốn cập nhật lãi suất cho loại tiết kiệm: " + txtMaLoaiTK.Text.Trim() + "?",
                "Xác nhận xóa",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning
            );

            // Nếu người dùng chọn "Yes"
            if (result == DialogResult.Yes)
            {
                var (ketQua, thongBao) = interestRateManagement.UpdateInterestRate(maLoaiTK, laiSuatMoi, currentUserId);

                // Hiển thị thông báo
                ShowNotification(thongBao, ketQua);

                // Nếu xóa thành công, làm mới dữ liệu
                if (ketQua == 1)
                {
                    LoadInterestRates();
                    ShowNotification(thongBao, ketQua);
                }
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearFields();
            HideNotification();
            LoadInterestRates();
        }

        private void dgvInterestRates_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvInterestRates.Rows[e.RowIndex];
                txtMaLoaiTK.Text = row.Cells["MaLoaiTK"].Value.ToString();
                txtTenLoaiTK.Text = row.Cells["TenLoaiTK"].Value.ToString();
                txtKyHan.Text = row.Cells["KyHan"].Value.ToString();
                txtMaLoaiTK.Enabled = false;
                HideNotification();
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void ClearFields()
        {
            txtMaLoaiTK.Text = "";
            txtTenLoaiTK.Text = "";
            txtKyHan.Text = "";
            txtNewRate.Text = "";
            txtMaLoaiTK.Enabled = true;
        }

        private void LoadInterestRates()
        {
            try
            {
                DataTable dataTable = interestRateManagement.GetAllInterestRates();
                dgvInterestRates.DataSource = dataTable;
                ClearFields();
                HideNotification();

                AdjustDataGridView();
                ConfigureDataGridView();
            }
            catch (Exception ex)
            {
                ShowNotification(ex.Message, 1);
            }
        }

        private void SetupNumericValidation()
        {
            txtNewRate.KeyPress += (sender, e) =>
            {
                // Allow only digits, decimal point, and control characters
                if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.')
                {
                    e.Handled = true;
                }

                // Allow only one decimal point
                if (e.KeyChar == '.' && (sender as TextBox).Text.IndexOf('.') > -1)
                {
                    e.Handled = true;
                }
            };
        }

        private void ShowNotification(string message, int result)
        {
            lblMessage.Text = message;
            lblMessage.ForeColor = result == 0 ? System.Drawing.Color.Red : System.Drawing.Color.Green;
            lblMessage.Visible = true;
        }

        private void HideNotification()
        {
            lblMessage.Visible = false;
        }

        // Kiểm tra dữ liệu đầu vào cho chức năng thêm
        private bool ValidateInputForAdd()
        {
            if (string.IsNullOrWhiteSpace(txtMaLoaiTK.Text))
            {
                ShowNotification("Vui lòng nhập mã loại tiết kiệm!", 0);
                txtMaLoaiTK.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtTenLoaiTK.Text))
            {
                ShowNotification("Vui lòng nhập tên loại tiết kiệm!", 0);
                txtTenLoaiTK.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtKyHan.Text))
            {
                ShowNotification("Vui lòng nhập kỳ hạn cho loại tiết kiệm!", 0);
                txtKyHan.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtNewRate.Text))
            {
                ShowNotification("Vui lòng nhập lãi suất!", 0);
                txtNewRate.Focus();
                return false;
            }

            // Kiểm tra định dạng kỳ hạn
            if (!int.TryParse(txtKyHan.Text.Trim(), out int kyHan) || kyHan <= 0)
            {
                ShowNotification("Kỳ hạn phải là số nguyên dương hợp lệ!", 0);
                txtKyHan.Focus();
                return false;
            }

            // Kiểm tra định dạng lãi suất
            if (!decimal.TryParse(txtNewRate.Text, NumberStyles.Any, CultureInfo.InvariantCulture, out decimal laiSuat) || laiSuat < 0 || laiSuat > 100)
            {
                ShowNotification("Lãi suất phải là số hợp lệ và nằm trong khoảng từ 0% đến 100%!", 0);
                txtNewRate.Focus();
                return false;
            }

            return true;
        }

        // Kiểm tra dữ liệu đầu vào cho chức năng xóa
        private bool ValidateInputForDelete()
        {
            if (string.IsNullOrWhiteSpace(txtMaLoaiTK.Text))
            {
                ShowNotification("Vui lòng nhập mã loại tiết kiệm để xóa!", 0);
                txtMaLoaiTK.Focus();
                return false;
            }

            return true;
        }

        private bool ValidateInputforUpdate()
        {
            if (string.IsNullOrWhiteSpace(txtMaLoaiTK.Text))
            {
                ShowNotification("Vui lòng nhập mã loại tiết kiệm!", 0);
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtNewRate.Text))
            {
                ShowNotification("Vui lòng nhập lãi suất mới!", 0);
                return false;
            }

            decimal newRate;
            if (!decimal.TryParse(txtNewRate.Text, NumberStyles.Any, CultureInfo.InvariantCulture, out newRate))
            {
                ShowNotification("Lãi suất phải là số thập phân hợp lệ!", 0);
                return false;
            }

            if (newRate < 0 || newRate > 100)
            {
                ShowNotification("Lãi suất phải nằm trong khoảng từ 0% đến 100%!", 0);
                return false;
            }

            return true;
        }

        private void AdjustDataGridView()
        {
            if (dgvInterestRates.Columns.Count == 0 || dgvInterestRates.Rows.Count == 0)
                return;

            // Thiết lập xuống dòng
            DataGridViewCellStyle wrapStyle = new DataGridViewCellStyle();
            wrapStyle.WrapMode = DataGridViewTriState.True;
            dgvInterestRates.DefaultCellStyle = wrapStyle;

            // Điều chỉnh hàng
            AdjustRowHeights();
        }

        private void AdjustRowHeights()
        {
            dgvInterestRates.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;

            // Tính toán lại chiều cao cho từng hàng
            foreach (DataGridViewRow row in dgvInterestRates.Rows)
            {
                row.Height = row.GetPreferredHeight(row.Index, DataGridViewAutoSizeRowMode.AllCells, true);
            }
        }

        private void ConfigureDataGridView()
        {
            // 1. Đổi tên cột sang tiếng Việt có dấu
            if (dgvInterestRates.Columns.Contains("MaLoaiTK"))
                dgvInterestRates.Columns["MaLoaiTK"].HeaderText = "Mã LTK";
            if (dgvInterestRates.Columns.Contains("TenLoaiTK"))
                dgvInterestRates.Columns["TenLoaiTK"].HeaderText = "Tên loại tiết kiệm";
            if (dgvInterestRates.Columns.Contains("KyHan"))
                dgvInterestRates.Columns["KyHAn"].HeaderText = "Kỳ hạn";
            if (dgvInterestRates.Columns.Contains("LaiSuat"))
                dgvInterestRates.Columns["LaiSuat"].HeaderText = "Lãi suất";

            //Tự động đánh số thứ tự
            dgvInterestRates.RowPostPaint += (sender, e) =>
            {
                var grid = sender as DataGridView;
                if (grid == null) return;

                var rowIdx = (e.RowIndex + 1).ToString();
                var centerFormat = new StringFormat()
                {
                    Alignment = StringAlignment.Center,
                    LineAlignment = StringAlignment.Center
                };

                var headerBounds = new Rectangle(
                    e.RowBounds.Left,
                    e.RowBounds.Top,
                    grid.RowHeadersWidth,
                    e.RowBounds.Height);
                e.Graphics.DrawString(
                    rowIdx,
                    grid.Font,
                    SystemBrushes.ControlText,
                    headerBounds,
                    centerFormat);


                //Không cho phép chỉnh sửa trên bảng dữ liệu
                dgvInterestRates.ReadOnly = true;
                dgvInterestRates.AllowUserToAddRows = false;
                dgvInterestRates.AllowUserToDeleteRows = false;
                dgvInterestRates.EditMode = DataGridViewEditMode.EditProgrammatically;
            };

            dgvInterestRates.AllowUserToAddRows = false;
        }

        private void ActivateButton(object senderBtn, System.Drawing.Color color)
        {
            if (senderBtn != null)
            {
                DisableButton();
                currentBtn = (Button)senderBtn;
                currentBtn.BackColor = System.Drawing.Color.FromArgb(37, 96, 81);
                currentBtn.ForeColor = color;
                currentBtn.TextAlign = ContentAlignment.MiddleCenter;
            }
        }

        private struct RGBColors
        {
            public static System.Drawing.Color color1 = System.Drawing.Color.FromArgb(172, 126, 241);
            public static System.Drawing.Color color2 = System.Drawing.Color.FromArgb(249, 118, 176);
            public static System.Drawing.Color color3 = System.Drawing.Color.FromArgb(253, 138, 114);
        }

        private void DisableButton()
        {
            if (currentBtn != null)
            {
                currentBtn.BackColor = System.Drawing.Color.FromArgb(31, 30, 68);
                currentBtn.ForeColor = System.Drawing.Color.Gainsboro;
                currentBtn.TextAlign = ContentAlignment.MiddleLeft;
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void btnThemLTK_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBColors.color1);

            // Kiểm tra dữ liệu đầu vào
            if (!ValidateInputForAdd())
                return;

            // Hiển thị hộp thoại xác nhận
            DialogResult result = MessageBox.Show(
                "Bạn chắc chắn muốn thêm loại tiết kiệm: " + txtMaLoaiTK.Text.Trim() + "?",
                "Xác nhận thêm",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            // Nếu người dùng chọn "Yes"
            if (result == DialogResult.Yes)
            {
                // Lấy giá trị kỳ hạn
                int kyHan = int.Parse(txtKyHan.Text.Trim());

                // Lấy giá trị lãi suất
                decimal laiSuat = decimal.Parse(txtNewRate.Text.Trim());

                // Gọi phương thức AddLoaiTietKiem
                var (ketQua, thongBao) = interestRateManagement.AddLoaiTietKiem(
                    txtMaLoaiTK.Text.Trim(),
                    txtTenLoaiTK.Text.Trim(),
                    kyHan,
                    laiSuat
                );

                // Hiển thị thông báo
                ShowNotification(thongBao, ketQua);

                // Nếu thêm thành công, làm mới dữ liệu (giả sử bạn có hàm LoadLoaiTietKiem)
                if (ketQua == 1)
                {
                    LoadInterestRates();
                    ShowNotification(thongBao, ketQua);
                }
            }
        }

        private void btnXoaLTK_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBColors.color2);

            // Kiểm tra dữ liệu đầu vào
            if (!ValidateInputForDelete())
                return;

            // Hiển thị hộp thoại xác nhận
            DialogResult result = MessageBox.Show(
                "Bạn chắc chắn muốn xóa loại tiết kiệm: " + txtMaLoaiTK.Text.Trim() + "?",
                "Xác nhận xóa",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning
            );

            // Nếu người dùng chọn "Yes"
            if (result == DialogResult.Yes)
            {
                // Gọi phương thức DeleteLoaiTietKiem
                (int ketQua, string thongBao) = interestRateManagement.DeleteLoaiTietKiem(txtMaLoaiTK.Text.Trim());

                // Hiển thị thông báo
                ShowNotification(thongBao, ketQua);

                // Nếu xóa thành công, làm mới dữ liệu
                if (ketQua == 1)
                {
                    LoadInterestRates();
                    ShowNotification(thongBao, ketQua);
                }
            }
        }

        private void lblMessage_Click(object sender, EventArgs e)
        {

        }

        private void btnSearches_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBColors.color3);

            int kyHan = 0;
            
            // Gọi phương thức SearchInterestRates để tìm kiếm loại tiết kiệm
            DataTable searchResults = interestRateManagement.SearchInterestRates(
                txtMaLoaiTK.Text.Trim(),
                txtTenLoaiTK.Text.Trim(),
                kyHan,
                txtNewRate.Text.Trim()
            );

            // Hiển thị kết quả tìm kiếm trong DataGridView
            dgvInterestRates.DataSource = searchResults;

            // Hiển thị thông báo
            if (searchResults == null || searchResults.Rows.Count == 0)
            {
                MessageBox.Show("Không tìm thấy loại tiết kiệm nào khớp với tiêu chí!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show($"Tìm thấy {searchResults.Rows.Count} loại tiết kiệm!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
