
using global::Quizz.Domain.Core.Dto;
using global::Quizz.Domain.Core.Interfaces.Questions;
using Microsoft.AspNetCore.Mvc;

namespace Quizz.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuestionController : ControllerBase
    {
        private readonly ICreateQuestion createQuestion;
        private readonly IGetQuestionById getQuestionById;
        private readonly IGetAllQuestion getAllQuestion;
        private readonly IUpdateQuestion updateQuestion;
        private readonly IDeleteQuestion deleteQuestion;

        public QuestionController(
            ICreateQuestion createQuestion, 
            IGetQuestionById getQuestionById, 
            IGetAllQuestion getAllQuestion, 
            IUpdateQuestion updateQuestion, 
            IDeleteQuestion deleteQuestion
        )
        {
            this.createQuestion = createQuestion;
            this.getQuestionById = getQuestionById;
            this.getAllQuestion = getAllQuestion;
            this.updateQuestion = updateQuestion;
            this.deleteQuestion = deleteQuestion;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await getAllQuestion.Handle());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(await getQuestionById.Handle(id));
        }


        [HttpPost]
        public async Task<IActionResult> Post([FromBody] QuestionRequest questionRequest)
        {
            return Ok(await createQuestion.Handle(questionRequest));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] QuestionRequest questionRequest)
        {
            return Ok(await updateQuestion.Handle(questionRequest));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(QuestionRequest questionRequest)
        {
            return Ok(await deleteQuestion.Handle(questionRequest));
        }
    }
}


