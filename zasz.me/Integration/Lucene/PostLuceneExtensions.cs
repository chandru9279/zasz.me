using zasz.me.Areas.Shared.Models;

namespace zasz.me.Integration.Lucene
{
    public static class PostLuceneExtensions
    {
        
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