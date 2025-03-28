using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace QuanLyGuiTietKiem
{
    class DB_Connect
    {
        // Khai báo chuỗi kết nối
        private string connectionString = ConfigurationManager.ConnectionStrings["QuanLyGuiTietKiemConnection"].ConnectionString;        //Khai báo đối tượng kết nối
        private SqlConnection sqlCon;
        public DB_Connect()
        {
            sqlCon = new SqlConnection(connectionString);
        }

        public void OpenConnection()
        {
            try
            {
                if (sqlCon.State == ConnectionState.Closed)
                {
                    sqlCon.Open();
                    Console.WriteLine("Kết nối cơ sở dữ liệu thành công!");
                }
            }
            catch (SqlException ex)
            {
                throw new Exception("Lỗi kết nối cơ sở dữ liệu: " + ex.Message);
            }
        }

        public void CloseConnection()
        {
            try
            {
                if (sqlCon.State == ConnectionState.Open)
                {
                    sqlCon.Close();
                    Console.WriteLine("Đóng kết nối thành công!");
                }
            }
            catch (SqlException ex)
            {
                throw new Exception("Lỗi khi đóng kết nối: " + ex.Message);
            }
        }

        public SqlConnection GetConnection()
        {
            return sqlCon;
        }

    }
}
