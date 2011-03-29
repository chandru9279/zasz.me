using Elmah;

namespace zasz.me.Models
{
    public class Log
    {
        [ID]
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
    }
}