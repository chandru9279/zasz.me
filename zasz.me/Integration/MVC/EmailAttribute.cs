using System;
using System.ComponentModel.DataAnnotations;
using System.Net.Mail;

namespace zasz.me.Integration.MVC
{
    public class EmailAttribute : ValidationAttribute
    {
        public const string RequiredMessage = "Please mention your email, so I can get in touch with you.";
        public const string LongMessage = "Email must be less that 80 characters";
        public const string FormatMessage = "Not a Valid Email";

        public override bool IsValid(object value)
        {
            try
            {
                var Address = value as string;
                if(string.IsNullOrEmpty(Address))
                {
                    ErrorMessage = RequiredMessage;
                    return false;
                }
                if(Address.Length >= 80)
                {
                    ErrorMessage = LongMessage;
                    return false;
                }
                var Parsed = new MailAddress(Address).Address;
                return true;
            }
            catch (FormatException)
            {
                ErrorMessage = FormatMessage;
                return false;
            }
        }
    }
}