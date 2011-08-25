using System.Configuration;
using System.Linq;
using System.Reflection;
using System.Web.Mvc;

namespace zasz.me.Integration.MVC
{
    public abstract class BaseController : Controller
    {
        public ActionResult Default()
        {
            return RedirectToActionPermanent(GetDefaultActionName());
        }

        protected override void HandleUnknownAction(string ActionName)
        {
            RedirectToAction("NotFound", "Error", new { ActionName }).ExecuteResult(ControllerContext);
        }


        private string GetDefaultActionName()
        {
            var DefaultAction = typeof(DefaultActionAttribute);

            var MethodsFlaggedWithDefaultAction = from Member in GetType().GetMethods()
                                                  where Member.GetCustomAttributes(DefaultAction, false).Length > 0
                                                  select Member;

            if (MethodsFlaggedWithDefaultAction.Count() == 0)
                throw new ConfigurationErrorsException(
                    string.Format(
                        "{0} does not have an Action flagged with the {1} attribute",
                        GetType().Name, DefaultAction.Name));
            return MethodsFlaggedWithDefaultAction.First().Name;
        }
    }
}