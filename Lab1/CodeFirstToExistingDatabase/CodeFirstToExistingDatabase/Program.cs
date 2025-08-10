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
            using (var db = new BloggingContext())
            {
                Console.OutputEncoding = System.Text.Encoding.UTF8;

                //var blog = new Blog { Name = "name" };
                //db.Blogs.Add(blog);
                //db.SaveChanges();

                db.Database.Delete();   // Drop DB CodeFirstEF_DB
                db.Database.Create();

                // Thêm mới dữ liệu cho bảng Blog
                db.Blogs.Add(new Blog { Name = "Văn hóa" });
                db.Blogs.Add(new Blog { Name = "Xã hội" });
                db.Blogs.Add(new Blog { Name = "Tự nhiên" });
                db.Blogs.Add(new Blog { Name = "Kinh tế" });

                db.SaveChanges();

                // Thêm mới dữ liệu cho bảng Post
                db.Posts.Add(new Post
                {
                    Title = "Bóng đá Việt Nam thay huấn luyện viên",
                    Content = "Ông Nguyễn Hữu Thắng trở thành tân\r\nhuấn luyện viên tuyển Việt Nam",
                    BlogId = 1
                });
                db.Posts.Add(new Post
                {
                    Title = "Tiêm phòng vắc xin bệnh dại ",
                    Content = "Tiêm phòng ngày 25/02/2012",
                    BlogId = 2
                });
                db.Posts.Add(new Post
                {
                    Title = "Tin tự nhiên",
                    Content = "Tin tự nhiên",
                    BlogId = 2
                });
                db.Posts.Add(new Post
                {
                    Title = "ABC",
                    Content = "DEF",
                    BlogId = 4
                });

                db.SaveChanges();

                XuatDanhSachPost(db);
            }

        }

        // Hàm xuất danh sách các post
        static void XuatDanhSachPost(BloggingContext db)
        {
            // Fix for the CS1660 error
            var posts = db.Posts.Include("Blog").ToList();
            Console.WriteLine("Danh sách các Post:");
            Console.WriteLine("----------------------------------------------------------------------------------------------------");
            foreach (var post in posts)
            {
                Console.WriteLine($"\tPostId: {post.PostId}, Title: {post.Title}, Content: {post.Content}, Blog: {post.Blog?.Name}");
            }
            Console.WriteLine("----------------------------------------------------------------------------------------------------");
        }
    }
}
