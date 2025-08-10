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
            Console.OutputEncoding = Encoding.UTF8;

            using (var db = new BloggingContext())
            {
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

                // Truy vấn các Post có BlogId tên là "Xã hội"
                var blog = db.Blogs.FirstOrDefault(b => b.Name == "Xã hội");
                if (blog != null)
                {
                    // Lấy các Post có BlogId tương ứng
                    var posts = db.Posts.Where(p => p.BlogId == blog.BlogId).ToList();
                    Console.WriteLine($"\nCác bài viết trong blog '{blog.Name}':");

                    // Duyệt và hiển thị kết quả
                    foreach (var post in posts)
                    {
                        Console.WriteLine($"\tPost Title: {post.Title}, Content: {post.Content}");
                    }
                }
                else
                {
                    Console.WriteLine("Không tìm thấy blog tên 'Xã hội'");
                }

                // Xóa mục Post có PostId = 4
                var xoaPost = db.Posts.Find(4);
                if (xoaPost != null)
                {
                    db.Posts.Remove(xoaPost);
                    db.SaveChanges();
                    Console.WriteLine("\nĐã xóa bài viết có PostId = 4.");
                }
                else
                {
                    Console.WriteLine("\nKhông tìm thấy bài viết có PostId = 4.");
                }
                // Hiển thị lại danh sách các Blog và Post sau khi xóa
                XuatDanhSachPost(db);

                // Cập nhật nội dung cho PostId = 3 thay Title là "Tin không tự nhiên".
                var updatePost = db.Posts.Find(3); // Tìm bài viết có PostId = 3
                if (updatePost != null)
                {
                    updatePost.Title = "Tin không tự nhiên";
                    db.SaveChanges();
                }
                else
                {
                    Console.WriteLine("\nKhông tìm thấy bài viết có PostId = 3.");
                }
                db.SaveChanges();
                XuatDanhSachPost(db);

                // Truy vấn toàn bộ Blog và các Post liên quan
                var blogs = db.Blogs.Include(b => b.Posts).ToList();

                foreach (var blog1 in blogs)
                {
                    Console.WriteLine($"Blog: {blog1.Name}");
                    if (blog1.Posts != null && blog1.Posts.Count > 0)
                    {
                        foreach (var post in blog1.Posts)
                        {
                            Console.WriteLine($"\tPostId: {post.PostId}, Title: {post.Title}, Content: {post.Content}");
                        }
                    }
                    else
                    {
                        Console.WriteLine("\tKhông có bài viết nào.");
                    }
                }


                // Dừng chương trình và đợi người dùng nhấn Enter
                Console.WriteLine("Nhấn Enter để thoát...");
                Console.ReadLine();
            }

        }

        // Hàm xuất danh sách các post
        static void XuatDanhSachPost(BloggingContext db)
        {
            var posts = db.Posts.Include(p => p.Blog).ToList();
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
