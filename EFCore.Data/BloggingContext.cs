using EFCore.DomainModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace EFCore.Data
{
    public class BloggingContext : DbContext
    {
 
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Post> Posts { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder options)
            =>
            options.UseSqlServer("Data Source=.;Initial Catalog=Blogging;Integrated Security=True;Pooling=False");

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Blog>(eb =>
            {
                eb.HasKey(c => c.BlogId);
                eb.Ignore(c => c.LoadedFromDatabase);
                eb.Property(b => b.Url)
                .IsRequired()
                .HasMaxLength(50);

            });

            modelBuilder.Entity<Post>()

                .HasOne(p => p.Blog)
                 .WithMany(b => b.Posts)
                 .HasForeignKey(p => p.BlogId);

        }

    }
}
