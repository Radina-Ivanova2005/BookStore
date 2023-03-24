using bookRepository.Busines;
using bookRepository.Data;
using bookRepository.Data.Models;
using Microsoft.EntityFrameworkCore;
using Moq;
using NUnit.Framework;

namespace BookShop.Tests
{


    public class CategoryTests
    {
        [TestCase]
        public void CreateCategory_Add_A_Category_Via_Context()
        {
            var mockSet = new Mock<DbSet<Category>>();

            var mockContext = new Mock<BookShopContext>();
            mockContext.Setup(m => m.Categories).Returns(mockSet.Object);

            var controller = new CategoryController(mockContext.Object);
            controller.AddCategory(new Category("TestCategory"));

            mockSet.Verify(m => m.Add(It.IsAny<Category>()), Times.Once());
            mockContext.Verify(m => m.SaveChanges(), Times.Once());
        }

        [TestCase]
        public void AddCategory_In_Database()
        {
            var data = new List<Category>
            {
                new Category ("TestCategory1"){ Id = 1},
                new Category ("TestCategory2"){ Id = 2},
                new Category ("TestCategory3"){ Id = 3}
            }.AsQueryable();

            var mockSet = new Mock<DbSet<Category>>();
            mockSet.As<IQueryable<Category>>().Setup(m => m.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<Category>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<Category>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<Category>>().Setup(m => m.GetEnumerator()).Returns(() => data.GetEnumerator());

            var mockContext = new Mock<BookShopContext>();
            mockContext.Setup(c => c.Categories).Returns(mockSet.Object);

            var controller = new CategoryController(mockContext.Object);
            data.ToList().ForEach(x => controller.AddCategory(x));

            Assert.AreEqual(3, controller.GetAllCategories().Count);



        }


        [TestCase]
        public void GetCategoryById_Should_Return_First_Category_InDatabase()
        {
            var data = new List<Category>
            {
                new Category ("TestCategory1"){ Id = 1},
                new Category ("TestCategory2"){ Id = 2},
                new Category ("TestCategory3"){ Id = 3}
            }.AsQueryable();

            var mockSet = new Mock<DbSet<Category>>();
            mockSet.As<IQueryable<Category>>().Setup(m => m.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<Category>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<Category>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<Category>>().Setup(m => m.GetEnumerator()).Returns(() => data.GetEnumerator());

            var mockContext = new Mock<BookShopContext>();
            mockContext.Setup(c => c.Categories).Returns(mockSet.Object);

            var controller = new CategoryController(mockContext.Object);
            data.ToList().ForEach(x => controller.AddCategory(x));
            var result = controller.GetCategoryById(1);
            Assert.AreEqual("TestCategory1", result.Name);

        }

        [TestCase]
        public void GetAllCategories_Should_Return_All_Categories_InDatabase()
        {
            var data = new List<Category>
            {
                new Category ("TestCategory1"){ Id = 1},
                new Category ("TestCategory2"){ Id = 2},
                new Category ("TestCategory3"){ Id = 3}
            }.AsQueryable();

            var mockSet = new Mock<DbSet<Category>>();
            mockSet.As<IQueryable<Category>>().Setup(m => m.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<Category>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<Category>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<Category>>().Setup(m => m.GetEnumerator()).Returns(() => data.GetEnumerator());

            var mockContext = new Mock<BookShopContext>();
            mockContext.Setup(c => c.Categories).Returns(mockSet.Object);

            var controller = new CategoryController(mockContext.Object);
            data.ToList().ForEach(x => controller.AddCategory(x));

            var expectedCount = 3; 
            var result = controller.GetAllCategories();
            var actualCount = result.Count;
            Assert.AreEqual(expectedCount, actualCount);
            Assert.AreEqual("TestCategory1", result[0].Name);
            Assert.AreEqual("TestCategory2", result[1].Name);
            Assert.AreEqual("TestCategory3", result[2].Name);


        }


        [TestCase]
        public void GetCategoryByName_Should_Return_Correct_Category_InDatabase()
        {
            var data = new List<Category>
            {
                new Category ("TestCategory1"){ Id = 1},
                new Category ("TestCategory2"){ Id = 2},
                new Category ("TestCategory3"){ Id = 3}
            }.AsQueryable();

            var mockSet = new Mock<DbSet<Category>>();
            mockSet.As<IQueryable<Category>>().Setup(m => m.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<Category>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<Category>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<Category>>().Setup(m => m.GetEnumerator()).Returns(() => data.GetEnumerator());

            var mockContext = new Mock<BookShopContext>();
            mockContext.Setup(c => c.Categories).Returns(mockSet.Object);

            var controller = new CategoryController(mockContext.Object);
            data.ToList().ForEach(x => controller.AddCategory(x));
            var result = controller.GetCategoryByName("TestCategory3");
            Assert.AreEqual(3, result.Id);
        }

       

    }   

}
