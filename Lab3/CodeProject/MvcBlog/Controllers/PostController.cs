using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using EntityModel;

namespace MvcBlog.Controllers
{
    public class PostController : Controller
    {
        private readonly EF db = new EF();

        // GET: /Post
        public ActionResult Index()
        {
            var posts = db.Posts
                          .Include(p => p.Blog)
                          .OrderBy(p => p.PostId)
                          .ToList();
            return View(posts);
        }

        // GET: /Post/Get/1
        public ActionResult Get(int id)
        {
            var post = db.Posts
                         .Include(p => p.Blog)
                         .FirstOrDefault(p => p.PostId == id);
            if (post == null) return HttpNotFound();
            return View(post);
        }
    }
}
