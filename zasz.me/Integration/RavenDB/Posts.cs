using System.Collections.Generic;
using System.Linq;
using Raven.Client.Document;
using Raven.Client.Indexes;
using zasz.me.Models;

namespace zasz.me.Integration.RavenDB
{
    public class Posts : RepoBase<Post>, IPostRepository
    {
        public Posts(DocumentStore Store)
            : base(Store)
        {
            if (null == _Store.DatabaseCommands.GetIndex("PostSlugIndex"))
                _Store.DatabaseCommands.PutIndex(
                    "PostSlugIndex",
                    new IndexDefinition<Post>
                        {
                            Map = Posts => from EachPost in Posts
                                           select EachPost.Slug
                        });
        }

        #region IPostRepository Members

        public Post FromSlug(string Slug)
        {
            using(var Session = _Store.OpenSession())
            {
                return Session.Query<Post>("PostSlugIndex").First(Entry => Entry.Slug == Slug);
            }
        }

        public List<Post> RecentPosts(int howMany)
        {
            using (var Session = _Store.OpenSession())
            {
                return Session.Query<Post>().OrderByDescending(Post => Post.Timestamp).Take(howMany).ToList();
            }
        }

        public List<Post> FromTag(string Tag)
        {
            using (var Session = _Store.OpenSession())
            {
                return Session.Query<Post>().Where(Entry => Entry.Tags.Any(EntryTag => EntryTag == Tag)).ToList();
            }
        }

        #endregion
    }
}