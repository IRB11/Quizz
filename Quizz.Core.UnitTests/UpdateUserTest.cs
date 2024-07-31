using NUnit.Framework;
using Quizz.Common.Interfaces;
using Quizz.Domain.Core.Dto;
using Quizz.Domain.Core.Interfaces.IUser;
using Quizz.Domain.Core.UseCases.User;
using Quizz.Domain.Core.UseCases.Rules;
using Quizz.Domain.Infrastructure.InMemory;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Quizz.Core.UnitTests
{
    public class UpdateUserTest
    {
        private IUpdateUser updateUser;
        private IUserRepository userRepository;
        private UserRequest user;
        List<ICheckRuleUser<UserRequest>> rules;

        [SetUp]
        public void SetUp()
        {
            userRepository = new InMemoryUserRepository();
            InitRules();
            updateUser = new UpdateUser(userRepository, rules);
            user = GetUserRequest();
        }

        private void InitRules()
        {
            rules = new List<ICheckRuleUser<UserRequest>>();
            rules.Add(new CheckAvailabilityOfUserEmail(userRepository));
        }

        [Test]
        public async Task Should_Return_Updated_User_If_Succeed()
        {
            user.FirstName = "update";
            user.EmailAddress = "update@test.com";
            var result = await updateUser.Handle(user);

            Assert.That(result.EmailAddress, Is.EqualTo("update@test.com"));
            Assert.That(result.FirstName, Is.EqualTo("update"));
            Assert.That(result.Id, Is.EqualTo(1));
        }

        [Test]
        public async Task Should_Return_Updated_User_FirstName_If_Succeed()
        {
            user.FirstName = "update";

            var result = await updateUser.Handle(user);

            Assert.That(result.FirstName, Is.EqualTo("update"));
            Assert.That(result.Id, Is.EqualTo(1));
        }

        [Test]
        public async Task Should_Return_False_If_User_Email_Already_Exist()
        {

            UserResponse result = await updateUser.Handle(user);

            Assert.That(result, Is.Not.EqualTo("Junior@admin.cin"));
        }

        [Test]
        public async Task Should_Return_User_Not_Found_If_Id_Does_Not_Exist()
        {
            // Arrange
            user.Id = 99;
            user.EmailAddress = "update@test.com";
            // Act
            var result = await updateUser.Handle(user);

            // Assert
            Assert.That(result.FirstName, Is.EqualTo("Users not found."));
            Assert.That(result.Id, Is.EqualTo(-1));
        }

        private UserRequest GetUserRequest()
        {
            return new UserRequest()
            {
                Id = 1,
                FirstName = "paul",
                LastName = "adm",
                EmailAddress = "Junior@admin.cin",
                Password = "amdin",
                ConfirmPassword = "amdin",
                IsActive = true,
                PhoneNumber = "Test",
                Role = new() { Id = 1, Name = "Admin" },
                Token = ""
            };
        }
    }
}
