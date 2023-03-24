using bookRepository.Busines;
using bookRepository.Data;
using Microsoft.EntityFrameworkCore;
using Moq;
using bookRepository.Models;
using NUnit.Framework;

namespace BookShop.Tests
{
    public class PublisherTests
    {
        [TestCase]
        public void CreatePublisher_Saves_A_Publisher_Via_Context()
        {
            var mockSet = new Mock<DbSet<Publisher>>();

            var mockContext = new Mock<BookShopContext>();
            mockContext.Setup(m => m.Publishers).Returns(mockSet.Object);

            var controller = new PublisherController(mockContext.Object);
            controller.AddPublisher(new Publisher("TestPublisher"));

            mockSet.Verify(m => m.Add(It.IsAny<Publisher>()), Times.Once());
            mockContext.Verify(m => m.SaveChanges(), Times.Once());
        }

        [TestCase]
        public void AddPublisher_In_Database_Successfully()
        {

            var data = new List<Publisher>
            {
                new Publisher ("TestPublisher1"){ Id = 1},
                new Publisher ("TestPublisher2"){ Id = 2},
                new Publisher ("TestPublisher3"){ Id = 3}
            }.AsQueryable();

            var mockSet = new Mock<DbSet<Publisher>>();
            mockSet.As<IQueryable<Publisher>>().Setup(m => m.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<Publisher>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<Publisher>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<Publisher>>().Setup(m => m.GetEnumerator()).Returns(() => data.GetEnumerator());

            var mockContext = new Mock<BookShopContext>();
            mockContext.Setup(c => c.Publishers).Returns(mockSet.Object);

            var controller = new PublisherController(mockContext.Object);
            data.ToList().ForEach(x => controller.AddPublisher(x));

            var publisher = controller.GetPublisherById(1);
            Assert.AreEqual(1, publisher.Id);

        }


        [TestCase]
        public void GetPublisherById_Should_Return_First_Publisher_In_Database()
        {
            var data = new List<Publisher>
            {
                new Publisher ("TestPublisher1"){ Id = 1},
                new Publisher ("TestPublisher2"){ Id = 2},
                new Publisher ("TestPublisher3"){ Id = 3}
            }.AsQueryable();

            var mockSet = new Mock<DbSet<Publisher>>();
            mockSet.As<IQueryable<Publisher>>().Setup(m => m.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<Publisher>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<Publisher>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<Publisher>>().Setup(m => m.GetEnumerator()).Returns(() => data.GetEnumerator());

            var mockContext = new Mock<BookShopContext>();
            mockContext.Setup(c => c.Publishers).Returns(mockSet.Object);

            var controller = new PublisherController(mockContext.Object);
            data.ToList().ForEach(x => controller.AddPublisher(x));
            var result = controller.GetPublisherById(1);
            Assert.AreEqual("TestPublisher1", result.Name);

        }

        [TestCase]
        public void GetAllPublisher_Should_Return_All_Publishers_In_Database()
        {
            var data = new List<Publisher>
            {
                new Publisher ("TestPublisher1"){ Id = 1},
                new Publisher ("TestPublisher2"){ Id = 2},
                new Publisher ("TestPublisher3"){ Id = 3}
            }.AsQueryable();

            var mockSet = new Mock<DbSet<Publisher>>();
            mockSet.As<IQueryable<Publisher>>().Setup(m => m.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<Publisher>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<Publisher>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<Publisher>>().Setup(m => m.GetEnumerator()).Returns(() => data.GetEnumerator());

            var mockContext = new Mock<BookShopContext>();
            mockContext.Setup(c => c.Publishers).Returns(mockSet.Object);

            var controller = new PublisherController(mockContext.Object);
            data.ToList().ForEach(x => controller.AddPublisher(x));

            var expectedCount = 3;
            var result = controller.GetAllPublishers();
            var actualCount = result.Count;
            Assert.AreEqual(expectedCount, actualCount);
            Assert.AreEqual("TestPublisher1", result[0].Name);

        }

        [TestCase]
        public void GetPublisherByName_Should_Return_Correct_Publisher_In_Database()
        {
            var data = new List<Publisher>
            {
                new Publisher ("TestPublisher1"){ Id = 1},
                new Publisher ("TestPublisher2"){ Id = 2},
                new Publisher ("TestPublisher3"){ Id = 3}
            }.AsQueryable();

            var mockSet = new Mock<DbSet<Publisher>>();
            mockSet.As<IQueryable<Publisher>>().Setup(m => m.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<Publisher>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<Publisher>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<Publisher>>().Setup(m => m.GetEnumerator()).Returns(() => data.GetEnumerator());

            var mockContext = new Mock<BookShopContext>();
            mockContext.Setup(c => c.Publishers).Returns(mockSet.Object);

            var controller = new PublisherController(mockContext.Object);
            data.ToList().ForEach(x => controller.AddPublisher(x));
            var result = controller.GetPublisherByName("TestPublisher3");
            Assert.AreEqual(3, result.Id);
        }
    }
}
