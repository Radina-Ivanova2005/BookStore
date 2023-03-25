using bookRepository.Busines;
using bookRepository.Data.Models;
using bookRepository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            authorController.AddAuthor(author1);
            authorController.AddAuthor(author2);
            authorController.AddAuthor(author3);
            authorController.AddAuthor(author4);


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
        }

        private void AddSeries()
        {
            SerieController serieController = new SerieController(new Data.BookShopContext());
            Serie serie1 = new Serie("Crescent City");
            Serie serie2 = new Serie("Vampire Academy");
            Serie serie3 = new Serie("Caraval");
            Serie serie4 = new Serie("Penryn and the End of Days");
            serieController.AddSerie(serie1);
            serieController.AddSerie(serie2);
            serieController.AddSerie(serie3);
            serieController.AddSerie(serie4);

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
            publisherController.AddPublisher(publisher1);
            publisherController.AddPublisher(publisher2);
            publisherController.AddPublisher(publisher3);
            publisherController.AddPublisher(publisher4);
        }

        private void AddBooks()
        {
            BookController bookController = new BookController(new Data.BookShopContext());
            Book book1 = new Book("Angellfall", 3, 3, 4, 10, 2, "English", 290, 14.90M, 5, 3);
            Book book2 = new Book("World After", 3, 3, 4, 10, 2, "English", 321, 15.90M, 5, 5);
            Book book3 = new Book("End of Days", 3, 3, 4, 10, 2, "English", 345, 15.90M, 5, 2);
            Book book4 = new Book("Vampire Academy", 4, 2, 1, 2, 2, "English", 352, 14.90M, 5, 5);
            Book book5 = new Book("Frostbite", 4, 2, 1, 2, 2, "English", 352, 14.90M, 5, 6);
            Book book6 = new Book("Shadow Kiss", 4, 2, 1, 2, 2, "English", 448, 15.90M, 5, 6);
            Book book7 = new Book("Blood Promise", 4, 2, 1, 2, 2, "English", 528, 16.90M, 4, 9);
            Book book8 = new Book("Spirit Bound", 4, 2, 1, 2, 2, "English", 512, 15.90M, 5, 7);
            Book book9 = new Book("Last Sacrafice", 4, 2, 1, 2, 2, "English", 608, 17.00M, 5, 2);
            Book book10 = new Book("House of Earth and Blood", 1, 1, 3, 3, 2, "English", 816, 40.00M, 5, 3);
            Book book11 = new Book("House of Sky and Breath", 1, 1, 3, 3, 2, "English", 768, 40.00M, 5, 5);
            Book book12 = new Book("Catwoman Soulstealer", 1, 3, 5, 2, "English", 400, 20.00M, 5, 10);
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

        }
    }
}
