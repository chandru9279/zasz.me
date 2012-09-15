using System.Collections.Generic;
using System.Linq;
using Microsoft.Practices.ServiceLocation;
using SolrNet;
using SolrNet.Commands.Parameters;
using SolrNet.DSL;
using zasz.me.Models;
using zasz.me.Services.Contracts;

namespace zasz.me.Services.Concrete
{
    public class SolrSearchService : ISearchService
    {
        private readonly ISolrOperations<Post> postOp; /* Pun Intended */
        private readonly IPostRepository posts;

        public SolrSearchService(IPostRepository posts, ISolrOperations<Post> postOp)
        {
            this.posts = posts;
            this.postOp = postOp;
        }

        #region ISearchService Members

        public List<Post> MoreLikeThis(string PostId)
        {
            var MltHandler = new QueryOptions {ExtraParams = new Dictionary<string, string> {{"qt", "/mlt"}}};
            var Results = postOp.Query(Query.Field("Id").Is(PostId), MltHandler);
            return Results.Select(X => posts.Load(X.Id)).ToList();
        }

        public string AutoComplete(string Input)
        {
            return ServiceLocator.Current.GetInstance<ISolrConnection>().Get("/autocomplete",
                                                                             new Dictionary<string, string>
                                                                                 {{"terms.regex", Input + ".*"}});
        }

        public SearchResults Search(string Term)
        {
            var SearchHandler = new QueryOptions
                                    {
                                        Start = 0,
                                        Rows = 10,
                                        ExtraParams = new Dictionary<string, string> {{"qt", "/search"}}
                                    };
            var SearchResults = new SearchResults();
            var Results = postOp.Query(Query.Simple(Term), SearchHandler);
            for (var I = 0; I < Results.NumFound; I++)
            {
                var Id = Results[I].Id.ToString();
                var Snippet = Results.Highlights[Id]["Post_Content"];
                SearchResults.Add(new SearchResult(Id, Results[I].Title, "/Blog/" + Results[I].Slug,
                                                   string.Join("...", Snippet)));
            }
            SearchResults.Spellchecking = Results.SpellChecking.Collation;

            return SearchResults;
        }

        public void Index(Post P)
        {
            postOp.Add(P);
            postOp.Commit();
        }

        public void Index(IEnumerable<Post> P)
        {
            foreach (var Post in P)
                postOp.Add(Post);
            postOp.Commit();
        }

        #endregion

        public void ClearIndex()
        {
            postOp.Delete(Query.Simple("*:*"));
            postOp.Commit();
        }
    }
}