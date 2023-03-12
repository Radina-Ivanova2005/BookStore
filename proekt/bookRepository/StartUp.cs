using bookRepository.Busines;
using bookRepository.Data.Models;
using bookRepository.Models;
using System.Threading.Channels;

public class StartUp
{
    private static void Main(string[] args)
    {




        //CategoryController c = new CategoryController();
        //Category c1 = new Category();
        //Category c2 = new Category();
        //c1.Name = "fantasy";
        //c2.Name = "romance";
        //c.AddCategory(c1);
        //c.AddCategory(c2);

        //GenreController g = new GenreController();
        //Genre g1 = new Genre();
        //Genre g2 = new Genre();
        //g1.Name = "fantasy";
        //g2.Name = "romance";
        //g.AddGenre(g1);
        //g.AddGenre(g2);

        //AuthorController autor = new AuthorController();
        //Author a = new Author();
        //a.Name = "Sarah";
        //autor.AddAuthor(a);
        //Author a1 = new Author();
        //a1.Name = "Stephanie";
        //autor.AddAuthor(a1);

        //PublisherController publisher = new PublisherController();
        //Publisher p = new Publisher();
        //p.Name = "a";
        //publisher.AddPublisher(p);
        //Publisher p1 = new Publisher();
        //p1.Name = "b";
        //publisher.AddPublisher(p1);

        //SerieController serieController = new SerieController();
        //Serie s = new Serie();
        //s.Title = "acotar";
        //serieController.AddSerie(s);
        //Serie s1 = new Serie();
        //s1.Title = "Caraval";
        //serieController.AddSerie(s1);

        BookController bookController = new BookController();
        Book b = new Book();
        b.Title = "acotar";
        b.AuthorId = 2;
        b.SerieId = 2;
        b.PublisherId = 2;
        b.Pages = 555;
        b.Price = 12.20M;
        b.Rating = 5;
        b.Count = 2;
        b.Language = "en";
        b.CategoryId = 2;
        b.GenreId = 1;
        Book b1 = new Book();
        b1.Title = "caraval";
        b1.AuthorId = 2;
        b1.SerieId = 2;
        b1.PublisherId = 2;
        b1.Pages = 525;
        b1.Price = 22.20M;
        b1.Rating = 5;
        b1.Count = 1;
        b1.Language = "bg";
        b1.CategoryId = 2;
        b1.GenreId = 1;
        bookController.AddBook(b);
        bookController.AddBook(b1);









    }
}