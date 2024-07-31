using NUnit.Framework;
using Quizz.Common.Interfaces;
using Quizz.Domain.Core.Dto;
using Quizz.Domain.Core.Interfaces.IUser;
using Quizz.Domain.Core.UseCases;
using Quizz.Domain.Core.UseCases.Rules;
using Quizz.Domain.Infrastructure.InMemory;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Quizz.Core.UnitTests
{
    public class GetAllUsersTest
    {
        private IUserRepository userRepository;
        private IGetAllUsers getAllUsers;
        private UserRequest userRequest;
        List<ICheckRuleUser<UserRequest>> rules;

        [SetUp]
        public void SetUp()
        {
            userRepository = new InMemoryUserRepository();
            InitRules();
            getAllUsers = new GetAllUsers(userRepository, rules);
        }

        #region Init
        private void InitRules()
        {
            rules = new List<ICheckRuleUser<UserRequest>>();
            rules.Add(new CheckAvailabilityOfUserEmail(userRepository));
        }

        #endregion
        [Test]
        public async Task Should_Return_All_Users()
        {

            var users = await getAllUsers.Handle();

            Assert.That(users.Count.Equals(7));

            Assert.That(users[0].Id.Equals(1));
            Assert.That(users[0].FirstName.Equals("paul"));
            Assert.That(users[0].LastName.Equals("adm"));
            Assert.That(users[0].EmailAddress.Equals("Junior@admin.cin"));

            Assert.That(users[1].Id.Equals(2));
            Assert.That(users[1].FirstName.Equals("jean"));
            Assert.That(users[1].LastName.Equals("test"));
            Assert.That(users[1].EmailAddress.Equals("Senior@admin.cin"));

            Assert.That(users[2].Id.Equals(3));
            Assert.That(users[2].FirstName.Equals("john"));
            Assert.That(users[2].LastName.Equals("doe"));
            Assert.That(users[2].EmailAddress.Equals("email3@test.test"));

            Assert.That(users[3].Id.Equals(4));
            Assert.That(users[3].FirstName.Equals("john"));
            Assert.That(users[3].LastName.Equals("doe"));
            Assert.That(users[3].EmailAddress.Equals("email4@test.test"));

            Assert.That(users[4].Id.Equals(5));
            Assert.That(users[4].FirstName.Equals("john"));
            Assert.That(users[4].LastName.Equals("doe"));
            Assert.That(users[4].EmailAddress.Equals("email5@test.test"));

            Assert.That(users[5].Id.Equals(6));
            Assert.That(users[5].FirstName.Equals("john"));
            Assert.That(users[5].LastName.Equals("doe"));
            Assert.That(users[5].EmailAddress.Equals("email6@test.test"));

            Assert.That(users[6].Id.Equals(7));
            Assert.That(users[6].FirstName.Equals("user"));
            Assert.That(users[6].LastName.Equals("delete"));
            Assert.That(users[6].EmailAddress.Equals("email7@test.test"));
        }
    }
}

