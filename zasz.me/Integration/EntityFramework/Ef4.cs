using Autofac;
using Autofac.Integration.Mvc;

namespace zasz.me.Integration.EntityFramework
{
    public class Ef4
    {
        public static void Setup()
        {
            var newBuilder = new ContainerBuilder();
            newBuilder.RegisterType<FullContext>().InstancePerHttpRequest();
            newBuilder.Update(Big.Box);
        }
    }
}