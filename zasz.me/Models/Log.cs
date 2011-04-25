using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Elmah;

namespace zasz.me.Models
{
    public class Log : IModel
    {
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