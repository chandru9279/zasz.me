using System.IO;
using SimpleLucene.Impl;

namespace zasz.me.Integration.Lucene
{
    public class LuceneIntegration
    {
        /* Refer here for SimpleLucene source
         * http://simplelucene.codeplex.com/SourceControl/list/changesets
         */
        public static void Bootstrap()
        {
            var Writer = new DirectoryIndexWriter(new DirectoryInfo(@"c:\index"), true);
        }
    }
}