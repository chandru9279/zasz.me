using System;
using System.Configuration;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.SessionState;
using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.Configuration;

namespace zasz.me.Integration
{
    public class UnityIntegration
    {
        public static void Bootstrap()
        {
            var BigBox = new UnityContainer();
            var Section = ConfigurationManager.GetSection("unity") as UnityConfigurationSection;
            if (Section != null) Section.Configure(BigBox, "BigBox");
            ControllerBuilder.Current.SetControllerFactory(new UnityControllerBuilder(BigBox));
            HugeBox.Swallow(BigBox);
        }
    }

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


    public class SingletonPerRequest : LifetimeManager, IDisposable
    {
        private readonly string _Name;

        #region IDisposable Members

        public void Dispose()
        {
            RemoveValue();
        }

        #endregion

        /// <summary>
        /// This is a Lifetime Manager that maintains a singleton instance per web request. For example
        /// A DB Session can be managed by this manager - you have one session instance for the whole 
        /// Request
        /// </summary>
        /// <param name="Name"></param>
        public SingletonPerRequest(string Name)
        {
            _Name = Name;
        }

        public override object GetValue()
        {
            return HttpContext.Current.Items[_Name];
        }

        public override void RemoveValue()
        {
            HttpContext.Current.Items.Remove(_Name);
        }

        public override void SetValue(object newValue)
        {
            throw new NotImplementedException();
        }
    }
}