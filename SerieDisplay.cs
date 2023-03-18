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
    public class SerieDisplay
    {
        private SerieController controller = new SerieController(new Data.BookShopContext());
        public SerieDisplay()
        {
            Input();
        }

        private int closeOperationId = 7;
        private void ShowMenu()
        {
            Console.WriteLine(new string('-', 40));
            Console.WriteLine(new string(
                ' ', 18) + "MENU" + new string(
                ' ', 18));
            Console.WriteLine(new string('-', 40));
            Console.WriteLine("1. List all series");
            Console.WriteLine("2. Add new serie");
            Console.WriteLine("3. Update serie");
            Console.WriteLine("4. Fetch serie by ID");
            Console.WriteLine("5. Fetch serie by name");
            Console.WriteLine("6. Delete serie by ID");
            Console.WriteLine("7. Close");
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

        private void Delete()
        {
            Console.WriteLine("Enter Id to delete: ");
            int id = int.Parse(Console.ReadLine());
            controller.DeleteSerie(id);
            Console.WriteLine("Done.");
        }

        private void FetchById()
        {
            Console.WriteLine("Enter ID to fetch: ");
            int id = int.Parse(Console.ReadLine());
            Serie serie = controller.GetSerieById(id);
            if (serie != null)
            {
                Console.WriteLine(new string('-', 40));
                Console.WriteLine("ID: " + serie.Id);
                Console.WriteLine("Name: " + serie.Title);
                Console.WriteLine(new string('-', 40));
            }
        }

        private void FetchByName()
        {
            Console.WriteLine("Enter name to fetch: ");
            string title = Console.ReadLine();
            Serie serie = controller.GetSerieByTitle(title);
            if (serie != null)
            {
                Console.WriteLine(new string('-', 40));
                Console.WriteLine("ID: " + serie.Id);
                Console.WriteLine("Name: " + serie.Title);
                Console.WriteLine(new string('-', 40));
            }
        }



        private void Update()
        {
            Console.WriteLine(new string("Enter ID to update: "));
            int id = int.Parse(Console.ReadLine());
            Serie serie = controller.GetSerieById(id);
            if (serie != null)
            {
                Console.WriteLine("Enter name: ");
                serie.Title = Console.ReadLine();
                controller.UpdateSerie(serie);
            }
            else { Console.WriteLine("Serie not found!"); }
        }

        private void Add()
        {
            Serie serie = new Serie();
            Console.WriteLine("Enter name: ");
            serie.Title = Console.ReadLine();
            controller.AddSerie(serie);
        }

        private void List()
        {
            Console.WriteLine(new string('-', 40));
            Console.WriteLine(new string(' ', 16)
                + "SERIES" + new string(' ', 16));
            Console.WriteLine(new string('-', 40));
            var series = controller.GetAllSeries();
            foreach (var serie in series)
            {
                Console.WriteLine($"{serie.Id} {serie.Title}");
            }
        }
    }
}
