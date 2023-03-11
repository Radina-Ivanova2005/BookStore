using bookRepository.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public DbSet<Book> Books { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Publisher> Publishers { get; set;}
        public DbSet<Serie> Series { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<BookGenre> BooksGenres { get; set; }
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
            modelBuilder.Entity<BookGenre>().HasKey(nameof(BookGenre.GenreId), nameof(BookGenre.BookId));
            modelBuilder.Entity<Book>().Property(m => m.SerieId).IsRequired(false);          
            modelBuilder.Entity<Author>().Property(b => b.IsDeleted).HasDefaultValue(false);
            modelBuilder.Entity<Book>().Property(b => b.IsDeleted).HasDefaultValue(false);
            modelBuilder.Entity<Genre>().Property(b => b.IsDeleted).HasDefaultValue(false);
            modelBuilder.Entity<Publisher>().Property(b => b.IsDeleted).HasDefaultValue(false);
            modelBuilder.Entity<Serie>().Property(b => b.IsDeleted).HasDefaultValue(false);
            base.OnModelCreating(modelBuilder);
           


 
        }

        
    }
}
