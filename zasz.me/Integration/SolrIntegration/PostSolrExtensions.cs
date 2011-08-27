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
            Manager.Add(PostType.GetProperty("Content"), "Post_Content");
            Manager.Add(PostType.GetProperty("Tags"), "Post_Tags", 1.5f);
            Manager.Add(PostType.GetProperty("Slug"), "Post_Slug");
            Manager.Add(PostType.GetProperty("Title"), "Post_Title", 2.0f);
        }
    }


    public class PostSearchResult
    {
        public PostSearchResult(string Id, string Link, string Snippet)
        {
            this.Id = Id;
            this.Link = Link;
            this.Snippet = Snippet;
        }

        public string Id { get; set; }
        public string Link { get; set; }
        public string Snippet { get; set; }
    }
}