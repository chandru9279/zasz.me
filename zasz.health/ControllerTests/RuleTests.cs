using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Reflection;
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
            var BaseType = typeof(BaseController);
            var AllControllers = (from EachType in Assembly.GetAssembly(BaseType).GetTypes()
                                  where EachType.Name.EndsWith("Controller")
                                  select EachType).ToList();
            var CriminalControllers = AllControllers.FindAll(C => !BaseType.IsAssignableFrom(C));
            CriminalControllers.ForEach(C => Debug.WriteLine(C.FullName));
            Assert.IsTrue(CriminalControllers.Count == 0);
        }

        [TestMethod]
        public void ShouldEnsureAllControllersHaveADefaultAction()
        {
            var BaseType = typeof(BaseController);
            var ConcreteControllers = from EachType in Assembly.GetAssembly(BaseType).GetTypes()
                                      where EachType.Name.EndsWith("Controller") && !EachType.IsAbstract
                                      select EachType;
            var CriminalControllers = ConcreteControllers.ToList().FindAll(C => !C.HasOneDefaultAction());
            CriminalControllers.ForEach(C => Debug.WriteLine(C.FullName));
            Assert.IsTrue(CriminalControllers.Count == 0);            
        }
    }

    public static class TypeExtension
    {
        public static bool HasOneDefaultAction(this Type ControllerType)
        {
            Exception up = new ArgumentException("Type should be a Controller");
            if (!typeof(Controller).IsAssignableFrom(ControllerType))
                throw up;
            var DefaultAction = typeof(DefaultActionAttribute);
            var Actions = from Method in ControllerType.GetMethods()
                          where Method.GetCustomAttributes(DefaultAction, false).Length > 0
                          select Method;
            return Actions.ToList().Count == 1;
        }
    }
}
