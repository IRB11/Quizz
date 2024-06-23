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
    public class GetAllLevelsTest
    {
        private ILevelRepository levelRepository;
        private IGetAllLevels getAllLevels;

        private LevelRequest level;
        List<ICheckRuleLevel<LevelRequest>> rules;

        [SetUp]
        public void SetUp()
        {
            levelRepository = new InMemoryLevelRepository();
            InitRules();
            getAllLevels = new GetAllLevels(levelRepository, rules);
        }
        #region Init
        private void InitRules()
        {
            rules = new List<ICheckRuleLevel<LevelRequest>>();
            rules.Add(new CheckAvailabilityOfLevelContent(levelRepository));
        }

        #endregion

        [Test]
        public async Task Should_Return_All_Levels()
        {

            var result = await getAllLevels.Handle();

            Assert.That(result, Is.Not.Null);
            Assert.That(result.Count.Equals(3));
            Assert.That(result[0].Id.Equals(0));
            Assert.That(result[0].Content.Equals("Junior"));
            Assert.That(result[1].Id.Equals(1));
            Assert.That(result[1].Content.Equals("Senior"));
            Assert.That(result[2].Id.Equals(2));
            Assert.That(result[2].Content.Equals("To Delete"));
        }

    }




}
