using System.Linq;
using System.Linq.Expressions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Reflection;
using zasz.me.Areas.Shared.Models;
using zasz.me.Integration.MVC;
using System.Diagnostics;
using System;
using System.Web.Mvc;

namespace zasz.health.ControllerTests
{
    [TestClass]
    public class RuleTests
    {
        [TestMethod]
        public void ShouldEnsureAllControllersExtendFromTheBaseController()
        {
            var BaseType = typeof (BaseController);
            var AllControllers = (from EachType in Assembly.GetAssembly(BaseType).GetTypes()
                                  where EachType.Name.EndsWith("Controller")
                                  select EachType).ToList();
            var CriminalControllers = AllControllers.FindAll(C => !BaseType.IsAssignableFrom(C));
            CriminalControllers.ForEach(C => Debug.WriteLine(C.FullName));
            Assert.IsTrue(CriminalControllers.Count == 0);
        }

        [TestMethod]
        public void ExpressionTest()
        {
            string Name = Extensions.Name(X => X.Id);
            Assert.AreEqual(Name, "Id");
            Assert.AreEqual(Extensions.Name(X => X.Content), "Content");
            Assert.AreEqual(Extensions.PropertyInfo(X => X.Content).Name, "Content");
        }

        [TestMethod]
        public void ShouldEnsureAllControllersHaveADefaultAction()
        {
            var BaseType = typeof (BaseController);
            var ConcreteControllers = from EachType in Assembly.GetAssembly(BaseType).GetTypes()
                                      where EachType.Name.EndsWith("Controller") && !EachType.IsAbstract
                                      select EachType;
            var CriminalControllers = ConcreteControllers.ToList().FindAll(C => !C.HasOneDefaultAction());
            CriminalControllers.ForEach(C => Debug.WriteLine(C.FullName));
            Assert.IsTrue(CriminalControllers.Count == 0);
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