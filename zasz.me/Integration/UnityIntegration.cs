using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Mvc;
using Microsoft.Practices.Unity;
using zasz.me.Configuration;

namespace zasz.me.Integration
{
    public class UnityIntegration
    {
        public static void Bootstrap()
        {
            var BigBox = new UnityContainer();
            Config.Unity.Configure(BigBox, "BigBox");
            Config.PutConfigurationAndSettingsInside(BigBox);
            HugeBox.Swallow(BigBox);
            DependencyResolver.SetResolver(new UnityDependencyResolver());
        }
    }

    public class UnityDependencyResolver : IDependencyResolver
    {
        private readonly IUnityContainer container;

        public UnityDependencyResolver()
        {
            container = HugeBox.BigBox;
        }

        #region IDependencyResolver Members

        public object GetService(Type serviceType)
        {
            if (!container.IsRegistered(serviceType))
            {
                if (serviceType.IsAbstract || serviceType.IsInterface)
                {
                    return null;
                }
            }
            return container.Resolve(serviceType);
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return container.ResolveAll(serviceType);
        }

        #endregion
    }

    public class SingletonPerRequest : LifetimeManager, IDisposable
    {
        private readonly string _Name;

        public SingletonPerRequest(string Name)
        {
            _Name = Name;
        }

        #region IDisposable Members

        public void Dispose()
        {
            RemoveValue();
        }

        #endregion

        public override object GetValue()
        {
            return HttpContext.Current.Items[_Name];
        }

        public override void RemoveValue()
        {
            HttpContext.Current.Items.Remove(_Name);
        }

        public override void SetValue(object NewValue)
        {
            HttpContext.Current.Items[_Name] = NewValue;
        }
    }
}