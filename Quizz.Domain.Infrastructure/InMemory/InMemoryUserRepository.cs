using Quizz.Common.Interfaces;
using Quizz.Domain.Core.Dto;
using Quizz.Domain.Core.Entities;
using Quizz.Domain.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quizz.Domain.Infrastructure.InMemory
{
    public class InMemoryUserRepository : IUserRepository
    {
        private List<User> users;
        public InMemoryUserRepository() 
        {
            users = GetUsers();
        }

        public Task<UserResponse> CreateUser(UserRequest createUserRequest)
        {
            throw new NotImplementedException();
        }

        public Task<bool> EmailIsNotAvailable(string email)
        {
            return Task.Run(() => users.Any(f => f.EmailAddress == email));
        }


        public Task<UserResponse> GetByEmailAndPassword(LoginRequest authenticateRequest)
        {
            var user = users.FirstOrDefault(
                u => u.EmailAddress == authenticateRequest.EmailAddress
                && u.Password == authenticateRequest.Password
            );

            if (user == null)
            {
                return Task.FromResult<UserResponse>(null);
            }

            return Task.FromResult(new UserResponse
            {
                FirstName = user.FirstName,
                LastName = user.LastName,
                EmailAddress = user.EmailAddress,
                Id = user.Id,
                Token = user.Token
            });
        }

        public Task<UserResponse> Login(UserRequest userRequest)
        {
            if (userRequest == null) throw new ArgumentNullException(nameof(userRequest));
            return null;
        }

        public void UpdateToken(int? id, string token)
        {
            var users = GetUsers();
            var user = users.FirstOrDefault(u => u.Id == id);

            if (user != null && token != null)
            {
                user.Token = token;
            }
        }

        private List<User> GetUsers()
        {
            return new List<User> {
            new User
            {
                EmailAddress = "Junior@admin.cin",
                FirstName = "paul",
                LastName = "adm",
                Id = 1,
                Password = "amdin",
                Token = ""
            },
            new User
            {
                EmailAddress = "Senior@admin.cin",
                FirstName = "jean",
                LastName = "test",
                Id = 1,
                Password = "test",
                Token = ""
            },            
            new User
            {
                EmailAddress = "email@test.test",
                FirstName = "john",
                LastName = "doe",
                Id = 1,
                Password = "monpassP",
                Token = ""
            }
            };
        }

        private List<UserRequest> GetUsersRequest()
        {
            return new List<UserRequest>
            {
                new UserRequest
                {
                    EmailAddress ="Junior@admin.cin",
                    Password ="amdin"
                },
            };
        }
    }
}
