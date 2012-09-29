using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Xunit;
using zasz.me.Integration.EntityFramework;
using zasz.me.Models;
using zasz.me.Services.Concrete;

namespace zasz.health.RepositoryTests
{
    public class CacheRepositoryTests : IDisposable
    {
        private readonly Answer anotherAnswer;
        private readonly TestContext assertContext;
        private readonly Caches repo;
        private readonly Answer sampleAnswer;
        private readonly TestContext testContext;

        public CacheRepositoryTests()
        {
            sampleAnswer = new Answer
                               {
                                   Sort = 1,
                                   AnswerId = 8203291,
                                   QuestionId = 8203265,
                                   QuestionTitle = "First"
                               };
            anotherAnswer = new Answer
                                {
                                    Sort = 2,
                                    AnswerId = 8203291,
                                    QuestionId = 8203265,
                                    QuestionTitle = "Second"
                                };
            Database.SetInitializer(new TestStorageInitializer());
            testContext = new TestContext();
            assertContext = new TestContext();
            repo = new Caches(testContext, new JsonSofuService());
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
        public void CachesAndAnswersCanBeSavedToTheDatabase()
        {
            var cache = new Cache
                              {
                                  Answers = new List<Answer> {sampleAnswer, anotherAnswer}
                              };

            repo.Save(cache);
            repo.Commit();
            var assertCache = assertContext.Caches.Include(x => x.Answers).First(x => x.Id == cache.Id);
            Assert.NotNull(assertCache.Id);
            Assert.Equal(2, assertCache.Answers.Count);
            var first = assertCache.Answers.First(x => x.Id == sampleAnswer.Id);
            var second = assertCache.Answers.First(x => x.Id == anotherAnswer.Id);
            AssertAnswer(sampleAnswer, first);
            AssertAnswer(anotherAnswer, second);
        }

        private static void AssertAnswer(Answer expected, Answer actual)
        {
            Assert.NotNull(actual.Cache);

            Assert.Equal(expected.QuestionTitle, actual.QuestionTitle);
            Assert.Equal(expected.QuestionId, actual.QuestionId);
            Assert.Equal(expected.AnswerId, actual.AnswerId);
            Assert.Equal(expected.Sort, actual.Sort);
        }

        [Fact]
        public void ClearCacheClearsExistingAnswersAndCaches()
        {
            var cache = new Cache
                              {
                                  Answers = new List<Answer> {sampleAnswer, anotherAnswer}
                              };
            repo.Save(cache);
            repo.Commit();
            repo.ClearCache();
            Assert.Equal(0, assertContext.Caches.Count());
            Assert.Equal(0, assertContext.Answers.Count());
            var assertCache = assertContext.Caches.Include(x => x.Answers).FirstOrDefault();
            Assert.Null(assertCache);
        }

        [Fact]
        public void RefreshWillGetNewSetFromSoApi()
        {
            repo.Refresh();
            var cacheCount = assertContext.Caches.Count();
            Assert.True(cacheCount == 1);
            var answerCount = assertContext.Answers.Count();
            Assert.True(answerCount >= 30);
        }
    }
}