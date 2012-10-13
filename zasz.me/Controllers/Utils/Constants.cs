using System.Collections.Generic;
using zasz.me.Services;

namespace zasz.me.Controllers.Utils
{
    public static class Constants
    {
        private static readonly string[][] goWords =
            {
                new[] {"c#", "c-sharp"},
                new[] {".net", "dot-net"},
                new[] {"c++", "c-plus-plus"},
                new[] {"&", "and"},
                new[] {"%", "percent"},
                new[] {"@", "at"},
                new[] {"=", "equals"},
                new[] {"+", "plus"},
                new[] {"=>", "implies"},
                new[] {"\\", "or"},
                new[] {"/", "or"},
                new[] {"F#", "j-sharp"},
                new[] {"J#", "f-sharp"}
            };

        public static char[] Shredders = new[] {' ', ',', ';', '|'};

        public static Pairs<string, int> Months =
            new Pairs<string, int>(
                new[]
                    {
                        "January", "February", "March", "April", "May", "June", "July", "August", "September", "October"
                        ,
                        "November", "December"
                    },
                new[] {1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12});

        public static string DefaultWordList = @"asp.net, 15
games, 10
fun, 15
books, 5
music, 5
crapo, 4
dota, 5
concept, 2
.net, 5
fiction, 5
sci-fi, 3
mystery, 5
romance, 4
";

        public static Dictionary<string, string> GoWords()
        {
            var dictionary = new Dictionary<string, string>(goWords.Length);
            foreach (var pair in goWords)
                dictionary.Add(pair[0], pair[1]);
            return dictionary;
        }

        public const string PostsFolder = @"\App_Data\Posts\";
        public const string SolrReindexUrl = @"http://localhost:5000/solr/dataimport?verbose=true&clean=true&commit=true&command=full-import";
    }
}