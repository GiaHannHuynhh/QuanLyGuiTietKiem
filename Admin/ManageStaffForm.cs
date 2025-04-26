using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyGuiTietKiem
{
    public partial class ManageStaffForm: Form
    {
        private string connectionString = ConfigurationManager.ConnectionStrings["QuanLyGuiTietKiemConnection"].ConnectionString;
      
        public ManageStaffForm()
        {
            InitializeComponent();
            DisplayStaffID();
            LoadEmployees();
        }

        private void DisplayStaffID()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("sp_SinhMaTuDong", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Prefix", "NV");
                cmd.Parameters.AddWithValue("@TableName", "NHAN_VIEN");
                cmd.Parameters.AddWithValue("@ColumnName", "MaNV");
                SqlParameter newIdParam = new SqlParameter("@NewID", SqlDbType.VarChar, 20)
                {
                    Direction = ParameterDirection.Output
                };
                cmd.Parameters.Add(newIdParam);

                cmd.ExecuteNonQuery();

                string maNV = newIdParam.Value.ToString();
                txtMaNV.Text = maNV;
            }
        }

        private void LoadEmployees()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("sp_TimKiemNhanVien", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@MaNV", DBNull.Value);
                cmd.Parameters.AddWithValue("@HoTen", DBNull.Value);
                cmd.Parameters.AddWithValue("@MaSoCCCD", DBNull.Value);
                cmd.Parameters.AddWithValue("@ChucVu", DBNull.Value);
                cmd.Parameters.AddWithValue("@MaCN", DBNull.Value);
                cmd.Parameters.AddWithValue("@TinhTrang", "Đang làm việc");

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adapter.Fill(dt);

                dgvEmployees.DataSource = dt;

                if (dgvEmployees.Columns["MaNV"] != null) dgvEmployees.Columns["MaNV"].HeaderText = "Mã nhân viên";
                if (dgvEmployees.Columns["HoTen"] != null) dgvEmployees.Columns["HoTen"].HeaderText = "Họ tên";
                if (dgvEmployees.Columns["NgaySinh"] != null) dgvEmployees.Columns["NgaySinh"].HeaderText = "Ngày sinh";
                if (dgvEmployees.Columns["SDT"] != null) dgvEmployees.Columns["SDT"].HeaderText = "Số điện thoại";
                if (dgvEmployees.Columns["DiaChi"] != null) dgvEmployees.Columns["DiaChi"].HeaderText = "Địa chỉ";
                if (dgvEmployees.Columns["ChucVu"] != null) dgvEmployees.Columns["ChucVu"].HeaderText = "Chức vụ";
                if (dgvEmployees.Columns["TinhTrang"] != null) dgvEmployees.Columns["TinhTrang"].HeaderText = "Tình trạng";
                if (dgvEmployees.Columns["MaCN"] != null) dgvEmployees.Columns["MaCN"].HeaderText = "Mã chi nhánh";
                if (dgvEmployees.Columns["TenCN"] != null) dgvEmployees.Columns["TenCN"].HeaderText = "Tên chi nhánh";

                // Gán sự kiện SelectionChanged để tự động điền thông tin khi chọn hàng
                dgvEmployees.SelectionChanged += (s, e) =>
                {
                    if (dgvEmployees.SelectedRows.Count > 0)
                    {
                        var row = dgvEmployees.SelectedRows[0];
                        txtMaNV.Text = row.Cells["MaNV"].Value?.ToString();
                        txtHoTen.Text = row.Cells["HoTen"].Value?.ToString();
                        dtpNgaySinh.Value = Convert.ToDateTime(row.Cells["NgaySinh"].Value);
                        txtCCCD.Text = GetMaSoCCCD(txtMaNV.Text);
                        dtpNgayCap.Value = GetNgayCap(txtMaNV.Text);
                        txtSDT.Text = row.Cells["SDT"].Value?.ToString();
                        richtxtDiaChi.Text = row.Cells["DiaChi"].Value?.ToString();
                        txtChucVu.Text = row.Cells["ChucVu"].Value?.ToString();
                        txtMaCN.Text = row.Cells["MaCN"].Value?.ToString();
                        txtUsername.Text = "";
                        txtPassword.Text = "";
                    }
                };

                // Gán sự kiện KeyDown để hỗ trợ xóa bằng phím Delete
                dgvEmployees.KeyDown += (s, e) =>
                {
                    if (e.KeyCode == Keys.Delete && dgvEmployees.SelectedRows.Count > 0)
                    {
                        DeleteEmployee();
                        LoadEmployees();
                    }
                };
            }
        }

        private void AddEmployee()
        {
            if (string.IsNullOrWhiteSpace(txtHoTen.Text) ||
                 string.IsNullOrWhiteSpace(txtCCCD.Text) || string.IsNullOrWhiteSpace(txtSDT.Text) ||
                 string.IsNullOrWhiteSpace(richtxtDiaChi.Text) || string.IsNullOrWhiteSpace(txtChucVu.Text) ||
                 string.IsNullOrWhiteSpace(txtMaCN.Text) || string.IsNullOrWhiteSpace(txtUsername.Text) ||
                 string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            ProgressForm.ShowProgress(this, () =>
            {
                try
                {
                    using (SqlConnection conn = new SqlConnection(connectionString))
                    {
                        conn.Open();
                        SqlCommand cmd = new SqlCommand("sp_ThemNhanVienVoiTaiKhoan", conn);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@HoTen", txtHoTen.Text);
                        cmd.Parameters.AddWithValue("@NgaySinh", dtpNgaySinh.Value);
                        cmd.Parameters.AddWithValue("@MaSoCCCD", txtCCCD.Text);
                        cmd.Parameters.AddWithValue("@NgayCap", dtpNgayCap.Value);
                        cmd.Parameters.AddWithValue("@SDT", txtSDT.Text);
                        cmd.Parameters.AddWithValue("@DiaChi", richtxtDiaChi.Text);
                        cmd.Parameters.AddWithValue("@ChucVu", txtChucVu.Text);
                        cmd.Parameters.AddWithValue("@MaCN", txtMaCN.Text);
                        cmd.Parameters.AddWithValue("@TenDangNhap", txtUsername.Text);
                        cmd.Parameters.AddWithValue("@MatKhau", txtPassword.Text);
                        cmd.Parameters.AddWithValue("@TenDangNhapAdmin", UserSession.Username);
                        cmd.Parameters.Add("@MaNV", SqlDbType.VarChar, 10).Direction = ParameterDirection.Output;
                        cmd.Parameters.Add("@KetQua", SqlDbType.Bit).Direction = ParameterDirection.Output;
                        cmd.Parameters.Add("@ThongBao", SqlDbType.NVarChar, 255).Direction = ParameterDirection.Output;

                        cmd.ExecuteNonQuery();

                        bool ketQua = (bool)cmd.Parameters["@KetQua"].Value;
                        string thongBao = cmd.Parameters["@ThongBao"].Value.ToString();

                        MessageBox.Show(thongBao, "Thông báo", MessageBoxButtons.OK, ketQua ? MessageBoxIcon.Information : MessageBoxIcon.Error);

                        if (ketQua)
                        {
                            DisplayStaffID(); // Sửa tên phương thức gọi đúng
                            txtHoTen.Text = "";
                            txtCCCD.Text = "";
                            txtSDT.Text = "";
                            richtxtDiaChi.Text = "";
                            txtChucVu.Text = "";
                            txtMaCN.Text = "";
                            txtUsername.Text = "";
                            txtPassword.Text = "";
                            dtpNgaySinh.Value = DateTime.Now;
                            dtpNgayCap.Value = DateTime.Now;
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            });
        }


        private void UpdateEmployee()
        {
            if (string.IsNullOrWhiteSpace(txtMaNV.Text))
            {
                MessageBox.Show("Vui lòng chọn nhân viên để sửa!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            ProgressForm.ShowProgress(this, () =>
            {
                try
                {
                    using (SqlConnection conn = new SqlConnection(connectionString))
                    {
                        conn.Open();
                        SqlCommand cmd = new SqlCommand("sp_CapNhatNhanVien", conn);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@MaNV", txtMaNV.Text);
                        cmd.Parameters.AddWithValue("@HoTen", txtHoTen.Text);
                        cmd.Parameters.AddWithValue("@NgaySinh", dtpNgaySinh.Value);
                        cmd.Parameters.AddWithValue("@SDT", txtSDT.Text);
                        cmd.Parameters.AddWithValue("@DiaChi", richtxtDiaChi.Text);
                        cmd.Parameters.AddWithValue("@ChucVu", txtChucVu.Text);
                        cmd.Parameters.AddWithValue("@MaCN", txtMaCN.Text);
                        cmd.Parameters.AddWithValue("@TenDangNhapAdmin", UserSession.Username);
                        cmd.Parameters.Add("@KetQua", SqlDbType.Bit).Direction = ParameterDirection.Output;
                        cmd.Parameters.Add("@ThongBao", SqlDbType.NVarChar, 255).Direction = ParameterDirection.Output;

                        cmd.ExecuteNonQuery();

                        bool ketQua = (bool)cmd.Parameters["@KetQua"].Value;
                        string thongBao = cmd.Parameters["@ThongBao"].Value.ToString();

                        MessageBox.Show(thongBao, "Thông báo", MessageBoxButtons.OK, ketQua ? MessageBoxIcon.Information : MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            });
        }

        private void DeleteEmployee()
        {
            if (dgvEmployees.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn nhân viên để đặt trạng thái nghỉ việc!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string maNV = dgvEmployees.SelectedRows[0].Cells["MaNV"].Value.ToString();
            string hoTen = dgvEmployees.SelectedRows[0].Cells["HoTen"].Value.ToString();

            DialogResult result = MessageBox.Show($"Bạn có chắc chắn muốn đặt trạng thái nhân viên '{hoTen}' thành nghỉ việc không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                ProgressForm.ShowProgress(this, () =>
                {
                    try
                    {
                        using (SqlConnection conn = new SqlConnection(connectionString))
                        {
                            conn.Open();
                            SqlCommand cmd = new SqlCommand("sp_XoaNhanVien", conn);
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.AddWithValue("@MaNV", maNV);
                            cmd.Parameters.AddWithValue("@TenDangNhapAdmin", UserSession.Username);
                            cmd.Parameters.Add("@KetQua", SqlDbType.Bit).Direction = ParameterDirection.Output;
                            cmd.Parameters.Add("@ThongBao", SqlDbType.NVarChar, 255).Direction = ParameterDirection.Output;

                            cmd.ExecuteNonQuery();

                            bool ketQua = (bool)cmd.Parameters["@KetQua"].Value;
                            string thongBao = cmd.Parameters["@ThongBao"].Value.ToString();

                            MessageBox.Show(thongBao, "Thông báo", MessageBoxButtons.OK, ketQua ? MessageBoxIcon.Information : MessageBoxIcon.Error);

                            if (ketQua)
                            {
                                DisplayStaffID(); // Hiển thị mã nhân viên mới sau khi xóa
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                });
            }
        }

        private string GetMaSoCCCD(string maNV)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT MaSoCCCD FROM MA_DINH_DANH WHERE MaNV = @MaNV", conn);
                cmd.Parameters.AddWithValue("@MaNV", maNV);
                object result = cmd.ExecuteScalar();
                return result?.ToString() ?? "";
            }
        }

        private DateTime GetNgayCap(string maNV)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT NgayCap FROM MA_DINH_DANH WHERE MaNV = @MaNV", conn);
                cmd.Parameters.AddWithValue("@MaNV", maNV);
                object result = cmd.ExecuteScalar();
                return result != null ? Convert.ToDateTime(result) : DateTime.Now;
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            AddEmployee();
            LoadEmployees();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            UpdateEmployee();
            LoadEmployees();
        }

        private void btnResign_Click(object sender, EventArgs e)
        {
            DeleteEmployee();
            LoadEmployees();
        }
    }
}
