using System;
using System.Linq;
using zasz.me.Models;

namespace zasz.me.Integration.EntityFramework
{
    public class LogsRepository : Repository<Log, Guid>, ILogsRepository
    {
        public LogsRepository(FullContext context) : base(context)
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

        public override Paged<Log> Page(int pageNumber, int pageSize)
        {
            return PageQuery(Set.OrderBy(x => x.Id), pageNumber, pageSize);
        }

        #endregion
    }
}