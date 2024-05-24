using Dapper;
using LM.Business.Interfaces;
using LM.Business.Models;
using LM.Data.Dapper.Command;
using LM.Data.Interfaces;
using LM.Domain.Entities;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace LM.Business.Services
{
    internal class UserService : IUserService
    {
        private IUserRepository _userRepository;
        public IConfiguration _configuration;
        private int tokenTime = 20;//in minutes
        public UserService(IUserRepository userRepository, IConfiguration configuration)
        {
            _userRepository = userRepository;
            _configuration = configuration;
        }

        public async Task<Response> ValidateUser(ValidateUserInput input, CancellationToken cancellationToken)
        {
            var result = await _userRepository.ValidateUser(input.Username, input.Password, cancellationToken);
            if (result != null)
            {
                return await GenerateJWTToken(input.Username);
            }
            return new Response { Data = null, Message = "Validation un-successful", Status = 400 };
        }
        
        public async Task<Response> GenerateJWTToken(string Username)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.UTF8.GetBytes(_configuration["JWT:Secret"]);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[] {
                new Claim("UserName",Username),
                new Claim("TokenTimeStamp",DateTime.UtcNow.ToString()),
                new Claim(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString())
                }),
                NotBefore = DateTime.Now,
                Expires = DateTime.Now.AddMinutes(tokenTime),// This point change the expired token time
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return new Response { Status = 200, Data = tokenHandler.WriteToken(token), Message = "Login Successful." };
        }

    }
}
