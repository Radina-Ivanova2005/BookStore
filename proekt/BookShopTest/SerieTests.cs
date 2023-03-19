using bookRepository.Busines;
using bookRepository.Data;
using bookRepository.Models;
using Microsoft.EntityFrameworkCore;
using Moq;
using NUnit.Framework;

namespace BookShop.Tests
{
    public class SerieTests
    {
        [TestCase]
        public void CreateSerie_Saves_A_Serie_Via_Context()
        {
            var mockSet = new Mock<DbSet<Serie>>();

            var mockContext = new Mock<BookShopContext>();
            mockContext.Setup(m => m.Series).Returns(mockSet.Object);

            var controller = new SerieController(mockContext.Object);
            controller.AddSerie(new Serie("TestSerie"));

            mockSet.Verify(m => m.Add(It.IsAny<Serie>()), Times.Once());
            mockContext.Verify(m => m.SaveChanges(), Times.Once());
        }

        [TestCase]
        public void AddSerie_In_Database_Successfully()
        {

            var data = new List<Serie>
            {
                new Serie ("TestSerie1"){ Id = 1},
                new Serie ("TestSerie2"){ Id = 2},
                new Serie ("TestSerie3"){ Id = 3}
            }.AsQueryable();

            var mockSet = new Mock<DbSet<Serie>>();
            mockSet.As<IQueryable<Serie>>().Setup(m => m.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<Serie>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<Serie>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<Serie>>().Setup(m => m.GetEnumerator()).Returns(() => data.GetEnumerator());

            var mockContext = new Mock<BookShopContext>();
            mockContext.Setup(c => c.Series).Returns(mockSet.Object);

            var controller = new SerieController(mockContext.Object);
            data.ToList().ForEach(x => controller.AddSerie(x));

            var serie = controller.GetSerieById(1);
            Assert.AreEqual(1, serie.Id);

        }

        [TestCase]
        public void GetSerieById_Should_Return_First_Serie_In_Database()
        {
            var data = new List<Serie>
            {
                new Serie ("TestSerie1"){ Id = 1},
                new Serie ("TestSerie2"){ Id = 2},
                new Serie ("TestSerie3"){ Id = 3}
            }.AsQueryable();

            var mockSet = new Mock<DbSet<Serie>>();
            mockSet.As<IQueryable<Serie>>().Setup(m => m.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<Serie>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<Serie>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<Serie>>().Setup(m => m.GetEnumerator()).Returns(() => data.GetEnumerator());

            var mockContext = new Mock<BookShopContext>();
            mockContext.Setup(c => c.Series).Returns(mockSet.Object);

            var controller = new SerieController(mockContext.Object);
            data.ToList().ForEach(x => controller.AddSerie(x));
            var result = controller.GetSerieById(1);
            Assert.AreEqual("TestSerie1", result.Title);

        }

        [TestCase]
        public void GetAllSeries_Should_Return_All_Series_In_Database()
        {
            var data = new List<Serie>
            {
                new Serie ("TestSerie1"){ Id = 1},
                new Serie ("TestSerie2"){ Id = 2},
                new Serie ("TestSerie3"){ Id = 3}
            }.AsQueryable();

            var mockSet = new Mock<DbSet<Serie>>();
            mockSet.As<IQueryable<Serie>>().Setup(m => m.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<Serie>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<Serie>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<Serie>>().Setup(m => m.GetEnumerator()).Returns(() => data.GetEnumerator());

            var mockContext = new Mock<BookShopContext>();
            mockContext.Setup(c => c.Series).Returns(mockSet.Object);

            var controller = new SerieController(mockContext.Object);
            data.ToList().ForEach(x => controller.AddSerie(x));

            var expectedCount = 3;
            var result = controller.GetAllSeries();
            var actualCount = result.Count;
            Assert.AreEqual(expectedCount, actualCount);
            Assert.AreEqual("TestSerie1", result[0].Title);

        }

        [TestCase]
        public void GetSerieByTitle_Should_Return_Correct_Serie_In_Database()
        {
            var data = new List<Serie>
            {
                new Serie ("TestSerie1"){ Id = 1},
                new Serie ("TestSerie2"){ Id = 2},
                new Serie ("TestSerie3"){ Id = 3}
            }.AsQueryable();

            var mockSet = new Mock<DbSet<Serie>>();
            mockSet.As<IQueryable<Serie>>().Setup(m => m.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<Serie>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<Serie>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<Serie>>().Setup(m => m.GetEnumerator()).Returns(() => data.GetEnumerator());

            var mockContext = new Mock<BookShopContext>();
            mockContext.Setup(c => c.Series).Returns(mockSet.Object);

            var controller = new SerieController(mockContext.Object);
            data.ToList().ForEach(x => controller.AddSerie(x));
            var result = controller.GetSerieByTitle("TestSerie3");
            Assert.AreEqual(3, result.Id);
        }
    }
}
