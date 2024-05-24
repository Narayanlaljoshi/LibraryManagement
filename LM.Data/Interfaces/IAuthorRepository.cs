using LM.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LM.Data.Interfaces
{
    public interface IAuthorRepository
    {
        Task<Guid> AddAuthor(string name, string email, CancellationToken cancellationToken);
        Task<IEnumerable<Authors>> ListAllAuthors(CancellationToken cancellationToken);
    }
}
