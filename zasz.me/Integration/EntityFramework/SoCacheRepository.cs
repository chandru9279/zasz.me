using System;
using System.Collections.Generic;
using System.Linq;
using zasz.me.Models;
using zasz.me.Services;
using zasz.me.Services.Contracts;
using zasz.me.ViewModels;

namespace zasz.me.Integration.EntityFramework
{
    class SoCacheRepository : RepoBase<SoCache, Guid>, ISoCacheRepository
    {
        private readonly ISofuService service;

        public SoCacheRepository(FullContext session, ISofuService service) : base(session)
        {
            this.service = service;
        }

        public SoCache Get()
        {
            var cache = ModelSet.First();
            return cache.HasExpired() ? Refresh() : cache;
        }

        public Paged<SoAnswer> Page(SoCache cache, int pageNumber, int pageSize)
        {
            var soCaches = cache.Answers.Skip(pageNumber * pageSize).Take(pageSize).ToList();
            var count = cache.Answers.Count();
            return new Paged<SoAnswer>{Set = soCaches, NumberOfPages = count};
        }

        internal SoCache Refresh()
        {
            ClearCache();
            var cache = new SoCache();
            Pair<bool, List<SoAnswer>> questionsAnswered;
            var page = 1;
            do
            {
                questionsAnswered = service.QuestionsAnswered(page);
                service.PopulateTitles(questionsAnswered.Other);
                questionsAnswered.Other.ForEach(cache.Answers.Add);
                Save(cache);
                page++;
            } while (questionsAnswered.One);
            Commit();
            return cache;
        }

        internal void ClearCache()
        {
            Session.Database.ExecuteSqlCommand("DELETE FROM SoCaches; DELETE FROM SoAnswers;");
        }
    }
}