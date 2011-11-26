using zasz.me.Areas.Shared.Controllers;
using zasz.me.Areas.Shared.Models;

namespace zasz.me.Areas.Rest.Controllers
{
    public class BlogController : BlogBaseController
    {
        public BlogController(IPostRepository Posts, ITagRepository Tags)
            : base(Posts, Tags, Site.Rest)
        {
        }
    }
}
