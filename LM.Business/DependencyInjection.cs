using LM.Data.Dapper.Command;
using LM.Data.Dapper.Interface;
using LM.Data.Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using LM.Business.Interfaces;
using LM.Business.Services;

namespace LM.Business
{
    public static class DependencyInjection
    {
        public static void AddBusiness(this IServiceCollection services)
        {
            services.AddScoped< IAuthorService, AuthorService>();
            services.AddScoped< IBookService, BookService>();
            services.AddScoped<IUserService, UserService>();
        }
    }
}
