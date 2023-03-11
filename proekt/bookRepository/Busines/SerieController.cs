using bookRepository.Data;
using bookRepository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bookRepository.Busines
{
    public class SerieController
    {
        private BookShopContext context;
        public SerieController()
        {
            context = new BookShopContext();
        }


        public void AddSerie(Serie serie)
        {
            this.context.Series.Add(serie);
            this.context.SaveChanges();
        }

        public List<Serie> GetAllSeries()
        {
            return context.Series.Where(x => x.IsDeleted == false).ToList();
        }

        public Serie GetSerieById(int id)
        {
            var serie = this.context.Series.FirstOrDefault(x => x.Id == id && x.IsDeleted == false);
            return serie;
        }
        public void UpdateSerie(Serie serie)
        {
            var serieItem = this.GetSerieById(serie.Id);
            this.context.Entry(serieItem).CurrentValues.SetValues(serie);
            this.context.SaveChanges();
        }


        public void DeleteSerie(int id)
        {
            var serieItem = this.GetSerieById(id);           
            BookController bookController = new BookController();
            var books = bookController.GetBooksBySerie(serieItem.Id).ToList();
            foreach (var book in books)
            {
                bookController.DeleteBook(book.BookId);
                this.context.SaveChanges();
            }

            serieItem.IsDeleted = true;
            this.context.SaveChanges();
        }
    }
}
