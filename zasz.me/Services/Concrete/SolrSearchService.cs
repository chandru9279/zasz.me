using SolrNet;
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
            return null;
        }

        public void AddPostToIndex(Post P)
        {
            _PostOp.Add(P);

        }
    }
}