using System;
using System.ComponentModel.DataAnnotations;
using zasz.me.Services;

namespace zasz.me.Integration.MVC
{
    public class RequiredDatetimeAttribute : RequiredAttribute
    {
        public override bool IsValid(object value)
        {
            if (!base.IsValid(value)) return false;
            var date = value as DateTime?;
            if (date == null || date == default(DateTime))
            {
                ErrorMessage = Messages.TimestampRequiredMessage;
                return false;
            }
            return true;
        }
    }
}