using Elmah;

namespace zasz.me.Models
{
    public class Log
    {
        public Log(string Id, Error Error)
        {
            this.Id = Id;
            this.Error = Error;
        }

        public string Id { get; set; }

        public Error Error { get; set; }
    }

    public interface ILogsRepository : IRepository<Log>
    {
    }
}