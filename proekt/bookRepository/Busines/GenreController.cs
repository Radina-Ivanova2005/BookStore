using bookRepository.Data;
using bookRepository.Models;

namespace bookRepository.Busines
{
    public class GenreController
    {

        private BookShopContext context;
        public GenreController(BookShopContext context)
        {
            this.context = context;
        }

        public void AddGenre(Genre genre)
        {
            this.context.Genres.Add(genre);
            this.context.SaveChanges();
        }

        public List<Genre> GetAllGenres()
        {
            return context.Genres.OrderBy(g=>g.Name).ToList();
        }

        public Genre GetGenreById(int id)
        {
            var genre = this.context.Genres.FirstOrDefault(x => x.Id == id );
            return genre;
        }

        public Genre GetGenreByName(string name)
        {
            var genre = this.context.Genres.FirstOrDefault(x => x.Name == name);
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
            this.context.Genres.Remove(genreItem);
            this.context.SaveChanges();

        }




    }
}
