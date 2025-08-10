using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirstToExistingDatabase
{
    internal class BloggingContext : DbContext
    {
        /*
         •	Blogs và Posts là hai bảng tương ứng với hai lớp Blog và Post.
         •	Lớp này dùng để thao tác với cơ sở dữ liệu theo mô hình Code First.
        */
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Post> Posts { get; set; }

    }
}
