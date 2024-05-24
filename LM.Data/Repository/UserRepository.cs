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
    internal class UserRepository : DapperRepository, IUserRepository
    {
        private readonly DapperCommand _validateUser =
                new DapperCommand("dbo.sp_ValidateUser", CommandType.StoredProcedure);
        public UserRepository(IDbConnectionFactory factory, IDapperWrapper dapperWrapper) : base(factory, dapperWrapper)
        {
        }

        public async Task<User> ValidateUser(string username, string password,CancellationToken cancellationToken)
        {

            var parameters = new DynamicParameters();

            parameters.Add("Username", username);
            parameters.Add("Password", password);
            var result = await DapperWrapper.QueryFirstOrDefaultAsync<User>(GetConnection(),
                   _validateUser, parameters, cancellationToken);

            return result;
        }
    }
}
