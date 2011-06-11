using System.Data.Entity;
using Microsoft.Practices.Unity;
using zasz.me.Areas.Shared.Models;

namespace zasz.me.Integration.EntityFramework
{
    public class EntityFramework
    {
        public static void Bootstrap()
        {
            /* TODO: The next line needs to be removed in production. Manual modification only afterwards. */
            Database.SetInitializer(new ColdStorageInitializer());
            /* TODO: The table EdmMetadata can also be deleted, with the above line. */
            SetupUnityToGiveDbContextSingletonPerWebRequest();
        }

        /// <summary>
        ///     Sets up the Unity container
        ///     to create and give one DBContext per web request. (singleton session per webrequest,
        ///     using the HttpContext.Current.Items)
        /// 
        ///     For registering factories, that helps unity build objects-
        ///     http://www.pnpguidance.net/post/RegisteringFactoryMethodCreateObjectsUnityStaticFactoryExtension.aspx
        ///     which is now obsolete - or so visual studio says. Further it tells me to use InjectionFactory
        ///     <code>new InjectionFactory(Container => new FullContext())</code>
        /// </summary>
        public static void SetupUnityToGiveDbContextSingletonPerWebRequest()
        {
            HugeBox.BigBox.RegisterType<FullContext>(new SingletonPerRequest("DB-Context"));
        }
    }

    public class FullContext : DbContext
    {
        public DbSet<Post> Posts { get; set; }

        public DbSet<Passphrase> Vault { get; set; }

        public DbSet<Log> ErrorLogs { get; set; }

        public DbSet<Tag> Tags { get; set; }

        protected override void OnModelCreating(DbModelBuilder ModelBuilder)
        {
        }
    }

    public class ColdStorageInitializer : DropCreateDatabaseIfModelChanges<FullContext>
    {
    }
}