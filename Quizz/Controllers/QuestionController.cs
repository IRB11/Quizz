
    using global::Quizz.Domain.Core.Dto;
    using global::Quizz.Domain.Core.Interfaces.Questions;
    using Microsoft.AspNetCore.Mvc;
    using System.Threading.Tasks;

    namespace Quizz.Controllers
    {
        [Route("api/[controller]")]
        [ApiController]
        public class QuestionController : ControllerBase
        {
            private readonly ICreateQuestion createQuestion;

            public QuestionController(ICreateQuestion createQuestion)
            {
                this.createQuestion = createQuestion;

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
            public async Task<IActionResult> Post([FromBody] QuestionRequest questionRequest)
            {
                return Ok(await createQuestion.Handle(questionRequest));
            }

            [HttpPut("{id}")]
            public async Task<IActionResult> Put(int id, [FromBody] QuestionRequest questionRequest)
            {
                return Ok();
            }

            [HttpDelete("{id}")]
            public async Task<IActionResult> Delete([FromBody] QuestionRequest questionRequest)
            {
                return Ok();
            }
        }
    }


