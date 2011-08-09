using System;
using Elmah;
using zasz.me.Areas.Shared.Models;

namespace zasz.me.Services
{
    public class SearchService
    {
        public IPostRepository Posts { get; set; }

        public SearchService(IPostRepository Posts)
        {
            this.Posts = Posts;
        }

        public void Search(string Term)
        {
        }

        public void AddPostToIndex(Post P)
        {
            
        }

        /* Use DotNetOpenAuth and store comments in my site with Recaptcha? 
         * Brave enough to delete Comments to WXR and Disqus integration?
         * All for what - Comments import from old site will be easier, and 
         * comments are indexed by googol. And know-how on open auth background.
         */
        public void AddCommentToIndex(/*Comment C*/)
        {
            
        }

        public void IndexColdStorage()
        {
            
        }
    }
}