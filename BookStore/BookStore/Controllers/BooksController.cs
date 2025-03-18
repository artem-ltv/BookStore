using BookStore.API.Contracts;
using BookStore.Core.Abstractions;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.API.Controllers
{
    [ApiController]
    [Route("{controller}")]
    public class BooksController(IBooksService booksService) : ControllerBase
    {
        private readonly IBooksService _booksService = booksService;

        [HttpGet]
        public async Task<ActionResult<IEnumerable<BooksResponse>>> GetBooks() 
        {
            var books = await _booksService.GetAllBooks();
            var response = books.Select(b => new BooksResponse(b.Id, b.Title, b.Description, b.Price));

            return Ok(response);
        }
    }
}
