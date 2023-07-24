using Microsoft.AspNetCore.Mvc;
using WebApplication3.Models;
using System.Collections.Generic;
using System.Linq;

namespace WebApplication3.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BookController : ControllerBase
    {
        private readonly BookstoreDbContext _context;

        public BookController(BookstoreDbContext context)
        {
            _context = context;
        }

        // GET /Book
        [HttpGet]
        public IEnumerable<Book> GetAllBooks()
        {
            return _context.Books.ToList();
        }

        // GET /Book/{id}
        [HttpGet("{id}")]
        public IActionResult GetBookById(int id)
        {
            var book = _context.Books.Find(id);
            if (book == null)
            {
                return NotFound();
            }
            return Ok(book);
        }

        // POST /Book
        [HttpPost]
        public IActionResult CreateBook([FromBody] Book book)
        {
            if (book == null)
            {
                return BadRequest();
            }

            _context.Books.Add(book);
            _context.SaveChanges();

            return CreatedAtAction(nameof(GetBookById), new { id = book.BookId }, book);
        }

        // PUT /Book/{id}
        [HttpPut("{id}")]
        public IActionResult UpdateBook(int id, [FromBody] Book book)
        {
            if (book == null || book.BookId != id)
            {
                return BadRequest();
            }

            var existingBook = _context.Books.Find(id);
            if (existingBook == null)
            {
                return NotFound();
            }

            existingBook.BookName = book.BookName;
            existingBook.Author = book.Author;

            _context.SaveChanges();

            return NoContent();
        }

        // DELETE /Book/{id}
        [HttpDelete("{id}")]
        public IActionResult DeleteBook(int id)
        {
            var book = _context.Books.Find(id);
            if (book == null)
            {
                return NotFound();
            }

            _context.Books.Remove(book);
            _context.SaveChanges();

            return NoContent();
        }
    }
}
