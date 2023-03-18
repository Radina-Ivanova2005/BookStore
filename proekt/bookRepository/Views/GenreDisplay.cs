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
    public class GenreDisplay
    {
        private GenreController controller = new GenreController(new Data.BookShopContext());
        public GenreDisplay()
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
                    case 4: Fetch(); break;
                    case 5: Delete(); break;
                    default:
                        break;
                }
            } while (operation != closeOperationId);
        }

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

        private void Delete()
        {
            Console.WriteLine("Enter Id to delete: ");
            int id = int.Parse(Console.ReadLine());
            controller.DeleteGenre(id);
            Console.WriteLine("Done.");
        }

        private void Fetch()
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
            else { Console.WriteLine("Author not found!"); }
        }

        private void Add()
        {
            Genre genre = new Genre();
            Console.WriteLine("Enter name: ");
            genre.Name = Console.ReadLine();
            controller.AddGenre(genre);
        }
    }
}
