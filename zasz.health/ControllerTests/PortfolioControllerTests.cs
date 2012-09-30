using System;
using Moq;
using Xunit;
using zasz.me.Controllers;
using zasz.me.Models;
using zasz.me.ViewModels;

namespace zasz.health.ControllerTests
{
    public class PortfolioControllerTests : IDisposable
    {
        private PortfolioController controller;
        private readonly Mock<ICacheRepository> caches;

        public PortfolioControllerTests()
        {
            caches = new Mock<ICacheRepository>();
        }

        [Fact]
        public void StackExchangeActionRendersMyQuestions()
        {
            var cache = new Cache();
            caches.Setup(x => x.Get()).Returns(cache);
            var returnModel = new Paged<Answer>();
            caches.Setup(x => x.Page(cache, 1, 10)).Returns(returnModel);
            controller = new PortfolioController(caches.Object); 
            
            var stackExchange = controller.StackExchange();
            var model = (Paged<Answer>)stackExchange.Model;
            Assert.Equal(returnModel, model);
        }

        public void Dispose()
        {
            caches.VerifyAll();
        }
    }
}