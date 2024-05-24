using Dapper;
using LM.Data.Dapper.Interface;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Dapper.SqlMapper;

namespace LM.Data.Dapper.Command
{

    public class DapperWrapper : IDapperWrapper
    {
        public async Task<IEnumerable<T>> QueryAsync<T>(
            IDbConnection dbConnection,
            DapperCommand dapperCommand,
            DynamicParameters parameters,
            CancellationToken cancellationToken = default)
        {
            using (var connection = dbConnection)
            {
                return await connection.QueryAsync<T>(dapperCommand.Definition(parameters));
            }
        }

        public async Task<IEnumerable<T>> QueryAsync<T>(
            IDbConnection dbConnection,
            DapperCommand dapperCommand,
            CancellationToken cancellationToken = default)
        {
            using (var connection = dbConnection)
            {
                return await connection.QueryAsync<T>(dapperCommand.Definition(cancellationToken));
            }
        }

        public async Task<T> QuerySingleAsync<T>(
            IDbConnection dbConnection,
            DapperCommand dapperCommand,
            DynamicParameters parameters,
            CancellationToken cancellationToken = default)
        {
            using (var connection = dbConnection)
            {
                return await connection.QuerySingleAsync<T>(dapperCommand.Definition(parameters));
            }
        }

        public async Task<T> QueryFirstOrDefaultAsync<T>(
            IDbConnection dbConnection,
            DapperCommand dapperCommand,
            DynamicParameters parameters,
            CancellationToken cancellationToken = default)
        {
            using (var connection = dbConnection)
            {
                return await connection.QueryFirstOrDefaultAsync<T>(dapperCommand.Definition(parameters));
            }
        }
        public async Task<int> ExecuteAsync(IDbConnection dbConnection, DapperCommand dapperCommand, DynamicParameters
            parameters, CancellationToken cancellationToken = default)
        {
            var connection = dbConnection;
            return await connection.ExecuteAsync(dapperCommand.Definition(parameters, cancellationToken));
        }


    }
}
