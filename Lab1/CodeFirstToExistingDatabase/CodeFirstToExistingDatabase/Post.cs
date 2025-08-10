using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirstToExistingDatabase
{
    internal class Post
    {
        // Khóa chính của bảng
        public int PostId { get; set; }

        // Tiêu đề và nội dung bài viết.
        public string Title { get; set; }
        public string Content { get; set; }

        // Khóa ngoại liên kết đến bảng Blog.
        public int BlogId { get; set; }

        // Thuộc tính điều hướng đến đối tượng Blog.
        public virtual Blog Blog { get; set; }

    }
}
