using System.Configuration;

namespace zasz.me.Configuration
{
    public class BlogConfig : ConfigurationSection
    {
        [ConfigurationProperty("MaxPostsPerPage", DefaultValue = 10)]
        public int MaxPostsPerPage
        {
            get
            { return (int)this["MaxPostsPerPage"]; }
            set
            { this["MaxPostsPerPage"] = value; }
        }

        [ConfigurationProperty("DescriptionLength", DefaultValue = 80)]
        public int DescriptionLength
        {
            get
            { return (int)this["DescriptionLength"]; }
            set
            { this["DescriptionLength"] = value; }
        }
    }
}