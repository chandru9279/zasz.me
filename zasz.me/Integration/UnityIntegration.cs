using System;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.SessionState;
using Microsoft.Practices.Unity;

namespace zasz.me.Integration
{
    public class UnityControllerBuilder : IControllerFactory
    {
        private readonly UnityContainer BigBox;

        public UnityControllerBuilder(UnityContainer BigBox)
        {
            this.BigBox = BigBox;
        }

        #region IControllerFactory Members

        public IController CreateController(RequestContext requestContext, string ControllerName)
        {
            var AreaName = (string) requestContext.RouteData.DataTokens["area"];
            string Area = String.IsNullOrEmpty(AreaName) ? "" : "Areas." + AreaName + ".";
            ControllerName = String.Format("zasz.me.{0}Controllers.{1}Controller", Area, ControllerName);
            if (String.IsNullOrWhiteSpace(ControllerName)) throw new ArgumentException("Controller name was NULL");
            var ControllerType = Type.GetType(ControllerName);

            if (null == ControllerType) throw new ArgumentException("Controller type not found");
            if (!(typeof (IController).IsAssignableFrom(ControllerType))) throw new ArgumentException("The type requested is not a controller");
            var Controller = BigBox.Resolve(Type.GetType(ControllerName)) as IController;

            if (null == Controller) throw new ArgumentException("Unity could not resolve the controller : " + ControllerName);
            return Controller;
        }

        public SessionStateBehavior GetControllerSessionBehavior(RequestContext requestContext, string controllerName)
        {
            return SessionStateBehavior.Disabled;
        }

        public void ReleaseController(IController controller)
        {
            BigBox.Teardown(controller);
        }

        #endregion
    }
}