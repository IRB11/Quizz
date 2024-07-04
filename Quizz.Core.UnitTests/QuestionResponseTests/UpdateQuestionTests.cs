using NUnit.Framework;
using Quizz.Common.Interfaces;
using Quizz.Domain.Core.Dto;
using Quizz.Domain.Core.Entities;
using Quizz.Domain.Core.Interfaces.Questions;
using Quizz.Domain.Core.UseCases.Question;
using Quizz.Domain.Core.UseCases.Rules.QuestionRules;
using Quizz.Domain.Infrastructure.Data.Repositories;
using Quizz.Domain.Infrastructure.InMemory;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Quizz.Core.UnitTests
{
    public class UpdateQuestionTests
    {
        private IUpdateQuestion updateQuestion;
        private IQuestionRepository _questionRepository;
        private QuestionRequest question;
        List<ICheckQuestionRule<QuestionRequest>> _rules;

        [SetUp]
        public void SetUp()
        {
            _questionRepository = new InMemoryQuestionRepository();
            InitRules();
            updateQuestion = new UpdateQuestion(_questionRepository, _rules);
            question = GetQuestionRequest();
        }

        #region Init
        private void InitRules()
        {
            _rules = new List<ICheckQuestionRule<QuestionRequest>>();
            _rules.Add(new CheckIfOpenQuestionHasNoResponse());
            _rules.Add(new CheckIfQuestionExists(_questionRepository));
            _rules.Add(new CheckIfQuestionIsActive());
            _rules.Add(new CheckIfAtLeastOneResponseIsCorrect());
            _rules.Add(new CheckIfOpenQuestionHasNoResponse());
            _rules.Add(new CheckIfMultipleOrSingleChoiceQuestionHasTwoOrFourResponses());
            _rules.Add(new ValidQuestionTypeRule());
        }

        private QuestionRequest GetQuestionRequest()
        {
            return new QuestionRequest()
            {
                Id = 1,
                Content = "What is the capital of France?",
                Type = "MultipleChoice",
                IsValid = true,
                Order = 1,
                AdminId = 1,
                Response = new List<Response_Request>
                {
                    new Response_Request { Id = 1, Content = "Paris", isCorrect = true },
                    new Response_Request { Id = 2, Content = "London", isCorrect = false }
                },
                LevelId = 1,
                TechnologyId = 1,
            };
        }
        #endregion

        [Test]
        public async Task Should_Update_Question()
        {
            // Arrange
            question.Content = "What is the capital of Italy?";

            // Act
            var result = await updateQuestion.Handle(question);

            // Assert
            Assert.That(result.Content, Is.EqualTo("What is the capital of Italy?"));
            Assert.That(result.Id, Is.EqualTo(1));
        }

        [Test]
        public async Task Should_Return_Null_If_Question_Not_Found()
        {
            // Arrange
            question.Id = 99;

            // Act
            var result = await updateQuestion.Handle(question);

            // Assert
            Assert.That(result, Is.Null);
        }

        [Test]
        public async Task Should_Return_Question_If_OpenQuestion_Has_Responses()
        {
            // Arrange
            question.Type = "OpenQuestion";
            question.Response = new List<Response_Request>
            {
                new Response_Request { Id = 1, Content = "Rome", isCorrect = true }
            };

            // Act
            var result = await updateQuestion.Handle(question);

            // Assert
            Assert.That(result, Is.Null);
        }

        [Test]
        public async Task Should_Return_Error_If_MultipleChoice_Question_Has_Invalid_Response_Count()
        {
            // Arrange
            question.Type = "MultipleChoice";
            question.Response = new List<Response_Request>
            {
                new Response_Request { Id = 1, Content = "Rome", isCorrect = true }
            };

            // Act
            var result = await updateQuestion.Handle(question);

            // Assert
            Assert.That(result, Is.Null);
        }

        [Test]
        public async Task Should_Return_Error_If_SingleChoice_Question_Has_Invalid_Response_Count()
        {
            // Arrange
            question.Type = "SingleChoice";
            question.Response = new List<Response_Request>
            {
                new Response_Request { Id = 1, Content = "Rome", isCorrect = true }
            };

            // Act
            var result = await updateQuestion.Handle(question);

            // Assert
            Assert.That(result, Is.Null);
        }
    }
}