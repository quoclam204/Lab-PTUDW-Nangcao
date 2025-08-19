using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using EntityModel; // dùng DbContext EF và entity Blog/Post

namespace MvcBlog.Controllers
{
    public class BlogController : Controller
    {
        private readonly EF db = new EF();

        // GET: /Blog
        // Hiển thị toàn bộ Blog + danh sách Post con
        public ActionResult Index()
        {
            var blogs = db.Blogs
                          .Include(b => b.Posts)  // kèm Posts
                          .OrderBy(b => b.BlogId)
                          .ToList();
            return View(blogs);
        }

        // GET: /Blog/Get/1
        // Lấy 1 blog theo id (kèm Posts)
        public ActionResult Get(int id)
        {
            var blog = db.Blogs
                         .Include(b => b.Posts)
                         .FirstOrDefault(b => b.BlogId == id);
            if (blog == null) return HttpNotFound();
            return View(blog);
        }
    }
}
