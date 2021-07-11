using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.Concrete;
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
        Context _Context = new Context();
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
            var contacts = _Context.Contacts.Count().ToString();
            ViewBag.contact = contacts;

            var messages = _Context.Messages.Count(x => x.ReciverMail == "fatih@hotmail.com").ToString();
            ViewBag.message = messages;

            return PartialView();
        }

    }
}