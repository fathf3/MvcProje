using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProje.Controllers
{
    public class AdminCategoryController : Controller
    {
        CategoryManager categoryManager = new CategoryManager(new EfCategoryDal());
        public ActionResult Index()
        {
            var categoryValues = categoryManager.getList();
            return View(categoryValues);
        }
        [HttpGet]
        public ActionResult AddCategory()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddCategory(Category category)
        {
            CategoryValidator categoryValidator = new CategoryValidator();
            ValidationResult results = categoryValidator.Validate(category);
            if (results.IsValid) 
            {
                categoryManager.addCategory(category);
                return RedirectToAction("Index");
            }
            else 
            { 
                foreach(var item  in results.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View();
        }

        public ActionResult DeleteCategory(int id)
        {
            var categoryValue = categoryManager.getByID(id);
            categoryManager.DeleteCategory(categoryValue);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult UpdateCategory(int id)
        {
            // getById ile gelen id ye sahip nesne degerleri alınır
            // Sayfada gelen nesne bilgileri gostermek icin view e gonderilir
            var categoryValue = categoryManager.getByID(id);
            return View(categoryValue);
        }
        [HttpPost]
        public ActionResult UpdateCategory(Category category)
        {
            categoryManager.UpdateCategory(category);
            return RedirectToAction("Index");
        }


    }
}