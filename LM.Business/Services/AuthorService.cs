using LM.Business.Interfaces;
using LM.Business.Models;
using LM.Data.Dapper.Command;
using LM.Data.Interfaces;
using LM.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LM.Business.Services
{
    internal class AuthorService: IAuthorService
    {
        private readonly IAuthorRepository _authorRepository;

        public AuthorService(IAuthorRepository authorRepository)
        {
            _authorRepository = authorRepository;
        }

        public async Task<Response> AddAuthor(AuthorDetails authorDetails, CancellationToken cancellationToken)
        {
            var result = await _authorRepository.AddAuthor(authorDetails.Name, authorDetails.Email, cancellationToken);
            if (result != null)
            {
                return new Response { Data = result, Message = "Author Added successfully", Status = 200 };
            }

            return new Response { Data = result, Message = "Author Not Added", Status = 400 };
        }

        public async Task<Response> ListAllAuthors(CancellationToken cancellationToken)
        {
            var result = await _authorRepository.ListAllAuthors(cancellationToken);
            if (result.Count()>0)
            {
                return new Response { Data = result, Message = "Author List Found", Status = 200 };
            }
            return new Response { Data = result, Message = "Author List Not Found", Status = 200 };
        }
    }
}
