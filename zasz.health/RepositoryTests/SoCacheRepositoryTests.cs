using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Xunit;
using zasz.me.Integration.EntityFramework;
using zasz.me.Models;
using zasz.me.Services.Concrete;

namespace zasz.health.IntegrationTests
{
    public class SoCacheRepositoryTests : IDisposable
    {
        private readonly SoAnswer anotherAnswer;
        private readonly TestContext assertContext;
        private readonly SoCacheRepository repo;
        private readonly SoAnswer sampleAnswer;
        private readonly TestContext testContext;

        public SoCacheRepositoryTests()
        {
            sampleAnswer = new SoAnswer
                               {
                                   Sort = 1,
                                   AnswerId = 8203291,
                                   QuestionId = 8203265,
                                   QuestionTitle = "First"
                               };
            anotherAnswer = new SoAnswer
                                {
                                    Sort = 2,
                                    AnswerId = 8203291,
                                    QuestionId = 8203265,
                                    QuestionTitle = "Second"
                                };
            Database.SetInitializer(new TestStorageInitializer());
            testContext = new TestContext();
            assertContext = new TestContext();
            repo = new SoCacheRepository(testContext, new JsonSofuService());
        }

        #region IDisposable Members

        public void Dispose()
        {
            testContext.Dispose();
        }

        #endregion

        [Fact]
        public void RefreshWillDeleteExistingRows()
        {
            repo.Refresh();
        }

        [Fact]
        public void SoCacheAndSoAnswersCanBeSavedToTheDatabase()
        {
            var soCache = new SoCache
                              {
                                  Answers = new List<SoAnswer> {sampleAnswer, anotherAnswer}
                              };

            repo.Save(soCache);
            repo.Commit();
            var assertCache = assertContext.SoCaches.Include(x => x.Answers).First(x => x.Id == soCache.Id);
            Assert.NotNull(assertCache.Id);
            Assert.Equal(2, assertCache.Answers.Count);
            var first = assertCache.Answers.First(x => x.Id == sampleAnswer.Id);
            var second = assertCache.Answers.First(x => x.Id == anotherAnswer.Id);
            AssertAnswer(sampleAnswer, first);
            AssertAnswer(anotherAnswer, second);
        }

        private static void AssertAnswer(SoAnswer expected, SoAnswer actual)
        {
            Assert.NotNull(actual.Cache);

            Assert.Equal(expected.QuestionTitle, actual.QuestionTitle);
            Assert.Equal(expected.QuestionId, actual.QuestionId);
            Assert.Equal(expected.AnswerId, actual.AnswerId);
            Assert.Equal(expected.Sort, actual.Sort);
        }

        [Fact]
        public void ClearCacheClearsExistingSoAnswersAndCaches()
        {
            var soCache = new SoCache
                              {
                                  Answers = new List<SoAnswer> {sampleAnswer, anotherAnswer}
                              };
            repo.Save(soCache);
            repo.Commit();
            repo.ClearCache();
            Assert.Equal(0, assertContext.SoCaches.Count());
            Assert.Equal(0, assertContext.SoAnswers.Count());
            var assertCache = assertContext.SoCaches.Include(x => x.Answers).FirstOrDefault();
            Assert.Null(assertCache);
        }

        [Fact]
        public void RefreshWillGetNewSetFromSoApi()
        {
            repo.Refresh();
            var cacheCount = assertContext.SoCaches.Count();
            Assert.True(cacheCount == 1);
            var answerCount = assertContext.SoAnswers.Count();
            Assert.True(answerCount >= 30);
        }
    }
}