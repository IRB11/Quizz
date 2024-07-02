using Microsoft.AspNetCore.Mvc;
using Quizz.Domain.Core.Dto;
using Quizz.Domain.Core.Interfaces;


namespace Quizz.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly ICreateUser createUser;
        private readonly IUpdateUser updateUser;
        private readonly IGetAllUsers getAllUsers;
        private readonly IGetUserById getUserById;
        private readonly IDeleteUser deleteUser;

        public UserController(ICreateUser user, IUpdateUser updateUser, IGetAllUsers getAllUsers, IGetUserById getUserById, IDeleteUser deleteUser)
        {
            this.createUser = user;
            this.updateUser = updateUser;
            this.getAllUsers = getAllUsers;
            this.getUserById = getUserById;
            this.deleteUser = deleteUser;
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await getAllUsers.Handle());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(await getUserById.Handle(id));
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] UserRequest userRequest)
        {
            return Ok(await createUser.Handle(userRequest));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] UserRequest userRequest)
        {
            return Ok(updateUser.Handle(userRequest));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(UserRequest userRequest)
        {
            return Ok(await deleteUser.Handle(userRequest));
        }
    }
}
