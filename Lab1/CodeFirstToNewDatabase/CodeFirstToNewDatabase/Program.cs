using System;
using System.Linq;
using System.Data.Entity;
using System.Text;

namespace CodeFirstToNewDatabase
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using (var db = new BloggingContext())
            {
                //var blog = new Blog { Name = "name" };
                //db.Blogs.Add(blog);
                //db.SaveChanges();

                // Thêm mới dữ liệu cho bảng Blog
                db.Blogs.Add(new Blog { Name = "Văn hóa" });
                db.Blogs.Add(new Blog { Name = "Xã hội" });
                db.Blogs.Add(new Blog { Name = "Tự nhiên" });
                db.Blogs.Add(new Blog { Name = "Kinh tế" });

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
            }
        }
    }
}
