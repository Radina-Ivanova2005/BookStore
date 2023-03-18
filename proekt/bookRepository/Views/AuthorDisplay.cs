using bookRepository.Busines;
using bookRepository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bookRepository.Views
{
    public class AuthorDisplay
    {
        private AuthorController controller = new AuthorController(new Data.BookShopContext());
        public AuthorDisplay()
        {
            Input();
        }

        private int closeOperationId = 6;
        private void ShowMenu()
        {
            Console.WriteLine(new string('-', 40));
            Console.WriteLine(new string(
                ' ', 18) + "MENU" + new string(
                ' ', 18));
            Console.WriteLine(new string('-', 40));
            Console.WriteLine("1. List all authors");
            Console.WriteLine("2. Add new author");
            Console.WriteLine("3. Update author");
            Console.WriteLine("4. Fetch author by ID");
            Console.WriteLine("5. Delete author by ID");
            Console.WriteLine("6. Close");
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
                    case 2: Add(); break;
                    case 3: Update(); break;
                    case 4: Fetch(); break;
                    case 5: Delete(); break;
                    default:
                        break;
                }
            } while (operation != closeOperationId);
        }

        private void Delete()
        {
            Console.WriteLine("Enter Id to delete: ");
            int id = int.Parse(Console.ReadLine());
            controller.DeleteAuthor(id);
            Console.WriteLine("Done.");
        }

        private void Fetch()
        {
            Console.WriteLine("Enter ID to fetch: ");
            int id = int.Parse(Console.ReadLine());
            Author author = controller.GetAuthorById(id);
            if (author != null)
            {
                Console.WriteLine(new string('-', 40));
                Console.WriteLine("ID: " +  author.Id);
                Console.WriteLine("Name: " + author.Name);
                Console.WriteLine(new string('-', 40));
            }
        }

        private void Update()
        {
            Console.WriteLine(new string("Enter ID to update: "));
            int id = int.Parse(Console.ReadLine());
            Author author = controller.GetAuthorById(id);
            if (author != null)
            {
                Console.WriteLine("Enter name: ");
                author.Name = Console.ReadLine();
                controller.UpdateAuthor(author);
            }
            else { Console.WriteLine("Author not found!"); }
        }

        private void Add()
        {
            Author author = new Author();
            Console.WriteLine("Enter name: ");
            author.Name = Console.ReadLine();
            controller.AddAuthor(author);
        }

        private void List()
        {
            Console.WriteLine(new string('-', 40));
            Console.WriteLine(new string(' ', 16)
                + "AUTHORS" + new string(' ', 16));
            Console.WriteLine(new string('-', 40));
            var authors = controller.GetAllAuthors();
            foreach (var author in authors)
            {
                Console.WriteLine($"{author.Id} {author.Name}");
            }
        }
    }
}
