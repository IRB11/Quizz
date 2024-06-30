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
    public class CreateLevelTest
    {
        private ICreateLevel createLevel;
        private ILevelRepository levelRepository;
        private LevelRequest level;
        List<ICheckRuleLevel<LevelRequest>> rules;

        [SetUp]
        public void SetUp()
        {
            levelRepository = new InMemoryLevelRepository();
            InitRules();
            createLevel = new CreateLevel(levelRepository, rules);
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
        public async Task CreateLevel_WhenCalled_ReturnNull_IfLevelExist()
        {

            LevelResponse result = await createLevel.Handle(level);

            Assert.That(result, Is.Null);
        }
        [Test]
        public async Task CreateLevel_WhenCalled_AddLevel_ReturnLevel()
        {
            level.Content = "Advanced";

            LevelResponse result = await createLevel.Handle(level);

            Assert.That(result.Content.Equals(level.Content));
        }
    }
}
