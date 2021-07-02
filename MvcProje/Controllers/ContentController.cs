using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;

namespace MvcProje.Controllers
{
    public class ContentController : Controller
    {
        ContentManager contentManager = new ContentManager(new EfContentDal());

        public ActionResult Index()
        {
            var contentValues = contentManager.getList();
            return View(contentValues);
        }

        public ActionResult ContentByHeading(int id)
        {
            var contentValues = contentManager.getListByHeadingId(id);
            return View(contentValues);
        }

    }
}