using System.Web.Configuration;
using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.Configuration;

namespace zasz.me.Configuration
{
    public class Config
    {
        public static UnityConfigurationSection Unity
        {
            get { return WebConfigurationManager.GetWebApplicationSection("unity") as UnityConfigurationSection; }
        }

        public static UploadsConfig Uploads
        {
            get { return WebConfigurationManager.GetWebApplicationSection("zasz.me/Uploads") as UploadsConfig; }
        }

        public static BlogConfig Blog
        {
            get { return WebConfigurationManager.GetWebApplicationSection("zasz.me/Blog") as BlogConfig; }
        }

        public static SettingsConfig Settings
        {
            get { return WebConfigurationManager.GetWebApplicationSection("zasz.me/Settings") as SettingsConfig; }
        }

        public static void PutConfigurationAndSettingsInside(IUnityContainer bigBox)
        {
            // Type auto inferred
            bigBox.RegisterInstance("MaxPostsPerPage", Blog.MaxPostsPerPage);
            bigBox.RegisterInstance("DescriptionLength", Blog.DescriptionLength);
            bigBox.RegisterInstance("MailAccount", Settings.MailAccount);
            bigBox.RegisterInstance("SolrServer", Settings.Solr);
            bigBox.RegisterInstance(Uploads);
        }
    }
}