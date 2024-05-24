using LM.Business.Interfaces;
using LM.Business.Models;
using LM.Data.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IBookService _bookService;

        public BooksController(IBookService bookService)
        {
            _bookService = bookService;
        }

        [HttpPost]
        [Route("AddBook")]
        public async Task<Response> AddBook(BookDetails bookDetails, CancellationToken cancellationToken)
        {
            return await _bookService.AddBook(bookDetails, cancellationToken);
            
        }

        [HttpGet]
        [Route("ListAllBooks")]
        public async Task<Response> ListAllBooks(CancellationToken cancellationToken)
        {
            return await _bookService.ListAllBooks(cancellationToken);

        }

        [HttpPost]
        [Route("ListAllBooksByAuthor")]
        public async Task<Response> ListAllBooksByAuthor(AuthorIdInput author, CancellationToken cancellationToken)
        {
            var result = await _bookService.ListAllBooksByAuthor(author, cancellationToken);

            return new Response { Data = result, Message = "Books List not found", Status = 200 };
        }
    }
}
