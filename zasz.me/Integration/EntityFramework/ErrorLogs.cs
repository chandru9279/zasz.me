using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using zasz.me.Areas.Shared.Models;

namespace zasz.me.Integration.EntityFramework
{
    public class ErrorLogs : RepoBase<Log, Guid>, ILogsRepository
    {
        public ErrorLogs(FullContext Session) : base(Session)
        {
        }

        public override Log Save(Log Instance)
        {
            using (var NewTransaction = new FullContext())
            {
                NewTransaction.ErrorLogs.Add(Instance);
                NewTransaction.SaveChanges();
            }
            return Instance;
        }

        public override Expression<Func<Log, bool>> NaturalKeyComparison(Guid Id)
        {
            return It => It.Id == Id;
        }

        public List<Log> Page(int PageNumber, int PageSize)
        {
            return _ModelSet.OrderBy(Model => Model.Id).Skip(PageNumber*PageSize).Take(PageSize).ToList();
        }
    }
}