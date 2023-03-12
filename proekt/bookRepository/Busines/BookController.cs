using bookRepository.Data;
using bookRepository.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bookRepository.Busines
{
    public class BookController
    {
        private BookShopContext context;
        private AuthorController authorController;
        public BookController()
        {
            context = new BookShopContext();
        }
        public void AddBook(Book book)
        {
           
            this.context.Books.Add(book);
                
            this.context.SaveChanges();
            
        }

        public Book GetBookById(int id)
        {
            var book = this.context.Books.FirstOrDefault(x => x.BookId == id);
            return book;
        }
    

        public List<Book> GetAllBooks()
        {
            return context.Books.ToList();
        }

        public List<Book> GetBooksByAuthor(int authorId)
        {
            var books = context.Books.Where(x => x.AuthorId == authorId).ToList();
            return books;
        }

        public List<Book> GetBooksBySerie(int serieId)
        {
            var books = context.Books.Where(x => x.SerieId.Equals(serieId)).ToList();
            return books;
        }

        public List<Book> GetBooksByPublisher(int publisherId)
        {
            var books = context.Books.Where(x => x.PublisherId.Equals(publisherId)).ToList();
            return books;
        }

        public List<Book> GetBooksByGenre(int genreId)
        {
            var books = context.Books.Where(x => x.GenreId.Equals(genreId)).ToList();
            return books;
        }

        public List<Book> GetBooksByCategory(int categoryId)
        {
            var books = context.Books.Where(x => x.CategoryId.Equals(categoryId) ).ToList();
            return books;
        }

        public List<Book> GetBooksWithLessPages(int pages)
        {
            var books = context.Books.Where(x => x.Pages <= pages).ToList();
            return books;
        }

        public List<Book> GetBooksWithMorePages(int pages)
        {
            var books = context.Books.Where(x => x.Pages >= pages).ToList();
            return books;
        }

        public List<Book> GetBooksWithLessPrice(decimal price)
        {
            var books = context.Books.Where(x => x.Price <= price).ToList();
            return books;
        }

        public List<Book> GetBooksWithBiggerPrice(decimal price)
        {
            var books = context.Books.Where(x => x.Price >= price ).ToList();
            return books;
        }

        public List<Book> GetBooksWithTitle(string title)
        {
            var books = context.Books.Where(x => x.Title.Equals(title) ).ToList();
            return books;
        }

        public List<Book> GetBooksWithLanguage(string language)
        {
            var books = context.Books.Where(x => x.Language.Equals(language)).ToList();
            return books;
        }

        public List<Book> GetBooksWithRating(int rating)
        {
            var books = context.Books.Where(x => x.Rating == rating).ToList();
            return books;
        }

        public void UpdateBook(Book book, int genreId)
        {
            var bookItem = this.GetBookById(book.BookId);        
            this.context.Entry(bookItem).CurrentValues.SetValues(book);
            this.context.SaveChanges();
        }

        public void DeleteBook(int id)
        {
            var bookItem = this.GetBookById(id);
            this.context.Books.Remove(bookItem);
            this.context.SaveChanges();
        }

        public void SaleBook(int id)
        {
            var bookItem = this.GetBookById(id);
            BookController controller = new BookController();
            bookItem.Count--;
            if (bookItem.Count == 0)
            {
                this.context.Books.Remove(bookItem);
               
            }
            this.context.SaveChanges();
        }

    }
}
