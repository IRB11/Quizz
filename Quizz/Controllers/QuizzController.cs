using Microsoft.AspNetCore.Mvc;
using Quizz.Domain.Core.Dto;
using Quizz.Domain.Core.Interfaces.Questions;
using Quizz.Domain.Core.Interfaces.Quizz;

namespace Quizz.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuizzController : ControllerBase
    {
        private readonly IGenerateQuiz  generateQuiz;

        public QuizzController(
            IGenerateQuiz generateQuiz
        )
        {
            this.generateQuiz = generateQuiz;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            return Ok();
        }


        [HttpPost]
        public async Task<IActionResult> Post([FromBody] QuizRequest quizRequest)
        {
            return Ok(await generateQuiz.Handle(quizRequest));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] QuizRequest quizRequest)
        {
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(QuizRequest QuizRequest)
        {
            return Ok();
        }
    }
}
