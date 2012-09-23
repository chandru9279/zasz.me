using zasz.me.Models;

namespace zasz.me.ViewModels
{
    public class PostListViewModel : Paged<Post>
    {
        public int DescriptionLength { get; set; }
        public string WhatIsListed { get; set; }
    }
}