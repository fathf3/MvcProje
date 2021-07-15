using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using PagedList.Mvc;
using FluentValidation.Results;
using BusinessLayer.ValidationRules;

namespace MvcProje.Controllers
{
    public class WriterPanelController : Controller
    {
        // GET: WriterPanel

        HeadingManager headingManager = new HeadingManager(new EfHeadingDal());
        CategoryManager categoryManager = new CategoryManager(new EfCategoryDal());
        WriterManager writerManager = new WriterManager(new EfWriterDal());
        Context context = new Context();
        int writerIdInfo;


        [HttpGet]
        public ActionResult WriterProfile(int id = 0)
        {
            string p = (string)Session["WriterMail"];
            id = context.Writers.Where(x => x.WriterMail == p).Select(y => y.WriterID).FirstOrDefault();
            
            
            var writerValue = writerManager.getByID(id);
            return View(writerValue);
        }

        [HttpPost]
        public ActionResult WriterProfile(Writer writer)
        {
            WriterValidator writerValidator = new WriterValidator();
            ValidationResult results = writerValidator.Validate(writer);
            if (results.IsValid)
            {
                writerManager.Update(writer);
                return RedirectToAction("AllHeading", "WriterPanel");
            }
            else
            {
                foreach (var item in results.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View();
        }

        public ActionResult GetMyHeading(string p)
        {
            p = (string)Session["WriterMail"];
            writerIdInfo = context.Writers.Where(x => x.WriterMail == p).Select(y => y.WriterID).FirstOrDefault();
            var values = headingManager.GetListByWriter(writerIdInfo);
            return View(values);
        }

        [HttpGet]
        public ActionResult NewHeading()
        {
            List<SelectListItem> valueCategory = (from x in categoryManager.getList()
                                                  select new SelectListItem
                                                  {
                                                      Text = x.CategoryName,
                                                      Value = x.CategoryID.ToString()
                                                  }).ToList();
            

            ViewBag.categoryName = valueCategory;
            
            return View();
        }

        [HttpPost]
        public ActionResult NewHeading(Heading heading)
        {
            string writerInfo = (string)Session["WriterMail"];
            writerIdInfo = context.Writers.Where(x => x.WriterMail == writerInfo).Select(y => y.WriterID).FirstOrDefault();
            heading.HeadingDate = DateTime.Parse(DateTime.Now.ToShortDateString());
            heading.WriterID = writerIdInfo;
            heading.HeadingStatus = true;
            headingManager.add(heading);
            return RedirectToAction("GetMyHeading");
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
            return RedirectToAction("GetMyHeading");

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
            return RedirectToAction("GetMyHeading");
        }

        public ActionResult AllHeading(int p  = 1)
        {

            var headings = headingManager.getList().ToPagedList(p, 4);
            return View(headings);
        }



    }
}