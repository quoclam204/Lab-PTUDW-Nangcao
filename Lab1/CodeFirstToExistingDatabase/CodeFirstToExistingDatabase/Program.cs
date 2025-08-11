using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirstToExistingDatabase
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            // Khởi tạo kết nối đến cơ sở dữ liệu
            string connectionString = @"Data Source=DESKTOP-E3V9138\SQLEXPRESS;Initial Catalog=ef_lab1;Integrated Security=True";
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    Console.WriteLine("Kết nối thành công!");
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Kết nối thất bại: " + ex.Message);
                }
            }

        }
    }
}
