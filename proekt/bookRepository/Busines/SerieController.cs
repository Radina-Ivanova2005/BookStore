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

        //Added serie to the database 
        public void AddSerie(Serie serie)
        {
            this.context.Series.Add(serie);
            this.context.SaveChanges();
        }

        //Fetch list of series from the database
        public List<Serie> GetAllSeries()
        {
            return context.Series.OrderBy(s=>s.Title).ToList();
        }

        //Fetch certain sserie from the database by ID
        public Serie GetSerieById(int id)
        {
            var serie = this.context.Series.FirstOrDefault(x => x.Id == id);
            return serie;
        }

        //Fetch certain serie from the database by name
        public Serie GetSerieByTitle(string title)
        {
            var serie = this.context.Series.FirstOrDefault(x => x.Title== title);
            return serie;
        }

        //Update certain serie from the database with new serie characteristics
        public void UpdateSerie(Serie serie)
        {
            var serieItem = this.GetSerieById(serie.Id);
            this.context.Entry(serieItem).CurrentValues.SetValues(serie);
            this.context.SaveChanges();
        }

        //Delete certain serie from the database bi ID
        public void DeleteSerie(int id)
        {
            var serieItem = this.GetSerieById(id);
            this.context.Series.Remove(serieItem);
            this.context.SaveChanges();
        }
    }
}
