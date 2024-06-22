using Quizz.Domain.Core.Dto;
using Quizz.Domain.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quizz.Domain.Core.Interfaces
{
    public interface IHashingPassword
    {
        public Task<bool> UserVerify(LoginRequest loginRequest);
        public string HashPassword(string password, byte[] salt);
        public byte[] GenerateSalt();
    }
}
