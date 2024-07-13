
using global::Quizz.Domain.Core.Dto;
using global::Quizz.Domain.Core.Interfaces.Questions;
using Microsoft.AspNetCore.Mvc;
using Quizz.Domain.Infrastructure.Data.Repositories;

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
        private readonly IGetListQuestionIdsByQuizzId getListQuestionIdsByQuizzId;
        private readonly ISaveCandidateResponse saveCandidateResponse;

        public QuestionController(
            ICreateQuestion createQuestion, 
            IGetQuestionById getQuestionById, 
            IGetAllQuestion getAllQuestion, 
            IUpdateQuestion updateQuestion, 
            IDeleteQuestion deleteQuestion,
            IGetListQuestionIdsByQuizzId getListQuestionByQuizzId,
            ISaveCandidateResponse saveCandidateResponse 
        )
        {
            this.createQuestion = createQuestion;
            this.getQuestionById = getQuestionById;
            this.getAllQuestion = getAllQuestion;
            this.updateQuestion = updateQuestion;
            this.deleteQuestion = deleteQuestion;
            this.getListQuestionIdsByQuizzId = getListQuestionByQuizzId;
            this.saveCandidateResponse = saveCandidateResponse;
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

        [HttpGet("questions/{id}")]
        public async Task<IActionResult> GetListIds(int id)
        {
            return Ok(await getListQuestionIdsByQuizzId.Handle(id));
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] QuestionRequest questionRequest)
        {
            return Ok(await createQuestion.Handle(questionRequest));
        }

        [HttpPost("Save")]
        public async Task<IActionResult> Post([FromBody] List<CandidateResponse_Request> candidateResponses_Request)
        {
            return Ok(await saveCandidateResponse.Handle(candidateResponses_Request));
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


