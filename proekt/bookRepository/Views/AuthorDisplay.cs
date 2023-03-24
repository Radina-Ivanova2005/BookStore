using bookRepository.Busines;
using bookRepository.Models;


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
        //Print the menu
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
                    case 4: FetchById(); break;
                    case 5: FetchByName(); break;
                    case 6: Delete(); break;
                    default:
                        break;
                }
            } while (operation != closeOperationId);
        }
        //Get author ID from the console and delete the author with this ID
        private void Delete()
        {
            Console.WriteLine("Enter Id to delete: ");
            int id = int.Parse(Console.ReadLine());
            controller.DeleteAuthor(id);
            Console.WriteLine("Done.");
        }
        //Get author ID from the console and fetch author with this ID
        private void FetchById()
        {
            Console.WriteLine("Enter ID to fetch: ");
            int id = int.Parse(Console.ReadLine());
            Author author = controller.GetAuthorById(id);
            if (author != null)
            {
                Console.WriteLine(new string('-', 40));
                Console.WriteLine("ID: " + author.Id);
                Console.WriteLine("Name: " + author.Name);
                Console.WriteLine(new string('-', 40));
            }
        }
        //Get author name from the console and fetch author with this name
        private void FetchByName()
        {
            Console.WriteLine("Enter name to fetch: ");
            string name = Console.ReadLine();
            Author author = controller.GetAuthorByName(name);
            if (author != null)
            {
                Console.WriteLine(new string('-', 40));
                Console.WriteLine("ID: " + author.Id);
                Console.WriteLine("Name: " + author.Name);
                Console.WriteLine(new string('-', 40));
            }
        }
        //Get author ID from the console, fetch author with this ID and update it
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
        //Added new author to the database
        private void Add()
        {
            Author author = new Author();
            Console.WriteLine("Enter name: ");
            author.Name = Console.ReadLine();
            controller.AddAuthor(author);
        }
        //Fetch list of all authors from the database
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
