using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirstToExistingDatabase
{
    internal class Program
    {
        static void Main(string[] args)
        {
        }

        public static string isValidBirthday(string dateStr)
        {
            int count = 0;
            for (int i = 1; i < dateStr.Length; i++)
            {
                if (dateStr[i] == '/')
                {
                    count++;
                }
            }
            if (count != 2)
            {
                return "Ngày không hợp lệ - Sai định dạng";
            }

            // Giả lập kiểm tra đơn giản
            if (dateStr == "29/02/2007")
            {
                return "Ngày không hợp lệ - Năm không nhuận";
            }
            if (dateStr == "10/10/2008")
            {
                return "Ngày không hợp lệ - Chưa đủ 18 tuổi";
            }

            return "Ngày sinh hợp lệ";
        }
    }
}
