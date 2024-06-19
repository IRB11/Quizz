using Microsoft.AspNetCore.Mvc;
using Quizz.Domain.Core.Dto;
using Quizz.Domain.Core.Interfaces;
using Quizz.Domain.Core.UseCases;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace Quizz.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly ILoginUser LoginUser;

        public LoginController(ILoginUser loginUser)
        {
            this.LoginUser = loginUser;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] LoginRequest authenticateRequest)
        {
            return Ok(await LoginUser.Handle(authenticateRequest));
        }

    }
}
