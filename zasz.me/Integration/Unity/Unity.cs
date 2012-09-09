using System.Web.Mvc;
using Microsoft.Practices.Unity;
using zasz.me.Configuration;

namespace zasz.me.Integration.Unity
{
    public class Unity
    {
        public static void Setup()
        {
            var theBigBox = new UnityContainer();
            Config.Unity.Configure(theBigBox, "BigBox");
            Config.PutConfigurationAndSettingsInside(theBigBox);
            Big.Swallow(theBigBox);
            DependencyResolver.SetResolver(new UnityDependencyResolver());
        }
    }
}