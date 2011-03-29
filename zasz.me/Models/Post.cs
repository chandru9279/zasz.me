using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace zasz.me.Models
{
    public class Post
    {
        private List<string> _Tags = new List<string>();

        [JsonConverter(typeof(Site.SiteJsonConverter))]
        public Site Site { get; set; }

        public string Title { get; set; }

        [ID]
        public string Slug { get; set; }

        public string Content { get; set; }

        public List<string> Tags
        {
            get { return _Tags ?? (_Tags = new List<string>()); }
            set { _Tags = value; }
        }

        public DateTime Timestamp { get; set; }

        [JsonIgnore]
        public string Permalink
        {
            get { return string.Format("http://{0}/{1}/post/{2}", Site.Host, Site.Name, Slug); }
        }
    }

    public interface IPostRepository : IRepository<Post>
    {
        Post FromSlug(string Slug);

        List<Post> RecentPosts(int HowMany);

        List<Post> FromTag(string Tag);
    }
}