using System;
using System.Collections;
using Elmah;
using zasz.me.Areas.Shared.Models;

namespace zasz.me.Integration
{
    public class ElmahAdaptor : ErrorLog
    {
        private readonly ILogsRepository _Repo;

        public ElmahAdaptor(IDictionary Config)
        {
            _Repo = HugeBox.Grab<ILogsRepository>();
        }

        public override string Log(Error Error)
        {
            var ALog = new Log(Error);
            _Repo.Save(ALog);
            return ALog.IdString;
        }

        public override ErrorLogEntry GetError(string Id)
        {
            Log TheLog = _Repo.Get(Guid.Parse(Id));
            return new ErrorLogEntry(this, TheLog.IdString, TheLog.Error);
        }

        public override int GetErrors(int PageIndex, int PageSize, IList ErrorEntryList)
        {
            _Repo.Page(PageIndex, PageSize).ForEach
                (It => ErrorEntryList.Add(new ErrorLogEntry(this, It.IdString, It.Error)));
            return _Repo.Count() > int.MaxValue ? int.MaxValue : (int) _Repo.Count();
        }
    }
}