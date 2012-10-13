using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using zasz.me.Integration.MVC;
using zasz.me.Services;

namespace zasz.me.ViewModels
{
    public class ContactViewModel
    {
        [StringLength(80, ErrorMessage = "Name must be less that 80 characters")]
        public string Name { get; set; }

        /* Order of validation is not controllable in as of MVC3. Since custom validators 
         * dont have client side validation, I've put in a required validator also, even if email
         * validator also does the same thing, just for JS validation
         */

        [Email]
        [Required(ErrorMessage = Messages.EmailRequiredMessage)]
        public string Email { get; set; }

        [Required(ErrorMessage = "You forgot to key in the message!")]
        [AllowHtml]
        [StringLength(1000, ErrorMessage = "Message must be less that 1000 characters")]
        public string Message { get; set; }

        [StringLength(80, ErrorMessage = "Website must be less that 80 characters")]
        public string Website { get; set; }
    }
}