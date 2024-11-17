using Books.WebApi.Models;
using Books.WebApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace Books.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BooksController : ControllerBase
    {
        private readonly IBookService _bookService;

        public BooksController(IBookService bookService)
        {
            _bookService = bookService;
        }

        [HttpGet]
        public IEnumerable<Book> GetAll() => _bookService.GetAll();

        [HttpGet("{id}")]
        public ActionResult<Book> GetById(int id)
        {
            var book = _bookService.GetById(id);
            if (book == null) return NotFound();
            return book;
        }

        [HttpPost]
        public IActionResult Add(Book book)
        {
            _bookService.Add(book);
            return CreatedAtAction(nameof(GetById), new { id = book.Id }, book);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, Book book)
        {
            if (id != book.Id) return BadRequest();

            var existingBook = _bookService.GetById(id);
            if (existingBook == null) return NotFound();

            _bookService.Update(book);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var book = _bookService.GetById(id);
            if (book == null) return NotFound();

            _bookService.Delete(id);
            return NoContent();
        }
    }
}
