using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProje.Controllers
{
    public class StatisticsController : Controller
    {
        Context context = new Context();

        // GET: Statistics
        public ActionResult Index()
        {
            var result = context.Categories.Count();
            var result2 = context.Headings.Count(c => c.Category.CategoryName == "Spor");
            var result3 = context.Writers.Count(c => c.WriterName.Contains("a"));
            var result4 = context.Headings.Max(c => c.Category.CategoryName);
            var result5 = context.Categories.Count(c => c.CategoryStatus == true);
            var result6 = context.Categories.Count(c => c.CategoryStatus == false);
            ViewBag.result = result;
            ViewBag.result2 = result2;
            ViewBag.result3 = result3;
            ViewBag.result4 = result4;
            ViewBag.result5 = (result5 - result6);
            return View();
        }
    }
}