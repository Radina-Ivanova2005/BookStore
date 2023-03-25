using bookRepository.Data.Models;
using bookRepository.Models;
using Microsoft.EntityFrameworkCore;

namespace bookRepository.Data
{
    public class BookShopContext : DbContext
    {
        public BookShopContext()
        {

        }

        public BookShopContext(DbContextOptions options) : base(options)
        {

        }

        public virtual DbSet<Book> Books { get; set; }
        public virtual DbSet<Author> Authors { get; set; }
        public virtual DbSet<Publisher> Publishers { get; set;}
        public virtual DbSet<Serie> Series { get; set; }
        public virtual DbSet<Genre> Genres { get; set; }
        public virtual DbSet<Category> Categories { get; set; } 


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(Configuration.ConnectionString);
            }
            base.OnConfiguring(optionsBuilder);

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder) 
        {
           
            modelBuilder.Entity<Book>().Property(m => m.SerieId).IsRequired(false);

            modelBuilder.Entity<Serie>()
                 .HasMany(m => m.Books)
                 .WithOne(e => e.Serie)
                 .OnDelete(DeleteBehavior.Cascade);
        }

        
    }
}
