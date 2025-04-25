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
                    using (SqlCommand command = new SqlCommand("sp_DanhSachChiNhanh", connection))
                    {
                        SqlDataAdapter adapter = new SqlDataAdapter("SELECT MaLoaiTK, TenLoaiTK, LaiSuat FROM LOAI_TIET_KIEM", connection);
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
    }
}
