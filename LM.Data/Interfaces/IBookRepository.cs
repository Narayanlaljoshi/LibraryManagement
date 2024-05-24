using LM.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LM.Data.Interfaces
{
    public interface IBookRepository
    {
        Task<bool> AddBook(string title, string isbn, int year, Guid authorId, CancellationToken cancellationToken);
        Task<IEnumerable<Books>> ListAllBooks(CancellationToken cancellationToken);
        Task<IEnumerable<Books>> ListAllBooksByAuthor(Guid authorId, CancellationToken cancellationToken);
    }
}
