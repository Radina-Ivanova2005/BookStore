using bookRepository.Data;
using bookRepository.Models;

namespace bookRepository.Busines
{
    public class AuthorController
    {
        private BookShopContext context;
        public AuthorController()
        {
            context = new BookShopContext();
        }

        public void AddAuthor(Author author)
        {
            this.context.Authors.Add(author);
            this.context.SaveChanges();
            
        }

        public List<Author> GetAllAuthors()
        {
            return context.Authors.ToList();
        }
        public Author GetAuthorById(int id)
        {
            var author = this.context.Authors.FirstOrDefault(x => x.Id == id);
            return author;
        }
        public void UpdateAuthor(Author author)
        {
            var authorItem = this.GetAuthorById(author.Id);
            this.context.Entry(authorItem).CurrentValues.SetValues(author);
            this.context.SaveChanges();
        }

        public void DeleteAuthor(int id)
        {
            var authorItem = this.GetAuthorById(id);
            this.context.Authors.Remove(authorItem);
            this.context.SaveChanges(); 
        }


        
    }
}
