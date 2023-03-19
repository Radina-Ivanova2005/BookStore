using bookRepository.Busines;
using bookRepository.Data;
using bookRepository.Models;
using Microsoft.EntityFrameworkCore;
using Moq;
using NUnit.Framework;


namespace BookShopTest
{
    public class GenreTest
    {
        [TestCase]
        public void CreateGenre_Add_A_Genre_Via_Context()
        {
            var mockSet = new Mock<DbSet<Genre>>();

            var mockContext = new Mock<BookShopContext>();
            mockContext.Setup(m => m.Genres).Returns(mockSet.Object);

            var controller = new GenreController(mockContext.Object);
            controller.AddGenre(new Genre("TestGenre"));

            mockSet.Verify(m => m.Add(It.IsAny<Genre>()), Times.Once());
            mockContext.Verify(m => m.SaveChanges(), Times.Once());
        }


        [TestCase]
        public void AddGenre_In_Database()
        {
            var data = new List<Genre>
            {
                new Genre ("TestGenre1"){ Id = 1},
                new Genre ("TestGenre2"){ Id = 2},
                new Genre ("TestGenre3"){ Id = 3}
            }.AsQueryable();

            var mockSet = new Mock<DbSet<Genre>>();
            mockSet.As<IQueryable<Genre>>().Setup(m => m.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<Genre>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<Genre>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<Genre>>().Setup(m => m.GetEnumerator()).Returns(() => data.GetEnumerator());

            var mockContext = new Mock<BookShopContext>();
            mockContext.Setup(c => c.Genres).Returns(mockSet.Object);

            var controller = new GenreController(mockContext.Object);
            data.ToList().ForEach(x => controller.AddGenre(x));

            Assert.AreEqual(3, controller.GetAllGenres().Count);
        }

        [TestCase]
        public void GetGenreById_Should_Return_First_Genre_InDatabase()
        {
            var data = new List<Genre>
            {
                new Genre  ("TestGenre1"){ Id = 1},
                new Genre ("TestGenre2"){ Id = 2},
                new Genre ("TestGenre3"){ Id = 3}
            }.AsQueryable();

            var mockSet = new Mock<DbSet<Genre>>();
            mockSet.As<IQueryable<Genre>>().Setup(m => m.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<Genre>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<Genre>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<Genre>>().Setup(m => m.GetEnumerator()).Returns(() => data.GetEnumerator());

            var mockContext = new Mock<BookShopContext>();
            mockContext.Setup(c => c.Genres).Returns(mockSet.Object);

            var controller = new GenreController(mockContext.Object);
            data.ToList().ForEach(x => controller.AddGenre(x));
            var result = controller.GetGenreById(1);
            Assert.AreEqual("TestGenre1", result.Name);

        }

        [TestCase]
        public void GetAllGenres_Should_Return_All_Genres_InDatabase()
        {
            var data = new List<Genre>
            {
                new Genre ("TestGenre1"){ Id = 1},
                new Genre ("TestGenre2"){ Id = 2},
                new Genre ("TestGenre3"){ Id = 3}
            }.AsQueryable();

            var mockSet = new Mock<DbSet<Genre>>();
            mockSet.As<IQueryable<Genre>>().Setup(m => m.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<Genre>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<Genre>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<Genre>>().Setup(m => m.GetEnumerator()).Returns(() => data.GetEnumerator());

            var mockContext = new Mock<BookShopContext>();
            mockContext.Setup(c => c.Genres).Returns(mockSet.Object);

            var controller = new GenreController(mockContext.Object);
            data.ToList().ForEach(x => controller.AddGenre(x));

            var expectedCount = 3;
            var result = controller.GetAllGenres();
            var actualCount = result.Count;
            Assert.AreEqual(expectedCount, actualCount);
            Assert.AreEqual("TestGenre1", result[0].Name);
            Assert.AreEqual("TestGenre2", result[1].Name);
            Assert.AreEqual("TestGenre3", result[2].Name);
        }

        [TestCase]
        public void GetGenreByName_Should_Return_Correct_Genre_InDatabase()
        {
            var data = new List<Genre>
            {
                new Genre ("TestGenre1"){ Id = 1},
                new Genre ("TestGenre2"){ Id = 2},
                new Genre ("TestGenre3"){ Id = 3}
            }.AsQueryable();

            var mockSet = new Mock<DbSet<Genre>>();
            mockSet.As<IQueryable<Genre>>().Setup(m => m.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<Genre>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<Genre>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<Genre>>().Setup(m => m.GetEnumerator()).Returns(() => data.GetEnumerator());

            var mockContext = new Mock<BookShopContext>();
            mockContext.Setup(c => c.Genres).Returns(mockSet.Object);

            var controller = new GenreController(mockContext.Object);
            data.ToList().ForEach(x => controller.AddGenre(x));
            var result = controller.GetGenreByName("TestGenre3");
            Assert.AreEqual(3, result.Id);
        }
    }
}
