using LM.Business.Interfaces;
using LM.Business.Models;
using LM.Data.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorController : BaseApiController
    {
        private readonly IAuthorService _authorService;
        public AuthorController(IHttpContextAccessor context, IAuthorService authorService) : base(context.HttpContext)
        {
            _authorService = authorService;
        }


        [HttpPost]
        [Route("AddAuthor")]
        public Task<Response> AddAuthor(AuthorDetails input, CancellationToken cancellationToken)
        {
            return _authorService.AddAuthor(input, cancellationToken);
        }

        [HttpPost]
        [Route("AddAuthor")]
        public Task<Response> ListAllAuthors(CancellationToken cancellationToken)
        {
            return _authorService.ListAllAuthors(cancellationToken);
        }
    }
}
