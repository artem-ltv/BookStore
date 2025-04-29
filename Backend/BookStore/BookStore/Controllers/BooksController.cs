using BookStore.Contracts;
using BookStore.Core.Abstractions;
using BookStore.Core.Models;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BooksController(IBooksService booksService) : ControllerBase
    {
        private readonly IBooksService _booksService = booksService;

        [HttpGet]
        public async Task<ActionResult<List<BooksResponse>>> Get()
        {
            var books = await _booksService.GetBooks();
            var response = books.Select(b => new BooksResponse(b.Id, b.Title, b.Description, b.Price));

            return Ok(response);
        }

        [HttpPost]
        public async Task<ActionResult<Guid>> Create([FromBody]BooksRequest request)
        {
            var book = Book.Create(
                Guid.NewGuid(),
                request.Title,
                request.Description,
                request.Price
                );

            if (!string.IsNullOrEmpty(book.Error))
            {
                return BadRequest(book.Error);
            }

            var bookId = await _booksService.CreateBook(book.Book);

            return Ok(bookId);
        }

        [HttpPut("{id:guid}")]
        public async Task<ActionResult<Guid>> Update(Guid id, [FromBody] BooksRequest request)
        {
            var bookId = await _booksService.UpdateBook(id, request.Title, request.Description, request.Price);

            return Ok(bookId);
        }

        [HttpDelete("{id:guid}")]
        public async Task<ActionResult<Guid>> Delete(Guid id)
        {
            var bookId = await _booksService.DeleteBook(id);

            return Ok(bookId);
        }
    }
}
