using System;
using Elmah;
using Lucene.Net.Index;
using Lucene.Net.Search;
using zasz.me.Areas.Shared.Models;
using zasz.me.Integration.Lucene;

namespace zasz.me.Services
{
    /* http://www.ifdefined.com/blog/post/2009/02/Full-Text-Search-in-ASPNET-using-LuceneNET.aspx */
    public class SearchService
    {
        public IndexSearcher Searcher { get; set; }
        public IndexWriter Writer { get; set; }
        public IPostRepository Posts { get; set; }

        public SearchService(IndexSearcher Searcher, IndexWriter Writer, IPostRepository Posts)
        {
            this.Searcher = Searcher;
            this.Writer = Writer;
            this.Posts = Posts;
        }

        public void Search(string Term)
        {
            TopDocs Results = Searcher.Search(new TermQuery(new Term("body", Term)), 50);
        }

        public void AddPostToIndex(Post P)
        {
            try
            {
                Writer.DeleteDocuments(P.GetIndexId());
                Writer.AddDocument(P.ToLuceneDocument());
                Writer.Commit();
                Writer.Optimize(); 
                Writer.Close();
            }
            catch (Exception E)
            {
                ErrorSignal.FromCurrentContext().Raise(E);
            }
        }


        public void IndexColdStorage()
        {
            try
            {
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
            catch (Exception E)
            {
                ErrorSignal.FromCurrentContext().Raise(E);
            }
        }
    }
}