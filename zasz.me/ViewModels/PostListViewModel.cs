using System.Collections.Generic;
using zasz.me.Models;

namespace zasz.me.ViewModels
{
    public class PostListViewModel
    {
        public List<Post> Posts { get; set; }
        public int NumberOfPages { get; set; }
        public int DescriptionLength { get; set; }
        public string WhatIsListed { get; set; }
    }
}