using System.Collections.Generic;
using zasz.me.Areas.Shared.Models;
using zasz.me.Integration.SolrIntegration;

namespace zasz.me.Services.Contracts
{
    public interface ISearchService
    {
        SearchResults Search(string Term);

        void AddPostToIndex(Post P);

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
}