﻿using System.Configuration;
using System.Linq;
using System.Reflection;
using System.Web.Mvc;

namespace zasz.me.Integration.MVC
{
    public class BaseController : Controller
    {
        public ActionResult Default()
        {
            var DefaultAction = typeof (DefaultActionAttribute);

            var MethodsFlaggedWithDefaultAction = from Member in GetType().GetMembers()
                                                  where Member.MemberType == MemberTypes.Method && Member.GetCustomAttributes(DefaultAction, false).Length > 0 
                                                  select Member;

            if (MethodsFlaggedWithDefaultAction.Count() == 0)
                throw new ConfigurationErrorsException(string.Format("{0} does not have an Action flagged with the {1} attribute", GetType().Name, DefaultAction.Name));

            return RedirectToActionPermanent(MethodsFlaggedWithDefaultAction.First().Name);
        }
    }
}