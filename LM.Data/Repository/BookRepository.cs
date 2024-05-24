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
    internal class BookRepository : DapperRepository, IBookRepository
    {
        private readonly DapperCommand _addBook =
               new DapperCommand("dbo.sp_AddBook", CommandType.StoredProcedure);
        private readonly DapperCommand _listAllBooksByAuthor =
               new DapperCommand("dbo.sp_ListAllBooksByAuthor", CommandType.StoredProcedure);
        private readonly DapperCommand _listAllBooks =
               new DapperCommand("dbo.sp_ListAllBooks", CommandType.StoredProcedure);
        public BookRepository(IDbConnectionFactory factory, IDapperWrapper dapperWrapper) : base(factory, dapperWrapper)
        {
        }

        public async Task<bool> AddBook(string title, string isbn, int year, Guid authorId, CancellationToken cancellationToken)
        {
            var parameters = new DynamicParameters();

            parameters.Add("Title", title);
            parameters.Add("ISBN", isbn);
            parameters.Add("YearPublished", year);
            parameters.Add("AuthorId", authorId);
            var result = await DapperWrapper.ExecuteAsync(GetConnection(),
                   _addBook, parameters, cancellationToken);

            return result > 0 ? true : false;
        }
        public async Task<IEnumerable<Books>> ListAllBooks(CancellationToken cancellationToken)
        {
            var result = await DapperWrapper.QueryAsync<Books>(GetConnection(),
                   _listAllBooks, null, cancellationToken);

            return result;
        }
        public async Task<IEnumerable<Books>> ListAllBooksByAuthor(Guid authorId, CancellationToken cancellationToken)
        {
            var parameters = new DynamicParameters();

            parameters.Add("AuthorId", authorId);
            var result = await DapperWrapper.QueryAsync<Books>(GetConnection(),
                   _listAllBooksByAuthor, parameters, cancellationToken);

            return result;
        }
    }
}
