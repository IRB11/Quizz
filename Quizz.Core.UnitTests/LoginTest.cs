using AutoMapper;
using NUnit.Framework;
using Quizz.Common.Interfaces;
using Quizz.Controllers;
using Quizz.Domain.Core.Dto;
using Quizz.Domain.Core.Interfaces;
using Quizz.Domain.Core.Services;
using Quizz.Domain.Core.UseCases;
using Quizz.Domain.Core.UseCases.Rules;
using Quizz.Domain.Infrastructure.Data.Repositories;
using Quizz.Domain.Infrastructure.InMemory;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Quizz.Core.UnitTests
{
    public class LoginTest 
    {
        private ILoginUser loginUser;
        private IUserRepository UserRepository;
        private JWTService JWTService;
        IMapper mapper;
        private LoginRequest user;
        List<ICheckRule<UserRequest>> rules;


        [SetUp]
        public void SetUp()
        {
            UserRepository = new InMemoryUserRepository();

            InitRules();
            loginUser = new LoginUser(UserRepository,JWTService);
            user = GetLoginRequest();
        }
        private void InitRules()
        {

        }

        [Test]
        public async Task Should_Return_Null_If_Email_Not_Found()
        {
            var loginRequest = GetLoginRequest();
            loginRequest.EmailAddress = "nonexistentemail@example.com"; // Adresse e-mail non trouvée

            var response = await UserRepository.GetByEmailAndPassword(loginRequest);

            Assert.That(response, Is.Null);
        }
        private LoginRequest GetLoginRequest()
        {
            return new LoginRequest()
            {
                EmailAddress ="email@test.test",
                Password ="monpassP"
            };
        }
    }

}
