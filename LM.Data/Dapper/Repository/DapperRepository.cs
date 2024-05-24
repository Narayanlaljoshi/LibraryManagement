using LM.Data.Dapper.Interface;
using System.Data;

namespace LM.Data.Dapper.Repository
{
    public abstract class DapperRepository
    {
        protected readonly IDapperWrapper DapperWrapper;

        protected DapperRepository(IDbConnectionFactory factory, IDapperWrapper dapperWrapper)
        {
            Factory = factory;
            DapperWrapper = dapperWrapper;
        }

        private static IDbConnectionFactory Factory { get; set; }

        protected static IDbConnection GetConnection()
        {
            return Factory.CreateConnection();
        }
    }
}
