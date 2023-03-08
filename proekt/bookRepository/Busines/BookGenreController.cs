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
    public class BookGenreController
    {
        private BookShopContext context;
        public BookGenreController()
        {
            context = new BookShopContext();
        }

        public void AddBookGenre(BookGenre bookGenre)
        {
            this.context.BooksGenres.Add(bookGenre);
            this.context.SaveChanges();
        }

        public List<Book> GetBooksByGenres(int genreId)
        {
           var books=context.Books.Where(x=>x.BookId.Equals(genreId) && x.IsDeleted == false).ToList();
            return books;
        }

    }
}
