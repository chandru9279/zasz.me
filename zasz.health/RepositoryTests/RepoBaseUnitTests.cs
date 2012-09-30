using System;
using Moq;
using Xunit;
using zasz.me.Integration.EntityFramework;
using zasz.me.Models;

namespace zasz.health.RepositoryTests
{
    public class RepoBaseUnitTests
    {
        private readonly TestPosts postRepo;
        private readonly TestLogs logsRepo;

        public RepoBaseUnitTests()
        {
            postRepo = new TestPosts();
            logsRepo = new TestLogs();
        }

        [Fact]
        public void NaturalKeyEqualsConstructsALambdaExpressionThatHelpsFindTheModel()
        {
            var expOfStringBool = postRepo.NaturalKeyEquals("test-slug");
            Assert.Equal("x => (x.Slug == \"test-slug\")", expOfStringBool.ToString());
            var logId = Guid.NewGuid();
            var expOfGuidBool = logsRepo.NaturalKeyEquals(logId);
            Assert.Equal("x => (x.Id == " + logId + ")", expOfGuidBool.ToString());
        }
    }

    public class TestPosts : RepoBase<Post, string>
    {
        public TestPosts()
            : base(new Mock<TestContext>().Object)
        {
        }
    }

    public class TestLogs : RepoBase<Log, Guid>
    {
        public TestLogs()
            : base(new Mock<TestContext>().Object)
        {
        }
    }
}