using System.IO;
using Lucene.Net.Analysis.Standard;
using Lucene.Net.Index;
using Lucene.Net.Store;
using Lucene.Net.Util;
using zasz.me.Areas.Shared.Models;
using zasz.me.Integration.Lucene;

namespace zasz.me.Services
{
    /* http://www.ifdefined.com/blog/post/2009/02/Full-Text-Search-in-ASPNET-using-LuceneNET.aspx */
    public class SearchService
    {
        public string IndexPath { get; set; }
        public IPostRepository Posts { get; set; }

        public SearchService(string IndexPath, IPostRepository Posts)
        {
            this.IndexPath = IndexPath;
            this.Posts = Posts;
        }

        public void Search(string Term)
        {
            //            var searcher = new DirectoryIndexSearcher(new DirectoryInfo(IndexPath), true);
            //            var query = new TermQuery(new Term("name", "Football"));
            //            var searchService = new SearchService(IndexPath);
            //            Func<Document, PostSearchResult> converter = (doc) =>
            //            {
            //                return new ProductSearchResult
            //                {
            //                    Id = int.Parse(doc.GetValues("id")[0]),
            //                    Name = doc.GetValues("name")[0]
            //                };
            //            };
            //            IList<PostSearchResult> results = searchService.Search();
        }


        public void IndexColdStorage()
        {
            var IndexDirectory = FSDirectory.Open(new DirectoryInfo(IndexPath), new NativeFSLockFactory());
            var Writer = new IndexWriter(IndexDirectory, new StandardAnalyzer(Version.LUCENE_29), true, IndexWriter.MaxFieldLength.UNLIMITED);
            var Count = Posts.Count();
            for (var I = 0; I < Count; I += 20)
            {
                var FiftyPosts = Posts.Page(0, 20);
                FiftyPosts.ForEach(P => Writer.AddDocument(P.ToLuceneDocument()));
                Writer.Commit();
            }

            Writer.Optimize();
            Writer.Close();
        }
    }
}