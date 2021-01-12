using Identity.Models;
using System.Collections.Generic;
using System.Linq;

namespace Identity.Data
{
    public class DbInitializer
    {
        public static void Initialize(UserContext context)
        {
            context.Database.EnsureCreated();

            if (context.Users.Any())
            {
                return;
            }

            var users = new List<User>
            {
                new User
                {
                    Username = "Admin",
                    Password = "Admin",
                    UserStatus = UserStatus.Admin
                },
                new User
                {
                    Username = "User",
                    Password = "User",
                    UserStatus = UserStatus.User
                }
            };

            context.Users.AddRange(users);
            context.SaveChanges();
        }
    }
}
