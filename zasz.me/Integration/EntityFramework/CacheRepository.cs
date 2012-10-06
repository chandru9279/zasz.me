using System;
using System.Collections.Generic;
using System.Linq;
using zasz.me.Models;
using zasz.me.Services;
using zasz.me.Services.Contracts;

namespace zasz.me.Integration.EntityFramework
{
    internal class CacheRepository : Repository<Cache, Guid>, ICacheRepository
    {
        private readonly ISofuService service;

        public CacheRepository(FullContext context, ISofuService service)
            : base(context)
        {
            this.service = service;
        }

        #region ICacheRepository Members

        public Cache Get()
        {
            var cache = Set.FirstOrDefault();
            return cache == null || cache.HasExpired() ? Refresh() : cache;
        }

        #endregion

        /// <summary>
        /// Easier ways to write this method, but this ensures no more that 30 Answers are in-memory
        /// </summary>
        /// <returns>Latest updated cache</returns>
        internal Cache Refresh()
        {
            ClearCache();
            var cache = NewCache();
            Pair<bool, List<Answer>> questionsAnswered;
            var page = 1;
            do
            {
                questionsAnswered = service.QuestionsAnswered(page);
                service.PopulateTitles(questionsAnswered.Other);
                UnitOfWork(x =>
                               {
                                   // ReSharper disable AccessToModifiedClosure
                                   var soCache = x.Caches.Find(cache.Id);
                                   questionsAnswered.Other.ForEach(y => y.Cache = soCache);
                                   questionsAnswered.Other.ForEach(y => x.Answers.Add(y));
                                   x.SaveChanges();
                                   // ReSharper restore AccessToModifiedClosure
                               });
                page++;
            } while (questionsAnswered.One);
            return cache;
        }

        private Cache NewCache()
        {
            var cache = new Cache();
            Save(cache);
            Commit();
            return cache;
        }

        internal void ClearCache()
        {
            var caches = X.FullTableName<Cache>();
            var answers = X.FullTableName<Answer>();
            var deleteQueries = string.Format("DELETE FROM {0}; DELETE FROM {1};", caches, answers);
            Context.Database.ExecuteSqlCommand(deleteQueries);
        }
    }
}