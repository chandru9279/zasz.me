using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace zasz.me.Areas.Shared.Models
{
    [ComplexType]
    public class Site
    {
        public const string PRO = "Pro";
        public const string REST = "Rest";
        public const string SHARED = "Shared";

        public static readonly Site Pro = new Site("chandruon.net", PRO);
        public static readonly Site Rest = new Site("zasz.me", REST);
        public static readonly Site Shared = new Site("chandruon.net", SHARED);


        private Site(string Host, string Domain)
        {
            this.Host = Host;
            Name = Domain;
        }

        [Obsolete("Should not be used in code, present for use by entity framework only", true)]
        public Site()
        {
        }

        [NotMapped]
        public string Host { get; set; }

        public string Name { get; set; }

        public static Site With(string DomainName)
        {
            return (from Domain in new[] {Pro, Rest, Shared}
                    where Domain.Name == DomainName
                    select Domain).FirstOrDefault();
        }
    }
}