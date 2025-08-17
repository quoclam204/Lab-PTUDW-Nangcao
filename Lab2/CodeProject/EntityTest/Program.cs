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

            using (var db = new EF())
            {
                // Thêm Blog mới
                var newBlog = new Blog { Name = "Blog mới" };
                db.Blogs.Add(newBlog);
                db.SaveChanges();
                Console.WriteLine($"Đã thêm Blog: {newBlog.BlogId} - {newBlog.Name}");

                // Sửa Blog vừa thêm
                newBlog.Name = "Blog đã sửa";
                db.SaveChanges();
                Console.WriteLine($"Đã sửa Blog: {newBlog.BlogId} - {newBlog.Name}");

                // Lấy danh sách Blog
                Console.WriteLine("\nDanh sách Blog:");
                foreach (var b in db.Blogs.ToList())
                {
                    Console.WriteLine($"{b.BlogId} - {b.Name}");
                }

                // Xóa Blog vừa thêm
                db.Blogs.Remove(newBlog);
                db.SaveChanges();
                Console.WriteLine($"Đã xóa Blog: {newBlog.BlogId}");
            }

            Console.WriteLine("\nHoàn tất. Nhấn phím bất kỳ để thoát...");
            Console.ReadKey();
        }
    }
}
