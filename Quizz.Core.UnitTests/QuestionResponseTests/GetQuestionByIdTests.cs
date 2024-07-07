using NUnit.Framework;
using Quizz.Domain.Core.Interfaces.Questions;
using Quizz.Domain.Core.UseCases.Question;
using Quizz.Domain.Infrastructure.InMemory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quizz.Core.UnitTests.QuestionResponseTests
{
    public class GetQuestionByIdTests
    {
        private IGetQuestionById _getQuestionById;
        private IQuestionRepository _questionRepository;

        [SetUp]
        public void SetUp()
        {
            _questionRepository = new InMemoryQuestionRepository();
            _getQuestionById = new GetQuestionById(_questionRepository);
        }

        [Test]
        public async Task Should_Read_Question_By_Id()
        {
            // Arrange
            var questionId = 1;

            // Act
            var result = await _getQuestionById.Handle(questionId);

            // Assert
            Assert.That(result, Is.Not.Null);
            Assert.That(result.Id, Is.EqualTo(1));
            Assert.That(result.Content, Is.EqualTo("What is the capital of France?"));
            Assert.That(result.Type, Is.EqualTo("MultipleChoice"));
            Assert.That(result.Response.Count, Is.EqualTo(2));
            Assert.That(result.Response.ElementAt(0).Content, Is.EqualTo("Paris"));
            Assert.That(result.Response.ElementAt(0).isCorrect, Is.True);
        }

        [Test]
        public async Task Should_Return_Null_If_Question_Id_Not_Exist()
        {
            // Arrange
            var questionId = 99;

            // Act
            var result = await _getQuestionById.Handle(questionId);

            // Assert
            Assert.That(result, Is.Null);
        }
    }
}

