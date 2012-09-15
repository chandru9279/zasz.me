﻿using System;
using System.Web;
using Moq;
using Xunit;
using zasz.me.Controllers;
using zasz.me.Models;

namespace zasz.health.ControllerTests
{
    public class PostControllerTests
    {
        private readonly Mock<IPostRepository> postRepository;
        private readonly Mock<ITagRepository> tagRepository;

        public PostControllerTests()
        {
            postRepository = new Mock<IPostRepository>();
            tagRepository = new Mock<ITagRepository>();
        }

        [Fact]
        public void TestSlugger()
        {
            Func<string, string> Try = PostController.GetSlug;
            Assert.Equal("detail-id-equals-2190", Try("detail?id=2190"));
            Assert.Equal("func-percent-20-gnome", Try("func%20&nbsp;gnome"));
            Assert.Equal("c-sharp-rocks", Try("C# Rocks!"));
            Assert.Equal("using-di-or-dependency-injection",
                         Try(HttpUtility.HtmlEncode("using DI/Dependency Injection")));
            Assert.Equal("using-di-or-dependency-injection", Try("using DI/Dependency Injection"));
        }
    }
}