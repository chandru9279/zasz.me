using System.Configuration;

namespace zasz.me.Configuration
{
    public class WritingsConfig : ConfigurationSection
    {
        [ConfigurationProperty("MaxPostsPerPage", DefaultValue = 10)]
        public int MaxPostsPerPage
        {
            get
            { return (int)this["MaxPostsPerPage"]; }
            set
            { this["MaxPostsPerPage"] = value; }
        }
    }
}