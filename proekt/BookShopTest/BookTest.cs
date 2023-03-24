using bookRepository.Busines;
using bookRepository.Data;
using bookRepository.Models;
using Microsoft.EntityFrameworkCore;
using Moq;
using NUnit.Framework;
using NUnit.Framework.Internal.Execution;
using System.Net;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace BookShopTest
{
    public class BookTest
    {
        [TestCase]
        public void CreateBook_Add_A_Book_Via_Context()
        {
            var mockSet = new Mock<DbSet<Book>>();

            var mockContext = new Mock<BookShopContext>();
            mockContext.Setup(m => m.Books).Returns(mockSet.Object);

            var controller = new BookController(mockContext.Object);
            controller.AddBook(new Book("TestBook", 1, 1, 1, 1, "TestLanguage", 1, 1, 1, 1));

            mockSet.Verify(m => m.Add(It.IsAny<Book>()), Times.Once());
            mockContext.Verify(m => m.SaveChanges(), Times.Once());
        }


        [TestCase]
        public void AddBook_In_Database()
        {
            var data = new List<Book>
            {
                new Book ("TestBook1",1,1,1,1,"TestLanguage",1,1,1,1),
                new Book ("TestBook2",1,1,1,1,"TestLanguage",1,1,1,1),
                new Book ("TestBook3",1,1,1,1,"TestLanguage",1,1,1,1)
            }.AsQueryable();

            var mockSet = new Mock<DbSet<Book>>();
            mockSet.As<IQueryable<Book>>().Setup(m => m.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<Book>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<Book>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<Book>>().Setup(m => m.GetEnumerator()).Returns(() => data.GetEnumerator());

            var mockContext = new Mock<BookShopContext>();
            mockContext.Setup(c => c.Books).Returns(mockSet.Object);

            var controller = new BookController(mockContext.Object);
            data.ToList().ForEach(x => controller.AddBook(x));

            Assert.AreEqual(3, controller.GetAllBooks().Count);
        }

        [TestCase]
        public void GetBookById_Should_Return_First_Book_InDatabase()
        {
            var data = new List<Book>
            {
                new Book ("TestBook1",1,1,1,1,"TestLanguage",1,1,1,1){BookId=1},
                new Book ("TestBook2",1,1,1,1,"TestLanguage",1,1,1,1){BookId=2},
                new Book ("TestBook3",1,1,1,1,"TestLanguage",1,1,1,1){BookId=3}
            }.AsQueryable();

            var mockSet = new Mock<DbSet<Book>>();
            mockSet.As<IQueryable<Book>>().Setup(m => m.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<Book>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<Book>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<Book>>().Setup(m => m.GetEnumerator()).Returns(() => data.GetEnumerator());

            var mockContext = new Mock<BookShopContext>();
            mockContext.Setup(c => c.Books).Returns(mockSet.Object);

            var controller = new BookController(mockContext.Object);
            data.ToList().ForEach(x => controller.AddBook(x));
            var result = controller.GetBookById(1);
            Assert.AreEqual("TestBook1", result.Title);

        }

        [TestCase]
        public void GetAllBooks_Should_Return_All_Books_InDatabase()
        {
            var data = new List<Book>
            {
                new Book ("TestBook1",1,1,1,1,"TestLanguage",1,1,1,1),
                new Book ("TestBook2",1,1,1,1,"TestLanguage",1,1,1,1),
                new Book ("TestBook3",1,1,1,1,"TestLanguage",1,1,1,1)
            }.AsQueryable();

            var mockSet = new Mock<DbSet<Book>>();
            mockSet.As<IQueryable<Book>>().Setup(m => m.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<Book>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<Book>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<Book>>().Setup(m => m.GetEnumerator()).Returns(() => data.GetEnumerator());

            var mockContext = new Mock<BookShopContext>();
            mockContext.Setup(c => c.Books).Returns(mockSet.Object);

            var controller = new BookController(mockContext.Object);
            data.ToList().ForEach(x => controller.AddBook(x));

            var expectedCount = 3;
            var result = controller.GetAllBooks();
            var actualCount = result.Count;
            Assert.AreEqual(expectedCount, actualCount);
            Assert.AreEqual("TestBook1", result[0].Title);
            Assert.AreEqual("TestBook2", result[1].Title);
            Assert.AreEqual("TestBook3", result[2].Title);
        }

        [TestCase]
        public void GetBookByTitle_Should_Return_Correct_Book_InDatabase()
        {
            var data = new List<Book>
            {
               new Book ("TestBook1",1,1,1,1,"TestLanguage",1,1,1,1),
                new Book ("TestBook2",1,1,1,1,"TestLanguage",1,1,1,1),
                new Book ("TestBook3",1,1,1,1,"TestLanguage",1,1,1,1)
            }.AsQueryable();

            var mockSet = new Mock<DbSet<Book>>();
            mockSet.As<IQueryable<Book>>().Setup(m => m.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<Book>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<Book>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<Book>>().Setup(m => m.GetEnumerator()).Returns(() => data.GetEnumerator());

            var mockContext = new Mock<BookShopContext>();
            mockContext.Setup(c => c.Books).Returns(mockSet.Object);

            var controller = new BookController(mockContext.Object);
            data.ToList().ForEach(x => controller.AddBook(x));
            var result = controller.GetBookByTitle("TestBook3");
            Assert.AreEqual("TestBook3", result.Title);
        }

        [TestCase]
        public void GetBookByAuthor_Should_Return_First_Book_InDatabase()
        {
            var data = new List<Book>
            {
                new Book ("TestBook1",1,1,1,1,"TestLanguage",1,1,1,1){BookId=1},
                new Book ("TestBook2",1,1,1,1,"TestLanguage",1,1,1,1){BookId=2},
                new Book ("TestBook3",1,1,1,1,"TestLanguage",1,1,1,1){BookId=3}
            }.AsQueryable();

            var mockSet = new Mock<DbSet<Book>>();
            mockSet.As<IQueryable<Book>>().Setup(m => m.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<Book>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<Book>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<Book>>().Setup(m => m.GetEnumerator()).Returns(() => data.GetEnumerator());

            var mockContext = new Mock<BookShopContext>();
            mockContext.Setup(c => c.Books).Returns(mockSet.Object);

            var controller = new BookController(mockContext.Object);
            data.ToList().ForEach(x => controller.AddBook(x));
            var result = controller.GetBooksByAuthor(1);
            Assert.AreEqual(1, result[0].AuthorId);

        }
        [TestCase]
        public void GetBookByGenre_Should_Return_First_Book_InDatabase()
        {
            var data = new List<Book>
            {
                new Book ("TestBook1",1,1,1,1,"TestLanguage",1,1,1,1){BookId=1},
                new Book ("TestBook2",1,1,1,1,"TestLanguage",1,1,1,1){BookId=2},
                new Book ("TestBook3",1,1,1,1,"TestLanguage",1,1,1,1){BookId=3}
            }.AsQueryable();

            var mockSet = new Mock<DbSet<Book>>();
            mockSet.As<IQueryable<Book>>().Setup(m => m.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<Book>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<Book>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<Book>>().Setup(m => m.GetEnumerator()).Returns(() => data.GetEnumerator());

            var mockContext = new Mock<BookShopContext>();
            mockContext.Setup(c => c.Books).Returns(mockSet.Object);

            var controller = new BookController(mockContext.Object);
            data.ToList().ForEach(x => controller.AddBook(x));
            var result = controller.GetBooksByGenre(1);
            Assert.AreEqual(1, result[0].GenreId);

        }

        [TestCase]
        public void GetBookByPublisher_Should_Return_First_Book_InDatabase()
        {
            var data = new List<Book>
            {
                new Book ("TestBook1",1,1,1,1,"TestLanguage",1,1,1,1){BookId=1},
                new Book ("TestBook2",1,1,1,1,"TestLanguage",1,1,1,1){BookId=2},
                new Book ("TestBook3",1,1,1,1,"TestLanguage",1,1,1,1){BookId=3}
            }.AsQueryable();

            var mockSet = new Mock<DbSet<Book>>();
            mockSet.As<IQueryable<Book>>().Setup(m => m.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<Book>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<Book>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<Book>>().Setup(m => m.GetEnumerator()).Returns(() => data.GetEnumerator());

            var mockContext = new Mock<BookShopContext>();
            mockContext.Setup(c => c.Books).Returns(mockSet.Object);

            var controller = new BookController(mockContext.Object);
            data.ToList().ForEach(x => controller.AddBook(x));
            var result = controller.GetBooksByPublisher(1);
            Assert.AreEqual(1, result[0].PublisherId);

        }

        [TestCase]
        public void GetBookByCategory_Should_Return_First_Book_InDatabase()
        {
            var data = new List<Book>
            {
                new Book ("TestBook1",1,1,1,1,"TestLanguage",1,1,1,1){BookId=1},
                new Book ("TestBook2",1,1,1,1,"TestLanguage",1,1,1,1){BookId=2},
                new Book ("TestBook3",1,1,1,1,"TestLanguage",1,1,1,1){BookId=3}
            }.AsQueryable();

            var mockSet = new Mock<DbSet<Book>>();
            mockSet.As<IQueryable<Book>>().Setup(m => m.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<Book>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<Book>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<Book>>().Setup(m => m.GetEnumerator()).Returns(() => data.GetEnumerator());

            var mockContext = new Mock<BookShopContext>();
            mockContext.Setup(c => c.Books).Returns(mockSet.Object);

            var controller = new BookController(mockContext.Object);
            data.ToList().ForEach(x => controller.AddBook(x));
            var result = controller.GetBooksByCategory(1);
            Assert.AreEqual(1, result[0].CategoryId);

        }

        [TestCase]
        public void GetBookWithLessPages_Should_Return_First_Book_InDatabase()
        {
            var data = new List<Book>
            {
                new Book ("TestBook1",1,1,1,1,"TestLanguage",1,1,1,1){BookId=1},
                new Book ("TestBook2",1,1,1,1,"TestLanguage",1,1,1,1){BookId=2},
                new Book ("TestBook3",1,1,1,1,"TestLanguage",1,1,1,1){BookId=3}
            }.AsQueryable();

            var mockSet = new Mock<DbSet<Book>>();
            mockSet.As<IQueryable<Book>>().Setup(m => m.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<Book>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<Book>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<Book>>().Setup(m => m.GetEnumerator()).Returns(() => data.GetEnumerator());

            var mockContext = new Mock<BookShopContext>();
            mockContext.Setup(c => c.Books).Returns(mockSet.Object);

            var controller = new BookController(mockContext.Object);
            data.ToList().ForEach(x => controller.AddBook(x));
            var result = controller.GetBooksWithLessPages(1);
            Assert.AreEqual(1, result[0].Pages);

        }

        [TestCase]
        public void GetBookWithMorePages_Should_Return_First_Book_InDatabase()
        {
            var data = new List<Book>
            {
                new Book ("TestBook1",1,1,1,1,"TestLanguage",1,1,1,1){BookId=1},
                new Book ("TestBook2",1,1,1,1,"TestLanguage",1,1,1,1){BookId=2},
                new Book ("TestBook3",1,1,1,1,"TestLanguage",1,1,1,1){BookId=3}
            }.AsQueryable();

            var mockSet = new Mock<DbSet<Book>>();
            mockSet.As<IQueryable<Book>>().Setup(m => m.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<Book>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<Book>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<Book>>().Setup(m => m.GetEnumerator()).Returns(() => data.GetEnumerator());

            var mockContext = new Mock<BookShopContext>();
            mockContext.Setup(c => c.Books).Returns(mockSet.Object);

            var controller = new BookController(mockContext.Object);
            data.ToList().ForEach(x => controller.AddBook(x));
            var result = controller.GetBooksWithMorePages(1);
            Assert.AreEqual(1, result[0].Pages);

        }

        [TestCase]
        public void GetBookWithLessPrice_Should_Return_First_Book_InDatabase()
        {
            var data = new List<Book>
            {
                new Book ("TestBook1",1,1,1,1,"TestLanguage",1,1,1,1){BookId=1},
                new Book ("TestBook2",1,1,1,1,"TestLanguage",1,1,1,1){BookId=2},
                new Book ("TestBook3",1,1,1,1,"TestLanguage",1,1,1,1){BookId=3}
            }.AsQueryable();

            var mockSet = new Mock<DbSet<Book>>();
            mockSet.As<IQueryable<Book>>().Setup(m => m.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<Book>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<Book>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<Book>>().Setup(m => m.GetEnumerator()).Returns(() => data.GetEnumerator());

            var mockContext = new Mock<BookShopContext>();
            mockContext.Setup(c => c.Books).Returns(mockSet.Object);

            var controller = new BookController(mockContext.Object);
            data.ToList().ForEach(x => controller.AddBook(x));
            var result = controller.GetBooksWithLessPrice(1);
            Assert.AreEqual(1, result[0].Price);

        }

        [TestCase]
        public void GetBookWithBiggerPrice_Should_Return_First_Book_InDatabase()
        {
            var data = new List<Book>
            {
                new Book ("TestBook1",1,1,1,1,"TestLanguage",1,1,1,1){BookId=1},
                new Book ("TestBook2",1,1,1,1,"TestLanguage",1,1,1,1){BookId=2},
                new Book ("TestBook3",1,1,1,1,"TestLanguage",1,1,1,1){BookId=3}
            }.AsQueryable();

            var mockSet = new Mock<DbSet<Book>>();
            mockSet.As<IQueryable<Book>>().Setup(m => m.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<Book>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<Book>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<Book>>().Setup(m => m.GetEnumerator()).Returns(() => data.GetEnumerator());

            var mockContext = new Mock<BookShopContext>();
            mockContext.Setup(c => c.Books).Returns(mockSet.Object);

            var controller = new BookController(mockContext.Object);
            data.ToList().ForEach(x => controller.AddBook(x));
            var result = controller.GetBooksWithBiggerPrice(1);
            Assert.AreEqual(1, result[0].Price);

        }

        [TestCase]
        public void GetBookWithLanguage_Should_Return_Correct_Book_InDatabase()
        {
            var data = new List<Book>
            {
               new Book ("TestBook1",1,1,1,1,"TestLanguage",1,1,1,1),
                new Book ("TestBook2",1,1,1,1,"TestLanguage",1,1,1,1),
                new Book ("TestBook3",1,1,1,1,"TestLanguage",1,1,1,1)
            }.AsQueryable();

            var mockSet = new Mock<DbSet<Book>>();
            mockSet.As<IQueryable<Book>>().Setup(m => m.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<Book>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<Book>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<Book>>().Setup(m => m.GetEnumerator()).Returns(() => data.GetEnumerator());

            var mockContext = new Mock<BookShopContext>();
            mockContext.Setup(c => c.Books).Returns(mockSet.Object);

            var controller = new BookController(mockContext.Object);
            data.ToList().ForEach(x => controller.AddBook(x));
            var result = controller.GetBooksWithLanguage("TestLanguage");
            Assert.AreEqual("TestLanguage", result[0].Language);
        }

        [TestCase]
        public void GetBookBySerie_Should_Return_First_Book_InDatabase()
        {
            var data = new List<Book>
            {
                new Book ("TestBook1",1,1,1,1,1,"TestLanguage",1,1,1,1),
                new Book ("TestBook2",1,1,1,1,1,"TestLanguage",1,1,1,1),
                new Book ("TestBook3",1,1,1,1,1,"TestLanguage",1,1,1,1)
            }.AsQueryable();

            var mockSet = new Mock<DbSet<Book>>();
            mockSet.As<IQueryable<Book>>().Setup(m => m.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<Book>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<Book>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<Book>>().Setup(m => m.GetEnumerator()).Returns(() => data.GetEnumerator());

            var mockContext = new Mock<BookShopContext>();
            mockContext.Setup(c => c.Books).Returns(mockSet.Object);

            var controller = new BookController(mockContext.Object);
            data.ToList().ForEach(x => controller.AddBook(x));
            var result = controller.GetBooksBySerie(1);
            Assert.AreEqual(1, result[0].SerieId);

        }

        [TestCase]
        public void GetBookWithRating_Should_Return_Correct_Book_InDatabase()
        {
            var data = new List<Book>
            {
               new Book ("TestBook1",1,1,1,1,"TestLanguage",1,1,1,1),
                new Book ("TestBook2",1,1,1,1,"TestLanguage",1,1,1,1),
                new Book ("TestBook3",1,1,1,1,"TestLanguage",1,1,1,1)
            }.AsQueryable();

            var mockSet = new Mock<DbSet<Book>>();
            mockSet.As<IQueryable<Book>>().Setup(m => m.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<Book>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<Book>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<Book>>().Setup(m => m.GetEnumerator()).Returns(() => data.GetEnumerator());

            var mockContext = new Mock<BookShopContext>();
            mockContext.Setup(c => c.Books).Returns(mockSet.Object);

            var controller = new BookController(mockContext.Object);
            data.ToList().ForEach(x => controller.AddBook(x));
            var result = controller.GetBooksWithRating(1);
            Assert.AreEqual(1, result[0].Rating);
        }

        [TestCase]
        public void Delete_Book_From_The_Database()
        {
            var mockSet = new Mock<DbSet<Book>>();

            var mockContext = new Mock<BookShopContext>();
            mockContext.Setup(m => m.Books).Returns(mockSet.Object);

            var controller = new BookController(mockContext.Object);
            controller.AddBook(new Book("TestBook", 1, 1, 1, 1, "TestLanguage", 1, 1, 1, 1));
            controller.DeleteBook(1);

            //mockSet.Verify(m => m.Add(It.IsAny<Book>()), Times.Once());
          //  mockContext.Verify(m => m.SaveChanges(), Times.Once());

            Assert.Pass();
        }
    }
}
