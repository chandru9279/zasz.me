using System.Web.Mvc;
using zasz.me.Shared.Models;

namespace zasz.me.Pro
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