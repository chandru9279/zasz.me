using System;
using System.Collections.Generic;
using zasz.health.Builders;
using zasz.health.UtilityTests;
using zasz.me;
using zasz.me.Integration.EntityFramework;
using zasz.me.Models;

namespace zasz.health.RepositoryTests
{
    public class PostAndTagsTestData : TestData
    {
        private readonly dynamic postBuilder;
        public Post First { get; set; }
        public Post Second { get; set; }
        public Post Third { get; set; }

        public PostAndTagsTestData()
        {
            postBuilder = new PostBuilder();
            First = postBuilder.Build()
                .Timestamp(DateTime.Now.AddDays(-1))
                .TagStrings(new List<string> { "tag1", "tag2" })
                .Save(Context);
            Second = postBuilder.Build()
                .TagStrings(new List<string> { "tag2", "tag3" })
                .Save(Context);
            Third = postBuilder.Build()
                .Timestamp(DateTime.Now.AddDays(1))
                .TagStrings(new List<string> { "tag1", "tag3" })
                .Save(Context);
        }

        protected override void Cleanup()
        {
            var posts = typeof(Post).TableAndSchemaName();
            var tags = typeof(Tag).TableAndSchemaName();
            var deleteQueries = string.Format("DELETE FROM {4}; DELETE FROM [{0}].[{1}]; DELETE FROM [{2}].[{3}];",
                                              posts.Other, posts.One, tags.Other, tags.One, DbConstants.PostTagMapping);
            Context.Database.ExecuteSqlCommand(deleteQueries);
        }
    }
}