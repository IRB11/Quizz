

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Quizz.Domain.Core.Dto;
using Quizz.Domain.Core.Interfaces;
using System.Threading.Tasks;

namespace Quizz.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CandidateController : ControllerBase
    {
        private readonly ICreateCandidate createCandidate;
        private readonly IUpdateCandidate updateCandidate;
        private readonly IGetCandidateById getCandidateById;
        private readonly IGetAllCandidates getAllCandidates;
        private readonly IDeleteCandidate deleteCandidate;

        public CandidateController(ICreateCandidate createCandidate, IGetCandidateById getCandidateById, IUpdateCandidate updateCandidate, IDeleteCandidate deleteCandidate, IGetAllCandidates getAllCandidates)
        {
            this.createCandidate = createCandidate;
            this.updateCandidate = updateCandidate;
            this.deleteCandidate = deleteCandidate;
            this.getCandidateById = getCandidateById;
            this.getAllCandidates = getAllCandidates;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await getAllCandidates.Handle());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(await getCandidateById.Handle(id));
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CandidateRequest candidateRequest)
        {
            return Ok(await createCandidate.Handle(candidateRequest));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] CandidateRequest candidateRequest)
        {
            return Ok(await updateCandidate.Handle(candidateRequest));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(CandidateRequest candidateRequest)
        {
            return Ok(await deleteCandidate.Handle(candidateRequest));
        }
    }
}