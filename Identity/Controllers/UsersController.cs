using Identity.Data;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace Identity.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly UserContext _context;

        public UsersController(UserContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetUser([FromQuery] string username, string password)
        {
            var user = _context.Users.FirstOrDefault(u => u.Username == username && u.Password == password);

            if (user is null)
            {
                return BadRequest("Username or password are incorrect");
            }

            return Ok(user);
        }
    }
}
