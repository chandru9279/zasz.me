using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using zasz.me.Models;

namespace zasz.me.Integration.EntityFramework
{
    public class ErrorLogs : RepoBase<Log, Guid>, ILogsRepository
    {
        public ErrorLogs(FullContext Session) : base(Session)
        {
        }

        #region ILogsRepository Members

        public override Log Save(Log Instance)
        {
            using (var NewTransaction = new FullContext())
            {
                NewTransaction.ErrorLogs.Add(Instance);
                NewTransaction.SaveChanges();
            }
            return Instance;
        }

        public List<Log> Page(int PageNumber, int PageSize)
        {
            return _ModelSet.OrderBy(Model => Model.Id).Skip(PageNumber*PageSize).Take(PageSize).ToList();
        }

        #endregion

        public override Expression<Func<Log, bool>> NaturalKeyComparison(Guid Id)
        {
            return x => x.Id == Id;
        }
    }
}