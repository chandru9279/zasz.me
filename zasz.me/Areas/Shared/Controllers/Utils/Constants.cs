using System.Collections.Generic;

namespace zasz.me.Controllers.Utils
{
    public static class Constants
    {
        public static char[] Shredders = new[] {' ', ',', ';', '|'};

        private static readonly string[][] _GoWords = {
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
                                                          new[] {"J#", "f-sharp"},
                                                      };

        public static Dictionary<string, string> GoWords()
        {
            var Dictionary = new Dictionary<string, string>(_GoWords.Length);
            foreach (var Pair in _GoWords)
                Dictionary.Add(Pair[0], Pair[1]);
            return Dictionary;
        }
    }
}