using System.Collections.Generic;
using SolrNet;
using SolrNet.DSL;
using zasz.me.Areas.Shared.Models;
using zasz.me.Services.Contracts;

namespace zasz.me.Services.Concrete
{
    public class SolrSearchService : ISearchService
    {
        private readonly ISolrOperations<Post> _PostOp;

        public SolrSearchService(ISolrOperations<Post> PostOp /* Pun Intended */)
        {
            _PostOp = PostOp;
        }

        public SearchResults Search(string Term)
        {
            var Results = _PostOp.Query(Query.Simple(Term));
            var p = Results.SimilarResults;
            var p1 = Results.SpellChecking;
            var p2 = Results.Header;
            var p3 = Results.Highlights;
            var p4 = Results.Collapsing;
            var p5 = Results[0];
            var p6 = Results[1];
            var p7 = Results[2];
            return new SearchResults
                       {
                           
                       };
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
    }
}