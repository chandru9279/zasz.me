using System.Collections.Generic;
using zasz.me.Models;

namespace zasz.me.Services.Contracts
{
    public interface ISearchService
    {
        SearchResults Search(string term);

        List<Post> MoreLikeThis(string postId);

        string AutoComplete(string input);

        void Index(Post p);

        void Index(IEnumerable<Post> p);
    }

    public class SearchResults
    {
        public List<SearchResult> Results { get; set; }
        public string Query { get; set; }
        public string Spellchecking { get; set; }
    }

    public class SearchResult
    {
        public SearchResult(Post post, string snippet)
        {
            Post = post;
            Snippet = snippet;
        }

        public Post Post { get; set; }
        public string Snippet { get; set; }
    }
}