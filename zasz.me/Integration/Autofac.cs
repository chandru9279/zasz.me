using System.Web.Mvc;
using Autofac;
using Autofac.Integration.Mvc;

namespace zasz.me.Integration
{
    public class AutoFac
    {
        public static void Setup()
        {
            var builder = new ContainerBuilder();
            builder.RegisterControllers(typeof(AutoFac).Assembly);
            builder.RegisterFilterProvider();
            builder.RegisterModelBinderProvider();
            builder.RegisterAssemblyTypes(typeof (AutoFac).Assembly)
                .Where(x =>  x.Namespace != null && (
                    x.Namespace.StartsWith("zasz.me.Services.Concrete") || 
                    x.Namespace.StartsWith("zasz.me.Integration.EntityFramework"
                    )))
                .AsImplementedInterfaces();
            var container = builder.Build();
            Big.Swallow(container);
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }
    }
}