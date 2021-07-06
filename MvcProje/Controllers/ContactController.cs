using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProje.Controllers
{
    public class ContactController : Controller
    {
        // GET: Contact
        
        ContactManager contactManager = new ContactManager(new EfContactDal());
        ContactValidator validationRules = new ContactValidator();
        public ActionResult Index()
        {
            var contactValues = contactManager.getList();
            return View(contactValues);
        }

        public ActionResult getContactDetails(int id)
        {
            var contactValues = contactManager.getByID(id);
            return View(contactValues);
        }

        public PartialViewResult ContactPartial()
        {
            return PartialView();
        }

    }
}