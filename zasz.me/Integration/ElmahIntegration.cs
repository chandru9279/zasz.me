using System;
using System.Collections;
using System.Web.Mvc;
using Elmah;

using zasz.me.Models;

namespace zasz.me.Integration
{
    public class ElmahAdaptor : ErrorLog
    {
        private readonly ILogsRepository repo;

        public ElmahAdaptor(IDictionary config)
        {
            repo = DependencyResolver.Current.GetService<ILogsRepository>();
        }

        public override string Log(Error error)
        {
            var aLog = new Log(error);
            repo.Save(aLog);
            return aLog.IdString;
        }

        public override ErrorLogEntry GetError(string Id)
        {
            var theLog = repo.Get(Guid.Parse(Id));
            return new ErrorLogEntry(this, theLog.IdString, theLog.Error);
        }

        public override int GetErrors(int PageIndex, int PageSize, IList ErrorEntryList)
        {
            repo.Page(PageIndex, PageSize).ForEach
                (It => ErrorEntryList.Add(new ErrorLogEntry(this, It.IdString, It.Error)));
            return repo.Count() > int.MaxValue ? int.MaxValue : (int) repo.Count();
        }
    }
}