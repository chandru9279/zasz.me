using SolrNet.Mapping;
using zasz.me.Areas.Shared.Models;

namespace zasz.me.Integration.SolrIntegration
{
    public static class PostSolrExtensions
    {
        public static void Map()
        {
            var Manager = new MappingManager();
            var PostType = typeof (Post);
            var IdentityProperty = PostType.GetProperty("Id");
            Manager.Add(IdentityProperty, "Id");
            Manager.SetUniqueKey(IdentityProperty);
            Manager.Add(PostType.GetProperty("Content"), "Post.Content");
            Manager.Add(PostType.GetProperty("Tags"), "Post.Tags", 1.5f);
            Manager.Add(PostType.GetProperty("Slug"), "Post.Slug");
            Manager.Add(PostType.GetProperty("Title"), "Post.Title", 2.0f);
        }
    }


    public class PostSearchResult
    {
        public PostSearchResult(string Id, string Permalink, string Context)
        {
            this.Id = Id;
            this.Permalink = Permalink;
            this.Context = Context;
        }

        public string Id { get; set; }
        public string Permalink { get; set; }
        public string Context { get; set; }
    }
}