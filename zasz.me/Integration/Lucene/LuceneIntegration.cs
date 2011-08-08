using System.Configuration;
using System.IO;
using Lucene.Net.Analysis.Standard;
using Lucene.Net.Index;
using Lucene.Net.Search;
using Lucene.Net.Store;
using Lucene.Net.Util;
using Microsoft.Practices.Unity;
using Directory = System.IO.Directory;

namespace zasz.me.Integration.Lucene
{
    public class LuceneIntegration
    {
        public static void Bootstrap()
        {
            string LuceneIndexPath = ConfigurationManager.AppSettings["ProjectRootPath"] +
                                     ConfigurationManager.AppSettings["DataFilesPath"];
            /* Here we create a singleton writer : 
             * http://stackoverflow.com/questions/5420566/lucene-net-writing-reading-synchronization 
             */
            CreateAndStoreWriters(LuceneIndexPath, "FullIndex");
            /* And, here a singleton searcher */
            CreateAndStoreSearchers(LuceneIndexPath, "FullIndex", "FullSearcher");
        }

        private static void CreateAndStoreWriters(string LuceneIndexPath, string IndexName)
        {
            var IndexPath = Path.Combine(LuceneIndexPath, IndexName);
            if (!Directory.Exists(IndexPath)) Directory.CreateDirectory(IndexPath);
            var IndexDirectory = FSDirectory.Open(new DirectoryInfo(LuceneIndexPath), new NativeFSLockFactory());
            var SiteIndexWriter = new IndexWriter(IndexDirectory, new StandardAnalyzer(Version.LUCENE_29), true,
                                                  IndexWriter.MaxFieldLength.UNLIMITED);
            /* ContainerControlledLifetimeManager: http://msdn.microsoft.com/en-us/library/ff647854.aspx */
            HugeBox.BigBox.RegisterInstance(typeof (IndexWriter), IndexName, SiteIndexWriter,
                                            new ContainerControlledLifetimeManager());
        }
        
        private static void CreateAndStoreSearchers(string LuceneIndexPath, string IndexName, string Searchername)
        {
            var IndexPath = Path.Combine(LuceneIndexPath, IndexName);
            var IndexDirectory = FSDirectory.Open(new DirectoryInfo(IndexPath), new NativeFSLockFactory());
            var SiteIndexWriter = new IndexSearcher(IndexDirectory, true);
            HugeBox.BigBox.RegisterInstance(typeof(IndexSearcher), Searchername, SiteIndexWriter,
                                            new ContainerControlledLifetimeManager());
        }
    }
}