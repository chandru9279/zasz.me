using System;
using System.ComponentModel.DataAnnotations.Schema;
using zasz.me.Integration.MVC;

namespace zasz.me.Models
{
    [Table("Answers", Schema = "StackExchange")]
    public class Answer : IModel
    {
        public Answer()
        {
            if (Id == default(Guid)) Id = Guid.NewGuid();
        }

        public int Sort { get; set; }
        public int QuestionId { get; set; }
        public string QuestionTitle { get; set; }
        public int AnswerId { get; set; }

        public Cache Cache { get; set; }

        #region IModel Members

        [NaturalKey]
        public Guid Id { get; set; }

        #endregion
    }

    public interface ICacheRepository : IRepository<Cache, Guid>
    {
        Cache Get();
    }
}