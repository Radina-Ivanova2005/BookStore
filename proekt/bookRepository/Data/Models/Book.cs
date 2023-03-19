using bookRepository.Data.Models;
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
        public Book(string title, int autorId, int publisherId, int genreId, int categoryId, string language, int pages, decimal price, int rating, int count)
        {
            Title = title;
            AuthorId = autorId;
            PublisherId = publisherId;
            GenreId = genreId;
            CategoryId = categoryId;
            Language = language;
            Pages = pages;
            Price = price;
            Rating = rating;
            Count = count;
        }

        public Book(string title, int autorId,int serieId, int publisherId, int genreId, int categoryId, string language, int pages, decimal price, int rating, int count)
        {
            Title = title;
            AuthorId = autorId;
            SerieId= serieId;
            PublisherId = publisherId;
            GenreId = genreId;
            CategoryId = categoryId;
            Language = language;
            Pages = pages;
            Price = price;
            Rating = rating;
            Count = count;           
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int BookId { get; set; }

        [Required]
        public string Title { get; set; }
        [Required]
        [ForeignKey(nameof(Author))]
        public int AuthorId { get; set; }
        public  Author Author { get; set; }


        [ForeignKey(nameof(Serie))]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public int? SerieId { get; set; }
        public  Serie Serie { get; set; }

        [Required]
        [ForeignKey(nameof(Publisher))]
        public int PublisherId { get; set; }
        public  Publisher Publisher { get; set; }

        [Required]
        [ForeignKey(nameof(Genre))]
        public int GenreId { get; set; }
        public Genre Genre { get; set; }

        [Required]
        [ForeignKey(nameof(Category))]
        public int CategoryId { get; set; }
        public Category Category { get; set; }
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

       

       

    }
}
