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
    public partial class BranchManagementForm: Form
    {
        private BranchManagement branchManagement;
        private DataTable branchesTable;
        public BranchManagementForm()
        {
            InitializeComponent();
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
                ShowNotification(ex.Message, true);
            }
        }

        private void ClearFields()
        {
            txtMaCN.Text = "";
            txtTenCN.Text = "";
            txtDiaChi.Text = "";
            txtMaCN.Enabled = true;
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
            if (string.IsNullOrWhiteSpace(txtMaCN.Text))
            {
                ShowNotification("Mã chi nhánh không được để trống!", true);
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtTenCN.Text))
            {
                ShowNotification("Tên chi nhánh không được để trống!", true);
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtDiaChi.Text))
            {
                ShowNotification("Địa chỉ không được để trống!", true);
                return false;
            }

            return true;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (!ValidateInput())
                return;

            var (ketQua, thongBao) = branchManagement.AddBranch(txtMaCN.Text.Trim(), txtTenCN.Text.Trim(), txtDiaChi.Text.Trim());
            ShowNotification(thongBao, ketQua == 0);

            if (ketQua == 1)
            {
                LoadBranches();
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (!ValidateInput())
                return;

            var (ketQua, thongBao) = branchManagement.UpdateBranch(txtMaCN.Text.Trim(), txtTenCN.Text.Trim(), txtDiaChi.Text.Trim());
            ShowNotification(thongBao, ketQua == 0);

            if (ketQua == 1)
            {
                LoadBranches();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMaCN.Text))
            {
                ShowNotification("Vui lòng chọn chi nhánh cần xóa!", true);
                return;
            }

            DialogResult result = MessageBox.Show(
                "Bạn có chắc chắn muốn xóa chi nhánh này?",
                "Xác nhận xóa",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (result == DialogResult.Yes)
            {
                var (ketQua, thongBao) = branchManagement.DeleteBranch(txtMaCN.Text.Trim());
                ShowNotification(thongBao, ketQua == 0);

                if (ketQua == 1)
                {
                    LoadBranches();
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
            dgvBranches.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
            dgvBranches.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;

        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearFields();
            HideNotification();
        }

        private void BranchManagementForm_Load(object sender, EventArgs e)
        {
            AdjustDataGridView();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void lblMessage_Click(object sender, EventArgs e)
        {

        }
                
        private void AdjustDataGridView()
        {
            if (dgvBranches.Columns.Count == 0 || dgvBranches.Rows.Count == 0)
                return;

            // Thiết lập xuống dòng
            DataGridViewCellStyle wrapStyle = new DataGridViewCellStyle();
            wrapStyle.WrapMode = DataGridViewTriState.True;
            dgvBranches.DefaultCellStyle = wrapStyle;

            // Tính toán kích thước
            int totalWidth = dgvBranches.ClientSize.Width - SystemInformation.VerticalScrollBarWidth;

            // Đặt tỷ lệ cột (20%-40%-40%)
            if (dgvBranches.Columns.Contains("MaCN"))
                dgvBranches.Columns["MaCN"].Width = (int)(totalWidth * 0.15);
            if (dgvBranches.Columns.Contains("TenCN"))
                dgvBranches.Columns["TenCN"].Width = (int)(totalWidth * 0.3);
            if (dgvBranches.Columns.Contains("DiaChi"))
                dgvBranches.Columns["DiaChi"].Width = (int)(totalWidth * 0.55);

            // Điều chỉnh hàng
            AdjustRowHeights();
        }

        private void BranchManagementForm_Resize(object sender, EventArgs e)
        {
            AdjustDataGridView();
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

                dgvBranches.RowHeadersWidth = (int)(dgvBranches.Width * 0.05);

                //Không cho phép chỉnh sửa trên bảng dữ liệu
                dgvBranches.ReadOnly = true;
            dgvBranches.AllowUserToAddRows = false;
            dgvBranches.AllowUserToDeleteRows = false;
            dgvBranches.EditMode = DataGridViewEditMode.EditProgrammatically;
            };

            dgvBranches.AllowUserToAddRows = false;
        }
    }
}
