using System;
using System.ComponentModel.DataAnnotations;
using System.Net.Mail;
using zasz.me.Services;

namespace zasz.me.Integration.MVC
{
    public class EmailAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            try
            {
                var address = value as string;
                if (string.IsNullOrEmpty(address))
                {
                    ErrorMessage = Messages.EmailRequiredMessage;
                    return false;
                }
                if (address.Length >= 80)
                {
                    ErrorMessage = Messages.EmailLongMessage;
                    return false;
                }
                var parsed = new MailAddress(address).Address;
                return true;
            }
            catch (FormatException)
            {
                ErrorMessage = Messages.EmailFormatMessage;
                return false;
            }
        }
    }
}