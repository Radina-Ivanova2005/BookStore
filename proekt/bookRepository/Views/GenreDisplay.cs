using bookRepository.Busines;
using bookRepository.Models;


namespace bookRepository.Views
{
    public class GenreDisplay
    {
        private GenreController controller = new GenreController(new Data.BookShopContext());
        public GenreDisplay()
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
            Console.WriteLine("1. List all genres");
            Console.WriteLine("2. Add new genre");
            Console.WriteLine("3. Update genre");
            Console.WriteLine("4. Fetch genre by ID");
            Console.WriteLine("5. Delete genre by ID");
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
        //Fetch list of all genres from the database
        private void List()
        {
            Console.WriteLine(new string('-', 40));
            Console.WriteLine(new string(' ', 16) + "GENRE" + new string(' ', 16));
            Console.WriteLine(new string('-', 40));
            var genres = controller.GetAllGenres();
            foreach (var genre in genres)
            {
                Console.WriteLine($"{genre.Id} {genre.Name} ");
            }
        }
        //Get genre ID from the console and delete the genre with this ID
        private void Delete()
        {
            Console.WriteLine("Enter Id to delete: ");
            int id = int.Parse(Console.ReadLine());
            controller.DeleteGenre(id);
            Console.WriteLine("Done.");
        }
        //Get genre ID from the console and fetch genre with this ID
        private void FetchById()
        {
            Console.WriteLine("Enter ID to fetch: ");
            int id = int.Parse(Console.ReadLine());
            Genre genre = controller.GetGenreById(id);
            if (genre != null)
            {
                Console.WriteLine(new string('-', 40));
                Console.WriteLine("ID: " + genre.Id);
                Console.WriteLine("Name: " + genre.Name);
                Console.WriteLine(new string('-', 40));
            }
        }

        //Get genre name from the console and fetch genre with this name
        private void FetchByName()
        {
            Console.WriteLine("Enter name to fetch: ");
            string name = Console.ReadLine();
            Genre genre = controller.GetGenreByName(name);
            if (genre != null)
            {
                Console.WriteLine(new string('-', 40));
                Console.WriteLine("ID: " + genre.Id);
                Console.WriteLine("Name: " + genre.Name);
                Console.WriteLine(new string('-', 40));
            }
        }
        //Get genre ID from the console, fetch genre with this ID and update it
        private void Update()
        {
            Console.WriteLine(new string("Enter ID to update: "));
            int id = int.Parse(Console.ReadLine());
            Genre genre = controller.GetGenreById(id);
            if (genre != null)
            {
                Console.WriteLine("Enter name: ");
                genre.Name = Console.ReadLine();

                controller.UpdateGenre(genre);
            }
            else { Console.WriteLine("Genre not found!"); }
        }
        //Added new genre to the database
        private void Add()
        {
            Genre genre = new Genre();
            Console.WriteLine("Enter name: ");
            genre.Name = Console.ReadLine();
            controller.AddGenre(genre);
        }
    }
}
