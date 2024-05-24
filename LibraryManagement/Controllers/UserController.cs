using LM.Business.Interfaces;
using LM.Business.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        [Route("ValidateUser")]
        public Task<Response> ValidateUser(ValidateUserInput input, CancellationToken cancellationToken)
        {
            return _userService.ValidateUser(input, cancellationToken);
        }

    }
}
