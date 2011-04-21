using zasz.me.Models;

namespace zasz.me.Integration.EntityFramework
{
    public class ErrorLogs : RepoBase<Log>, ILogsRepository
    {
        public ErrorLogs(FullContext Session) : base(Session)
        {
        }
    }
}