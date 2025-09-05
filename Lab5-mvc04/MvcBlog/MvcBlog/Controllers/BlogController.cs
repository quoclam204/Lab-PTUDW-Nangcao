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
    public class BlogController : Controller
    {
        private ef_lab1Entities1 db = new ef_lab1Entities1();

        // GET: Blog
        // GET: Blog
        public ActionResult Index(string name, string des, string own)
        {
            // Nạp danh sách Owner duy nhất cho DropDownList
            ViewBag.Owners = new SelectList(
                db.Blogs.Select(b => b.Owner).Distinct().OrderBy(x => x).ToList()
            );

            var blogs = db.Blogs.AsQueryable();

            if (!string.IsNullOrWhiteSpace(name))
                blogs = blogs.Where(b => b.Name.Contains(name));

            if (!string.IsNullOrWhiteSpace(des))
                blogs = blogs.Where(b => b.Description.Contains(des));

            if (!string.IsNullOrWhiteSpace(own))
                blogs = blogs.Where(b => b.Owner == own);

            // Giữ lại giá trị đã nhập để bind lại ra form
            ViewBag.Name = name;
            ViewBag.Des = des;
            ViewBag.Own = own;

            // Sắp xếp: Rank (null xuống cuối) rồi BlogId
            var data = blogs
                .OrderBy(b => b.Rank ?? int.MaxValue)
                .ThenBy(b => b.BlogId)
                .ToList();

            return View(data);
        }


        // GET: Blog/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Blog blog = db.Blogs.Find(id);
            if (blog == null)
            {
                return HttpNotFound();
            }
            return View(blog);
        }

        // GET: Blog/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Blog/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "BlogId,Name,Description,Owner,Rank")] Blog blog)
        {
            if (ModelState.IsValid)
            {
                db.Blogs.Add(blog);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(blog);
        }

        // GET: Blog/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Blog blog = db.Blogs.Find(id);
            if (blog == null)
            {
                return HttpNotFound();
            }
            return View(blog);
        }

        // POST: Blog/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "BlogId,Name,Description,Owner,Rank")] Blog blog)
        {
            if (ModelState.IsValid)
            {
                db.Entry(blog).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(blog);
        }


        // GET: Blog/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Blog blog = db.Blogs.Find(id);
            if (blog == null)
            {
                return HttpNotFound();
            }
            return View(blog);
        }

        // POST: Blog/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var blog = db.Blogs
                         .Include(b => b.Posts)       // tải kèm con
                         .FirstOrDefault(b => b.BlogId == id);

            if (blog == null) return HttpNotFound();

            try
            {
                // Xóa tất cả Posts thuộc Blog này (nếu có)
                if (blog.Posts != null && blog.Posts.Any())
                {
                    db.Posts.RemoveRange(blog.Posts);
                }

                db.Blogs.Remove(blog);
                db.SaveChanges();

                TempData["Success"] = "Đã xóa blog và các bài viết liên quan.";
                return RedirectToAction("Index");
            }
            catch (System.Data.Entity.Infrastructure.DbUpdateException)
            {
                ModelState.AddModelError("", "Không thể xóa do ràng buộc dữ liệu.");
                return View("Delete", blog);
            }
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
