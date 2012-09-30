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
        private Post post;

        public PostBuilder Build()
        {
            post = new Post
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
            post.GetType().GetProperty(binder.Name).SetValue(post, args[0], null);
            result = this;
            return true;
        }

        public Post Save(TestContext context)
        {
            var tags = new Tags(context);
            post.Tags = post.Tags.Select(x => tags.Get(x.Name) ?? tags.Save(new Tag(x.Name))).ToList();
            new Posts(context).Save(post);
            tags.Commit();
            return post;
        }
    }
}