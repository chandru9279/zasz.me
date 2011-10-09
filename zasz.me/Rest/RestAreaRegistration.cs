using System.Web.Mvc;
using zasz.me.Shared.Models;

namespace zasz.me.Rest
{
    public class RestAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get { return Site.REST; }
        }

        public override void RegisterArea(AreaRegistrationContext Context)
        {
        }
    }
}