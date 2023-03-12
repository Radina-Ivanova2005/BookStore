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
    public class PublisherDisplay
    {
        private PublisherController controller;
        public PublisherDisplay()
        {
            controller = new PublisherController();
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
            Console.WriteLine("1. List all publishers");
            Console.WriteLine("2. Add new publisher");
            Console.WriteLine("3. Update publisher");
            Console.WriteLine("4. Fetch publisher by ID");
            Console.WriteLine("5. Delete publisher by ID");
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
            controller.DeletePublisher(id);
            Console.WriteLine("Done.");
        }

        private void Fetch()
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

        private void Add()
        {
            Publisher publisher = new Publisher();
            Console.WriteLine("Enter name: ");
            publisher.Name = Console.ReadLine();
            controller.AddPublisher(publisher);
        }

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
