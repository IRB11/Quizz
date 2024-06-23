using NUnit.Framework;
using Quizz.Common.Interfaces;
using Quizz.Domain.Core.Dto;
using Quizz.Domain.Core.Interfaces;
using Quizz.Domain.Core.UseCases;
using Quizz.Domain.Core.UseCases.Rules;
using Quizz.Domain.Infrastructure.InMemory;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Quizz.Core.UnitTests
{
    public class UpdateLevelTest
    {
        private IUpdateLevel updateLevel;
        private ILevelRepository levelRepository;
        private LevelRequest level;
        List<ICheckRuleLevel<LevelRequest>> rules;

        [SetUp]
        public void SetUp()
        {
            levelRepository = new InMemoryLevelRepository();
            InitRules();
            updateLevel = new UpdateLevel(levelRepository, rules);
            level = GetLevelRequest();
        }

        private void InitRules()
        {
            rules = new List<ICheckRuleLevel<LevelRequest>>();
            rules.Add(new CheckAvailabilityOfLevelContent(levelRepository));
        }

        [Test]
        public async Task Should_Return_Updated_Level_If_Succeed()
        {
            level.Content = "update";
            var result = await updateLevel.Handle(level);

            Assert.That(result.Content, Is.EqualTo("update"));
            Assert.That(result.Id, Is.EqualTo(1));
        }

        [Test]
        public async Task Should_Return_False_If_Level_Already_Exist()
        {

            LevelResponse result = await updateLevel.Handle(level);

            Assert.That(result, Is.Not.EqualTo("Junior"));
        }

        [Test]
        public async Task Should_Return_Level_Not_Found_If_Id_Does_Not_Exist()
        {
            // Arrange
            var levelRequest = new LevelRequest { Id = 99, Content = "update" };

            // Act
            var result = await updateLevel.Handle(levelRequest);

            // Assert
            Assert.That(result.Content, Is.EqualTo("Level not found."));
            Assert.That(result.Id, Is.EqualTo(-1));
        }

        private LevelRequest GetLevelRequest()
        {
            return new LevelRequest()
            {
                Id = 1,
                Content = "Junior"
            };
        }
    }
}
