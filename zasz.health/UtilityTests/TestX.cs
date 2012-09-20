using System;
using System.Linq;
using zasz.me.Integration.MVC;

namespace zasz.health.UtilityTests
{
    public static class TestX
    {
        public static bool HasOneDefaultAction(this Type controllerType)
        {
            return (from method in controllerType.GetMethods()
                    where Attribute.IsDefined(method, typeof (DefaultActionAttribute))
                    select method).Count() == 1;
        }
        
        public static bool HasOneNaturalKey(this Type controllerType)
        {
            return (from property in controllerType.GetProperties()
                    where Attribute.IsDefined(property, typeof (NaturalKeyAttribute))
                    select property).Count() == 1;
        }
    }
}