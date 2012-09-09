using System.Configuration;

namespace zasz.me.Configuration
{
    public class SettingsConfig : ConfigurationSection
    {
        [ConfigurationProperty("MailAccount")]
        public string MailAccount
        {
            get { return (string) this["MailAccount"]; }
            set { this["MailAccount"] = value; }
        }

        [ConfigurationProperty("Solr")]
        public string Solr
        {
            get { return (string) this["Solr"]; }
            set { this["Solr"] = value; }
        }
    }
}