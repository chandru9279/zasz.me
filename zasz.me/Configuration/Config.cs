using System.Web.Configuration;
using Autofac;

namespace zasz.me.Configuration
{
    public class Config
    {
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

        public static void GetInto(ContainerBuilder bigBox)
        {
            // Type auto inferred
            bigBox.Register<string>((c, p) => { p.Named<string>("MaxPostsPerPage")});
            bigBox.RegisterInstance("MaxPostsPerPage", Blog.MaxPostsPerPage);
            bigBox.RegisterInstance("DescriptionLength", Blog.DescriptionLength);
            bigBox.RegisterInstance("MailAccount", Settings.MailAccount);
            bigBox.RegisterInstance("SolrServer", Settings.Solr);
            bigBox.RegisterInstance(Uploads);
        }
    }
}