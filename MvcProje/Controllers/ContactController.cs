using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.Concrete;
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
        [AllowAnonymous]
        [HttpGet]
        public ActionResult NewMessage()
        {

            return View();
        }
        [AllowAnonymous]
        [HttpPost]
        public ActionResult NewMessage(Contact contact)
        {
            ValidationResult results = validationRules.Validate(contact);
            if (results.IsValid)
            {
                contact.ContactDate = DateTime.Parse(DateTime.Now.ToShortDateString().ToString());
                contactManager.add(contact);
                return RedirectToAction("HomePage", "Home");
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


        public PartialViewResult ContactPartial()
        {
            string mail = (string)Session["WriterMail"];
            
            
            var contacts = _Context.Contacts.Count().ToString();
            ViewBag.contact = contacts;

            var messages = _Context.Messages.Count(x => x.ReciverMail == mail).ToString();
            ViewBag.message = messages;



            return PartialView();
        }

    }
}