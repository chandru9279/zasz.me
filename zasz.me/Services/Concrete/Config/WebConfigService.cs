using System.Web.Configuration;
using zasz.me.Services.Contracts;

namespace zasz.me.Services.Concrete.Config
{
    public class WebConfigService : IConfigurationService
    {
        public BlogConfig Blog
        {
            get { return WebConfigurationManager.GetWebApplicationSection("zasz.me/Blog") as BlogConfig; }
        }

        public SettingsConfig Settings
        {
            get { return WebConfigurationManager.GetWebApplicationSection("zasz.me/Settings") as SettingsConfig; }
        }
    }
}