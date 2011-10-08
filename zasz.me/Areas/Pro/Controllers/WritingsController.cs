﻿using zasz.me.Areas.Shared.Controllers;
using zasz.me.Areas.Shared.Models;

namespace zasz.me.Areas.Pro.Controllers
{
    public class WritingsController : WritingsBaseController
    {
        public WritingsController(IPostRepository Posts, ITagRepository Tags)
            : base(Posts, Tags, Site.Pro)
        {
        }
    }
}