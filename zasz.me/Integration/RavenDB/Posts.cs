using System.Collections.Generic;
using System.Linq;
using Raven.Client;
using zasz.me.Models;

namespace zasz.me.Integration.RavenDB
{
    public class Posts : RepoBase<Post>, IPostRepository
    {
        public Posts(IDocumentStore Store) : base(Store)
        {
        }

        #region IPostRepository Members

        public Post FromSlug(string Slug)
        {
            return Session.Query<Post>("PostSlugIndex").First(Entry => Entry.Slug == Slug);
        }

        public List<Post> RecentPosts(int howMany)
        {
            return Session.Query<Post>().OrderByDescending(Post => Post.Timestamp).Take(howMany).ToList();
        }

        public List<Post> FromTag(string Tag)
        {
            return Session.Query<Post>().Where(Entry => Entry.Tags.Any(EntryTag => EntryTag == Tag)).ToList();
        }

        #endregion
    }
}