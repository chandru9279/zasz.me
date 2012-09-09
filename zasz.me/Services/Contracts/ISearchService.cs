using System.Collections.Generic;
using zasz.me.Models;

namespace zasz.me.Services.Contracts
{
    public interface ISearchService
    {
        SearchResults Search(string Term);

        List<Post> MoreLikeThis(string PostId);

        string AutoComplete(string Input);

        void Index(Post P);

        void Index(IEnumerable<Post> P);

        /* Use DotNetOpenAuth and store comments in my site with Recaptcha? 
         * Brave enough to delete Comments to WXR and Disqus integration?
         * All for what - Comments import from old site will be easier, and 
         * comments are indexed by googol. And know-how on open auth background.
            
           void AddCommentToIndex(Comment C);
         */
    }

    public class SearchResults : List<SearchResult>
    {
        public string Query { get; set; }
        public string Spellchecking { get; set; }
    }

    public class SearchResult
    {
        public SearchResult(string Id, string Title, string Link, string Snippet)
        {
            this.Id = Id;
            this.Title = Title;
            this.Link = Link;
            this.Snippet = Snippet;
        }

        public string Id { get; set; }
        public string Title { get; set; }
        public string Link { get; set; }
        public string Snippet { get; set; }
    }
}