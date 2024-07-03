using NUnit.Framework;
using Quizz.Common.Interfaces;
using Quizz.Domain.Core.Dto;
using Quizz.Domain.Core.Interfaces.Questions;
using Quizz.Domain.Core.UseCases.Question;
using Quizz.Domain.Core.UseCases.Rules.QuestionRules;
using Quizz.Domain.Infrastructure.Data.Repositories;
using Quizz.Domain.Infrastructure.InMemory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quizz.Core.UnitTests.QuestionResponseTests
{
    public class GetAllQuestionsTests
    {
        private IGetAllQuestion getAllQuestions;
        private IQuestionRepository _questionRepository;
        private QuestionRequest questionRequest;
        private List<ICheckQuestionRule<QuestionRequest>> _rules;

        [SetUp]
        public void SetUp()
        {
            _questionRepository = new InMemoryQuestionRepository();
            InitRules();
            getAllQuestions = new GetAllQuestion(_questionRepository, _rules);
        }

        #region Init
        private void InitRules()
        {
            _rules = new List<ICheckQuestionRule<QuestionRequest>>();
            _rules.Add(new CheckIfQuestionExists(_questionRepository));
            _rules.Add(new CheckIfQuestionIsActive());
            _rules.Add(new CheckIfAtLeastOneResponseIsCorrect());
            _rules.Add(new CheckIfOpenQuestionHasNoResponse());
            _rules.Add(new CheckIfMultipleOrSingleChoiceQuestionHasTwoOrFourResponses());
            _rules.Add(new ValidQuestionTypeRule());
        }

        #endregion
        [Test]
        public async Task Should_Return_All_Questions()
        {
            // Act
            var result = await getAllQuestions.Handle();

            // Assert
            Assert.That(result, Is.Not.Null);
            Assert.That(result.Count, Is.EqualTo(3));  // Adjust based on initial data in InMemoryQuestionRepository
            Assert.That(result.Any(q => q.Content == "What is the capital of France?"), Is.True);
            Assert.That(result.Any(q => q.Content == "What is 2 + 2?"), Is.True);
        }

        [Test]
        public async Task Should_Return_Empty_List_When_No_Questions_Are_Present()
        {
            // Arrange
            // Clear the questions
            (_questionRepository as InMemoryQuestionRepository).ClearQuestions();

            // Act
            var result = await getAllQuestions.Handle();

            // Assert
            Assert.That(result, Is.Not.Null);
            Assert.That(result.Count, Is.EqualTo(0));
        }

        [Test]
        public async Task Should_Return_Questions_With_All_Properties_Set()
        {
            // Act
            var result = await getAllQuestions.Handle();

            // Assert
            Assert.That(result, Is.Not.Null);
            Assert.That(result, Has.Exactly(3).Items);  // Ensure there are exactly 2 questions
            Assert.That(result.All(q => q.Response != null), Is.True);  // All questions should have responses
            Assert.That(result.All(q => q.Level != null), Is.True);  // All questions should have a level
            Assert.That(result.All(q => q.Technology != null), Is.True);  // All questions should have a technology
        }

        [Test]
        public async Task Should_Return_Questions_With_Correct_Responses()
        {
            // Act
            var result = await getAllQuestions.Handle();

            // Assert
            Assert.That(result, Is.Not.Null);
            Assert.That(result, Has.Exactly(3).Items);
            foreach (var question in result)
            {
                if (question.Type != "OpenQuestion")
                {
                    Assert.That(question.Response.Any(r => r.isCorrect), Is.True, $"Question with Id '{question.Id}' and content '{question.Content}' does not have any correct response.");
                }
            }
        }

        [Test]
        public async Task Should_Contain_Level_And_Technology_For_Each_Question()
        {
            // Act
            var result = await getAllQuestions.Handle();

            // Assert
            Assert.That(result, Is.Not.Null);
            Assert.That(result.All(q => q.Level != null), Is.True);  // Each question must have a level
            Assert.That(result.All(q => q.Technology != null), Is.True);  // Each question must have a technology
        }

        [Test]
        public async Task Should_Return_Questions_Ordered_By_Order_Property()
        {
            // Act
            var result = await getAllQuestions.Handle();

            // Assert
            Assert.That(result, Is.Not.Null);
            Assert.That(result, Is.Ordered.By(nameof(QuestionResponse.Order)));  // Ensure the list is ordered by the Order property
        }
    }
}
