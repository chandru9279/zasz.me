using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Elmah;

namespace zasz.me.Models
{
    public class Log : IModel
    {
        public Log()
        {
        }

        public Log(Error Error)
        {
            Id = Guid.NewGuid();
            this.Error = Error;
        }

        public Error Error { get; set; }

        public string IdString
        {
            get { return Id.ToString(); }
        }

        #region IModel Members

        [Key]
        public Guid Id { get; set; }

        #endregion
    }

    public interface ILogsRepository : IRepository<Log, Guid>
    {
        List<Log> Page(int PageNumber, int PageSize);
    }
}