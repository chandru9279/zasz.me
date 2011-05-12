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

        public Log(string ID, Error Error)
        {
            this.ID = ID;
            this.Error = Error;
        }
    }

    public interface ILogsRepository : IRepository<Log>
    {
        List<Log> Page(int PageNumber, int PageSize);
    }
}