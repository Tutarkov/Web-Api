using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAppHw1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        public static List<string> _userDb = new List<string>
        {
            "User1", "User2", "User3"
        };

        [HttpGet]
        public IActionResult GetAllUsers()
        {
            return Ok(_userDb);
        }

        [HttpGet("{id}")]
        public IActionResult GetUser(int id)
        {
            if (id >= 0 && id < _userDb.Count)
            {
                return Ok(_userDb[id]);
            }
            return NotFound();
        }
    }
}
