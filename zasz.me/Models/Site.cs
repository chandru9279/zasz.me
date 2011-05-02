﻿using System.Collections.Generic;
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

        /*public bool Equals(Site Other)
        {
            if (ReferenceEquals(null, Other)) return false;
            if (ReferenceEquals(this, Other)) return true;
            return Equals(Other.Name, Name) || Equals(Other.Name, "Both");
        }

        public override bool Equals(object Obj)
        {
            if (ReferenceEquals(null, Obj)) return false;
            if (ReferenceEquals(this, Obj)) return true;
            if (Obj.GetType() != typeof (Site)) return false;
            return Equals((Site) Obj);
        }

        public override int GetHashCode()
        {
            return Name.GetHashCode();
        }

        public static bool operator ==(Site Left, Site Right)
        {
            return Equals(Left, Right);
        }

        public static bool operator !=(Site Left, Site Right)
        {
            return !Equals(Left, Right);
        }*/
    }
}