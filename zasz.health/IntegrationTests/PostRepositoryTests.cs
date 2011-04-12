﻿using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Raven.Client.Document;
using Raven.Client.Indexes;
using zasz.develop.SampleData;
using zasz.me.Integration.RavenDB;
using zasz.me.Integration.RavenDB.Indexes;
using zasz.me.Models;

namespace zasz.health.IntegrationTests
{
    [TestClass]
    public class PostRepositoryTests
    {
        private static DocumentStore _DocumentStore;
        private Posts Repo;

        [TestInitialize]
        public void Setup()
        {
            _DocumentStore = new DocumentStore {Url = "http://localhost:3000", DefaultDatabase = "TestStore"};
            _DocumentStore.Initialize();
            IndexCreation.CreateIndexes(typeof (Post_BySlug).Assembly, _DocumentStore);
            _DocumentStore.Conventions.FindIdentityProperty = RavenIntegration._FindIdentityProperty;
            var DocumentSession = _DocumentStore.OpenSession();
            Repo = new Posts(DocumentSession);

            ////This field has Value 0
            var Count = DocumentSession.Query<Post>().Count();

            //returns 0 results
            var FewPosts = from APost in DocumentSession.Query<Post>("Post/BySlug")
                           where APost.Slug.StartsWith("B")
                           select APost.Slug;

            // This field is an EMPTY array.
            var ThePosts = FewPosts.ToArray();
            
            if (Count == 0)
            {
                var SamplePosts = PostsData.GetFromFolder(@"C:\Documents and Settings\thiagac\My Documents\Visual Studio 2010\Projects\Confidence", Log);
                foreach (Post SamplePost in SamplePosts)
                    DocumentSession.Store(SamplePost);
                DocumentSession.SaveChanges();
            }
        }

        [TestMethod]
        public void TestSaving()
        {
            var IDS = new List<string> {"End of Holidays in Horizon :(", "Getting-started-with-Apache-Struts-2-2c-with-Netbeans-61"};
            var Posts = Repo.Page(0, 10);
            var ActualIDS = new List<string>(10);
            Posts.ForEach(Post => ActualIDS.Add(Post.Title));
            Assert.IsTrue(IDS.TrueForAll(ActualIDS.Contains));
        }

        public void Log(string Log)
        {
            Console.WriteLine(Log);
        }
    }
}