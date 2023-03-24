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
        //Added new genre to the database
        public void AddGenre(Genre genre)
        {
            this.context.Genres.Add(genre);
            this.context.SaveChanges();
        }
        //Fetch list of all genre in the database
        public List<Genre> GetAllGenres()
        {
            return context.Genres.ToList();
        }
        //Fetch certain genre from the database by ID
        public Genre GetGenreById(int id)
        {
            var genre = this.context.Genres.FirstOrDefault(x => x.Id == id );
            return genre;
        }
        //Fetch certain genre from the database by name of the genre
        public Genre GetGenreByName(string name)
        {
            var genre = this.context.Genres.FirstOrDefault(x => x.Name == name);
            return genre;
        }
        //Updated certain genre from the database with new genre characteristics
        public void UpdateGenre(Genre genre)
        {
            var genreItem = this.GetGenreById(genre.Id);
            this.context.Entry(genreItem).CurrentValues.SetValues(genre);
            this.context.SaveChanges();
        }
        //Deleted certain genre by ID
        public void DeleteGenre(int id)
        {
            var genreItem = this.GetGenreById(id);
            this.context.Genres.Remove(genreItem);
            this.context.SaveChanges();

        }




    }
}
