using bookRepository.Data;
using bookRepository.Models;


namespace bookRepository.Busines
{
    public class BookController
    {
        private BookShopContext context;
      
        public BookController(BookShopContext context)
        {
            this.context = context;
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
            return context.Books.OrderBy(b => b.Title).ToList();
        }

        public List<Book> GetBooksByAuthor(int authorId)
        {
            var books = context.Books.Where(x => x.AuthorId == authorId).OrderBy(b => b.Title).ToList();
            return books;
        }

        public List<Book> GetBooksBySerie(int serieId)
        {
            var books = context.Books.Where(x => x.SerieId.Equals(serieId)).OrderBy(b => b.Title).ToList();
            return books;
        }

        public List<Book> GetBooksByPublisher(int publisherId)
        {
            var books = context.Books.Where(x => x.PublisherId.Equals(publisherId)).OrderBy(b => b.Title).ToList();
            return books;
        }

        public List<Book> GetBooksByGenre(int genreId)
        {
            var books = context.Books.Where(x => x.GenreId.Equals(genreId)).OrderBy(b => b.Title).ToList();
            return books;
        }

        public List<Book> GetBooksByCategory(int categoryId)
        {
            var books = context.Books.Where(x => x.CategoryId.Equals(categoryId)).OrderBy(b => b.Title).ToList();
            return books;
        }

        public List<Book> GetBooksWithLessPages(int pages)
        {
            var books = context.Books.Where(x => x.Pages <= pages).OrderBy(b => b.Pages).ToList();
            return books;
        }

        public List<Book> GetBooksWithMorePages(int pages)
        {
            var books = context.Books.Where(x => x.Pages >= pages).OrderBy(b => b.Pages).ToList();
            return books;
        }

        public List<Book> GetBooksWithLessPrice(decimal price)
        {
            var books = context.Books.Where(x => x.Price <= price).OrderBy(b => b.Price).ToList();
            return books;
        }

        public List<Book> GetBooksWithBiggerPrice(decimal price)
        {
            var books = context.Books.Where(x => x.Price >= price).OrderBy(b => b.Price).ToList();
            return books;
        }

        public Book GetBookByTitle(string title)
        {
            var book = context.Books.FirstOrDefault(x => x.Title.Equals(title));
            return book;
        }

        public List<Book> GetBooksWithLanguage(string language)
        {
            var books = context.Books.Where(x => x.Language.Equals(language)).OrderBy(b => b.Title).ToList();
            return books;
        }

        public List<Book> GetBooksWithRating(int rating)
        {
            var books = context.Books.Where(x => x.Rating == rating).OrderBy(b => b.Title).ToList();
            return books;
        }

        public void UpdateBook(Book book)
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
            bookItem.Count--;
            if (bookItem.Count == 0)
            {
                this.context.Books.Remove(bookItem);

            }
            this.context.SaveChanges();
        }

    }
}
