using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.AccessControl;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace bookRepository.Models
{
    public class Book
    {
        public Book()
        {
            
        }
        public Book(string title, int autorId,  int serieId,  int publisherId, string language, int pages, decimal price, int rating, int count, bool isDeleted)
        {
           
            Title = title;
            AuthorId = autorId;
            SerieId = serieId;
            PublisherId = publisherId;
            Language = language;
            Pages = pages;
            Price = price;
            Rating = rating;
            Count = count;
            IsDeleted = isDeleted;
        }

        public Book(int bookId, string title, int autorId, int publisherId, string language, int pages, decimal price, int rating, int count)
        {
            BookId = bookId;
            Title = title;
            AuthorId = autorId;
            PublisherId = publisherId;
            Language = language;
            Pages = pages;
            Price = price;
            Rating = rating;
            Count = count;
            IsDeleted = false;
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int BookId { get; set; }

        [Required]
        public string Title { get; set; }
        [Required]
        [ForeignKey(nameof(Author))]
        public int AuthorId { get; set; }
      //  public virtual Author Author { get; set; }


        [ForeignKey(nameof(Serie))]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public int? SerieId { get; set; }
        //public virtual Serie Serie { get; set; }

        [Required]
        [ForeignKey(nameof(Publisher))]
        public int PublisherId { get; set; }
     //   public virtual Publisher Publisher { get; set; }
        [Required]
        public string Language { get; set; }
        [Required]
        public int Pages { get; set; }
        [Required]
        [Precision(5, 2)]
        public decimal Price { get; set; }
        [Required]
        public int Rating { get; set; }
        [Required]
        public int Count { get; set; }

        public bool IsDeleted { get; set; } 

        public ICollection<BookGenre> BookGenres { get; }

    }
}
