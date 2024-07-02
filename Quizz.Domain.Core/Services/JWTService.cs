using AutoMapper;
using Microsoft.IdentityModel.Tokens;
using Quizz.Domain.Core.Dto;
using Quizz.Domain.Core.Interfaces;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Quizz.Domain.Core.Services
{
    public class JWTService : IJWTService
    {
        private readonly IMapper _mapper;
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
