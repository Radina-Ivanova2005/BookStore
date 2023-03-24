using bookRepository.Busines;
using bookRepository.Models;

namespace bookRepository.Views
{
    public class BookDisplay
    {
        private BookController controller = new BookController(new Data.BookShopContext());
        public BookDisplay()
        {

            Input();
        }

        private int closeOperationId = 19;

        //Print the menu
        private void ShowMenu()
        {
            Console.WriteLine(new string('-', 40));
            Console.WriteLine(new string(
                ' ', 18) + "MENU" + new string(
                ' ', 18));
            Console.WriteLine(new string('-', 40));
            Console.WriteLine("1. List all books");
            Console.WriteLine("2. List all books by author");
            Console.WriteLine("3. List all books by category");
            Console.WriteLine("4. List all books by genre");
            Console.WriteLine("5. List all books by serie");
            Console.WriteLine("6. List all books by publisher");
            Console.WriteLine("7. List all books with less price");
            Console.WriteLine("8. List all books with bigger price");
            Console.WriteLine("9. List all books with less pages");
            Console.WriteLine("10. List all books with more pages");
            Console.WriteLine("11. List all books by rating");
            Console.WriteLine("12. List all books by language");
            Console.WriteLine("13. Add new book");
            Console.WriteLine("14. Update book");
            Console.WriteLine("15. Fetch book by ID");
            Console.WriteLine("16. Fetch book by Title");
            Console.WriteLine("17. Sale book by ID");
            Console.WriteLine("18. Delete book by ID");
            Console.WriteLine("19. Close");

        }
        private void Input()
        {
            var operation = -1;
            do
            {
                ShowMenu();
                operation = int.Parse(Console.ReadLine());
                switch (operation)
                {
                    case 1: List(); break;
                    case 2: ListBooksByAuthor(); break;
                    case 3: ListBooksByCategory(); break;
                    case 4: ListBooksByGenre(); break;
                    case 5: ListBooksBySerie(); break;
                    case 6: ListBooksByPublisher(); break;
                    case 7: ListBooksWithLessPrice(); break;
                    case 8: ListBooksWithBiggerPrice(); break;
                    case 9: ListBooksWithLessPages(); break;
                    case 10: ListBooksWithMorePages(); break;
                    case 11: ListBooksByRating(); break;
                    case 12: ListBooksByLanguage(); break;
                    case 13: Add(); break;
                    case 14: Update(); break;
                    case 15: FetchBookById(); break;
                    case 16: FetchBookByTitle(); break;
                    case 17: SaleBookById(); break;
                    case 18: Delete(); break;
                    default:
                        break;
                }
            } while (operation != closeOperationId);
        }
        //Sale book with given ID
        private void SaleBookById()
        {
            Console.WriteLine("Enter ID to sale: ");
            int id = int.Parse(Console.ReadLine());
            controller.SaleBook(id);
            Console.WriteLine("Done.");
        }

