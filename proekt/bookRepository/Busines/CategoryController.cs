using bookRepository.Data;
using bookRepository.Data.Models;

namespace bookRepository.Busines
{
    public class CategoryController
    {
        private BookShopContext context;
        public CategoryController(BookShopContext context)
        {
            this.context = context;
        }


        //Added new category to the database
        public void AddCategory(Category category)
        {
            this.context.Categories.Add(category);
            this.context.SaveChanges();
        }

        //Fetch list of all categories in the database
        public List<Category> GetAllCategories()
        {
            return context.Categories.ToList();
        }

        //Fetch certain categori from the database by ID
        public Category GetCategoryById(int id)
        {
            var category = this.context.Categories.FirstOrDefault(x => x.Id == id);
            return category;
        }

        //Fetch certain categori from the database by name of the category
        public Category GetCategoryByName(string name)
        {
            var category = this.context.Categories.FirstOrDefault(x => x.Name == name);
            return category;
        }

        //Updated certain category from the database with new categorу characteristics
        public void UpdateCategory(Category category)
        {
            var categoryItem = this.GetCategoryById(category.Id);
            this.context.Entry(categoryItem).CurrentValues.SetValues(category);
            this.context.SaveChanges();
        }


        //Deleted certain category by ID
        public void DeleteCategory(int id)
        {
            var categoryItem = this.GetCategoryById(id);
            this.context.Categories.Remove(categoryItem);
            this.context.SaveChanges();
        }

       

    }
}


