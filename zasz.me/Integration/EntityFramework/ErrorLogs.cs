using System.Collections.Generic;
using System.Linq;
using zasz.me.Areas.Shared.Models;

namespace zasz.me.Integration.EntityFramework
{
    public class ErrorLogs : RepoBase<Log>, ILogsRepository
    {
        public ErrorLogs(FullContext Session) : base(Session)
        {
        }

        public List<Log> Page(int PageNumber, int PageSize)
        {
            return _ModelSet.OrderBy(Model => Model.ID).Skip(PageNumber * PageSize).Take(PageSize).ToList();
        }
    }
}