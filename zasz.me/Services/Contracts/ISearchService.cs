using System.Collections.Generic;
using zasz.me.Integration.SolrIntegration;
using zasz.me.Shared.Models;

namespace zasz.me.Services.Contracts
{
    public interface ISearchService
    {
        SearchResults Search(string Term);

        void Index(Post P);

        void Index(IEnumerable<Post> P);

        /* Use DotNetOpenAuth and store comments in my site with Recaptcha? 
         * Brave enough to delete Comments to WXR and Disqus integration?
         * All for what - Comments import from old site will be easier, and 
         * comments are indexed by googol. And know-how on open auth background.
            
           void AddCommentToIndex(Comment C);
         */

    }

    public class SearchResults
    {
        public List<PostSearchResult> PostResults { get; set; }
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