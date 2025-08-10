using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirstToExistingDatabase
{
    internal class Blog
    {
        // Khóa chính của bảng
        public int BlogId { get; set; }

        // Tên của blog, có thể chứa tên của các chủ đề khác nhau.
        public string Name { get; set; }

        // Danh sách các bài viết thuộc blog này (quan hệ 1-nhiều).
        public virtual List<Post> Posts { get; set; }
    }
}
