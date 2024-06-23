using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Quizz.Domain.Core.Dto;
using Quizz.Domain.Core.Interfaces;


namespace Quizz.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LevelController : ControllerBase
    {
        private readonly ICreateLevel createLevel;
        private readonly IUpdateLevel updateLevel;
        private readonly IGetlevel getlevel;
        private readonly IGetAllLevels getAllLevels;
        private readonly IDeleteLevel deleteLevel;

        public LevelController(ICreateLevel createLevel, IGetlevel getlevel, IUpdateLevel updateLevel, IDeleteLevel deleteLevel, IGetAllLevels getAllLevels)
        {
            this.createLevel = createLevel;
            this.updateLevel = updateLevel;
            this.deleteLevel = deleteLevel;
            this.getlevel = getlevel;
            this.getAllLevels = getAllLevels;
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await getAllLevels.Handle());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(await getlevel.Handle(id));
        }

        [Authorize(Roles = "admin")]
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] LevelRequest levelRequest)
        {
            return Ok(await createLevel.Handle(levelRequest));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] LevelRequest value)
        {
            return Ok(await updateLevel.Handle(value));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(LevelRequest levelRequest)
        {
            return Ok(await deleteLevel.Handle(levelRequest));
        }
    }
}
