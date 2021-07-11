using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProje.Controllers
{
    public class HeadingController : Controller
    {
        HeadingManager headingManager = new HeadingManager(new EfHeadingDal());
        CategoryManager categoryManager = new CategoryManager(new EfCategoryDal());
        WriterManager writerManager = new WriterManager(new EfWriterDal());
        public ActionResult Index()
        {
            var headingValues = headingManager.getList();
            return View(headingValues);
        }

        [HttpGet]
        public ActionResult addHeading()
        {
            List<SelectListItem> valueCategory = (from x in categoryManager.getList() 
                                                  select new SelectListItem
                                                  {
                                                      Text = x.CategoryName,
                                                      Value = x.CategoryID.ToString()
                                                  }).ToList();
            List<SelectListItem> valueWriter = (from x in writerManager.getList()
                                                select new SelectListItem
                                                {
                                                    Text = x.WriterName+ " "+ x.WriterLastName,
                                                    Value = x.WriterID.ToString()

                                                }).ToList();
                                              

            ViewBag.categoryName = valueCategory;
            ViewBag.writerName = valueWriter;
            return View();
        }

        [HttpPost]
        public ActionResult addHeading(Heading heading)
        {
            heading.HeadingDate = DateTime.Parse(DateTime.Now.ToShortDateString());
            headingManager.add(heading);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult EditHeading(int id)
        {
            List<SelectListItem> valueCategory = (from x in categoryManager.getList()
                                                  select new SelectListItem
                                                  {
                                                      Text = x.CategoryName,
                                                      Value = x.CategoryID.ToString()
                                                  }).ToList();


            ViewBag.categoryName = valueCategory;
            var headingValue = headingManager.getByID(id);
            return View(headingValue);
        }

        [HttpPost]
        public ActionResult EditHeading(Heading heading)
        {

            headingManager.Update(heading);
            return RedirectToAction("Index");

        }

        public ActionResult DeleteHeading(int id)
        {
            var headingValue = headingManager.getByID(id);
            
            if (headingValue.HeadingStatus)
            {
                headingValue.HeadingStatus = false;
            }
            else
            {
                headingValue.HeadingStatus = true;
            }
            headingManager.Delete(headingValue); 
            return RedirectToAction("Index");
        }



    }
}