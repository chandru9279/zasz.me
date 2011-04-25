using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace zasz.me.Models
{
    [ComplexType]
    public class Site
    {
        private static readonly List<Site> _Sites = new List<Site>();

        private Site(string Host, string AreaName, string AreaUrl)
        {
            this.Host = Host;
            Name = AreaName;
            VirtualPath = AreaUrl;
        }

        /* Should not be used in code, present for use by entity framework only*/
        public Site()
        {
        }

        [NotMapped]
        public string Host { get; set; }

        public string Name { get; set; }

        [NotMapped]
        public string VirtualPath { get; set; }

        public static void Register(string Host, string AreaName, string AreaUrl)
        {
            _Sites.Add(new Site(Host, AreaName, AreaUrl));
        }

        public static void Register(string Host, string AreaName)
        {
            _Sites.Add(new Site(Host, AreaName, "~/" + AreaName));
        }

        public static Site WithHost(string Host)
        {
            return _Sites.Find(Site => Site.Host == Host);
        }

        public static Site WithName(string Name)
        {
            return _Sites.Find(Site => Site.Name == Name);
        }
    }
}