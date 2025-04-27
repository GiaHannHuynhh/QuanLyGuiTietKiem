using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Channels;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyGuiTietKiem
{
    public partial class BranchManagementForm: Form
    {
        private BranchManagement branchManagement;
        private DataTable branchesTable;
        private System.Windows.Forms.Button currentBtn;
        public BranchManagementForm()
        {
            InitializeComponent();
            this.Text = string.Empty;
            this.DoubleBuffered = true;

            branchManagement = new BranchManagement();
            dgvBranches.Resize += (s, e) => AdjustDataGridView();
            LoadBranches();
        }

        private void LoadBranches()
        {
            try
            {
                branchesTable = branchManagement.GetAllBranches();
                dgvBranches.DataSource = branchesTable;
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

        private void ClearFields()
        {
            txtMaCN.Text = "";
            txtTenCN.Text = "";
            txtDiaChi.Text = "";
            txtMaCN.Enabled = true;
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

        private bool ValidateInput()
        {
            if (string.IsNullOrWhiteSpace(txtMaCN.Text))
            {
                ShowNotification("Mã chi nhánh không được để trống!", 0);
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtTenCN.Text))
            {
                ShowNotification("Tên chi nhánh không được để trống!", 0);
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtDiaChi.Text))
            {
                ShowNotification("Địa chỉ không được để trống!", 0);
                return false;
            }

            return true;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBColors.color1);

            if (!ValidateInput())
                return;

            DialogResult result = MessageBox.Show(
               "Bạn chắc chắn muốn thêm chi nhánh: " + txtMaCN.Text.Trim() + "?",
               "Xác nhận thêm",
               MessageBoxButtons.YesNo,
               MessageBoxIcon.Question
            );

            if (result == DialogResult.Yes)
            {
                var (ketQua, thongBao) = branchManagement.AddBranch(txtMaCN.Text.Trim(), txtTenCN.Text.Trim(), txtDiaChi.Text.Trim());
                ShowNotification(thongBao, ketQua);

                if (ketQua == 1)
                {
                    LoadBranches();
                    ShowNotification(thongBao, ketQua);
                }
            }
            }


        private void btnUpdate_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBColors.color2);
            if (!ValidateInput())
                return;

            DialogResult result = MessageBox.Show(
               "Bạn chắc chắn muốn sửa thông tin chi nhánh " + txtMaCN.Text.Trim() + "?",
               "Xác nhận sửa",
               MessageBoxButtons.YesNo,
               MessageBoxIcon.Question
            );

            if (result == DialogResult.Yes)
            {
                var (ketQua, thongBao) = branchManagement.UpdateBranch(txtMaCN.Text.Trim(), txtTenCN.Text.Trim(), txtDiaChi.Text.Trim());
                ShowNotification(thongBao, ketQua);

                if (ketQua == 1)
                {
                    LoadBranches();
                    ShowNotification(thongBao, ketQua);
                }
            }

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBColors.color3);

            if (string.IsNullOrWhiteSpace(txtMaCN.Text))
            {
                ShowNotification("Vui lòng chọn chi nhánh cần xóa!", 0);
                return;
            }

            DialogResult result = MessageBox.Show(
                "Bạn có chắc chắn muốn xóa chi nhánh " + txtMaCN.Text.Trim() + "?",
                "Xác nhận xóa",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (result == DialogResult.Yes)
            {
                var (ketQua, thongBao) = branchManagement.DeleteBranch(txtMaCN.Text.Trim());
                ShowNotification(thongBao, ketQua);

                if (ketQua == 1)
                {
                    LoadBranches();
                    ShowNotification(thongBao, ketQua);
                }
            }
        }

        private void dgvBranches_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvBranches.Rows[e.RowIndex];
                txtMaCN.Text = row.Cells["MaCN"].Value.ToString();
                txtTenCN.Text = row.Cells["TenCN"].Value.ToString();
                txtDiaChi.Text = row.Cells["DiaChi"].Value.ToString();
                txtMaCN.Enabled = false;
                HideNotification();
            }

        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearFields();
            HideNotification();
            LoadBranches();
        }

        private void BranchManagementForm_Load(object sender, EventArgs e)
        {
            AdjustDataGridView();
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

        private void AdjustDataGridView()
        {
            if (dgvBranches.Columns.Count == 0 || dgvBranches.Rows.Count == 0)
                return;

            // Thiết lập xuống dòng
            DataGridViewCellStyle wrapStyle = new DataGridViewCellStyle();
            wrapStyle.WrapMode = DataGridViewTriState.True;
            dgvBranches.DefaultCellStyle = wrapStyle;

            // Đảm bảo các cột điền đầy DataGridView
            dgvBranches.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            // Điều chỉnh hàng
            AdjustRowHeights();
        }

        private void AdjustRowHeights()
        {
            dgvBranches.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;

            // Tính toán lại chiều cao cho từng hàng
            foreach (DataGridViewRow row in dgvBranches.Rows)
            {
                row.Height = row.GetPreferredHeight(row.Index, DataGridViewAutoSizeRowMode.AllCells, true);
            }
        }

        private void ConfigureDataGridView()
        {
            // 1. Đổi tên cột sang tiếng Việt có dấu
            if (dgvBranches.Columns.Contains("MaCN"))
                dgvBranches.Columns["MaCN"].HeaderText = "Mã CN";
            if (dgvBranches.Columns.Contains("TenCN"))
                dgvBranches.Columns["TenCN"].HeaderText = "Tên Chi Nhánh";
            if (dgvBranches.Columns.Contains("DiaChi"))
                dgvBranches.Columns["DiaChi"].HeaderText = "Địa Chỉ";

            //Tự động đánh số thứ tự
            dgvBranches.RowPostPaint += (sender, e) =>
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
                dgvBranches.ReadOnly = true;
                dgvBranches.AllowUserToAddRows = false;
                dgvBranches.AllowUserToDeleteRows = false;
                dgvBranches.EditMode = DataGridViewEditMode.EditProgrammatically;
            };
        }


        private void label1_Click(object sender, EventArgs e) { }

        private void label2_Click(object sender, EventArgs e) { }

        private void label3_Click(object sender, EventArgs e) { }

        private void lblMessage_Click(object sender, EventArgs e) { }

        private void panelLogo_Paint(object sender, PaintEventArgs e) {}

        private void panelMenu_Paint(object sender, PaintEventArgs e) {}

        private void txtMaCN_TextChanged(object sender, EventArgs e) {}

        private void btnSearches_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBColors.color3);

            // Gọi phương thức SearchBranches để tìm kiếm chi nhánh
            DataTable searchResults = branchManagement.SearchBranches(
                txtMaCN.Text.Trim(),
                txtTenCN.Text.Trim(),
                txtDiaChi.Text.Trim()
            );

            // Hiển thị kết quả tìm kiếm trong DataGridView
            dgvBranches.DataSource = searchResults;

            // Hiển thị thông báo
            if (searchResults == null || searchResults.Rows.Count == 0)
            {
                ShowNotification("Không tìm thấy chi nhánh nào khớp với tiêu chí!", 0);
            }
            else
            {
                ShowNotification($"Tìm thấy {searchResults.Rows.Count} chi nhánh!", 1);
            }
        }
    }
}
