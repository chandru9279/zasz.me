using System.Collections.Generic;
using System.Linq;
using zasz.me.Models;

namespace zasz.me.Integration.EntityFramework
{
    public class Tags : RepoBase<Tag>, ITagRepository
    {
        public Tags(FullContext Session) : base(Session)
        {
        }

        public Tag FindOrNew(string Name)
        {
            return Get(Name) ?? new Tag(Name);
        }

        public List<Post> PagePosts(string Tag, int PageNumber, int MaxPostsPerPage, Site ProOrRest)
        {
            return (from EachPost in Get(Tag).Posts
                    where EachPost.Site.Name == ProOrRest.Name || EachPost.Site.Name == "Both"
                    select EachPost).Skip(PageNumber * MaxPostsPerPage).Take(MaxPostsPerPage).ToList();
        }
    }
}