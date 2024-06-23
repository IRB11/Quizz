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
    public class DeleteLevelTest
    {
        private IDeleteLevel deleteLevel;
        private ILevelRepository levelRepository;
        private LevelRequest level;
        List<ICheckRuleLevel<LevelRequest>> rules;

        [SetUp]
        public void SetUp()
        {
            levelRepository = new InMemoryLevelRepository();
            InitRules();
            deleteLevel = new DeleteLevel(levelRepository, rules);
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
                Id = 2,
                Content = "To Delete"
            };
        }
        #endregion

        [Test]
        public async Task Should_Remove_Level_If_Not_Used()
        {
            // Act
            var result = await deleteLevel.Handle(level);
            var deletedLevel = await levelRepository.IdIsNotAvailable((level.Id));

            // Assert
            Assert.That(result.Id.Equals(-1));
            Assert.That(deletedLevel, Is.True);

        }

        [Test]
        public async Task Should_Deactivate_Level_If_Used()
        {
            //Arrange 
            level.Id = 1;
            // Act
            var result = await deleteLevel.Handle(level);
            var deletedLevel = await levelRepository.GetLevelById((int)level.Id);

            // Assert
            Assert.That(result.IsActive, Is.False);
            Assert.That(deletedLevel.IsActive, Is.False);
        }
    }
}
