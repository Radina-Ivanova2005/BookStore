using bookRepository.Busines;
using bookRepository.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bookRepository.Views
{
    public class CategoryDidplay
    {
        private CategoryController controller;
        public CategoryDidplay() 
        {
            controller = new CategoryController();
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
            Console.WriteLine("1. List all categories");
            Console.WriteLine("2. Add new category");
            Console.WriteLine("3. Update category");
            Console.WriteLine("4. Fetch category by ID");
            Console.WriteLine("5. Delete category by ID");
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
            controller.DeleteCategory(id);
            Console.WriteLine("Done.");
        }

        private void Fetch()
        {
            Console.WriteLine("Enter ID to fetch: ");
            int id = int.Parse(Console.ReadLine());
            Category product = controller.GetCategoryById(id);
            if (product != null)
            {
                Console.WriteLine(new string('-', 40));
                Console.WriteLine("ID: " + product.Id);
                Console.WriteLine("Name: " + product.Name);
                Console.WriteLine(new string('-', 40));
            }
        }

        private void Update()
        {
            Console.WriteLine(new string("Enter ID to update: "));
            int id = int.Parse(Console.ReadLine());
            Category category = controller.GetCategoryById(id);
            if (category != null)
            {
                Console.WriteLine("Enter name: ");
                category.Name = Console.ReadLine();
                controller.UpdateCategory(category);
            }
            else { Console.WriteLine("Category not found!"); }
        }

        private void Add()
        {
            Category category = new Category();
            Console.WriteLine("Enter name: ");
            category.Name = Console.ReadLine();
            controller.AddCategory(category);
        }

        private void List()
        {
            Console.WriteLine(new string('-', 40));
            Console.WriteLine(new string(' ', 16) 
                + "CATEGORIES" + new string(' ', 16));
            Console.WriteLine(new string('-', 40));
            var categories = controller.GetAllCategories();
            foreach (var category in categories)
            {
                Console.WriteLine($"{category.Id} {category.Name}");
            }
        }
    }
}
