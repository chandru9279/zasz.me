using System.Data.Entity;

using zasz.me.Models;

namespace zasz.me.Integration.EntityFramework
{
    public class Ef4
    {
        public static void Setup()
        {
            // Setup unity to give SingletonPerWebRequest DbContext;
            Big.Box.RegisterType<FullContext>(new SingletonPerRequest("DB-Context"));
        }
    }

    public class FullContext : DbContext
    {
        public FullContext()
            : this("FullContext")
        {
        }

        protected FullContext(string nameOrConnectionString) : base(nameOrConnectionString)
        {
        }

        public DbSet<Post> Posts { get; set; }

        public DbSet<Passphrase> Vault { get; set; }

        public DbSet<Log> ErrorLogs { get; set; }

        public DbSet<Tag> Tags { get; set; }

        public DbSet<SoCache> SoCaches { get; set; }

        public DbSet<SoAnswer> SoAnswers { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SoCache>().HasKey(x => x.Id).HasMany(x => x.Answers).WithRequired(x => x.Cache).WillCascadeOnDelete();
            modelBuilder.Entity<SoAnswer>().HasKey(x => x.Id).HasRequired(x => x.Cache);
        }
    }
}