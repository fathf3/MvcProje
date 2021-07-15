using DataAccessLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProje.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        [AllowAnonymous]
        [HttpGet]
        public ActionResult HomePage()
        {
            Context context = new Context();
            var headingCount = context.Headings.Count().ToString();
            ViewBag.headingCount = headingCount;

            var writerCount = context.Writers.Count().ToString();
            ViewBag.writerCount = writerCount;

            var messageCount = context.Messages.Count().ToString();
            ViewBag.messageCount = messageCount;

            var categoryCount = context.Categories.Count().ToString();
            ViewBag.categoryCount = categoryCount;

            return View();
        }


    }
}