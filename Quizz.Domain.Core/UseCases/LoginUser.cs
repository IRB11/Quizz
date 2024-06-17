using AutoMapper;
using Microsoft.AspNetCore.DataProtection.KeyManagement;
using Microsoft.IdentityModel.Tokens;
using Quizz.Common.Interfaces;
using Quizz.Domain.Core.Dto;
using Quizz.Domain.Core.Interfaces;
using Quizz.Domain.Core.Services;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Quizz.Domain.Core.UseCases
{
    public class LoginUser : ILoginUser
    {
        private readonly IEnumerable<ICheckRule<UserRequest>> rules;
        private readonly IUserRepository userRepository;
        private readonly IMapper mapper;
        private readonly JWTService jWTService;


        public LoginUser(IUserRepository userRepository, IMapper mapper, JWTService jWTService)
        {
            this.userRepository = userRepository;
            this.mapper = mapper;
            this.jWTService = jWTService;
        }

        public async Task<UserResponse> Handle(LoginRequest authenticateRequest)
        {
            var user = await userRepository.GetByEmailAndPassword(authenticateRequest);

            if (user == null) return null;


            user.Token = jWTService.GetToken(user);
            try
            {
                userRepository.UpdateToken(user.Id,user.Token);
            }
            catch (Exception e)
            {

                throw e;
            }

            var response = mapper.Map<UserResponse>(user);

            return response;
        }
    }
}
