using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApiHw2.Model;

namespace WebApiHw2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        public static List<Book> _books = new List<Book>
        {
            new Book { Author = "Author1", Title = "Title1" },
            new Book { Author = "Author2", Title = "Title2" }
        };

        [HttpGet]
        public IActionResult GetAllBooks()
        {
            return Ok(_books);
        }

        [HttpGet("{index}")]
        public IActionResult GetBookByIndex(int index)
        {
            if (index >= 0 && index < _books.Count)
            {
                return Ok(_books[index]);
            }
            return NotFound();
        }

        [HttpGet("filter")]
        public IActionResult GetBookByAuthorAndTitle([FromQuery] string author, [FromQuery] string title)
        {
            var book = _books.FirstOrDefault(b => b.Author == author && b.Title == title);
            if (book != null)
            {
                return Ok(book);
            }
            return NotFound();
        }

        [HttpPost]
        public IActionResult AddBook([FromBody] Book newBook)
        {
            _books.Add(newBook);
            return CreatedAtAction(nameof(GetAllBooks), _books);
        }

        [HttpPost("titles")]
        public IActionResult GetTitlesFromBooks([FromBody] List<Book> bookList)
        {
            var titles = bookList.Select(b => b.Title).ToList();
            return Ok(titles);
        }

    }
}
