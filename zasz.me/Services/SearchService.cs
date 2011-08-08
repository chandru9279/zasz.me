using System;
using System.IO;
using Elmah;
using Lucene.Net.Analysis.Standard;
using Lucene.Net.Index;
using Lucene.Net.Store;
using zasz.me.Areas.Shared.Models;
using zasz.me.Integration.Lucene;
using Version = Lucene.Net.Util.Version;

namespace zasz.me.Services
{
    /* http://www.ifdefined.com/blog/post/2009/02/Full-Text-Search-in-ASPNET-using-LuceneNET.aspx */
    public class SearchService
    {
        public IndexWriter Writer { get; set; }
        public IPostRepository Posts { get; set; }

        public SearchService(IndexWriter Writer, IPostRepository Posts)
        {
            this.Writer = Writer;
            this.Posts = Posts;
        }

        public void Search(string Term)
        {
            
        }

        public void AddPostToIndex(Post P)
        {
            try
            {
                
                Writer.DeleteDocuments(P.GetIndexId());
                Writer.AddDocument(P.ToLuceneDocument());
                Writer.Commit();
                Writer.Close();
            }
            catch (Exception e)
            {
                ErrorSignal.FromCurrentContext().Raise(e);
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
//                    FiftyPosts.ForEach(P => P.Site.Equals(Site.PRO) Writer.AddDocument(P.ToLuceneDocument()));
                    Writer.Commit();
                }
                Writer.Optimize();
                Writer.Close();
            }
            catch (Exception e)
            {
                ErrorSignal.FromCurrentContext().Raise(e);
            }
        }
    }
}