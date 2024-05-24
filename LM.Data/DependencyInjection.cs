using LM.Data.Dapper;
using LM.Data.Dapper.Command;
using LM.Data.Dapper.Interface;
using LM.Data.Interfaces;
using LM.Data.Repository;
using Microsoft.Extensions.DependencyInjection;

namespace LM.Data
{
    public static class DependencyInjection
    {
        public static void AddInfrastructure(this IServiceCollection services)
        {
            services.AddScoped<IAuthorRepository, AuthorRepository>();
            services.AddScoped<IBookRepository, BookRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IDbConnectionFactory, SqlConnectionFactory>();
            services.AddScoped<IDapperWrapper, DapperWrapper>();
        }
    }
}
