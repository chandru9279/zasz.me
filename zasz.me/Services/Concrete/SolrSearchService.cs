using System.Collections.Generic;
using System.Linq;

using SolrNet;
using SolrNet.Commands.Parameters;
using SolrNet.DSL;
using zasz.me.Models;
using zasz.me.Services.Contracts;

namespace zasz.me.Services.Concrete
{
    public class SolrSearchService : ISearchService
    {
        private readonly ISolrConnection connection;
        private readonly ISolrOperations<Post> postOp; /* Pun Intended */
        private readonly IPostRepository posts;

        public SolrSearchService(IPostRepository posts, ISolrOperations<Post> postOp, ISolrConnection connection)
        {
            this.posts = posts;
            this.postOp = postOp;
            this.connection = connection;
        }

        [Dependency("DescriptionLength")]
        public int DescriptionLength { get; set; }

        #region ISearchService Members

        public List<Post> MoreLikeThis(string postId)
        {
            var mltHandler = new QueryOptions {ExtraParams = new Dictionary<string, string> {{"qt", "/mlt"}}};
            var results = postOp.Query(Query.Field("Id").Is(postId), mltHandler);
            return results.Select(x => posts.Load(x.Id)).ToList();
        }

        public string AutoComplete(string input)
        {
            var results = connection.Get("/autosuggest", new Dictionary<string, string> {{"q", input}});
            const string suggestionsStart = "\"suggestion\":";
            var startIndex = results.IndexOf(suggestionsStart) + suggestionsStart.Length;
            return results.Substring(startIndex, results.IndexOf("]}") - startIndex + 1);
        }

        public SearchResults Search(string term)
        {
            var searchHandler = new QueryOptions {Start = 0, Rows = 10};
            var searchResults = new SearchResults();
            var results = postOp.Query(term, searchHandler);
            for (var result = 0; result < results.Count(); result++)
            {
                var id = results[result].Id.ToString().ToUpperInvariant();
                var hlForResult = results.Highlights[id];
                var snippet = hlForResult.ContainsKey("Post_Content")
                                  ? string.Join("... <br />", hlForResult["Post_Content"]) + "..."
                                  : results[result].GetDescription(DescriptionLength);
                searchResults.Results = results.Select(x => new SearchResult(x, snippet)).ToList();
            }
            searchResults.Spellchecking = results.SpellChecking.Collation;
            return searchResults;
        }

        public void Index(Post p)
        {
            postOp.Add(p);
            postOp.Commit();
        }

        public void Index(IEnumerable<Post> p)
        {
            foreach (var post in p)
                postOp.Add(post);
            postOp.Commit();
        }

        #endregion
    }
}