using Microsoft.AspNetCore.Mvc;
using Quizz.Domain.Core.Dto;
using Quizz.Domain.Core.Interfaces.IUser;
using Quizz.Domain.Core.UseCases.User;


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
        private readonly IGetUsersByRoleId getUsersByRoleId;

        public UserController(ICreateUser user, IUpdateUser updateUser, IGetAllUsers getAllUsers, IGetUserById getUserById, IDeleteUser deleteUser, IGetUsersByRoleId getUsersByRoleId)
        {
            this.createUser = user;
            this.updateUser = updateUser;
            this.getAllUsers = getAllUsers;
            this.getUserById = getUserById;
            this.deleteUser = deleteUser;
            this.getUsersByRoleId = getUsersByRoleId;

        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await getAllUsers.Handle());
        }

        [HttpGet("Role/{id}")]
        public async Task<IActionResult> GetUsersByRole(int id)
        {
            return Ok(await getUsersByRoleId.Handle(id));
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
