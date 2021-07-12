using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProje.Controllers
{
    public class GalleryController : Controller
    {
        // GET: Gallery
        ImageFileManager fileManager = new ImageFileManager(new EfImageFileDal());
        public ActionResult Index()
        {
            var imageFile = fileManager.GetList();
            return View(imageFile);
        }
    }
}