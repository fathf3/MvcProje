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
    public class MessageController : Controller
    {
        // GET: Message

        MessageManager messageManager = new MessageManager(new EfMessageDal());
        MessageValidator validations = new MessageValidator();
        [Authorize]
        public ActionResult Inbox(string p)
        {
            var messageList = messageManager.GetListInbox(p);
            return View(messageList);
        }

        public ActionResult Sendbox(string p)
        {
            var messageList = messageManager.GetListSendbox(p);
            return View(messageList);
        }
        [HttpGet]
        public ActionResult NewMessage()
        {
            
            return View();
        }
        [HttpPost]
        public ActionResult NewMessage(Message message)
        {
            ValidationResult results = validations.Validate(message);
            if (results.IsValid)
            {
                message.MessageDate = DateTime.Parse(DateTime.Now.ToShortDateString().ToString());
                messageManager.add(message);
                return RedirectToAction("Sendbox");
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

        public ActionResult getInboxMessageDetails(int id)
        {
            var messageContent = messageManager.getByID(id);
            return View(messageContent);
        }

        public ActionResult getSendMessageDetails(int id)
        {
            var messageContent = messageManager.getByID(id);
            return View(messageContent);
        }

    }
}