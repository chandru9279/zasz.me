using System.Collections;
using System.Linq;
using Elmah;
using zasz.me.Models;

namespace zasz.me.Integration
{
    public class ElmahAdaptor : ErrorLog
    {
        private readonly ILogsRepository _Repo;

        public ElmahAdaptor()
        {
            _Repo = HugeBox.Grab<ILogsRepository>();
        }

        public override string Log(Error Error)
        {
            var ALog = new Log(null, Error);
            _Repo.Save(ALog);
            return ALog.ID;
        }

        public override ErrorLogEntry GetError(string Id)
        {
            Log TheLog = _Repo.Get(Id);
            return new ErrorLogEntry(this, TheLog.ID, TheLog.Error);
        }

        public override int GetErrors(int PageIndex, int PageSize, IList ErrorEntryList)
        {
            var logs = _Repo.Page(PageIndex, PageSize);
            ErrorEntryList.Add(logs);
            return _Repo.Count() > int.MaxValue ? int.MaxValue : (int) _Repo.Count();
        }
    }
}