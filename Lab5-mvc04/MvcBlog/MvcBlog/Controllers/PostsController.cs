using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MvcBlog;

namespace MvcBlog.Controllers
{
    public class PostsController : Controller
    {
        private ef_lab1Entities1 db = new ef_lab1Entities1();

        // GET: Posts
        // GET: Posts
        // Hỗ trợ cả ?id=... & ?blogId=... và segment /Posts/Index/{blogId}/{title}/{fromDate}/{toDate}
        public ActionResult Index(int? id, int? blogId, string title, string fromDate, string toDate)
        {
            // Nguồn cho DropDownList
            ViewBag.Blogs = new SelectList(
                db.Blogs.Select(b => new { b.BlogId, b.Name })
                        .OrderBy(x => x.Name)
                        .ToList(),
                "BlogId", "Name"
            );

            var posts = db.Posts.Include(p => p.Blog).AsQueryable();

            // 1) Lọc theo BlogId
            int? selectedBlogId = blogId ?? id; // theo đề: id=BlogId
            if (selectedBlogId.HasValue)
                posts = posts.Where(p => p.BlogId == selectedBlogId.Value);

            // 2) Lọc theo Title
            if (!string.IsNullOrWhiteSpace(title))
                posts = posts.Where(p => p.Title.Contains(title));

            // 3) Lọc theo khoảng ngày (CreatedDate)
            //   Nếu Post không có CreatedDate, dùng p.Blog.CreatedDate (đổi dòng Where bên dưới)
            DateTime from, to;
            bool hasFrom = DateTime.TryParse(fromDate, out from);
            bool hasTo = DateTime.TryParse(toDate, out to);

            if (hasFrom && hasTo)
            {
                if (to < from)
                {
                    ModelState.AddModelError("", "‘Đến ngày’ phải ≥ ‘Từ ngày’."); // bắt lỗi trước khi truy vấn
                }
                else
                {
                    to = to.Date.AddDays(1).AddTicks(-1); // inclusive tới cuối ngày
                    posts = posts.Where(p => p.CreatedDate >= from && p.CreatedDate <= to);
                    // Nếu không có Post.CreatedDate, dùng: posts = posts.Where(p => p.Blog.CreatedDate >= from && p.Blog.CreatedDate <= to);
                }
            }
            else if (hasFrom)
            {
                posts = posts.Where(p => p.CreatedDate >= from);
            }
            else if (hasTo)
            {
                to = to.Date.AddDays(1).AddTicks(-1);
                posts = posts.Where(p => p.CreatedDate <= to);
            }

            // Bind lại ra form
            ViewBag.SelBlogId = selectedBlogId;
            ViewBag.TitleKey = title;
            ViewBag.FromDate = fromDate;
            ViewBag.ToDate = toDate;

            var result = posts
                .OrderByDescending(p => p.CreatedDate)   // nếu dùng Blog.CreatedDate thì đổi cho phù hợp
                .ThenBy(p => p.PostId)
                .ToList();

            return View(result);
        }

        // GET: Posts/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Post post = db.Posts.Find(id);
            if (post == null)
            {
                return HttpNotFound();
            }
            return View(post);
        }

        // GET: Posts/Create
        public ActionResult Create()
        {
            ViewBag.BlogId = new SelectList(db.Blogs, "BlogId", "Name");
            return View();
        }

        // POST: Posts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PostId,Title,Content,BlogId")] Post post)
        {
            // vì form không có CreatedDate nên xóa lỗi nếu có
            ModelState.Remove("CreatedDate");

            // set ở server
            post.CreatedDate = DateTime.Now;

            if (!ModelState.IsValid)
            {
                ViewBag.BlogId = new SelectList(db.Blogs, "BlogId", "Name", post.BlogId);
                return View(post);
            }

            db.Posts.Add(post);
            db.SaveChanges();
            return RedirectToAction("Index", new { blogId = post.BlogId });
        }


        // GET: Posts/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Post post = db.Posts.Find(id);
            if (post == null)
            {
                return HttpNotFound();
            }
            ViewBag.BlogId = new SelectList(db.Blogs, "BlogId", "Name", post.BlogId);
            return View(post);
        }

        // POST: Posts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PostId,Title,Content,BlogId,CreatedDate")] Post post)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.BlogId = new SelectList(db.Blogs, "BlogId", "Name", post.BlogId);
                return View(post);
            }

            var existing = db.Posts.FirstOrDefault(p => p.PostId == post.PostId);
            if (existing == null) return HttpNotFound();

            existing.Title = post.Title?.Trim();
            existing.Content = post.Content;
            existing.BlogId = post.BlogId;
            existing.CreatedDate = post.CreatedDate; // <-- quan trọng

            db.SaveChanges();
            return RedirectToAction("Index", new { blogId = existing.BlogId });
        }


        // GET: Posts/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Post post = db.Posts.Find(id);
            if (post == null)
            {
                return HttpNotFound();
            }
            return View(post);
        }

        // POST: Posts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Post post = db.Posts.Find(id);
            db.Posts.Remove(post);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
