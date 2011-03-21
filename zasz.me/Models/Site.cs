using System.Collections.Generic;

namespace zasz.me.Models
{
    public class Site
    {
        private static readonly List<Site> Sites = new List<Site>();

        private Site(string Host, string AreaName, string AreaUrl)
        {
            this.Host = Host;
            this.Name = AreaName;
            this.VirtualPath = AreaUrl;
        }

        public string Host { get; set; }

        public string Name { get; set; }

        public string VirtualPath { get; set; }

        public static void Register(string Host, string AreaName, string AreaUrl)
        {
            Sites.Add(new Site(Host, AreaName, AreaUrl));
        }

        public static void Register(string Host, string AreaName)
        {
            Sites.Add(new Site(Host, AreaName, "~/" + AreaName));
        }

        public static Site WithHost(string Host)
        {
            return Sites.Find(Site => Site.Host == Host);
        }

        public static Site WithName(string Name)
        {
            return Sites.Find(Site => Site.Name == Name);
        }
    }
}