        //Fetch list of all books from the database
        private void List()
        {
            Console.WriteLine(new string('-', 40));
            Console.WriteLine(new string(' ', 16) + "BOOK" + new string(' ', 16));
            Console.WriteLine(new string('-', 40));
            var books = controller.GetAllBooks();
            foreach (var book in books)
            {
                Console.WriteLine($"{book.BookId} {book.Title} {book.Language} {book.Pages} {book.Price} {book.Rating} {book.Count} ");
            }
        }
        //Get author ID from the console, fetch list of books by author ID from the database
        private void ListBooksByAuthor()
        {
            Console.WriteLine("Enter author's ID: ");
            int id = int.Parse(Console.ReadLine());
            Console.WriteLine(new string('-', 40));
            Console.WriteLine(new string(' ', 16) + "BOOK" + new string(' ', 16));
            Console.WriteLine(new string('-', 40));
            var books = controller.GetBooksByAuthor(id);
            foreach (var book in books)
            {
                Console.WriteLine($"{book.BookId} {book.Title} {book.Language} {book.Pages} {book.Price} {book.Rating} {book.Count} ");
            }
        }
        //Get category ID from the console, fetch list of books by category ID from the database
        private void ListBooksByCategory()
        {
            Console.WriteLine("Enter category's ID: ");
            int id = int.Parse(Console.ReadLine());

            Console.WriteLine(new string('-', 40));
            Console.WriteLine(new string(' ', 16) + "BOOK" + new string(' ', 16));
            Console.WriteLine(new string('-', 40));
            var books = controller.GetBooksByCategory(id);
            foreach (var book in books)
            {
                Console.WriteLine($"{book.BookId} {book.Title} {book.Language} {book.Pages} {book.Price} {book.Rating} {book.Count} ");
            }
        }
        //Get genre ID from the console, fetch list of books by genre ID from the database
        private void ListBooksByGenre()
        {
            Console.WriteLine("Enter genre's ID: ");
            int id = int.Parse(Console.ReadLine());
            Console.WriteLine(new string('-', 40));
            Console.WriteLine(new string(' ', 16) + "BOOK" + new string(' ', 16));
            Console.WriteLine(new string('-', 40));
            var books = controller.GetBooksByGenre(id);
            foreach (var book in books)
            {
                Console.WriteLine($"{book.BookId} {book.Title} {book.Language} {book.Pages} {book.Price} {book.Rating} {book.Count} ");
            }
        }
        //Get serie ID from the console, fetch list of books by serie ID from the database
        private void ListBooksBySerie()
        {
            Console.WriteLine("Enter serie's ID: ");
            int id = int.Parse(Console.ReadLine());
            Console.WriteLine(new string('-', 40));
            Console.WriteLine(new string(' ', 16) + "BOOK" + new string(' ', 16));
            Console.WriteLine(new string('-', 40));
            var books = controller.GetBooksBySerie(id);
            foreach (var book in books)
            {
                Console.WriteLine($"{book.BookId} {book.Title} {book.Language} {book.Pages} {book.Price} {book.Rating} {book.Count} ");
            }
        }
        //Get publisher ID from the console, fetch list of books by publisher ID from the database
        private void ListBooksByPublisher()
        {
            Console.WriteLine("Enter publisher's ID: ");
            int id = int.Parse(Console.ReadLine());
            Console.WriteLine(new string('-', 40));
            Console.WriteLine(new string(' ', 16) + "BOOK" + new string(' ', 16));
            Console.WriteLine(new string('-', 40));
            var books = controller.GetBooksByPublisher(id);
            foreach (var book in books)
            {
                Console.WriteLine($"{book.BookId} {book.Title} {book.Language} {book.Pages} {book.Price} {book.Rating} {book.Count} ");
            }
        }
        //Get price from the console, fetch list of books with less price from the database
        private void ListBooksWithLessPrice()
        {
            decimal price = int.Parse(Console.ReadLine());
            Console.WriteLine(new string('-', 40));
            Console.WriteLine(new string(' ', 16) + "BOOK" + new string(' ', 16));
            Console.WriteLine(new string('-', 40));
            var books = controller.GetBooksWithLessPrice(price);
            foreach (var book in books)
            {
                Console.WriteLine($"{book.BookId} {book.Title} {book.Language} {book.Pages} {book.Price} {book.Rating} {book.Count} ");
            }
        }
        //Get price from the console, fetch list of books with bigger price from the database
        private void ListBooksWithBiggerPrice()
        {
            decimal price = int.Parse(Console.ReadLine());
            Console.WriteLine(new string('-', 40));
            Console.WriteLine(new string(' ', 16) + "BOOK" + new string(' ', 16));
            Console.WriteLine(new string('-', 40));
            var books = controller.GetBooksWithBiggerPrice(price);
            foreach (var book in books)
            {
                Console.WriteLine($"{book.BookId} {book.Title} {book.Language} {book.Pages} {book.Price} {book.Rating} {book.Count} ");
            }
        }
        //Get pages from the console, fetch list of books with less pages from the database
        private void ListBooksWithLessPages()
        {
            int pages = int.Parse(Console.ReadLine());
            Console.WriteLine(new string('-', 40));
            Console.WriteLine(new string(' ', 16) + "BOOK" + new string(' ', 16));
            Console.WriteLine(new string('-', 40));
            var books = controller.GetBooksWithLessPages(pages);
            foreach (var book in books)
            {
                Console.WriteLine($"{book.BookId} {book.Title} {book.Language} {book.Pages} {book.Price} {book.Rating} {book.Count} ");
            }
        }
        //Get pages from the console, fetch list of books with more pages from the database
        private void ListBooksWithMorePages()
        {
            int pages = int.Parse(Console.ReadLine());
            Console.WriteLine(new string('-', 40));
            Console.WriteLine(new string(' ', 16) + "BOOK" + new string(' ', 16));
            Console.WriteLine(new string('-', 40));
            var books = controller.GetBooksWithMorePages(pages);
            foreach (var book in books)
            {
                Console.WriteLine($"{book.BookId} {book.Title} {book.Language} {book.Pages} {book.Price} {book.Rating} {book.Count} ");
            }
        }
        //Get rating from the console, fetch list of books by rating from the database
        private void ListBooksByRating()
        {
            Console.WriteLine("Enter rating: ");
            int rating = int.Parse(Console.ReadLine());
            Console.WriteLine(new string('-', 40));
            Console.WriteLine(new string(' ', 16) + "BOOK" + new string(' ', 16));
            Console.WriteLine(new string('-', 40));
            var books = controller.GetBooksWithRating(rating);
            foreach (var book in books)
            {
                Console.WriteLine($"{book.BookId} {book.Title} {book.Language} {book.Pages} {book.Price} {book.Rating} {book.Count} ");
            }
        }
        //Get language from the console, fetch list of books by language from the database
        private void ListBooksByLanguage()
        {
            Console.WriteLine("Enter language: ");
            string language = Console.ReadLine();
            Console.WriteLine(new string('-', 40));
            Console.WriteLine(new string(' ', 16) + "BOOK" + new string(' ', 16));
            Console.WriteLine(new string('-', 40));
            var books = controller.GetBooksWithLanguage(language);
            foreach (var book in books)
            {
                Console.WriteLine($"{book.BookId} {book.Title} {book.Pages} {book.Price} {book.Rating} {book.Count} ");
            }
        }
        //Added new book to the database
        private void Add()
        {
            Book book = new Book();
            Console.WriteLine("Enter language: ");
            book.Language = Console.ReadLine();
            Console.WriteLine("Enter author's id: ");
            book.AuthorId = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter category's id: ");
            book.CategoryId = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter genre's id: ");
            book.GenreId = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter serie's id: ");
            book.SerieId = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter publisher's id: ");
            book.PublisherId = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter price: ");
            book.Price = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter pages: ");
            book.Pages = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter rating: ");
            book.Rating = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter count:");
            book.Count = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter title: ");
            book.Title = Console.ReadLine();
            controller.AddBook(book);
        }
        //Get book ID from the console, fetch book with this ID and update it
        private void Update()
        {
            Console.WriteLine(new string("Enter ID to update: "));
            int id = int.Parse(Console.ReadLine());
            Book book = controller.GetBookById(id);
            if (book != null)
            {
                Console.WriteLine("Enter title: ");
                book.Title = Console.ReadLine();
                controller.UpdateBook(book);
            }
            else { Console.WriteLine("Book not found!"); }
        }
        //Get book ID from the console and fetch book with this ID
        private void FetchBookById()
        {
            Console.WriteLine("Enter ID to fetch: ");
            int id = int.Parse(Console.ReadLine());
            Book book = controller.GetBookById(id);
            if (book != null)
            {
                Console.WriteLine(new string('-', 40));
                Console.WriteLine($"{book.BookId} {book.Title} {book.Language} {book.Pages} {book.Price} {book.Rating} {book.Count} ");
                Console.WriteLine(new string('-', 40));
            }
        }
        //Get book ID from the console and delete the book with this ID
        private void Delete()
        {
            Console.WriteLine("Enter ID to delete: ");
            int id = int.Parse(Console.ReadLine());
            controller.DeleteBook(id);
            Console.WriteLine("Done.");
        }
        //Get book title from the console and fetch book with this title
        private void FetchBookByTitle()
        {
            Console.WriteLine("Enter title to fetch: ");
            string title = Console.ReadLine();
            Book book = controller.GetBookByTitle(title);
            if (book != null)
            {
                Console.WriteLine(new string('-', 40));
                Console.WriteLine($"{book.BookId} {book.Title} {book.Language} {book.Pages} {book.Price} {book.Rating} {book.Count} ");
                Console.WriteLine(new string('-', 40));
            }
        }
    }
}
