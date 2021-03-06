using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Elmah;
using zasz.me.Integration.MVC;

namespace zasz.me.Models
{
    [Table("Logs", Schema = "Manage")]
    public class Log : IModel
    {
        public Log()
        {
        }

        public Log(Error error)
        {
            Id = Guid.NewGuid();
            Error = error;
        }

        public Error Error { get; set; }

        public string IdString
        {
            get { return Id.ToString(); }
        }

        #region IModel Members

        [Key]
        [NaturalKey]
        public Guid Id { get; set; }

        #endregion
    }

    public interface ILogsRepository : IRepository<Log, Guid>
    {
    }
}