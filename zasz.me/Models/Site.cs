using System;
using System.Collections.Generic;
using System.Reflection;
using Newtonsoft.Json;

namespace zasz.me.Models
{
    [JsonConverter(typeof (SiteJsonConverter))]
    public class Site
    {
        private static readonly List<Site> Sites = new List<Site>();

        private Site(string Host, string AreaName, string AreaUrl)
        {
            this.Host = Host;
            Name = AreaName;
            VirtualPath = AreaUrl;
        }

        [JsonIgnore]
        public string Host { get; set; }

        public string Name { get; set; }

        [JsonIgnore]
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

        #region Nested type: SiteJsonConverter

        public class SiteJsonConverter : JsonConverter
        {
            public override void WriteJson(JsonWriter Writer, object Value, JsonSerializer Serializer)
            {
                PropertyInfo NameProperty = Value.GetType().GetProperty("Name");
                Writer.WriteStartObject();
                Writer.WritePropertyName("Name");
                Serializer.Serialize(Writer, NameProperty.GetValue(Value, null));
                Writer.WriteEndObject();
            }

            public override object ReadJson(JsonReader Reader, Type ObjectType, object ExistingValue, JsonSerializer Serializer)
            {
                var a = Reader.Read();
                var a1 = Reader.Read();
                object Name = Serializer.Deserialize(Reader, typeof(string));
                var a2 = Reader.Read();
                return WithName(Name.ToString());
            }

            public override bool CanConvert(Type ObjectType)
            {
                return ObjectType.Equals(typeof (Site));
            }
        }

        #endregion
    }
}