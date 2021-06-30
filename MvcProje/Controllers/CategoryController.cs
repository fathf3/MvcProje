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
    public class CategoryController : Controller
    {
        // GET: Category
        CategoryManager categoryManager = new CategoryManager(new  EfCategoryDal());
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult getCategoryList()
        {
            // getAll ile tablodaki degerleri aldik 
            // View ile gelen bilgileri View a gonderdık
            var categoryValues = categoryManager.getList();
            return View(categoryValues);

        }
        [HttpGet]
        public ActionResult addCategory()
        {   
            // Sayfa yuklendiginde  HttpGet ile sayfa gelicek
            return View();
        }

        [HttpPost]
        public ActionResult addCategory(Category category)
        {
            // HttpPost ile sayfa icinde girilen bilgiler veritabanina yazilacak
            //categoryManager.CategoryAdd(category);

            CategoryValidator categoryValidator = new CategoryValidator();
            ValidationResult validationResult = categoryValidator.Validate(category);
            if (validationResult.IsValid)
            {
                categoryManager.addCategory(category);
                return RedirectToAction("getCategoryList");
            }
            else
            {
                foreach(var item in validationResult.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View();

        }






    }
}