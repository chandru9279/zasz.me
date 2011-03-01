using Raven.Client.Document;
using zasz.me.Models;

namespace zasz.me.Integration.RavenDB
{
    public class ErrorLogs : RepoBase<Log>, ILogsRepository
    {
        public ErrorLogs(DocumentStore Store) : base(Store)
        {
        }
    }
}