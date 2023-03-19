using bookRepository.Busines;
using bookRepository.Data;
using Microsoft.EntityFrameworkCore;
using Moq;
using NUnit.Framework;
using bookRepository.Models;

namespace BookShopTest
{
    public class AuthorTest
    {
        [TestCase]
        public void CreateAuthor_Add_An_Author_Via_Context()
        {
            var mockSet = new Mock<DbSet<Author>>();

            var mockContext = new Mock<BookShopContext>();
            mockContext.Setup(m => m.Authors).Returns(mockSet.Object);

            var controller = new AuthorController(mockContext.Object);
            controller.AddAuthor(new Author("TestAuthor"));

            mockSet.Verify(m => m.Add(It.IsAny<Author>()), Times.Once());
            mockContext.Verify(m => m.SaveChanges(), Times.Once());
        }


        [TestCase]
        public void AddAuthor_In_Database()
        {
            var data = new List<Author>
            {
                new Author ("TestAuthor1"){ Id = 1},
                new Author ("TestAuthor2"){ Id = 2},
                new Author ("TestAuthor3"){ Id = 3}
            }.AsQueryable();

            var mockSet = new Mock<DbSet<Author>>();
            mockSet.As<IQueryable<Author>>().Setup(m => m.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<Author>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<Author>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<Author>>().Setup(m => m.GetEnumerator()).Returns(() => data.GetEnumerator());

            var mockContext = new Mock<BookShopContext>();
            mockContext.Setup(c => c.Authors).Returns(mockSet.Object);

            var controller = new AuthorController(mockContext.Object);
            data.ToList().ForEach(x => controller.AddAuthor(x));

            Assert.AreEqual(3, controller.GetAllAuthors().Count);
        }

        [TestCase]
        public void GetAuthorById_Should_Return_First_Author_InDatabase()
        {
            var data = new List<Author>
            {
                new Author  ("TestAuthor1"){ Id = 1},
                new Author ("TestAuthor2"){ Id = 2},
                new Author ("TestAuthor3"){ Id = 3}
            }.AsQueryable();

            var mockSet = new Mock<DbSet<Author>>();
            mockSet.As<IQueryable<Author>>().Setup(m => m.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<Author>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<Author>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<Author>>().Setup(m => m.GetEnumerator()).Returns(() => data.GetEnumerator());

            var mockContext = new Mock<BookShopContext>();
            mockContext.Setup(c => c.Authors).Returns(mockSet.Object);

            var controller = new AuthorController(mockContext.Object);
            data.ToList().ForEach(x => controller.AddAuthor(x));
            var result = controller.GetAuthorById(1);
            Assert.AreEqual("TestAuthor1", result.Name);

        }

        [TestCase]
        public void GetAllAuthors_Should_Return_All_Authors_InDatabase()
        {
            var data = new List<Author>
            {
                new Author ("TestAuthor1"){ Id = 1},
                new Author ("TestAuthor2"){ Id = 2},
                new Author ("TestAuthor3"){ Id = 3}
            }.AsQueryable();

            var mockSet = new Mock<DbSet<Author>>();
            mockSet.As<IQueryable<Author>>().Setup(m => m.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<Author>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<Author>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<Author>>().Setup(m => m.GetEnumerator()).Returns(() => data.GetEnumerator());

            var mockContext = new Mock<BookShopContext>();
            mockContext.Setup(c => c.Authors).Returns(mockSet.Object);

            var controller = new AuthorController(mockContext.Object);
            data.ToList().ForEach(x => controller.AddAuthor(x));

            var expectedCount = 3;
            var result = controller.GetAllAuthors();
            var actualCount = result.Count;
            Assert.AreEqual(expectedCount, actualCount);
            Assert.AreEqual("TestAuthor1", result[0].Name);
            Assert.AreEqual("TestAuthor2", result[1].Name);
            Assert.AreEqual("TestAuthor3", result[2].Name);
        }

        [TestCase]
        public void GetAuthorByName_Should_Return_Correct_Author_InDatabase()
        {
            var data = new List<Author>
            {
                new Author ("TestAuthor1"){ Id = 1},
                new Author ("TestAuthor2"){ Id = 2},
                new Author ("TestAuthor3"){ Id = 3}
            }.AsQueryable();

            var mockSet = new Mock<DbSet<Author>>();
            mockSet.As<IQueryable<Author>>().Setup(m => m.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<Author>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<Author>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<Author>>().Setup(m => m.GetEnumerator()).Returns(() => data.GetEnumerator());

            var mockContext = new Mock<BookShopContext>();
            mockContext.Setup(c => c.Authors).Returns(mockSet.Object);

            var controller = new AuthorController(mockContext.Object);
            data.ToList().ForEach(x => controller.AddAuthor(x));
            var result = controller.GetAuthorByName("TestAuthor3");
            Assert.AreEqual(3, result.Id);
        }
    }
}
