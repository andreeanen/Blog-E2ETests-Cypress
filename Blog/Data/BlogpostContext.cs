using Blog.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Blog.Data
{
    public class BlogpostContext : DbContext
    {
        IConfiguration Configuration { get; set; }

        public BlogpostContext()
        {

        }

        public BlogpostContext(DbContextOptions<BlogpostContext> options, IConfiguration configuration) : base(options)
        {
            Configuration = configuration;
        }

        public virtual DbSet<Blogpost> Blogposts { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"));
        }
    }
}
