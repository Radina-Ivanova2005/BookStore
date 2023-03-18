using Azure;
using bookRepository.Data;
using bookRepository.Busines;
using bookRepository.Data.Models;
using bookRepository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bookRepository.Views
{
    public class BookDisplay
    {
        private BookController controller = new BookController(new Data.BookShopContext());
        public BookDisplay()
        {
            
            Input();
        }

        private int closeOperationId = 17;
        private AuthorController authorController;
        private CategoryController categoryController;
        private GenreController genreController;
        private PublisherController publisherController;
        private SerieController serieController;


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
            Console.WriteLine("16. Delete book by ID");
            Console.WriteLine("17. Close");

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
                    case 15: Fetch(); break;
                    case 16: Delete(); break;
                    default:
                        break;
                }
            } while (operation != closeOperationId);
        }

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
        private void ListBooksByAuthor()
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
        private void ListBooksByCategory()
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

        private void ListBooksByGenre()
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
        private void ListBooksBySerie()
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

        private void ListBooksByPublisher()
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

        private void ListBooksByRating()
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

        private void ListBooksByLanguage()
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





        private void Add()
        {
            Book book = new Book();
            Console.WriteLine("Enter language: ");
            book.Language = Console.ReadLine();
            Console.WriteLine("Enter author_id: ");
            book.AuthorId = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter category_id: ");
            book.CategoryId = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter genre_id: ");
            book.GenreId = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter serie_id: ");
            book.SerieId = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter publisher_id: ");
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
        private void Fetch()
        {
            Console.WriteLine("Enter ID to fetch: ");
            int id = int.Parse(Console.ReadLine());
            Book book = controller.GetBookById(id);
            if (book != null)
            {
                Console.WriteLine(new string('-', 40));
                Console.WriteLine("ID: " + book.BookId);
                Console.WriteLine("Title: " + book.Title);
                Console.WriteLine(new string('-', 40));
            }
        }
        private void Delete()
        {
            Console.WriteLine("Enter ID to delete: ");
            int id = int.Parse(Console.ReadLine());
            controller.DeleteBook(id);
            Console.WriteLine("Done.");
        }









    }
}
