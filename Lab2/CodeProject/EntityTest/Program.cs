using System;
using System.Linq;
using System.Text;
using EntityModel; // DbContext EF nằm trong namespace này

namespace EntityTest
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;

            // Nếu vẫn bị nhận nhầm, có thể ghi rõ tên đầy đủ:
            // using (var db = new EntityModel.EF())
            using (var db = new EF())
            {
                foreach (var b in db.Blogs.ToList())
                {
                    Console.WriteLine($"{b.BlogId} - {b.Name}");
                }
            }

            Console.WriteLine("\nHoàn tất. Nhấn phím bất kỳ để thoát...");
            Console.ReadKey();
        }
    }
}
