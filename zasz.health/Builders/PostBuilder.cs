using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using zasz.health.RepositoryTests;
using zasz.me.Integration.EntityFramework;
using zasz.me.Models;

namespace zasz.health.Builders
{
    public class PostBuilder : DynamicObject
    {
        public Post Post { get; private set; }

        public PostBuilder Build()
        {
            Post = new Post
                       {
                           Content = @"<div class='content'>TestContent</div>",
                           Id = Guid.NewGuid(),
                           Slug = "test-slug",
                           Tags = new List<Tag>(),
                           Timestamp = DateTime.Now,
                           Title = "test-title",
                       };
            return this;
        }

        public override bool TryInvokeMember(InvokeMemberBinder binder, object[] args, out object result)
        {
            Post.GetType().GetProperty(binder.Name).SetValue(Post, args[0], null);
            result = this;
            return true;
        }

        public Post Save(TestContext context)
        {
            var tags = new TagRepository(context);
            Post.Tags = Post.Tags.Select(x => tags.Get(x.Name) ?? tags.Save(new Tag(x.Name))).ToList();
            new PostRepository(context).Save(Post);
            tags.Commit();
            return Post;
        }
    }
}