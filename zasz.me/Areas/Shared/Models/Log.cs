using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Elmah;

namespace zasz.me.Areas.Shared.Models
{
    public class Log : IModel<Log, Guid>
    {
        public Log()
        {
        }

        public Log(Error Error)
        {
            Id = Guid.NewGuid();
            this.Error = Error;
        }

        [Key]
        public Guid Id { get; set; }

        public Error Error { get; set; }

        public string IdString
        {
            get { return Id.ToString(); }
        }

        public Func<Log, bool> NaturalEquals(Guid NewId)
        {
            return It=> It.Id == NewId;
        }
    }

    public interface ILogsRepository : IRepository<Log, Guid>
    {
        List<Log> Page(int PageNumber, int PageSize);
    }
}