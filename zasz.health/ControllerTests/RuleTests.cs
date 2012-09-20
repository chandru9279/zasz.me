using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Web.Mvc;
using Xunit;
using zasz.health.UtilityTests;
using zasz.me.Integration.MVC;
using zasz.me.Models;

namespace zasz.health.ControllerTests
{
    public class RuleTests
    {
        [Fact]
        public void AllModelsHaveExactlyOneNaturalKey()
        {
            var baseType = typeof (IModel);
            var criminalModels = (from eachType in Assembly.GetAssembly(baseType).GetTypes()
                                  where baseType.IsAssignableFrom(eachType) && !eachType.IsInterface
                                  where !eachType.HasOneNaturalKey()
                                  select eachType).ToList();
            criminalModels.ForEach(c => Debug.WriteLine(c.FullName));
            Assert.True(criminalModels.Count == 0);
        }

        [Fact]
        public void AllControllersExtendFromTheBaseController()
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
        public void AllControllersHaveADefaultAction()
        {
            var baseType = typeof (BaseController);
            var criminalControllers = (from eachType in Assembly.GetAssembly(baseType).GetTypes()
                                       where typeof (Controller).IsAssignableFrom(eachType) && !eachType.IsAbstract
                                       where !eachType.HasOneDefaultAction()
                                       select eachType).ToList();
            criminalControllers.ForEach(c => Debug.WriteLine(c.FullName));
            Assert.True(criminalControllers.Count == 0);
        }
    }
}