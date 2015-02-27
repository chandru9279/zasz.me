using System;
using System.Net.Mail;
using System.Web.Mvc;
using Elmah;
using zasz.me.Integration.MVC;
using zasz.me.Services.Contracts;
using zasz.me.ViewModels;

namespace zasz.me.Controllers
{
    public class ContactController : BaseController
    {
        private readonly IConfigurationService service;

        public ContactController(IConfigurationService service)
        {
            this.service = service;
        }

        [DefaultAction]
        public ActionResult Form()
        {
            return View(new ContactViewModel());
        }

        public ActionResult Mail(ContactViewModel contactModel)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View("Form", contactModel);
            }

            var mail = new MailMessage(new MailAddress(contactModel.Email), new MailAddress(this.service.Settings.MailAccount))
                           {
                               Body = contactModel.Message,
                               IsBodyHtml = true,
                               Subject = "Contact - from zasz.me - Name: " + contactModel.Name
                           };

            if (this.Request.IsLocal)
            {
                return this.View();
            }

            try
            {
                new SmtpClient("127.0.0.1", 25).Send(mail);
            }
            catch (Exception e)
            {
                ErrorSignal.FromCurrentContext().Raise(e);
            }

            return this.View();
        }
    }
}