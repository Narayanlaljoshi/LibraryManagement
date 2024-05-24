using LM.Business.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LM.Business.Interfaces
{
    public interface IUserService
    {
        Task<Response> ValidateUser(ValidateUserInput input, CancellationToken cancellationToken);
    }
}
