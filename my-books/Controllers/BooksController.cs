using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using my_books.Data.Services;
using my_books.Data.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace my_books.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        public BooksService _booksService;
        public BooksController(BooksService booksService)
        {
            _booksService = booksService;
        }

        [HttpGet("get-all-books")]
        public IActionResult GetAllBooks()
        {
            var allBooks = _booksService.GetAllBooks();
            return Ok(allBooks);
        }

        [HttpGet("get-book-by-id/{id}")]
        public IActionResult GetBook(int id)
        {
            var books = _booksService.GetBookById(id);
            return Ok(books);
        }

        [HttpPost("add-book-with-author")]
        public IActionResult AddBook([FromBody]BookVM book)
        {
            _booksService.AddBookWithAuthor(book);
            return Ok();
        }

        [HttpPut("update-book/{id}")]
        public IActionResult UpdateBook([FromBody] BookVM book, int id)
        {
            var updatedBooks = _booksService.UpdateBookById(id, book);
            return Ok(updatedBooks);
        }

        [HttpDelete("delete-book/{id}")]
        public IActionResult DeleteBook(int id)
        {
            _booksService.DeleteBookById(id);
            return Ok();
        }
    }
}
