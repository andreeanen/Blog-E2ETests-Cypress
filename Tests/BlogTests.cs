using Blog.Controllers;
using Blog.Data;
using Blog.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests
{
    [TestClass]
    public class BlogTests
    {
       
            [TestMethod]
            public void GetBlogs_WhenCalled_ReturnOkObjectResult()
            {
                var data = new List<Blogpost>
            {
                new Blogpost
                {
                    Author = "Admin",
                    Title = "Blog title 1",
                    DateTime = DateTime.Now,
                    Text = "Lorem Ipsum Blog Text 1"
                },
                new Blogpost
                {
                    Author = "Admin",
                    Title = "Blog title 2",
                    DateTime = DateTime.Now,
                    Text = "Lorem Ipsum Blog Text 2"
                },
            }.AsQueryable();

                var mockSet = new Mock<DbSet<Blogpost>>();
                mockSet.As<IQueryable<Blogpost>>().Setup(m => m.Provider).Returns(data.Provider);
                mockSet.As<IQueryable<Blogpost>>().Setup(m => m.Expression).Returns(data.Expression);
                mockSet.As<IQueryable<Blogpost>>().Setup(m => m.ElementType).Returns(data.ElementType);
                mockSet.As<IQueryable<Blogpost>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());

                var mockContext = new Mock<BlogpostContext>();
                mockContext.Setup(c => c.Blogposts).Returns(mockSet.Object);

                var service = new BlogpostsController(mockContext.Object);
                var actualResult = service.GetBlogposts();
                Assert.IsInstanceOfType(actualResult, typeof(OkObjectResult));
            }

            [TestMethod]
            public void CreateBlog_WhenCalled_ReturnCreatedObjectResult()
            {
                var data = new List<Blogpost>().AsQueryable();

                var newBlog = new BlogpostCreate()
                {
                    Author = "Admin",
                    Title = "New Blog",
                    Text = "Lorem Ipsum"
                };

                var mockSet = new Mock<DbSet<Blogpost>>();
                mockSet.As<IQueryable<Blogpost>>().Setup(m => m.Provider).Returns(data.Provider);
                mockSet.As<IQueryable<Blogpost>>().Setup(m => m.Expression).Returns(data.Expression);
                mockSet.As<IQueryable<Blogpost>>().Setup(m => m.ElementType).Returns(data.ElementType);
                mockSet.As<IQueryable<Blogpost>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());

                var mockContext = new Mock<BlogpostContext>();
                mockContext.Setup(c => c.Blogposts).Returns(mockSet.Object);

                var service = new BlogpostsController(mockContext.Object);
                var actualResult = service.CreateBlog(newBlog);
                Assert.IsInstanceOfType(actualResult, typeof(CreatedResult));
            }

        [TestMethod]
        public void GetNumberOfBlogposts_WhenCalled_ReturnsBlogpostsCount()
        {
            var data = new List<Blogpost>
            {
                new Blogpost
                {
                    Author = "Admin",
                    Title = "Blog title 1",
                    DateTime = DateTime.Now,
                    Text = "Lorem Ipsum Blog Text 1"
                },
                new Blogpost
                {
                    Author = "Admin",
                    Title = "Blog title 2",
                    DateTime = DateTime.Now,
                    Text = "Lorem Ipsum Blog Text 2"
                },
            }.AsQueryable();

            var mockSet = new Mock<DbSet<Blogpost>>();
            mockSet.As<IQueryable<Blogpost>>().Setup(m => m.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<Blogpost>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<Blogpost>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<Blogpost>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());

            var mockContext = new Mock<BlogpostContext>();
            mockContext.Setup(c => c.Blogposts).Returns(mockSet.Object);
           
            var service = new BlogpostsController(mockContext.Object);
            var actualResult = service.GetNumberOfBlogposts();
            var expectedResult = data.Count();
            Assert.AreEqual(actualResult, expectedResult);
        }

        [TestMethod]
        public void DeleteBlogpost_WhenCalled_ReturnsNoContent()
        {
            var data = new List<Blogpost>
            {
                new Blogpost
                {
                    Author = "Admin",
                    Title = "Blog title 1",
                    DateTime = DateTime.Now,
                    Text = "Lorem Ipsum Blog Text 1"
                },
                new Blogpost
                {
                    Author = "Admin",
                    Title = "Blog title 2",
                    DateTime = DateTime.Now.AddHours(1),
                    Text = "Lorem Ipsum Blog Text 2"
                }
            }.AsQueryable();

            var mockSet = new Mock<DbSet<Blogpost>>();
            mockSet.As<IQueryable<Blogpost>>().Setup(m => m.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<Blogpost>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<Blogpost>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<Blogpost>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());

            var mockContext = new Mock<BlogpostContext>();
            mockContext.Setup(c => c.Blogposts).Returns(mockSet.Object);

            var service = new BlogpostsController(mockContext.Object);
            var actualResult = service.DeleteBlogpost();

            Assert.IsInstanceOfType(actualResult, typeof(NoContentResult));
        }
    }
}
