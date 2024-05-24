using LM.Business.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LM.Business.Interfaces
{
    public interface IAuthorService
    {
        Task<Response> AddAuthor(AuthorDetails authorDetails, CancellationToken cancellationToken);
        Task<Response> ListAllAuthors(CancellationToken cancellationToken);
    }
}
