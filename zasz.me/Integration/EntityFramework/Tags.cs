﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using zasz.me.Models;

namespace zasz.me.Integration.EntityFramework
{
    public class Tags : RepoBase<Tag, string>, ITagRepository
    {
        public Tags(FullContext Session) : base(Session)
        {
        }

        #region ITagRepository Members

        public List<Post> PagePosts(string Tag, int PageNumber, int MaxPostsPerPage, Site ProOrRest)
        {
            return (from EachPost in Get(Tag).Posts
                    where EachPost.Site.Name == ProOrRest.Name || EachPost.Site.Name == Site.SHARED
                    select EachPost).Skip(PageNumber*MaxPostsPerPage).Take(MaxPostsPerPage).ToList();
        }

        public int CountPosts(string Tag, Site ProOrRest)
        {
            return (from EachPost in Get(Tag).Posts
                    where EachPost.Site.Name == ProOrRest.Name || EachPost.Site.Name == Site.SHARED
                    select EachPost).Count();
        }

        public Dictionary<string, int> WeightedList(Site ProOrRest)
        {
            return (from EachTag in _Session.Tags
                    let Count = (from EachPost in EachTag.Posts
                                 where EachPost.Site.Name == ProOrRest.Name || EachPost.Site.Name == Site.SHARED
                                 select EachPost).Count()
                    where Count > 0
                    select new {EachTag.Name, Count}).ToDictionary(x => x.Name, x => x.Count);
        }

        #endregion

        public override Expression<Func<Tag, bool>> NaturalKeyComparison(string TagName)
        {
            return x => x.Name == TagName;
        }
    }
}