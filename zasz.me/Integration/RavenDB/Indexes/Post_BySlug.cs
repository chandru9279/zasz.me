using System.Linq;
using Raven.Client.Indexes;
using Raven.Database.Indexing;
using zasz.me.Models;

namespace zasz.me.Integration.RavenDB.Indexes
{
    // Convention-named : "Post/BySlug"
    public class Post_BySlug : AbstractIndexCreationTask
    {
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