using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TestTask.Application;
using TestTask.Application.Models;

namespace TestTask.Web.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BookController : ControllerBase
    {
        private readonly IBookService _bookService;

        public BookController(IBookService bookService)
        {
            _bookService = bookService;
        }

        [HttpGet("{bookId}")]
        public async Task<BookModelDTO> GetBookItem(int bookId)
        {
            var result =  await _bookService.GetBookAsync(bookId);

            if (result == null)
                throw new Exception("Such book is not exist");

            return result;
        }

        [HttpGet]
        public async Task<IEnumerable<BookModelDTO>> GetBooks()
        {
            var books = await _bookService.GetBookItemsAsync();

            if (books == null) { throw new Exception("No books!"); }

            return books;
        }

        [HttpPost]
        public async Task<IActionResult> CreateBook([FromBody] BookModelDTO input)
        {
            await _bookService.CreateAsync(input);
            return Ok();
        }

        [HttpPut]
        public async Task<BookModelDTO> UpdateBook([FromBody] BookModelDTO input)
        {
            var book = await _bookService.UpdateBookAsync(input);

            if (book == null) { throw new Exception("Book is not change!"); }

            return book;
        }

        [HttpDelete("{bookId}")]
        public async Task<IActionResult> DeleteBook(int bookId)
        {
            await _bookService.DeleteBookAsync(bookId);
            return Ok();
        }
    }
}

