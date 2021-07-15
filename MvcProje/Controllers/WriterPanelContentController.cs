using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProje.Controllers
{
    public class WriterPanelContentController : Controller
    {
        // GET: WriterPanelContent
        ContentManager contentManager = new ContentManager(new EfContentDal());
        Context context = new Context();
        public ActionResult MyContent(string p)
        {
            
            p = (string)Session["WriterMail"];
            
            var writerIdInfo = context.Writers.Where(x => x.WriterMail == p).Select(y => y.WriterID).FirstOrDefault();
            
            var contentValues = contentManager.getListByWriter(writerIdInfo);
            return View(contentValues);
        }
        [HttpGet]
        public ActionResult AddContent(int id)
        {
            ViewBag.d = id;
            return View();
        }
        [HttpPost]
        public ActionResult AddContent(Content content)
        {
            content.ContentDate = DateTime.Parse(DateTime.Now.ToShortDateString());
            
            string p = (string)Session["WriterMail"];
            var writerIdInfo = context.Writers.Where(x => x.WriterMail == p).Select(y => y.WriterID).FirstOrDefault();
            content.WriterID = writerIdInfo;
            content.ContentStatus = true;
            contentManager.add(content);
            return RedirectToAction("MyContent");
        }


    }
}