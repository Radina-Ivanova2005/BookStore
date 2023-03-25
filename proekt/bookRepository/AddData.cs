using bookRepository.Busines;
using bookRepository.Data.Models;
using bookRepository.Models;


namespace bookRepository
{
    public class AddData
    {
        public AddData()
        {
            Data();
        }

        private void Data()
        {
            AddAuthors();
            AddCategories();
            AddGenres();
            AddSeries();
            AddPublisher();
            AddBooks();
        }

        private void AddAuthors()
        {
            AuthorController authorController = new AuthorController(new Data.BookShopContext());
            Author author1 = new Author("Sarah J. Maas");
            Author author2 = new Author("Stephanie Garber");
            Author author3 = new Author("Susan Ee");
            Author author4 = new Author("Richelle Mead");
            Author author5 = new Author("Cassandra Clare");
            Author author6 = new Author("Sing Shong");
            Author author7 = new Author("Pierre Pevel");
            Author author8 = new Author("Sidney Sheldon");
            authorController.AddAuthor(author1);
            authorController.AddAuthor(author2);
            authorController.AddAuthor(author3);
            authorController.AddAuthor(author4);
            authorController.AddAuthor(author5);
            authorController.AddAuthor(author6);
            authorController.AddAuthor(author7);
            authorController.AddAuthor(author8);

        }

        private void AddGenres()
        {
            GenreController genreController = new GenreController(new Data.BookShopContext());
            Genre genre1 = new Genre("Horror");
            Genre genre2 = new Genre("Romance");
            Genre genre3 = new Genre("Fantasy");
            Genre genre4 = new Genre("Drama");
            Genre genre5 = new Genre("Science Fiction");
            Genre genre6 = new Genre("Comedy");
            Genre genre7 = new Genre("Biography");
            Genre genre8 = new Genre("Thriller");
            Genre genre9 = new Genre("Mystery");
            Genre genre10 = new Genre("Antiutopia");
            Genre genre11 = new Genre("Adventure");
            Genre genre12 = new Genre("Historical");
            Genre genre13 = new Genre("Tragedy");
            genreController.AddGenre(genre1);
            genreController.AddGenre(genre2);
            genreController.AddGenre(genre3);
            genreController.AddGenre(genre4);
            genreController.AddGenre(genre5);
            genreController.AddGenre(genre6);
            genreController.AddGenre(genre7);
            genreController.AddGenre(genre8);
            genreController.AddGenre(genre9);
            genreController.AddGenre(genre10);
            genreController.AddGenre(genre11);
            genreController.AddGenre(genre12);
            genreController.AddGenre(genre13);
        }

        private void AddSeries()
        {
            SerieController serieController = new SerieController(new Data.BookShopContext());
            Serie serie1 = new Serie("Crescent City");
            Serie serie2 = new Serie("Vampire Academy");
            Serie serie3 = new Serie("Caraval");
            Serie serie4 = new Serie("Penryn and the End of Days");
            Serie serie5 = new Serie("Omnicient Reader's Viewpoint");
            serieController.AddSerie(serie1);
            serieController.AddSerie(serie2);
            serieController.AddSerie(serie3);
            serieController.AddSerie(serie4);
            serieController.AddSerie(serie5);
        }

        private void AddCategories()
        {
            CategoryController categoryController = new CategoryController(new Data.BookShopContext());
            Category category1 = new Category("Comic");
            Category category2 = new Category("Novel");
            Category category3 = new Category("Novelette");
            Category category4 = new Category("Poem");
            categoryController.AddCategory(category1);
            categoryController.AddCategory(category2);
            categoryController.AddCategory(category3);
            categoryController.AddCategory(category4);
        }

        private void AddPublisher()
        {
            PublisherController publisherController = new PublisherController(new Data.BookShopContext());
            Publisher publisher1 = new Publisher("Penguin");
            Publisher publisher2 = new Publisher("Poradnia");
            Publisher publisher3 = new Publisher("Bloomsbury");
            Publisher publisher4 = new Publisher("Hodder & Stoughton");
            Publisher publisher5 = new Publisher("Chosun Ilbo");
            Publisher publisher6 = new Publisher("Simon & Schuster");
            Publisher publisher7 = new Publisher("Orin");
            Publisher publisher8 = new Publisher("Grand Central Publishing");
            publisherController.AddPublisher(publisher1);
            publisherController.AddPublisher(publisher2);
            publisherController.AddPublisher(publisher3);
            publisherController.AddPublisher(publisher4);
            publisherController.AddPublisher(publisher5);
            publisherController.AddPublisher(publisher6);
            publisherController.AddPublisher(publisher7);
            publisherController.AddPublisher(publisher8);
        }

