using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bookRepository.Views
{
    public class Display
    {

        public Display()
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
            Console.WriteLine("1. Books");
            Console.WriteLine("2. Authors");
            Console.WriteLine("3. Categories");
            Console.WriteLine("4. Genres");
            Console.WriteLine("5. Publishers");
            Console.WriteLine("6. Series");
            Console.WriteLine("7. Exit");

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
                    case 1: BookDisplay bookDisplay = new BookDisplay(); break;
                    case 2: AuthorDisplay authorDisplay = new AuthorDisplay(); break;
                    case 3: CategoryDidplay categoryDidplay = new CategoryDidplay(); break;
                    case 4: GenreDisplay genreDisplay = new GenreDisplay(); break;
                    case 5: PublisherDisplay publisherDisplay = new PublisherDisplay(); break;
                    case 6: SerieDisplay serieDisplay = new SerieDisplay(); break;
                    default:
                        break;
                }
            } while (operation != closeOperationId);
        }
    }
}
