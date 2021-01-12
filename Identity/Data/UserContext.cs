using Identity.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Identity.Data
{
    public class UserContext : DbContext
    {
        IConfiguration Configuration { get; set; }

        public UserContext()
        {

        }

        public UserContext(DbContextOptions<UserContext> options, IConfiguration configuration) : base(options)
        {
            Configuration = configuration;
        }

        public virtual DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"));
        }
    }
}
