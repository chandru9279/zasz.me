using System;
using System.Collections.Generic;

namespace zasz.me.Models
{
    public class Post
    {
        public Site Site { get; set; }

        public string Permalink { get; set; }

        public string Title { get; set; }

        [ID]
        public string Slug { get; set; }

        public string Content { get; set; }

        public List<string> Tags { get; set; }

        public DateTime Timestamp { get; set; }
    }

    public interface IPostRepository : IRepository<Post>
    {
        Post FromSlug(string Slug);

        List<Post> RecentPosts(int HowMany);

        List<Post> FromTag(string Tag);
    }
}