using System.Collections.Generic;
using System.Linq;
using Microsoft.Practices.ServiceLocation;
using SolrNet;
using SolrNet.Commands.Parameters;
using SolrNet.DSL;
using SolrNet.Mapping.Validation;
using zasz.me.Models;
using zasz.me.Services.Contracts;

namespace zasz.me.Services.Concrete
{
    public class SolrSearchService : ISearchService
    {
        private readonly ISolrOperations<Post> _PostOp; /* Pun Intended */
        private readonly IPostRepository _Posts;

        public SolrSearchService(IPostRepository Posts)
        {
            _Posts = Posts;
            _PostOp = ServiceLocator.Current.GetInstance<ISolrOperations<Post>>();
        }

        #region ISearchService Members

        public List<Post> MoreLikeThis(string PostId)
        {
            var MltHandler = new QueryOptions {ExtraParams = new Dictionary<string, string> {{"qt", "/mlt"}}};
            var Results = _PostOp.Query(Query.Field("Id").Is(PostId), MltHandler);
            return Results.Select(X => _Posts.Load(X.Id)).ToList();
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
            var Results = _PostOp.Query(Query.Simple(Term), SearchHandler);
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
            _PostOp.Add(P);
            _PostOp.Commit();
        }

        public void Index(IEnumerable<Post> P)
        {
            foreach (var Post in P)
                _PostOp.Add(Post);
            _PostOp.Commit();
        }

        #endregion

        public void ClearIndex()
        {
            _PostOp.Delete(Query.Simple("*:*"));
            _PostOp.Commit();
        }

        public IEnumerable<string> ValidateSchema()
        {
            IList<ValidationResult> Mismatches = _PostOp.EnumerateValidationResults().ToList();
            var Errors = Mismatches.OfType<ValidationError>();
            foreach (var Error in Errors)
                yield return "Mapping error: " + Error.Message;
            foreach (var Warning in Mismatches.OfType<ValidationWarning>())
                yield return "Mapping warning: " + Warning.Message;
        }
    }
}