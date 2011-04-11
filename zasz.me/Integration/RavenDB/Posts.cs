using System.Collections.Generic;
using System.Linq;
using Raven.Client;
using zasz.me.Integration.RavenDB.Indexes;
using zasz.me.Models;

namespace zasz.me.Integration.RavenDB
{
    public class Posts : RepoBase<Post>, IPostRepository
    {
        public Posts(IDocumentSession Session)
            : base(Session)
        {
        }

        #region IPostRepository Members

        public Post FromSlug(string Slug)
        {
            return _Session.Load<Post>(Slug);
        }

        public List<Post> RecentPosts(int howMany)
        {
            return _Session.Query<Post>().OrderByDescending(Post => Post.Timestamp).Take(howMany).ToList();
        }

        public List<Post> FromTag(string Tag)
        {
            return _Session.Query<Post>().Where(Entry => Entry.Tags.Any(EntryTag => EntryTag == Tag)).ToList();
        }

        #endregion
    }
}