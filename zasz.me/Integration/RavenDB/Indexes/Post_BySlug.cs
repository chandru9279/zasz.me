using System.Linq;
using Raven.Client.Indexes;
using Raven.Database.Indexing;
using zasz.me.Models;

namespace zasz.me.Integration.RavenDB.Indexes
{
    public class Post_BySlug : AbstractIndexCreationTask
    {
        public override string IndexName
        {
            get { return "Posts/BySlug"; }
        }

        public override IndexDefinition CreateIndexDefinition()
        {
            return new IndexDefinition<Post>
                       {
                           Map = Posts => from EachPost in Posts
                                          select new
                                                     {
                                                         EachPost.Slug
                                                     }
                       }.ToIndexDefinition(Conventions);
        }
    }
}