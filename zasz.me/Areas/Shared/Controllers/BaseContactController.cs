using System;
using System.ComponentModel.DataAnnotations;
using System.Net.Mail;
using System.Web.Mvc;
using Elmah;
using Microsoft.Practices.Unity;
using zasz.me.Integration.MVC;

namespace zasz.me.Areas.Shared.Controllers
{
    public abstract class BaseContactController : BaseController
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

        #region Nested type: ContactViewModel

        public class ContactViewModel
        {
            [StringLength(80, ErrorMessage = "Name must be less that 80 characters")]
            public string Name { get; set; }

            /* Order of validation is not controllable in as of MVC3. Since custom validators 
             * dont have client side validation, I've put in a required validator also, even if email
             * validator also does the same thing, just for JS validation
             */
            [Email]
            [Required(ErrorMessage = EmailAttribute.RequiredMessage)]
            public string Email { get; set; }

            [Required(ErrorMessage = "You forgot to key in the message!")]
            [StringLength(1000, ErrorMessage = "Message must be less that 1000 characters")]
            public string Message { get; set; }

            [StringLength(80, ErrorMessage = "Website must be less that 80 characters")]
            public string Website { get; set; }
        }

        #endregion
    }
}