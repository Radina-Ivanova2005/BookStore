using bookRepository.Data;
using bookRepository.Models;

namespace bookRepository.Busines
{
    public class AuthorController
    {
        private BookShopContext context;
        public AuthorController(BookShopContext context)
        {
            this.context = context;
        }
        //Added new author to the database
        public void AddAuthor(Author author)
        {
            this.context.Authors.Add(author);
            this.context.SaveChanges();

        }
        //Fetch list of all authors in the database
        public List<Author> GetAllAuthors()
        {
            return context.Authors.OrderBy(a => a.Name).ToList();
        }
        //Fetch certain author from the database by ID
        public Author GetAuthorById(int id)
        {
            var author = this.context.Authors.FirstOrDefault(x => x.Id == id);
            return author;
        }
        //Fetch certain author from the database by name of the author
        public Author GetAuthorByName(string name)
        {
            var author = this.context.Authors.FirstOrDefault(x => x.Name == name);
            return author;
        }
        //Updated certain author from the database with new author characteristics
        public void UpdateAuthor(Author author)
        {
            var authorItem = this.GetAuthorById(author.Id);
            this.context.Entry(authorItem).CurrentValues.SetValues(author);
            this.context.SaveChanges();
        }
        //Deleted certain author by ID
        public void DeleteAuthor(int id)
        {
            var authorItem = this.GetAuthorById(id);
            this.context.Authors.Remove(authorItem);
            this.context.SaveChanges();
        }



    }
}
