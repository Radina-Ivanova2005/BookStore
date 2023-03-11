using bookRepository.Busines;
using bookRepository.Models;
using System.Threading.Channels;

public class StartUp
{
    private static void Main(string[] args)
    {
       
      BookController controller = new BookController();
        controller.SaleBook(5);


        //GenreController g = new GenreController();
        //Genre g1 = new Genre();
        //Genre g2 = new Genre();
        //g1.Name = "fantasy";
        //g2.Name = "romance";
        //g.AddGenre(g1);
        //g.AddGenre(g2);

        ////var a = g.GetGenreById(1);

        ////    Console.WriteLine(a.Name);



        //AuthorController autor = new AuthorController();
        //////Author a = new Author();

        //////a.Name = "Sarah";
        //////a.IsDeleted = false;


        //Author a1 = new Author();
        //a1.IsDeleted = false;
        //a1.Name = "Stephanie";
        //autor.AddAuthor(a1);
        //autor.AddAuthor(a);

        //////var a = autor.GetAuthorById(1);

        //////    Console.WriteLine(a.Name);


        ////PublisherController publisher = new PublisherController();
        ////Publisher p = new Publisher();
        ////p.Name = "a";
        ////publisher.AddPublisher(p);
        ////Publisher p1 = new Publisher();
        ////p1.Name = "b";
        ////publisher.AddPublisher(p1);
        //////var a=publisher.GetAllPublisherss();
        //////foreach (var item in a)
        //////{
        //////    Console.WriteLine(item.Name);
        //////}


        //SerieController serieController = new SerieController();
        //Serie s = new Serie();
        //s.Title = "acotar";
        //serieController.AddSerie(s);
        //////Serie s1 = new Serie();
        //////s1.Title = "Caraval";
        //////serieController.AddSerie(s1);
        //////var a=serieController.GetAllSeries();
        //////foreach (var item in a)
        //////{
        //////    Console.WriteLine(item.Title);
        //////}

        //BookController bookController = new BookController();
        //Book b = new Book();
        //b.Title = "acotar";
        //b.AuthorId = 7;
        //b.SerieId = 2;
        //b.PublisherId = 1;
        //b.Pages = 555;
        //b.Price = 12.20M;
        //b.Rating = 5;
        //b.Count = 2;
        //b.Language = "en";
        //b.IsDeleted = false;
        //Book b1 = new Book();
        //b1.Title = "caraval";
        //b1.AuthorId = 7;
        //b1.SerieId = 2;
        //b1.PublisherId = 2;
        //b1.Pages = 525;
        //b1.Price = 22.20M;
        //b1.Rating = 5;
        //b1.Count = 1;
        //b1.Language = "bg";
        //b1.IsDeleted = false;
        //bookController.AddBook(b);
        //bookController.AddBook(b1);

        //BookGenreController bookGenreController = new BookGenreController();
        //BookGenre bg = new BookGenre();
        //bg.GenreId = 1;
        //bg.BookId = 1;
        //BookGenre bg1 = new BookGenre();
        //bg1.GenreId = 2;
        //bg1.BookId = 2;
        //bookGenreController.AddBookGenre(bg);
        //bookGenreController.AddBookGenre(bg1);








    }
}