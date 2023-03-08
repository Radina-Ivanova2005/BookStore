using bookRepository.Data;
using bookRepository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bookRepository.Busines
{
    public class GenreController
    {

        private BookShopContext context;
        public GenreController()
        {
            context = new BookShopContext();
        }

        public void AddGenre(Genre genre)
        {
            this.context.Genres.Add(genre);
            this.context.SaveChanges();
        }

        //public List<Genre> GetAllGenres()
        //{
        //    return context.Genres.Where(x=> x.IsDeleted == false).ToList();
        //}

        public Genre GetGenreById(int id)
        {
            var genre = this.context.Genres.FirstOrDefault(x => x.Id == id && x.IsDeleted == false);
            return genre;
        }
        public void UpdateGenre(Genre genre)
        {
            var genreItem = this.GetGenreById(genre.Id);
            this.context.Entry(genreItem).CurrentValues.SetValues(genre);
            this.context.SaveChanges();
        }

        public void DeleteGenre(int id)
        {
            var genreItem = this.GetGenreById(id);
            genreItem.IsDeleted = true;
            this.context.SaveChanges();
        }


    }
}
