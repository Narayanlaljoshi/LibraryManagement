using Dapper;
using LM.Data.Dapper.Command;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Dapper.SqlMapper;

namespace LM.Data.Dapper.Interface
{
    public interface IDapperWrapper
    {
        public Task<IEnumerable<T>> QueryAsync<T>(
            IDbConnection dbConnection,
            DapperCommand dapperCommand,
            DynamicParameters parameters,
            CancellationToken cancellationToken = default);

        public Task<IEnumerable<T>> QueryAsync<T>(
            IDbConnection dbConnection,
            DapperCommand dapperCommand,
            CancellationToken cancellationToken = default);

        public Task<T> QuerySingleAsync<T>(
            IDbConnection dbConnection,
            DapperCommand dapperCommand,
            DynamicParameters parameters,
            CancellationToken cancellationToken = default);

        public Task<T> QueryFirstOrDefaultAsync<T>(
            IDbConnection dbConnection,
            DapperCommand dapperCommand,
            DynamicParameters parameters,
            CancellationToken cancellationToken = default);



        public Task<int> ExecuteAsync(IDbConnection dbConnection, DapperCommand dapperCommand, DynamicParameters
            parameters, CancellationToken cancellationToken = default);
    }
}
