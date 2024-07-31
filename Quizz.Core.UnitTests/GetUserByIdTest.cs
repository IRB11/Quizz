using NUnit.Framework;
using Quizz.Common.Interfaces;
using Quizz.Domain.Core.Dto;
using Quizz.Domain.Core.Interfaces.IUser;
using Quizz.Domain.Core.UseCases.User;
using Quizz.Domain.Infrastructure.InMemory;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Quizz.Core.UnitTests
{
    public class GetUserByIdTest
    {
        IGetUserById getUserById;
        UserRequest user;
        private IUserRepository _userRepository;
        private List<ICheckRuleUser<UserRequest>> rules;


        [SetUp]
        public void SetUp()
        {
            _userRepository = new InMemoryUserRepository();
            InitRules();
            getUserById = new GetUserById(_userRepository, rules);
            user = GetUserRequest();
        }

        private UserRequest GetUserRequest()
        {
            return new()
            {
                Id = 1,
            };
        }

        private void InitRules()
        {
            rules = new List<ICheckRuleUser<UserRequest>>();
        }

        [Test]
        public async Task Should_Return_User_By_Id()
        {
            // Arrange
            var levelId = 1;

            // Act
            var result = await getUserById.Handle(levelId);

            // Assert
            Assert.That(result.Id.Equals(1));
            Assert.That(result.FirstName.Equals("paul"));
            Assert.That(result.LastName.Equals("adm"));
            Assert.That(result.EmailAddress.Equals("Junior@admin.cin"));
        }
        [Test]
        public async Task Should_Return_Level_Not_Found_By_Id_When_Id_Not_Exist()
        {
            // Arrange
            user.Id = 99;

            // Act
            var result = await getUserById.Handle((int)user.Id);

            // Assert
            Assert.That(result, Is.Null);
        }
    }
}
