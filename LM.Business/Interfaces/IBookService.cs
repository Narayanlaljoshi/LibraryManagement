using LM.Business.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LM.Business.Interfaces
{
    public interface IBookService
    {
        Task<Response> AddBook(BookDetails bookDetails, CancellationToken cancellationToken);
        Task<Response> ListAllBooks(CancellationToken cancellationToken);
        Task<Response> ListAllBooksByAuthor(AuthorIdInput author, CancellationToken cancellationToken);
    }
}
