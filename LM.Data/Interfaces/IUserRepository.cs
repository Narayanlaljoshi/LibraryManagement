using LM.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LM.Data.Interfaces
{
    public interface IUserRepository
    {
        Task<User> ValidateUser(string username, string password, CancellationToken cancellationToken);
    }
}
