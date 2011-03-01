using System;
using System.Collections.Generic;

namespace zasz.me.Models
{
    public class Post
    {
        public string Id { get; set; }

        public string Area { get; set; }

        public string Permalink { get; set; }

        public string Slug { get; set; }

        public string Content { get; set; }

        public List<string> Tags { get; set; }

        public DateTime Timestamp { get; set; }
    }

    public interface IPostRepository : IRepository<Post>
    {
        Post FromSlug(string Slug);

        List<Post> RecentPosts(int howMany);

        List<Post> FromTag(string tag);
    }
}