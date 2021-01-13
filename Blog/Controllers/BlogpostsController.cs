using Blog.Data;
using Blog.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blog.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogpostsController : ControllerBase
    {
        private readonly BlogpostContext _context;

        public BlogpostsController(BlogpostContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetBlogposts()
        {
            var blogposts = _context.Blogposts.OrderByDescending(b => b.DateTime).ToList();
            return Ok(blogposts);
        }

        [HttpGet("count")]
        public int GetNumberOfBlogposts()
        {
            var blogposts = _context.Blogposts.OrderByDescending(b => b.DateTime).ToList();
            return blogposts.Count;
        }

        [HttpPost]
        public IActionResult CreateBlog([FromBody] BlogpostCreate blogpostCreate)
        {
            var newBlogpost = new Blogpost()
            {
                Title = blogpostCreate.Title,
                Text = blogpostCreate.Text,
                Author = blogpostCreate.Author,
                DateTime = DateTime.Now
            };

            _context.Blogposts.Add(newBlogpost);
            _context.SaveChanges();

            return Created("GetBlogposts", newBlogpost);
        }

        [HttpDelete]
        public IActionResult DeleteBlogpost()
        {
            var latestBlogpost = _context.Blogposts.OrderByDescending(b => b.DateTime).FirstOrDefault();

            if (latestBlogpost is null)
            {
                return NotFound();
            }

            _context.Blogposts.Remove(latestBlogpost);
            _context.SaveChanges();

            return NoContent();
        }
    }
}
