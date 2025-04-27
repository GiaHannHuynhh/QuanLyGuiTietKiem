using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyGuiTietKiem
{
    public class InterestRateManagement
    {
        private string connectionString;

        public InterestRateManagement()
        {
            connectionString = ConfigurationManager.ConnectionStrings["QuanLyGuiTietKiemConnection"].ConnectionString;
        }

        // Get all interest rates
        public DataTable GetAllInterestRates()
        {
            DataTable dataTable = new DataTable();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand("sp_DanhSachLoaiTietKiem", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        SqlDataAdapter adapter = new SqlDataAdapter(command);
                        adapter.Fill(dataTable);
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("Lỗi khi lấy danh sách loại tiết kiệm: " + ex.Message);
                }
            }
            return dataTable;
        }

        public (int ketQua, string thongBao) AddLoaiTietKiem(string maLoaiTK, string tenLoaiTK, int kyHan, decimal laiSuat)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand("sp_ThemLoaiTietKiem", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        // Thêm các tham số đầu vào
                        command.Parameters.AddWithValue("@MaLoaiTK", maLoaiTK);
                        command.Parameters.AddWithValue("@TenLoaiTK", tenLoaiTK);
                        command.Parameters.AddWithValue("@KyHan", kyHan);
                        command.Parameters.AddWithValue("@LaiSuat", laiSuat);

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
                    return (0, "Lỗi khi thêm loại tiết kiệm: " + ex.Message);
                }
            }
        }

        public (int KetQua, string ThongBao) DeleteLoaiTietKiem(string maLoaiTK)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand("sp_XoaLoaiTietKiem", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        // Thêm tham số đầu vào
                        command.Parameters.AddWithValue("@MaLoaiTK", maLoaiTK);

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
                    return (0, "Lỗi khi xóa loại tiết kiệm: " + ex.Message);
                }
            }
        }

        public (int KetQua, string ThongBao) UpdateInterestRate(string maLoaiTK, decimal laiSuatMoi, string nguoiThayDoi)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand cmd = new SqlCommand("sp_CapNhatLaiSuat", connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    // Thêm các tham số đầu vào
                    cmd.Parameters.AddWithValue("@MaLoaiTK", maLoaiTK);
                    cmd.Parameters.AddWithValue("@LaiSuatMoi", laiSuatMoi);
                    cmd.Parameters.AddWithValue("@NguoiThayDoi", nguoiThayDoi);

                    // Thêm các tham số đầu ra
                    SqlParameter ketQuaParam = new SqlParameter("@KetQua", SqlDbType.Int)
                    {
                        Direction = ParameterDirection.Output
                    };
                    SqlParameter thongBaoParam = new SqlParameter("@ThongBao", SqlDbType.NVarChar, 200)
                    {
                        Direction = ParameterDirection.Output
                    };
                    cmd.Parameters.Add(ketQuaParam);
                    cmd.Parameters.Add(thongBaoParam);

                    // Thực thi stored procedure
                    cmd.ExecuteNonQuery();

                    // Lấy kết quả và thông báo
                    int ketQua = Convert.ToInt32(ketQuaParam.Value);
                    string thongBao = thongBaoParam.Value.ToString();

                    return (ketQua, thongBao);
                }
            }
        }

        public DataTable SearchInterestRates(string maLoaiTK, string tenLoaiTK, int kyHan, string laiSuat)
        {
            DataTable dataTable = new DataTable();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string query = "SELECT * FROM fn_TimKiemLoaiTietKiem(@MaLoaiTK, @TenLoaiTK, @KyHan, @LaiSuat)";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        // Thêm các tham số đầu vào
                        command.Parameters.AddWithValue("@MaLoaiTK", string.IsNullOrWhiteSpace(maLoaiTK) ? (object)DBNull.Value : maLoaiTK);
                        command.Parameters.AddWithValue("@TenLoaiTK", string.IsNullOrWhiteSpace(tenLoaiTK) ? (object)DBNull.Value : tenLoaiTK);
                        command.Parameters.AddWithValue("@KyHan", kyHan == 0 ? (object)DBNull.Value : kyHan);
                        command.Parameters.AddWithValue("@LaiSuat", string.IsNullOrWhiteSpace(laiSuat) ? (object)DBNull.Value : Convert.ToDouble(laiSuat));

                        // Sử dụng SqlDataAdapter để lấy dữ liệu
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
