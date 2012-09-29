using System.Data.Entity;
using zasz.me.Models;

namespace zasz.me.Integration.EntityFramework
{
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

        public DbSet<Cache> Caches { get; set; }

        public DbSet<Answer> Answers { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Post>().HasMany(x => x.Tags).WithMany(x => x.Posts).Map(x => x.ToTable("PostTagMap", "Blog"));
            modelBuilder.Entity<Cache>().HasKey(x => x.Id).HasMany(x => x.Answers).WithRequired(x => x.Cache).WillCascadeOnDelete();
            modelBuilder.Entity<Answer>().HasKey(x => x.Id).HasRequired(x => x.Cache);
        }
    }
}