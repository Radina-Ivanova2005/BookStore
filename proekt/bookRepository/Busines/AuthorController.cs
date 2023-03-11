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
            return context.Authors.Where(x => x.IsDeleted == false).ToList();
        }
        public Author GetAuthorById(int id)
        {
            var author = this.context.Authors.FirstOrDefault(x => x.Id == id && x.IsDeleted == false);
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
            BookController bookController = new BookController();
            var books = bookController.GetBooksByAuthor(authorItem.Id).ToList();
            foreach (var book in books)
            {
                bookController.DeleteBook(book.BookId);
                this.context.SaveChanges();
            }

            authorItem.IsDeleted = true;
            this.context.SaveChanges();

        }


        
    }
}
