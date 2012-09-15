using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using zasz.me.Models;

namespace zasz.me.Integration.EntityFramework
{
    public class ErrorLogs : RepoBase<Log, Guid>, ILogsRepository
    {
        public ErrorLogs(FullContext session) : base(session)
        {
        }

        #region ILogsRepository Members

        public override Log Save(Log instance)
        {
            using (var NewTransaction = new FullContext())
            {
                NewTransaction.ErrorLogs.Add(instance);
                NewTransaction.SaveChanges();
            }
            return instance;
        }

        public List<Log> Page(int PageNumber, int PageSize)
        {
            return ModelSet.OrderBy(Model => Model.Id).Skip(PageNumber*PageSize).Take(PageSize).ToList();
        }

        #endregion

        public override Expression<Func<Log, bool>> NaturalKeyComparison(Guid slug)
        {
            return x => x.Id == slug;
        }
    }
}