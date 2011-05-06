using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace zasz.me.Areas.Shared.Models
{
    [ComplexType]
    public class Site
    {
        private static readonly List<Site> _Sites = new List<Site>();

        private Site(string Host, Domain AreaName)
        {
            this.Host = Host;
            Name = AreaName.ToString();
        }

        /* Should not be used in code, present for use by entity framework only*/
        public Site()
        {
        }

        [NotMapped]
        public string Host { get; set; }

        public string Name { get; set; }

        public static void Register(string Host, Domain Domain)
        {
            _Sites.Add(new Site(Host, Domain));
        }

        public static Site WithName(string Name)
        {
            return _Sites.Find(Site => Site.Name == Name);
        }
    }

    public enum Domain
    {
        Pro,
        Rest,
        Both
    }
}