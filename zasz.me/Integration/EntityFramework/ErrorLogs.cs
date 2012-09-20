using System;
using System.Collections.Generic;
using System.Linq;
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
            using (var transaction = new FullContext())
            {
                transaction.ErrorLogs.Add(instance);
                transaction.SaveChanges();
            }
            return instance;
        }

        public List<Log> Page(int pageNumber, int pageSize)
        {
            return ModelSet.OrderBy(x => x.Id).Skip(pageNumber*pageSize).Take(pageSize).ToList();
        }

        #endregion
    }
}