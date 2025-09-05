using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcBlog.Controllers
{
    public class HelloWordController : Controller
    {
        // GET: HelloWord
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Index1()
        {
            return View();
        }

        public ActionResult Welcome(string name, int id = 1)
        {
            ViewBag.Message = "Hello " + name;
            ViewBag.NumTimes = id;
            return View();
        }

    }
}