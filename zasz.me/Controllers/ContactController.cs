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

        public ActionResult Mail(ContactViewModel ContactModel)
        {
            if (ModelState.IsValid)
            {
                var Mail = new MailMessage(new MailAddress(ContactModel.Email), new MailAddress(MailAccount))
                               {
                                   Body = ContactModel.Message,
                                   IsBodyHtml = false,
                                   Subject = "Contact - from zasz.me - Name: " + ContactModel.Name
                               };
                if (!Request.IsLocal)
                    try
                    {
                        new SmtpClient("127.0.0.1", 25).Send(Mail);
                    }
                    catch (Exception E)
                    {
                        ErrorSignal.FromCurrentContext().Raise(E);
                    }
                return View();
            }
            return View("Form", ContactModel);
        }
    }
}