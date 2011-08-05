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
            Document.Add(new Field("body", P.Content, Field.Store.YES, Field.Index.ANALYZED));
            Document.Add(new Field("title", P.Title, Field.Store.YES, Field.Index.ANALYZED));
            Document.Add(new Field("tags", P.TagsLine, Field.Store.YES, Field.Index.ANALYZED));
            Document.Add(new Field("slug", P.Slug, Field.Store.YES, Field.Index.ANALYZED));
            Document.Add(new Field("permalink", P.Permalink, Field.Store.YES, Field.Index.NOT_ANALYZED));
            return Document;
        }

        public static Term GetIndex(this Post P)
        {
            return new Term("id", P.Id.ToString());
        }
    }

    public class PostSearchResult
    {
        public string Id { get; set; }
        public string Slug { get; set; }
        public string Permalink { get; set; }
        public string Title { get; set; }

        public PostSearchResult(string Id, string Slug, string Permalink, string Title)
        {
            this.Id = Id;
            this.Slug = Slug;
            this.Permalink = Permalink;
            this.Title = Title;
        }
    }
}