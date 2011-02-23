using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace zasz.me.Models
{
    public class Post : Stored<Post>
    {
        public string Area { get; set; }

        public string Permalink { get; set; }
    }
}