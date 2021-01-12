using Identity.Controllers;
using Identity.Data;
using Identity.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;
using System.Linq;

namespace Tests
{
    [TestClass]
    public class IdentityTests
    {
        [TestMethod]
        public void GetUser_UserExists_ReturnsOk()
        {
            var data = new List<User>
            {
                new User { Username = "Andreea", Password="Andreea"}

            }.AsQueryable();

            var mockSet = new Mock<DbSet<User>>();
            mockSet.As<IQueryable<User>>().Setup(m => m.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<User>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<User>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<User>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());

            var mockContext = new Mock<UserContext>();
            mockContext.Setup(c => c.Users).Returns(mockSet.Object);

            var service = new UsersController(mockContext.Object);
            var actualUser = service.GetUser("Andreea", "Andreea");
            Assert.IsInstanceOfType(actualUser, typeof(OkObjectResult));
        }

        [TestMethod]
        public void GetUser_UserDoesNotExist_ReturnsBadRequest()
        {
            var data = new List<User>
            {
                new User { Username = "Andreea", Password= "Andreea"}

            }.AsQueryable();

            var mockSet = new Mock<DbSet<User>>();
            mockSet.As<IQueryable<User>>().Setup(m => m.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<User>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<User>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<User>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());

            var mockContext = new Mock<UserContext>();
            mockContext.Setup(c => c.Users).Returns(mockSet.Object);

            var service = new UsersController(mockContext.Object);
            var actualUser = service.GetUser("Hej", "Andreea");
            Assert.IsInstanceOfType(actualUser, typeof(BadRequestObjectResult));
        }
    }
}
