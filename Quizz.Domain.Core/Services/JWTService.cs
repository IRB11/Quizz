using AutoMapper;
using Microsoft.IdentityModel.Tokens;
using Quizz.Domain.Core.Dto;
using Quizz.Domain.Core.Entities;
using Quizz.Domain.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Quizz.Domain.Core.Services
{
    public class JWTService
    {
        private readonly IMapper _mapper;
        private readonly string _key;
        private readonly string _jwtSecret;

        public JWTService(string jwtSecret)
        {
            _jwtSecret = jwtSecret;
        }

        public string GetSecret() => _jwtSecret;

        public JWTService(IMapper mapper)
        {
            this._mapper = mapper;
        }
        public string GetToken(UserResponse user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_jwtSecret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                new Claim(ClaimTypes.Name , user.LastName),
                new Claim(ClaimTypes.Role, user.Role.Name)
            }),
                Expires = DateTime.UtcNow.AddDays(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            var tokenString = tokenHandler.WriteToken(token);
            return tokenString;
       }

    }
}
