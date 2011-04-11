using Raven.Client;
using zasz.me.Models;

namespace zasz.me.Integration.RavenDB
{
    public class ErrorLogs : RepoBase<Log>, ILogsRepository
    {
        public ErrorLogs(IDocumentSession Session) : base(Session)
        {
        }
    }
}