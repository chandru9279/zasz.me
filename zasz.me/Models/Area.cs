using System;
using System.Collections.Generic;

namespace zasz.me.Models
{
    public enum Area : byte
    {
        Pro,
        Rest,
        Admin
    }

    public class AreaSite
    {
        public AreaSite(Area Area, string Host, string AreaName)
        {
            this.Area = Area;
            this.Host = Host;
            this.AreaName = AreaName;
            AreaUrl = "~/" + AreaName;
        }

        public Area Area { get; set; }

        public string Host { get; set; }

        public string AreaName { get; set; }

        public string AreaUrl { get; set; }

        public bool Equals(AreaSite other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return Equals(other.Area, Area);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != typeof (AreaSite)) return false;
            return Equals((AreaSite) obj);
        }

        public override int GetHashCode()
        {
            return Area.GetHashCode();
        }
    }

    public static class Areas
    {
        public static HashSet<AreaSite> Sites = new HashSet<AreaSite>();

        public static void Add(Area Area, string Host, string AreaName)
        {
            Sites.Add(new AreaSite(Area, Host, AreaName));
        }

        public static string Url(String Host)
        {
            foreach (AreaSite AreaSite in Sites)
            {
                if (AreaSite.Host == Host)
                    return AreaSite.AreaUrl;
            }
            return "~/Home/Show";
        }
    }
}