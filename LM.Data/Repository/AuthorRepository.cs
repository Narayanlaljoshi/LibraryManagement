using Dapper;
using LM.Data.Dapper.Command;
using LM.Data.Dapper.Interface;
using LM.Data.Dapper.Repository;
using LM.Data.Interfaces;
using LM.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LM.Data.Repository
{
    internal class AuthorRepository : DapperRepository, IAuthorRepository
    {
        private readonly DapperCommand _addAuthor =
                new DapperCommand("dbo.sp_AddAuthor", CommandType.StoredProcedure);
        private readonly DapperCommand _listAllAuthor =
                new DapperCommand("dbo.sp_ListAllAuthor", CommandType.StoredProcedure);
        public AuthorRepository(IDbConnectionFactory factory, IDapperWrapper dapperWrapper) : base(factory, dapperWrapper)
        {
        }

        public async Task<Guid> AddAuthor(string name, string email, CancellationToken cancellationToken)
        {
            var parameters = new DynamicParameters();

            parameters.Add("Name", name);
            parameters.Add("Email", email);
            var result = await DapperWrapper.QueryFirstOrDefaultAsync<Guid>(GetConnection(),
                   _addAuthor, parameters, cancellationToken);

            return result;
        }

        public async Task<IEnumerable<Authors>> ListAllAuthors(CancellationToken cancellationToken)
        {
            var result = await DapperWrapper.QueryAsync<Authors>(GetConnection(),
                   _listAllAuthor, null, cancellationToken);

            return result;
        }
    }
}
