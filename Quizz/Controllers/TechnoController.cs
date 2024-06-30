using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Quizz.Domain.Core.Dto;
using Quizz.Domain.Core.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Quizz.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TechnoController : ControllerBase
    {
        private readonly ICreateTechno _createTechno;
        private readonly IGetAllTechnos _getAllTechnos;
        private readonly ITechnoRepository _technoRepository;
        private readonly IGetTechnoById _getTechnoById;
        private readonly IDeleteTechno _deleteTechno;


        public TechnoController(ICreateTechno createTechno,IGetAllTechnos getAllTechnos,
            ITechnoRepository technoRepository, IGetTechnoById getTechnoById,
            IDeleteTechno deleteTechno)
        {
            _createTechno = createTechno;
            _getAllTechnos = getAllTechnos;
            _technoRepository = technoRepository;
            _getTechnoById = getTechnoById;
            _deleteTechno = deleteTechno;
        }

        // GET: api/techno
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            //var technos = await _technoRepository.GetAll();
            return Ok(await _getAllTechnos.Handle());
        }

        // GET: api/techno/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var techno = await _technoRepository.GetTechnoById(id);
            if (techno == null)
            {
                return NotFound();
            }
            return Ok(techno);
        }

        // POST: api/techno

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] TechnologiesRequest request)
        {

            return Ok(await _createTechno.Handle(request)); 
        }

        // PUT: api/techno/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] TechnologiesRequest request)
        {
            // Implement the update logic here
            return NoContent();
        }

        // DELETE: api/techno/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(TechnologiesRequest technologiesRequest)
        {
            // Implement the delete logic here
            return Ok(await _deleteTechno.Handle(technologiesRequest));
        }
    }
}
