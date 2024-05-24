using LM.Business.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace LibraryManagement.Controllers
{

    public class BaseApiController : Controller
    {
        public readonly HttpContext _context;
        public readonly ClaimsIdentity? _identity;
        private readonly int tokenTime = 20;
        public BaseApiController(HttpContext context)
        {
            _context = context;
            _identity = _context.User.Identity as ClaimsIdentity;
            tokenValidaion();
        }
        private void tokenValidaion()
        {
            DateTime timeStamp = Convert.ToDateTime(_identity?.FindFirst(x => x.Type == "TokenTimeStamp")?.Value);
            if (timeStamp.AddMinutes(tokenTime) < DateTime.UtcNow)
            {
                throw new Exception("Token Expired");
            }
        }
        protected LoggedInUser loggedInUser
        {
            get
            {
                var userClaims = _identity?.Claims;
                return new LoggedInUser
                {
                    Username = userClaims.FirstOrDefault(x => x.Type == "UserName")?.Value
                };
            }
        }

    }
}
