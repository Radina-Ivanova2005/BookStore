using bookRepository.Busines;
using bookRepository.Data.Models;
using bookRepository.Data;
using Microsoft.EntityFrameworkCore;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using bookRepository.Models;

namespace BookShopTest
{
    public class AuthorTest
    {
        [TestCase]
        public void CreateAuthor_Add_A_Author_Via_Context()
        {
            var mockSet = new Mock<DbSet<Author>>();

            var mockContext = new Mock<BookShopContext>();
            mockContext.Setup(m => m.Authors).Returns(mockSet.Object);

            var controller = new AuthorController(mockContext.Object);
            controller.AddAuthor(new Author("TestCategory"));

            mockSet.Verify(m => m.Add(It.IsAny<Author>()), Times.Once());
            mockContext.Verify(m => m.SaveChanges(), Times.Once());
        }
    }
}
