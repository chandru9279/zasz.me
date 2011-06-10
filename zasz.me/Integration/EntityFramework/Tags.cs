using System.Collections.Generic;
using System.Linq;
using zasz.me.Areas.Shared.Models;

namespace zasz.me.Integration.EntityFramework
{
    public class Tags : RepoBase<Tag>, ITagRepository
    {
        public Tags(FullContext Session) : base(Session)
        {
        }

        public List<Post> PagePosts(string Tag, int PageNumber, int MaxPostsPerPage, Site ProOrRest)
        {
            return (from EachPost in Get(Tag).Posts
                    where EachPost.Site.Name == ProOrRest.Name || EachPost.Site.Name == "Both"
                    select EachPost).Skip(PageNumber * MaxPostsPerPage).Take(MaxPostsPerPage).ToList();
        }

        public int CountPosts(string Tag, Site ProOrRest)
        {
            return (from EachPost in Get(Tag).Posts
                    where EachPost.Site.Name == ProOrRest.Name || EachPost.Site.Name == "Both"
                    select EachPost).Count();
        }

        public Dictionary<string, int> WeightedList(Site ProOrRest)
        {
            return (from EachTag in _Session.Tags
                    let Count = (from EachPost in EachTag.Posts
                                 where EachPost.Site.Name == ProOrRest.Name || EachPost.Site.Name == "Both"
                                 select EachPost).Count()
                    where Count > 0
                    select new {EachTag.Name, Count}).ToDictionary(It => It.Name, It => It.Count);

        }
    }
}