using System;
using Moq;
using Xunit;
using zasz.me.Controllers;
using zasz.me.Integration.EntityFramework;
using zasz.me.Models;

namespace zasz.health.ControllerTests
{
    public class PortfolioControllerTests : IDisposable
    {
        private PortfolioController controller;
        private readonly Mock<ICacheRepository> caches;
        private Mock<IAnswerRepository> answers;

        public PortfolioControllerTests()
        {
            caches = new Mock<ICacheRepository>();
            answers = new Mock<IAnswerRepository>();
        }

        [Fact]
        public void StackExchangeActionRendersMyQuestions()
        {
            var cache = new Cache();
            caches.Setup(x => x.Get()).Returns(cache);
            var returnModel = new Paged<Answer>();
            answers.Setup(x => x.Page(cache, 0, 10)).Returns(returnModel);
            controller = new PortfolioController(caches.Object, answers.Object); 
            
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