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
        //Added new book to the database
        public void AddBook(Book book)
        {
            this.context.Books.Add(book);
            this.context.SaveChanges();
        }
        //Fetch certain book from the database by ID
        public Book GetBookById(int id)
        {
            var book = this.context.Books.FirstOrDefault(x => x.BookId == id);
            return book;
        }
        //Fetch list of all books in the database
        public List<Book> GetAllBooks()
        {
            return context.Books.OrderBy(b => b.Title).ToList();
        }
        //Fetch books from the database by author ID
        public List<Book> GetBooksByAuthor(int authorId)
        {
            var books = context.Books.Where(x => x.AuthorId == authorId).OrderBy(b => b.Title).ToList();
            return books;
        }
        //Fetch books from the database by serie ID
        public List<Book> GetBooksBySerie(int serieId)
        {
            var books = context.Books.Where(x => x.SerieId.Equals(serieId)).OrderBy(b => b.Title).ToList();
            return books;
        }
        //Fetch books from the database by publisher ID
        public List<Book> GetBooksByPublisher(int publisherId)
        {
            var books = context.Books.Where(x => x.PublisherId.Equals(publisherId)).OrderBy(b => b.Title).ToList();
            return books;
        }
        //Fetch books from the database by genre ID
        public List<Book> GetBooksByGenre(int genreId)
        {
            var books = context.Books.Where(x => x.GenreId.Equals(genreId)).OrderBy(b => b.Title).ToList();
            return books;
        }
        //Fetch books from the database by category ID
        public List<Book> GetBooksByCategory(int categoryId)
        {
            var books = context.Books.Where(x => x.CategoryId.Equals(categoryId)).OrderBy(b => b.Title).ToList();
            return books;
        }
        //Fetch books with pages less than the given
        public List<Book> GetBooksWithLessPages(int pages)
        {
            var books = context.Books.Where(x => x.Pages <= pages).OrderBy(b => b.Pages).ToList();
            return books;
        }
        //Fetch books with pages more than the given
        public List<Book> GetBooksWithMorePages(int pages)
        {
            var books = context.Books.Where(x => x.Pages >= pages).OrderBy(b => b.Pages).ToList();
            return books;
        }
        //Fetch books with price less than the given
        public List<Book> GetBooksWithLessPrice(decimal price)
        {
            var books = context.Books.Where(x => x.Price <= price).OrderBy(b => b.Price).ToList();
            return books;
        }
        //Fetch books with price bigger than the given
        public List<Book> GetBooksWithBiggerPrice(decimal price)
        {
            var books = context.Books.Where(x => x.Price >= price).OrderBy(b => b.Price).ToList();
            return books;
        }
        //Fetch certain book from the database by title of the book
        public Book GetBookByTitle(string title)
        {
            var book = context.Books.FirstOrDefault(x => x.Title.Equals(title));
            return book;
        }
        //Fetch books from the database by language 
        public List<Book> GetBooksWithLanguage(string language)
        {
            var books = context.Books.Where(x => x.Language.Equals(language)).OrderBy(b => b.Title).ToList();
            return books;
        }
        //Fetch books from the database by rating 
        public List<Book> GetBooksWithRating(int rating)
        {
            var books = context.Books.Where(x => x.Rating == rating).OrderBy(b => b.Title).ToList();
            return books;
        }
        //Updated certain book from the database with new book characteristics
        public void UpdateBook(Book book)
        {
            var bookItem = this.GetBookById(book.BookId);
            this.context.Entry(bookItem).CurrentValues.SetValues(book);
            this.context.SaveChanges();
        }
        //Deleted certain book by ID
        public void DeleteBook(int id)
        {
            var bookItem = this.GetBookById(id);
            this.context.Books.Remove(bookItem);
            this.context.SaveChanges();
        }
        //Decrease the count of book with given ID if the book exist
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
