using zasz.me.Shared.Controllers;
using zasz.me.Shared.Models;

namespace zasz.me.Rest.Controllers
{
    public class BlogController : BlogBaseController
    {
        public BlogController(IPostRepository Posts, ITagRepository Tags)
            : base(Posts, Tags, Site.Rest)
        {
        }
    }
}
