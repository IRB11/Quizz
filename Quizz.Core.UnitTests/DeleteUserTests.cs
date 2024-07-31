using NUnit.Framework;
using Quizz.Common.Interfaces;
using Quizz.Domain.Core.Dto;
using Quizz.Domain.Core.Dto.Enum;
using Quizz.Domain.Core.Interfaces.IUser;
using Quizz.Domain.Core.UseCases.Rules;
using Quizz.Domain.Core.UseCases.User;
using Quizz.Domain.Infrastructure.InMemory;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Quizz.Core.UnitTests
{
    public class DeleteUserTests
    {
        private IDeleteUser deleteUser;
        private IUserRepository userRepository;
        private UserRequest user;
        private UserRequest userToDelete;
        List<ICheckRuleUser<UserRequest>> rules;

        [SetUp]
        public void SetUp()
        {
            userRepository = new InMemoryUserRepository();
            InitRules();
            deleteUser = new DeleteUser(userRepository, rules);
            user = GetUserRequest();
            userToDelete = GetUserToDelete();
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
        private UserRequest GetUserToDelete()
        {
            return new UserRequest
            {
                EmailAddress = "email7@test.test",
                FirstName = "user",
                LastName = "delete",
                Id = 7,
                Password = "monpassP",
                Token = ""
            };
        }
        #endregion

        [Test]
        public async Task Should_Remove_User_If_Not_Used()
        {
            // Act
            var result = await deleteUser.Handle(userToDelete);
            var deletedLevel = await userRepository.EmailAlreadyExist((userToDelete.EmailAddress));

            // Assert
            Assert.That(result.Id.Equals(-1));
            Assert.That(deletedLevel, Is.False);

        }

        [Test]
        public async Task Should_Deactivate_User_If_Used()
        {
            //Arrange 
            user.Id = 1;
            // Act
            var result = await deleteUser.Handle(user);
            var deletedUser = await userRepository.GetById((int)user.Id);

            // Assert
            Assert.That(result.IsActive, Is.False);
            Assert.That(deletedUser.IsActive, Is.False);
        }
        [Test]
        public async Task Delete_ShouldReturnFalse_WhenUserNotFound()
        {
            // Arrange
            var request = new UserRequest { Id = 999 }; // Non-existent Id

            // Act
            var result = await userRepository.Delete(request);

            // Assert
            Assert.That(result, Is.False);
        }
    }
}
