using System;
using System.Net.Mail;
using System.Web.Mvc;
using Elmah;
using Microsoft.Practices.Unity;
using zasz.me.Integration.MVC;
using zasz.me.ViewModels;

namespace zasz.me.Controllers
{
    public class ContactController : BaseController
    {
        [Dependency("MailAccount")]
        public string MailAccount { get; set; }

        [DefaultAction]
        public ActionResult Form()
        {
            return View(new ContactViewModel());
        }

        public ActionResult Mail(ContactViewModel contactModel)
        {
            if (ModelState.IsValid)
            {
                var mail = new MailMessage(new MailAddress(contactModel.Email), new MailAddress(MailAccount))
                               {
                                   Body = contactModel.Message,
                                   IsBodyHtml = true,
                                   Subject = "Contact - from zasz.me - Name: " + contactModel.Name
                               };
                if (!Request.IsLocal)
                    try
                    {
                        new SmtpClient("127.0.0.1", 25).Send(mail);
                    }
                    catch (Exception e)
                    {
                        ErrorSignal.FromCurrentContext().Raise(e);
                    }
                return View();
            }
            return View("Form", contactModel);
        }
    }
}