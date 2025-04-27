using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace QuanLyGuiTietKiem
{

    public class BranchManagement
    {
        private string connectionString;

        public BranchManagement()
        {
            connectionString = ConfigurationManager.ConnectionStrings["QuanLyGuiTietKiemConnection"].ConnectionString;

        }

        public DataTable GetAllBranches()
        {
            DataTable dataTable = new DataTable();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand("sp_DanhSachChiNhanh", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        SqlDataAdapter adapter = new SqlDataAdapter(command);
                        adapter.Fill(dataTable);
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("Lỗi khi lấy danh sách chi nhánh: " + ex.Message);
                }
            }
            return dataTable;
        }

        public (int KetQua, string ThongBao) AddBranch(string maCN, string tenCN, string diaChi)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand("sp_ThemChiNhanh", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        // Thêm các tham số đầu vào
                        command.Parameters.AddWithValue("@MaCN", maCN);
                        command.Parameters.AddWithValue("@TenCN", tenCN);
                        command.Parameters.AddWithValue("@DiaChi", diaChi);

                        // Thêm các tham số đầu ra
                        SqlParameter ketQuaParam = new SqlParameter("@KetQua", SqlDbType.Int)
                        {
                            Direction = ParameterDirection.Output
                        };
                        SqlParameter thongBaoParam = new SqlParameter("@ThongBao", SqlDbType.NVarChar, 200)
                        {
                            Direction = ParameterDirection.Output
                        };
                        command.Parameters.Add(ketQuaParam);
                        command.Parameters.Add(thongBaoParam);

                        // Thực thi stored procedure
                        command.ExecuteNonQuery();

                        // Lấy kết quả và thông báo
                        int ketQua = Convert.ToInt32(ketQuaParam.Value);
                        string thongBao = thongBaoParam.Value.ToString();

                        return (ketQua, thongBao);
                    }
                }
                catch (Exception ex)
                {
                    return (0, "Lỗi khi thêm chi nhánh: " + ex.Message);
                }
            }
        }

        public (int KetQua, string ThongBao) UpdateBranch(string maCN, string tenCN, string diaChi)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand("sp_CapNhatChiNhanh", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        // Thêm các tham số đầu vào
                        command.Parameters.AddWithValue("@MaCN", maCN);
                        command.Parameters.AddWithValue("@TenCN", tenCN);
                        command.Parameters.AddWithValue("@DiaChi", diaChi);

                        // Thêm các tham số đầu ra
                        SqlParameter ketQuaParam = new SqlParameter("@KetQua", SqlDbType.Int)
                        {
                            Direction = ParameterDirection.Output
                        };
                        SqlParameter thongBaoParam = new SqlParameter("@ThongBao", SqlDbType.NVarChar, 200)
                        {
                            Direction = ParameterDirection.Output
                        };
                        command.Parameters.Add(ketQuaParam);
                        command.Parameters.Add(thongBaoParam);

                        // Thực thi stored procedure
                        command.ExecuteNonQuery();

                        // Lấy kết quả và thông báo
                        int ketQua = Convert.ToInt32(ketQuaParam.Value);
                        string thongBao = thongBaoParam.Value.ToString();

                        return (ketQua, thongBao);
                    }
                }
                catch (Exception ex)
                {
                    return (0, "Lỗi khi cập nhật chi nhánh: " + ex.Message);
                }
            }
        }

        public (int KetQua, string ThongBao) DeleteBranch(string maCN)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand("sp_XoaChiNhanh", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        // Thêm tham số đầu vào
                        command.Parameters.AddWithValue("@MaCN", maCN);

                        // Thêm các tham số đầu ra
                        SqlParameter ketQuaParam = new SqlParameter("@KetQua", SqlDbType.Int)
                        {
                            Direction = ParameterDirection.Output
                        };
                        SqlParameter thongBaoParam = new SqlParameter("@ThongBao", SqlDbType.NVarChar, 200)
                        {
                            Direction = ParameterDirection.Output
                        };
                        command.Parameters.Add(ketQuaParam);
                        command.Parameters.Add(thongBaoParam);

                        // Thực thi stored procedure
                        command.ExecuteNonQuery();

                        // Lấy kết quả và thông báo
                        int ketQua = Convert.ToInt32(ketQuaParam.Value);
                        string thongBao = thongBaoParam.Value.ToString();

                        return (ketQua, thongBao);
                    }
                }
                catch (Exception ex)
                {
                    return (0, "Lỗi khi xóa chi nhánh: " + ex.Message);
                }
            }
        }

        public DataTable SearchBranches(string maCN, string tenCN, string diaChi)
        {
            DataTable dataTable = new DataTable();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string query = "SELECT * FROM fn_TimKiemChiNhanh(@MaCN, @TenCN, @DiaChi)";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@MaCN", string.IsNullOrWhiteSpace(maCN) ? (object)DBNull.Value : maCN);
                        command.Parameters.AddWithValue("@TenCN", string.IsNullOrWhiteSpace(tenCN) ? (object)DBNull.Value : tenCN);
                        command.Parameters.AddWithValue("@DiaChi", string.IsNullOrWhiteSpace(diaChi) ? (object)DBNull.Value : diaChi);

                        using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                        {
                            adapter.Fill(dataTable);
                        }
                    }
                }
                catch (Exception ex)
                {
                    dataTable = null;
                }
            }

            return dataTable;
        }
    }
}
