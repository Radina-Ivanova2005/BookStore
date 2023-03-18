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
    public class SerieController
    {
        private BookShopContext context;
        public SerieController(BookShopContext context)
        {
            this.context = context;
        }


        public void AddSerie(Serie serie)
        {
            this.context.Series.Add(serie);
            this.context.SaveChanges();
        }

        public List<Serie> GetAllSeries()
        {
            return context.Series.OrderBy(s=>s.Title).ToList();
        }

        public Serie GetSerieById(int id)
        {
            var serie = this.context.Series.FirstOrDefault(x => x.Id == id);
            return serie;
        }

        public Serie GetSerieByTitle(string title)
        {
            var serie = this.context.Series.FirstOrDefault(x => x.Title== title);
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
            this.context.Series.Remove(serieItem);
            this.context.SaveChanges();
        }
    }
}
