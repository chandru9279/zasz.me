using System.Configuration;

namespace zasz.me.Configuration
{
    public class SettingsConfig : ConfigurationSection
    {
        [ConfigurationProperty("MailAccount", DefaultValue = "zasz@zasz.me")]
        public string MailAccount
        {
            get
            { return (string)this["MailAccount"]; }
            set
            { this["MailAccount"] = value; }
        }
    }
}