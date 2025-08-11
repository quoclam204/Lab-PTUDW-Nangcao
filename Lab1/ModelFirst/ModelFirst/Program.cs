using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelFirst
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            // Xem tên DbContext thật trong file BloggingModel.Context.cs, ví dụ "BloggingModelContainer"
            using (var db = new BloggingModelContainer())
            {
                // Seed dữ liệu nếu trống
                if (!db.Blogs.Any())
                {
                    var b1 = new Blog { Name = "Văn hóa" };
                    var b2 = new Blog { Name = "Xã hội" };
                    var b3 = new Blog { Name = "Tự nhiên" };
                    var b4 = new Blog { Name = "Kinh tế" };
                    db.Blogs.Add(b1);
                    db.Blogs.Add(b2);
                    db.Blogs.Add(b3);
                    db.Blogs.Add(b4);
                    db.SaveChanges();

                    db.Posts.Add(new Post
                    {
                        Title = "Bóng đá Việt Nam thay huấn luyện viên",
                        Content = "Ông Nguyễn Hữu Thắng trở thành tân huấn luyện viên tuyển Việt Nam",
                        Blog = b1
                    });
                    db.Posts.Add(new Post
                    {
                        Title = "Tiêm phòng vắc xin bệnh dại",
                        Content = "Tiêm phòng ngày 25/02/2012",
                        Blog = b2
                    });
                    db.Posts.Add(new Post
                    {
                        Title = "Tin tự nhiên",
                        Content = "Tin tự nhiên",
                        Blog = b2
                    });
                    db.Posts.Add(new Post
                    {
                        Title = "ABC",
                        Content = "DEF",
                        Blog = b4
                    });
                    db.SaveChanges();
                }

                // d) Truy vấn Post thuộc Blog "Xã hội"
                Console.WriteLine("Post thuộc Blog 'Xã hội':");
                var postsXaHoi = db.Posts.Where(p => p.Blog.Name == "Xã hội").ToList();
                foreach (var p in postsXaHoi)
                    Console.WriteLine($"- {p.Title} | {p.Content}");

                // e) Xóa PostId = 4
                var p4 = db.Posts.Find(4);
                if (p4 != null)
                {
                    db.Posts.Remove(p4);
                    db.SaveChanges();
                    Console.WriteLine("Đã xóa PostId = 4");
                }

                // f) Cập nhật PostId = 3 → Title = "Tin không tự nhiên"
                var p3 = db.Posts.Find(3);
                if (p3 != null)
                {
                    p3.Title = "Tin không tự nhiên";
                    db.SaveChanges();
                    Console.WriteLine("Đã cập nhật PostId = 3");
                }

                // e) Liệt kê toàn bộ Blog + Post
                Console.WriteLine("\nDanh sách Blog và Post:");
                // Fix for the error CS1660
                var blogs = db.Blogs.Include("Posts").ToList();
                foreach (var b in blogs)
                {
                    Console.WriteLine($"Blog: {b.Name}");
                    foreach (var p in b.Posts)
                        Console.WriteLine($"   - {p.Title}");
                }
            }

            Console.WriteLine("\nDone. Nhấn phím bất kỳ để thoát...");
            Console.ReadKey();
        }
    }
}
