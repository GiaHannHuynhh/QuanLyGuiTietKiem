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

        public InterestRateManagementForm()
        {
            InitializeComponent();
            // Khởi tạo InterestRateManagement với chuỗi kết nối
            interestRateManagement = new InterestRateManagement();
            dgvInterestRates.Resize += (s, e) => AdjustDataGridView();
            LoadInterestRates();
            ConfigureDataGridView();
        }

        private void InterestRateManagementForm_Load(object sender, EventArgs e)
        {
            LoadInterestRates();
            SetupNumericValidation();
        }

        private void btnUpdateRate_Click(object sender, EventArgs e)
        {
            // Kiểm tra dữ liệu đầu vào trước
            if (!ValidateInput())
            {
                return;
            }
            
            string maLoaiTK = txtMaLoaiTK.Text;

            // Lấy giá trị lãi suất mới (đã được validate trong ValidateInput)
            decimal laiSuatMoi = decimal.Parse(txtNewRate.Text, NumberStyles.Any, CultureInfo.InvariantCulture);
            // Làm tròn lãi suất mới đến 2 chữ số thập phân
            laiSuatMoi = Math.Round(laiSuatMoi, 2);

            try
            {
                // Gọi phương thức cập nhật lãi suất
                var (ketQua, thongBao) = interestRateManagement.UpdateInterestRate(maLoaiTK, laiSuatMoi, currentUserId);

                // Hiển thị thông báo từ SQL
                ShowNotification(thongBao, ketQua == 0);

                // Nếu cập nhật thành công, làm mới DataGridView
                if (ketQua == 1)
                {
                    LoadInterestRates();
                    ClearFields();
                }
            }
            catch (Exception ex)
            {
                ShowNotification("Lỗi khi cập nhật lãi suất: " + ex.Message, true);
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearFields();
            HideNotification();
        }

        private void dgvInterestRates_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvInterestRates.Rows[e.RowIndex];
                txtMaLoaiTK.Text = row.Cells["MaLoaiTK"].Value.ToString();
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
            txtNewRate.Text = "";
            lblMessage.Visible = false;
        }

        private void LoadInterestRates()
        {
            try
            {
                DataTable dataTable = interestRateManagement.GetAllInterestRates();
                dgvInterestRates.DataSource = dataTable;
            }
            catch (Exception ex)
            {
                lblMessage.Text = "Lỗi khi tải danh sách loại tiết kiệm: " + ex.Message;
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

        private void ShowNotification(string message, bool isError = false)
        {
            lblMessage.Text = message;
            lblMessage.ForeColor = isError ? System.Drawing.Color.Red : System.Drawing.Color.Green;
            lblMessage.Visible = true;
        }

        private void HideNotification()
        {
            lblMessage.Visible = false;
        }

        private bool ValidateInput()
        {
            if (string.IsNullOrWhiteSpace(txtMaLoaiTK.Text))
            {
                ShowNotification("Vui lòng nhập mã loại tiết kiệm!", true);
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtNewRate.Text))
            {
                ShowNotification("Vui lòng nhập lãi suất mới!", true);
                return false;
            }

            decimal newRate;
            if (!decimal.TryParse(txtNewRate.Text, NumberStyles.Any, CultureInfo.InvariantCulture, out newRate))
            {
                ShowNotification("Lãi suất phải là số thập phân hợp lệ!", true);
                return false;
            }

            if (newRate < 0 || newRate > 100)
            {
                ShowNotification("Lãi suất phải nằm trong khoảng từ 0% đến 100%!", true);
                return false;
            }

            return true;
        }

        private void AdjustDataGridView()
        {
            if (dgvInterestRates.Columns.Count == 0 || dgvInterestRates.Rows.Count == 0)
                return;

            
            // Tính toán kích thước
            int totalWidth = dgvInterestRates.ClientSize.Width - SystemInformation.VerticalScrollBarWidth;

            // Đặt tỷ lệ cột
            if (dgvInterestRates.Columns.Contains("MaLoaiTK"))
                dgvInterestRates.Columns["MaLoaiTK"].Width = (int)(totalWidth * 0.15);
            if (dgvInterestRates.Columns.Contains("TenLoaiTK"))
                dgvInterestRates.Columns["TenLoaiTK"].Width = (int)(totalWidth * 0.7);
            if (dgvInterestRates.Columns.Contains("LaiSuat"))
                dgvInterestRates.Columns["LaiSuat"].Width = (int)(totalWidth * 0.15);

        }
        private void ConfigureDataGridView()
        {
            // 1. Đổi tên cột sang tiếng Việt có dấu
            if (dgvInterestRates.Columns.Contains("MaLoaiTK"))
                dgvInterestRates.Columns["MaLoaiTK"].HeaderText = "Mã LTK";
            if (dgvInterestRates.Columns.Contains("TenLoaiTK"))
                dgvInterestRates.Columns["TenLoaiTK"].HeaderText = "Tên loại tiết kiệm";
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

                dgvInterestRates.RowHeadersWidth = (int)(dgvInterestRates.Width * 0.05);

                //Không cho phép chỉnh sửa trên bảng dữ liệu
                dgvInterestRates.ReadOnly = true;
                dgvInterestRates.AllowUserToAddRows = false;
                dgvInterestRates.AllowUserToDeleteRows = false;
                dgvInterestRates.EditMode = DataGridViewEditMode.EditProgrammatically;
            };

            dgvInterestRates.AllowUserToAddRows = false;
        }
    }
}
