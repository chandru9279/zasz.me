using System.Web.Mvc;
using Microsoft.Practices.Unity;
using zasz.me.Configuration;

namespace zasz.me.Integration.Unity
{
    public class Unity
    {
        public static void Setup()
        {
            var box = new UnityContainer();
            Config.Unity.Configure(box, "BigBox");
            Config.PutConfigurationAndSettingsInside(box);
            Big.Swallow(box);
            DependencyResolver.SetResolver(new UnityDependencyResolver());
        }
    }
}