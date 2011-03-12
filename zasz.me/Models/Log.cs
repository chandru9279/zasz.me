using Elmah;

namespace zasz.me.Models
{
    public class Log
    {
        [ID]
        public string Id { get; set; }

        public Error Error { get; set; }

        public Log(string Id, Error Error)
        {
            this.Id = Id;
            this.Error = Error;
        }
    }

    public interface ILogsRepository : IRepository<Log>
    {
    }
}