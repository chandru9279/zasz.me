using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Elmah;

namespace zasz.me.Areas.Shared.Models
{
    public class Log : IModel
    {
        public Log()
        {
        }

        [Key]
        public string ID { get; set; }

        public Error Error { get; set; }

        public Log(Error Error)
        {
            GuID = Guid.NewGuid();
            this.Error = Error;
        }

        [NotMapped]
        public Guid GuID
        {
            get { return Guid.Parse(ID); }
            set { ID = value.ToString(); }
        }
    }

    public interface ILogsRepository : IRepository<Log>
    {
        List<Log> Page(int PageNumber, int PageSize);
    }
}