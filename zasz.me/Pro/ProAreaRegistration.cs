using System.Web.Mvc;
using zasz.me.Areas.Shared.Models;

namespace zasz.me.Areas.Pro
{
    public class ProAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get { return Site.PRO; }
        }

        public override void RegisterArea(AreaRegistrationContext Context)
        {
        }
    }
}