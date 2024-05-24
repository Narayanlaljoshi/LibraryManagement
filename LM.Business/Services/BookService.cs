


using Dapper;
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
    internal class BookService : IBookService
    {
        private readonly IBookRepository _bookRepository;

        public BookService(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public async Task<Response> AddBook(BookDetails bookDetails, CancellationToken cancellationToken)
        {
            var result = await _bookRepository.AddBook(bookDetails.Title,bookDetails.ISBN, bookDetails.YearPublished, bookDetails.AuthorId, cancellationToken);
            if (result)
            {
                return new Response {Data = result, Message = "BookAdded successfully", Status = 200 };
            }

            return new Response { Data = result, Message = "Book Not Added", Status = 400 };
        }

        public async Task<Response> ListAllBooks(CancellationToken cancellationToken)
        {
            var result = await _bookRepository.ListAllBooks(cancellationToken);

            return new Response { Data = result, Message = "Books List found", Status = 200 };

        }
        public async Task<Response> ListAllBooksByAuthor(AuthorIdInput author, CancellationToken cancellationToken)
        {
            var result = await _bookRepository.ListAllBooksByAuthor(author.AuthorId, cancellationToken);

            return new Response { Data = result, Message = "Books List not found", Status = 200 };
        }
    }
}
