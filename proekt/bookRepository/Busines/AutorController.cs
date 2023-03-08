using bookRepository.Data;
using bookRepository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bookRepository.Busines
{
    public class AutorController
    {
        private BookShopContext context;
        public AutorController()
        {
            context = new BookShopContext();
        }

        public void AddAutor(Autor autor)
        {
            this.context.Autors.Add(autor);
            this.context.SaveChanges();
            
        }

        public List<Autor> GetAllAutors()
        {
            return context.Autors.Where(x => x.IsDeleted == false).ToList();
        }
        public Autor GetAutorById(int id)
        {
            var autor = this.context.Autors.FirstOrDefault(x => x.Id == id && x.IsDeleted == false);
            return autor;
        }
        public void UpdateAutor(Autor autor)
        {
            var autorItem = this.GetAutorById(autor.Id);
            this.context.Entry(autorItem).CurrentValues.SetValues(autor);
            this.context.SaveChanges();
        }

        public void DeleteAutor(int id)
        {
            var autorItem = this.GetAutorById(id);
            BookController bookController = new BookController();
            var books = bookController.GetBooksByAutor(autorItem.Id).ToList();
            foreach (var book in books)
            {
                book.IsDeleted = true;
            }

            autorItem.IsDeleted = true;
            this.context.SaveChanges();

        }


        
    }
}
