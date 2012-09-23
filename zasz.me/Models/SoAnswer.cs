using System;
using System.Collections.Generic;
using zasz.me.Integration.MVC;
using zasz.me.ViewModels;

namespace zasz.me.Models
{
    public class SoAnswer : IModel
    {
        public SoAnswer()
        {
            if (Id == default(Guid)) Id = Guid.NewGuid();
        }

        public int Sort { get; set; }
        public int QuestionId { get; set; }
        public string QuestionTitle { get; set; }
        public int AnswerId { get; set; }

        public SoCache Cache { get; set; }

        #region IModel Members

        [NaturalKey]
        public Guid Id { get; set; }

        #endregion
    }

    public class SoCache : IModel
    {
        public SoCache()
        {
            if (Timestamp == default(DateTime)) Timestamp = DateTime.Now;
            if (Answers == null) Answers = new List<SoAnswer>();
            if (Id == default(Guid)) Id = Guid.NewGuid();
        }

        public List<SoAnswer> Answers { get; set; }
        public DateTime Timestamp { get; set; }

        #region IModel Members

        [NaturalKey]
        public Guid Id { get; set; }

        #endregion

        public bool HasExpired()
        {
            return DateTime.Now.Subtract(Timestamp).Days > 1;
        }
    }

    public interface ISoCacheRepository : IRepository<SoCache, Guid>
    {
        SoCache Get();
        Paged<SoAnswer> Page(SoCache cache, int pageNumber, int pageSize);
    }
}