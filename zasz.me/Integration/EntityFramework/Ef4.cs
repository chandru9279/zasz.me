using Autofac;

namespace zasz.me.Integration.EntityFramework
{
    public class Ef4
    {
        public static void Setup()
        {
            var newBuilder = new ContainerBuilder();
            newBuilder.RegisterType<FullContext>().InstancePerRequest();
            newBuilder.Update(Big.Box);
        }
    }
}