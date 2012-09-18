using System.Collections.Generic;
using System.Diagnostics;
using Xunit;
using zasz.me.Controllers;

namespace zasz.health.ControllerTests
{
    public class PortfolioControllerTests
    {
        private readonly PortfolioController controller;

        public PortfolioControllerTests()
        {
            controller = new PortfolioController();
        }

        [Fact]
        public void ShouldBeAbleToGetMyQuestions()
        {
            var stackExchange = controller.StackExchange();
            var model = (List<int>)stackExchange.Model;
            Debug.WriteLine(string.Join(", ", model));
        }
    }
}