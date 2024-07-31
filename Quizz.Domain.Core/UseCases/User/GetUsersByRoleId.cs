using Quizz.Domain.Core.Dto;
using Quizz.Domain.Core.Interfaces;
using Quizz.Domain.Core.Interfaces.IUser;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quizz.Domain.Core.UseCases.User
{
    public class GetUsersByRoleId : IGetUsersByRoleId
    {
        private readonly IUserRepository userRepository;
        public GetUsersByRoleId( IUserRepository userRepository)
        {
           this.userRepository = userRepository;
        }

        public Task<List<UserResponse>> Handle(int id)
        {
            return userRepository.GetUsersByRolesId(id);
        }
    }
}
