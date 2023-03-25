using bookRepository.Busines;
using bookRepository.Models;

namespace bookRepository.Views
{
    public class PublisherDisplay
    {
        private PublisherController controller = new PublisherController(new Data.BookShopContext());
        public PublisherDisplay()
        {
            Input();
        }

        private int closeOperationId = 7;

        //Print the menu
        private void ShowMenu()
        {
            Console.WriteLine(new string('-', 40));
            Console.WriteLine(new string(
                ' ', 18) + "MENU" + new string(
                ' ', 18));
            Console.WriteLine(new string('-', 40));
            Console.WriteLine("1. List all publishers");
            Console.WriteLine("2. Add new publisher");
            Console.WriteLine("3. Update publisher");
            Console.WriteLine("4. Fetch publisher by ID");
            Console.WriteLine("5. Fetch publisher by Name");
            Console.WriteLine("6. Delete publisher by ID");
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

        //Get publisher ID from the console and delete the publisher with this ID
        private void Delete()
        {
            Console.WriteLine("Enter Id to delete: ");
            int id = int.Parse(Console.ReadLine());
            controller.DeletePublisher(id);
            Console.WriteLine("Done.");
        }

        //Get publisher ID from the console and fetch pu publisher with this ID
        private void FetchById()
        {
            Console.WriteLine("Enter ID to fetch: ");
            int id = int.Parse(Console.ReadLine());
            Publisher publisher = controller.GetPublisherById(id);
            if (publisher != null)
            {
                Console.WriteLine(new string('-', 40));
                Console.WriteLine("ID: " + publisher.Id);
                Console.WriteLine("Name: " + publisher.Name);
                Console.WriteLine(new string('-', 40));
            }
        }


        //Get publisher name from the console and fetch publisher with this name
        private void FetchByName()
        {
            Console.WriteLine("Enter name to fetch: ");
            string name = Console.ReadLine();
            Publisher publisher = controller.GetPublisherByName(name);
            if (publisher != null)
            {
                Console.WriteLine(new string('-', 40));
                Console.WriteLine("ID: " + publisher.Id);
                Console.WriteLine("Name: " + publisher.Name);
                Console.WriteLine(new string('-', 40));
            }
        }

        //Get publisher ID from the console, fetch publisher with this ID and update the it
        private void Update()
        {
            Console.WriteLine(new string("Enter ID to update: "));
            int id = int.Parse(Console.ReadLine());
            Publisher publisher = controller.GetPublisherById(id);
            if (publisher != null)
            {
                Console.WriteLine("Enter name: ");
                publisher.Name = Console.ReadLine();
                controller.UpdatePublisher(publisher);
            }
            else { Console.WriteLine("Publisher not found!"); }
        }

        //Addet new publisher to the database
        private void Add()
        {
            Publisher publisher = new Publisher();
            Console.WriteLine("Enter name: ");
            publisher.Name = Console.ReadLine();
            controller.AddPublisher(publisher);
        }

        //Fetch list of all publishers from the database
        private void List()
        {
            Console.WriteLine(new string('-', 40));
            Console.WriteLine(new string(' ', 16)
                + "PUBLISHERS" + new string(' ', 16));
            Console.WriteLine(new string('-', 40));
            var publishers = controller.GetAllPublishers();
            foreach (var publisher in publishers)
            {
                Console.WriteLine($"{publisher.Id} {publisher.Name}");
            }
        }
    }
}


