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
    public class WriterPanelMessageController : Controller
    {
        MessageManager messageManager = new MessageManager(new EfMessageDal());
        MessageValidator validations = new MessageValidator();
        Context context = new Context();
        // GET: WriterPanelMessage
        public ActionResult Inbox()
        {
            string mail = (string)Session["WriterMail"];
            
            var messageList = messageManager.GetListInbox(mail);
            return View(messageList);
        }

        public ActionResult Sendbox()
        {
            string mail = (string)Session["WriterMail"];
            int messageCount = messageManager.GetListSendbox(mail).Count();
            ViewBag.messageCount = messageCount;
            var messageList = messageManager.GetListSendbox(mail);
            return View(messageList);
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

        [HttpGet]
        public ActionResult NewMessage()
        {

            return View();
        }
        [HttpPost]
        public ActionResult NewMessage(Message message)
        {
            ValidationResult results = validations.Validate(message);
            string mail = (string)Session["WriterMail"];
            if (results.IsValid)
            {
                
                message.SenderMail = mail;
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



        public PartialViewResult MessageListMenu()
        {
            string mail = (string)Session["WriterMail"];
            int inboxMessageCount = messageManager.GetListInbox(mail).Count();
            ViewBag.inboxMessageCount = inboxMessageCount;

            return PartialView();
        }










    }
}