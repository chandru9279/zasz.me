using System;
using Moq;
using Xunit;
using zasz.me.Integration.EntityFramework;
using zasz.me.Models;

namespace zasz.health.RepositoryTests
{
    public class RepoBaseUnitTests
    {
        private readonly TestPosts repo;

        public RepoBaseUnitTests()
        {
            repo = new TestPosts();
        }

        [Fact]
        public void NaturalKeyEqualsConstructsALambdaExpressionThatHelpsFindTheModel()
        {
            var naturalKeyEquals = repo.NaturalKeyEquals("test-slug");
            Assert.Equal("x => (x.Slug == \"test-slug\")", naturalKeyEquals.ToString());
        }
    }

    public class TestPosts : RepoBase<Post, string>
    {
        public TestPosts() : base(new Mock<TestContext>().Object)
        {
        }
    }

    public class TestLogs : RepoBase<Log, Guid>
    {
        public TestLogs() : base(new Mock<TestContext>().Object)
        {
        }
    }
}