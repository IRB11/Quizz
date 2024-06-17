using AutoMapper;
using Microsoft.IdentityModel.Tokens;
using Quizz.Domain.Core.Dto;
using Quizz.Domain.Core.Interfaces;
using Quizz.Domain.Core.Services;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Quizz.Domain.Core.UseCases
{
    public class CreateUser : ICreateUser
    {
        private readonly IUserRepository userRepository;
        private readonly IMapper mapper;
        private readonly JWTService jwtService;

        public CreateUser(IUserRepository userRepository, IMapper mapper, JWTService jWTService)
        {
            this.userRepository = userRepository;
            this.mapper = mapper;
            this.jwtService = jWTService;   
        }

        public async Task<UserResponse> Handle(UserRequest createUserRequest)
        {
            var response = await userRepository.CreateUser(createUserRequest);

            if (response == null)
            {
                return null;
            }

            response.Token = jwtService.GetToken(response);

            return response;
        }
    }
}
