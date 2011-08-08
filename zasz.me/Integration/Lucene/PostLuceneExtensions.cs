using Lucene.Net.Documents;
using Lucene.Net.Index;
using zasz.me.Areas.Shared.Models;

namespace zasz.me.Integration.Lucene
{
    public static class PostLuceneExtensions
    {
        public static Document ToLuceneDocument(this Post P)
        {
            var Document = new Document();
            Document.Add(new Field("id", P.Id.ToString(), Field.Store.YES, Field.Index.NOT_ANALYZED));
            Document.Add(new Field("permalink", P.Permalink, Field.Store.YES, Field.Index.NOT_ANALYZED));
            Document.Add(new Field("body", P.GetBodyForIndexing(), Field.Store.YES, Field.Index.ANALYZED));
            return Document;
        }

        public static Term GetIndexId(this Post P)
        {
            return new Term("id", P.Id.ToString());
        }
    }

    public class PostSearchResult
    {
        public string Id { get; set; }
        public string Permalink { get; set; }
        public string Context { get; set; }

        public PostSearchResult(string Id, string Permalink, string Context)
        {
            this.Id = Id;
            this.Permalink = Permalink;
            this.Context = Context;
        }
    }
}