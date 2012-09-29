using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using zasz.me.Integration.MVC;

namespace zasz.me.Models
{
    [Table("Caches", Schema = "StackExchange")]
    public class Cache : IModel
    {
        public Cache()
        {
            if (Timestamp == default(DateTime)) Timestamp = DateTime.Now;
            if (Answers == null) Answers = new List<Answer>();
            if (Id == default(Guid)) Id = Guid.NewGuid();
        }

        public List<Answer> Answers { get; set; }
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
}