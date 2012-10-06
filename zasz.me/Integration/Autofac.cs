using System.Web.Mvc;
using Autofac;
using Autofac.Integration.Mvc;
using zasz.me.Services.Contracts;

namespace zasz.me.Integration
{
    public class AutoFac
    {
        public static void Setup()
        {
            var builder = new ContainerBuilder();
            var assembly = typeof (AutoFac).Assembly;
            builder.RegisterControllers(assembly);
            builder.RegisterFilterProvider();
            builder.RegisterModelBinderProvider();
            builder.RegisterAssemblyTypes(assembly)
                .Where(x =>  x.Namespace != null && (
                    x.Namespace.StartsWith("zasz.me.Services.Concrete") || 
                    x.Namespace.StartsWith("zasz.me.Integration.EntityFramework"
                    )))
                .AsImplementedInterfaces();
            builder.RegisterAssemblyTypes(assembly).Where(x => x.IsAssignableTo<IPostPopulator>()).AsSelf();
            var container = builder.Build();
            Big.Swallow(container);
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }
    }
}