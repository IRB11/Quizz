using Quizz.Domain.Core.Entities;
using Quizz.Domain.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quizz.Domain.Core.Services
{
    public class HashingPassword : IHashingPassword
    {
        public Task<string> CreateUser(User create)
        {
            throw new NotImplementedException();
        }

        public Task<string> UserVerify(User verify)
        {
            throw new NotImplementedException();
        }
    }
}
