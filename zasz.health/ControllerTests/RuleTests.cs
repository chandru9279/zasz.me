using System;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Web.Mvc;
using Xunit;
using zasz.me.Integration.MVC;
using zasz.me.Models;

namespace zasz.health.ControllerTests
{
    public class RuleTests
    {
        [Fact]
        public void ShouldEnsureAllControllersExtendFromTheBaseController()
        {
            var baseType = typeof (BaseController);
            var allControllers = (from type in Assembly.GetAssembly(baseType).GetTypes()
                                  where type.Name.EndsWith("Controller")
                                  select type).ToList();
            var criminalControllers = allControllers.FindAll(c => !baseType.IsAssignableFrom(c));
            criminalControllers.ForEach(c => Debug.WriteLine(c.FullName));
            Assert.True(criminalControllers.Count == 0);
        }

        [Fact]
        public void ExpressionTest()
        {
            var name = Extensions.Name(x => x.Id);
            Assert.Equal(name, "Id");
            Assert.Equal(Extensions.Name(x => x.Content), "Content");
            Assert.Equal(Extensions.PropertyInfo(x => x.Content).Name, "Content");
        }

        [Fact]
        public void ShouldEnsureAllControllersHaveADefaultAction()
        {
            var BaseType = typeof (BaseController);
            var ConcreteControllers = from EachType in Assembly.GetAssembly(BaseType).GetTypes()
                                      where EachType.Name.EndsWith("Controller") && !EachType.IsAbstract
                                      select EachType;
            var CriminalControllers = ConcreteControllers.ToList().FindAll(C => !C.HasOneDefaultAction());
            CriminalControllers.ForEach(C => Debug.WriteLine(C.FullName));
            Assert.True(CriminalControllers.Count == 0);
        }
    }

    public static class Extensions
    {
        public static bool HasOneDefaultAction(this Type ControllerType)
        {
            Exception Up = new ArgumentException("Type should be a Controller");
            if (!typeof (Controller).IsAssignableFrom(ControllerType))
                throw Up;
            var DefaultAction = typeof (DefaultActionAttribute);
            var Actions = from Method in ControllerType.GetMethods()
                          where Method.GetCustomAttributes(DefaultAction, false).Length > 0
                          select Method;
            return Actions.ToList().Count == 1;
        }

        public static string Name<T>(Expression<Func<Post, T>> Expression)
        {
            return ((MemberExpression) Expression.Body).Member.Name;
        }

        public static PropertyInfo PropertyInfo<T>(Expression<Func<Post, T>> Expression)
        {
            return ((MemberExpression) Expression.Body).Member as PropertyInfo;
        }
    }
}