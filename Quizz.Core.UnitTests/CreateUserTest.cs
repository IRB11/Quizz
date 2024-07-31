using NUnit.Framework;
using Quizz.Common.Interfaces;
using Quizz.Domain.Core.Dto;
using Quizz.Domain.Core.Dto.Enum;
using Quizz.Domain.Core.Interfaces.IUser;
using Quizz.Domain.Core.Services;
using Quizz.Domain.Core.UseCases;
using Quizz.Domain.Core.UseCases.Rules;
using Quizz.Domain.Infrastructure.InMemory;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Quizz.Core.UnitTests
{
    public class CreateUserTest
    {
        private ICreateUser createUser;
        private IUserRepository userRepository;
        private JWTService jWTService;
        private UserRequest user;
        List<ICheckRuleUser<UserRequest>> rules;

        [SetUp]
        public void SetUp()
        {
            userRepository = new InMemoryUserRepository();
            jWTService = new JWTService(jwtSecret: "jhjqhzjhdqoz356z2d1q2123d23q1d.36565656");
            InitRules();
            createUser = new CreateUser(userRepository, jWTService, rules);
            user = GetUserRequest();
        }


        #region Init
        private void InitRules()
        {
            rules = new List<ICheckRuleUser<UserRequest>>();
            rules.Add(new CheckAvailabilityOfUserEmail(userRepository));
        }
        private UserRequest GetUserRequest()
        {
            return new UserRequest()
            {
                Id = 1,
                FirstName = "John",
                LastName = "Doe",
                EmailAddress = "john.doe@example.com",
                Password = "password",
                ConfirmPassword = "password",
                PhoneNumber = "1234567890",
                IsActive = true,
                Role = new RoleRequest() { Id = (int)RoleEnum.Admin, Name = "Admin" },
            };
        }
        private UserRequest GetExistentUserRequest()
        {
            return new UserRequest()
            {
                Id = 1,
                EmailAddress = "Junior@admin.cin",
                FirstName = "paul",
                LastName = "adm",
                ConfirmPassword = "amdin",
                PhoneNumber = "1234567890",
                IsActive = true,
                Password = "amdin",
                Token = "",
                Role = new RoleRequest() { Id = (int)RoleEnum.Admin, Name = "Admin" },
            };
        }

        #endregion

        [Test]
        public async Task CreateUserAsync_WhenUserDoesNotExist_ShouldReturnUser()
        {
            // Act
            var result = await userRepository.Add(user);

            // Assert
            Assert.That(result, Is.Not.Null);
            Assert.That(result.EmailAddress, Is.EqualTo(user.EmailAddress));
        }

        [Test]
        public async Task CreateUserAsync_WhenUserExists_ShouldReturnNull()
        {

            await createUser.Handle(user);

            // Act
            var result = await createUser.Handle(user);

            // Assert
            Assert.That(result, Is.Null);
        }

    }
}
