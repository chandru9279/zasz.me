using System;
using System.Collections.Generic;
using System.Linq;
using zasz.me.Models;
using zasz.me.Services;
using zasz.me.Services.Contracts;
using zasz.me.ViewModels;

namespace zasz.me.Integration.EntityFramework
{
    internal class SoCacheRepository : RepoBase<SoCache, Guid>, ISoCacheRepository
    {
        private readonly ISofuService service;

        public SoCacheRepository(FullContext context, ISofuService service)
            : base(context)
        {
            this.service = service;
        }

        #region ISoCacheRepository Members

        public SoCache Get()
        {
            var cache = Set.FirstOrDefault();
            return cache == null || cache.HasExpired() ? Refresh() : cache;
        }

        public Paged<SoAnswer> Page(SoCache cache, int pageNumber, int pageSize)
        {
            var soCaches = cache.Answers.Skip(pageNumber * pageSize).Take(pageSize).ToList();
            var count = cache.Answers.Count();
            return new Paged<SoAnswer> { Set = soCaches, NumberOfPages = count };
        }

        #endregion

        /// <summary>
        /// Easier ways to write this method, but this ensures no more that 30 SoAnswers are in-memory
        /// </summary>
        /// <returns>Latest updated cache</returns>
        internal SoCache Refresh()
        {
            ClearCache();
            var cache = NewCache();
            Pair<bool, List<SoAnswer>> questionsAnswered;
            var page = 1;
            do
            {
                questionsAnswered = service.QuestionsAnswered(page);
                service.PopulateTitles(questionsAnswered.Other);
                UnitOfWork(x =>
                               {
                                   // ReSharper disable AccessToModifiedClosure
                                   var soCache = x.SoCaches.Find(cache.Id);
                                   questionsAnswered.Other.ForEach(y => y.Cache = soCache);
                                   questionsAnswered.Other.ForEach(y => x.SoAnswers.Add(y));
                                   x.SaveChanges();
                                   // ReSharper restore AccessToModifiedClosure
                               });
                page++;
            } while (questionsAnswered.One);
            return cache;
        }

        private SoCache NewCache()
        {
            var cache = new SoCache();
            Save(cache);
            Commit();
            return cache;
        }

        internal void ClearCache()
        {
            Context.Database.ExecuteSqlCommand("DELETE FROM SoCaches; DELETE FROM SoAnswers;");
        }
    }
}