        private void AddBooks()
        {
            BookController bookController = new BookController(new Data.BookShopContext());
            Book book1 = new Book("Angellfall", 3, 3, 4, 10, 2, "English", 290, 14.90M, 5, 3);
            Book book2 = new Book("World After", 3, 3, 4, 10, 2, "English", 321, 15.90M, 5, 5);
            Book book3 = new Book("End of Days", 3, 3, 4, 10, 2, "English", 345, 15.90M, 5, 2);
            Book book4 = new Book("Vampire Academy", 4, 2, 1, 3, 2, "English", 352, 14.90M, 5, 5);
            Book book5 = new Book("Frostbite", 4, 2, 1, 3, 2, "English", 352, 14.90M, 5, 6);
            Book book6 = new Book("Shadow Kiss", 4, 2, 1, 3, 2, "English", 448, 15.90M, 5, 6);
            Book book7 = new Book("Blood Promise", 4, 2, 1, 3, 2, "English", 528, 16.90M, 4, 9);
            Book book8 = new Book("Spirit Bound", 4, 2, 1, 3, 2, "English", 512, 15.90M, 5, 7);
            Book book9 = new Book("Last Sacrafice", 4, 2, 1, 3, 2, "English", 608, 17.00M, 5, 2);
            Book book10 = new Book("House of Earth and Blood", 1, 1, 3, 3, 2, "English", 816, 40.00M, 5, 3);
            Book book11 = new Book("House of Sky and Breath", 1, 1, 3, 3, 2, "English", 768, 40.00M, 5, 5);
            Book book12 = new Book("Catwoman Soulstealer", 1, 3, 3, 2, "English", 400, 20.00M, 5, 10);
            Book book13 = new Book("The Bane's Chronicles", 5, 6, 6, 3, "Bulgarian", 441, 19.00M, 5, 7);
            Book book14 = new Book("The Red Scrolls of Magic", 5, 6, 3, 2, "Bulgarian", 368, 30.00M, 4, 5);
            Book book15 = new Book("The Lost Book of The White", 5, 6, 11, 2, "English", 400, 30.00M, 4, 8);
            Book book16 = new Book("Omnicient Reader's Viewpoint Volume 1", 6, 5, 5, 13, 1, "English", 2079, 99.99M, 5, 4);
            Book book17 = new Book("Omnicient Reader's Viewpoint Volume 2", 6, 5, 5, 13, 1, "English", 903, 54.00M, 5, 6);
            Book book18 = new Book("Omnicient Reader's Viewpoint Volume 3", 6, 5, 5, 13, 1, "English", 903, 54.00M, 5, 10);
            Book book19 = new Book("Omnicient Reader's Viewpoint Volume 4", 6, 5, 5, 13, 1, "English", 1429, 79.00M, 5, 9);
            Book book20 = new Book("Omnicient Reader's Viewpoint Volume 5", 6, 5, 5, 13, 1, "English", 384, 31.00M, 5, 3);
            Book book21 = new Book("Omnicient Reader's Viewpoint Epilogue", 6, 5, 5, 13, 1, "English", 453, 44.00M, 5, 1);
            Book book22 = new Book("The Cardinal's Blades", 7, 7, 12, 2, "French", 316, 17.00M, 3, 8);
            Book book23 = new Book("The Alchemist in The Shadows", 7, 7, 12, 2, "French", 421, 26.30M, 4, 7);
            Book book24 = new Book("The Dragon Arcana", 7, 7, 12, 2, "French", 378, 22.90M, 3, 9);
            Book book25 = new Book("Rage of Angels", 8, 8, 8, 2, "English", 431, 31.00M, 5, 4);
            Book book26 = new Book("If Tomorrow Comes", 8, 8, 4, 2, "English", 396, 27.00M, 3, 7);
            Book book27 = new Book("Bloodline", 8, 8, 2, 2, "English", 440, 37.00M, 5, 6);
            bookController.AddBook(book1);
            bookController.AddBook(book2);
            bookController.AddBook(book3);
            bookController.AddBook(book4);
            bookController.AddBook(book5);
            bookController.AddBook(book6);
            bookController.AddBook(book7);
            bookController.AddBook(book8);
            bookController.AddBook(book9);
            bookController.AddBook(book10);
            bookController.AddBook(book11);
            bookController.AddBook(book12);
            bookController.AddBook(book13);
            bookController.AddBook(book14);
            bookController.AddBook(book15);
            bookController.AddBook(book16);
            bookController.AddBook(book17);
            bookController.AddBook(book18);
            bookController.AddBook(book19);
            bookController.AddBook(book20);
            bookController.AddBook(book21);
            bookController.AddBook(book22);
            bookController.AddBook(book23);
            bookController.AddBook(book24);
            bookController.AddBook(book25);
            bookController.AddBook(book26);
            bookController.AddBook(book27);
        }
    }
}
