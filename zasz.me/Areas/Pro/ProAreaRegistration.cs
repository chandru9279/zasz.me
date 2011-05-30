using System.Web.Mvc;
using zasz.me.Areas.Shared.Models;

namespace zasz.me.Areas.Pro
{
    public class ProAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get { return Domain.Pro.ToString(); }
        }

        public override void RegisterArea(AreaRegistrationContext Context)
        {
            Site.Register("chandruon.net", Domain.Pro);
        }
    }
}