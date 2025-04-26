using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

public class DB_Connect
{
    private readonly string connectionString;

    public DB_Connect()
    {
        connectionString = ConfigurationManager.ConnectionStrings["QuanLyGuiTietKiemConnection"].ConnectionString;
    }

    public void CreateRoles()
    {
        try
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand("sp_CreateRoles", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.ExecuteNonQuery();
                    Console.WriteLine("Tạo role thành công!");
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Lỗi khi tạo role: " + ex.Message);
        }
    }

    public void CreateLoginAndUser(string tenDangNhap, string matKhau, string vaiTro, out bool ketQua, out string thongBao)
    {
        ketQua = false;
        thongBao = string.Empty;

        try
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand("sp_CreateLoginAndUser", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@TenDangNhap", tenDangNhap);
                    cmd.Parameters.AddWithValue("@MatKhau", matKhau);
                    cmd.Parameters.AddWithValue("@VaiTro", vaiTro);

                    SqlParameter ketQuaParam = new SqlParameter("@KetQua", SqlDbType.Bit) { Direction = ParameterDirection.Output };
                    SqlParameter thongBaoParam = new SqlParameter("@ThongBao", SqlDbType.NVarChar, 255) { Direction = ParameterDirection.Output };
                    cmd.Parameters.Add(ketQuaParam);
                    cmd.Parameters.Add(thongBaoParam);

                    cmd.ExecuteNonQuery();

                    ketQua = (bool)ketQuaParam.Value;
                    thongBao = thongBaoParam.Value?.ToString() ?? string.Empty;
                }
            }
        }
        catch (Exception ex)
        {
            ketQua = false;
            thongBao = "Lỗi: " + ex.Message;
        }
    }

    public void GrantPermissions()
    {
        try
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand("sp_GrantPermissions", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.ExecuteNonQuery();
                    Console.WriteLine("Cấp quyền thành công!");
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Lỗi khi cấp quyền: " + ex.Message);
        }
    }

    public void RevokePermission(string roleName, string permission, string objectName)
    {
        try
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand("sp_RevokePermissions", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@RoleName", roleName);
                    cmd.Parameters.AddWithValue("@Permission", permission);
                    cmd.Parameters.AddWithValue("@ObjectName", objectName);
                    cmd.ExecuteNonQuery();
                    Console.WriteLine("Thu hồi quyền thành công!");
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Lỗi khi thu hồi quyền: " + ex.Message);
        }
    }
}