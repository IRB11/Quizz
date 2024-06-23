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
    public class GetLevelTest
    {
        private IGetlevel getLevel;
        private ILevelRepository levelRepository;
        private LevelRequest level;
        List<ICheckRuleLevel<LevelRequest>> rules;

        [SetUp]
        public void SetUp()
        {
            levelRepository = new InMemoryLevelRepository();
            InitRules();
            getLevel = new GetLevel(levelRepository, rules);
            level = GetLevelRequest();
        }
        #region Init
        private void InitRules()
        {
            rules = new List<ICheckRuleLevel<LevelRequest>>();
            rules.Add(new CheckAvailabilityOfLevelContent(levelRepository));
        }
        private LevelRequest GetLevelRequest()
        {
            return new LevelRequest()
            {
                Id = 1,
                Content = "Junior"
            };
        }
        #endregion
        [Test]
        public async Task Should_Read_Level_By_Id()
        {
            // Arrange
            var levelId = 1;

            // Act
            var result = await getLevel.Handle(levelId);

            // Assert
            Assert.That(result.Id, Is.EqualTo(1));
            Assert.That(result.Content, Is.EqualTo("Senior"));
        }
        [Test]
        public async Task Should_Return_Level_Not_Found_By_Id_When_Id_Not_Exist()
        {
            // Arrange
            level.Id = 99;

            // Act
            var result = await getLevel.Handle((int)level.Id);

            // Assert
            Assert.That(result, Is.Null);
        }
    }
}
