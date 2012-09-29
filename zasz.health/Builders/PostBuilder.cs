using zasz.me.Models;

namespace zasz.health.Builders
{
    public class PostBuilder
    {
        private readonly Post post = new Post();

        private Post Build()
        {
            return post;
        }
    }
}