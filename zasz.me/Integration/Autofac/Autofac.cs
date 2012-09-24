using System.Web.Mvc;
using Autofac;
using Autofac.Integration.Mvc;
using zasz.me.Configuration;

namespace zasz.me.Integration.Autofac
{
    public class Autofac
    {
        public static void Setup()
        {
            var builder = new ContainerBuilder();
            builder.RegisterControllers(typeof(Autofac).Assembly);
            Config.GetInto(builder);
            var container = builder.Build();
            Big.Swallow(container);
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));

            DependencyResolver.SetResolver(new UnityDependencyResolver());
        }
    }
}