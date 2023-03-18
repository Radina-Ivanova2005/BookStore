using bookRepository.Data;
using bookRepository.Data.Models;
using bookRepository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bookRepository.Busines
{
    public  class CategoryController
    {
        private BookShopContext context;
        public CategoryController(BookShopContext context)
        {
            this.context = context;
        }

        

        public void AddCategory(Category category)
        {
            this.context.Categories.Add(category);
            this.context.SaveChanges();
        }

        public List<Category> GetAllCategories()
        {
            return context.Categories.OrderBy(c=>c.Name).ToList();
        }

        public Category GetCategoryById(int id)
        {
            var category = this.context.Categories.FirstOrDefault(x => x.Id == id);
            return category;
        }

        public Category GetCategoryByName(string name)
        {
            var category = this.context.Categories.FirstOrDefault(x => x.Name == name);
            return category;
        }
        public void UpdateCategory(Category category)
        {
            var categoryItem = this.GetCategoryById(category.Id);
            this.context.Entry(categoryItem).CurrentValues.SetValues(category);
            this.context.SaveChanges();
        }


        public void DeleteCategory(int id)
        {
            var categoryItem = this.GetCategoryById(id);
            this.context.Categories.Remove(categoryItem);
            this.context.SaveChanges();
        }

        public void DeleteCategory(Category category)
        {
            var categoryItem = this.GetCategoryById(category.Id);
            this.context.Categories.Remove(categoryItem);
            this.context.SaveChanges();
        }

    }
}
