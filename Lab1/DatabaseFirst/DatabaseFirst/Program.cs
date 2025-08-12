using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseFirst
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;

            using (var db = new ef_lab1Entities()) // tên context sinh ra của bạn có thể khác
            {
                // (d) Truy vấn Post thuộc Blog "Xã hội"
                Console.WriteLine("Các Post thuộc Blog 'Xã hội':");
                var postsXaHoi = db.Posts
                    .Where(p => p.Blog.Name == "Xã hội")
                    .Select(p => new { p.PostId, p.Title })
                    .ToList();
                foreach (var p in postsXaHoi)
                    Console.WriteLine($"- {p.PostId}: {p.Title}");

                // (e) Xóa PostId = 4
                var post4 = db.Posts.Find(4);
                if (post4 != null)
                {
                    db.Posts.Remove(post4);
                    db.SaveChanges();
                    Console.WriteLine("Đã xóa PostId = 4");
                }

                // (f) Cập nhật Title cho PostId = 3
                var post3 = db.Posts.Find(3);
                if (post3 != null)
                {
                    post3.Title = "Tin không tự nhiên";
                    db.Entry(post3).State = EntityState.Modified;
                    db.SaveChanges();
                    Console.WriteLine("Đã cập nhật PostId = 3");
                }

                // (e cuối) Load toàn bộ Blog + Posts
                Console.WriteLine("\nDanh sách Blog và các Post:");
                var blogs = db.Blogs.Include(b => b.Posts).ToList();
                foreach (var b in blogs)
                {
                    Console.WriteLine($"Blog [{b.BlogId}] {b.Name}");
                    foreach (var p in b.Posts)
                        Console.WriteLine($"   - Post [{p.PostId}] {p.Title} (BlogId={p.BlogId})");
                }
            }

            Console.WriteLine("\nHoàn tất. Nhấn Enter để thoát...");
            Console.ReadLine();
        }
    }
}
