using System.Configuration;
using System.Linq;
using System.Web.Mvc;

namespace zasz.me.Integration.MVC
{
    public abstract class BaseController : Controller
    {
        public ActionResult Default()
        {
            return RedirectToActionPermanent(GetDefaultActionName());
        }

        protected override void HandleUnknownAction(string actionName)
        {
            RedirectToAction("NotFound", "Error", new {actionName}).ExecuteResult(ControllerContext);
        }


        private string GetDefaultActionName()
        {
            var defaultAction = typeof (DefaultActionAttribute);

            var methodsFlaggedWithDefaultAction = (from member in GetType().GetMethods()
                                                   where member.GetCustomAttributes(defaultAction, false).Length > 0
                                                   select member).ToList();

            if (!methodsFlaggedWithDefaultAction.Any())
                throw new ConfigurationErrorsException(
                    string.Format(
                        "{0} does not have an Action flagged with the {1} attribute",
                        GetType().Name, defaultAction.Name));
            return methodsFlaggedWithDefaultAction.First().Name;
        }
    }
}