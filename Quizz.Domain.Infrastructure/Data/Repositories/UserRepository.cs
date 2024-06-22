using AutoMapper;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using Quizz.Domain.Core.Dto;
using Quizz.Domain.Core.Interfaces;
using Quizz.Domain.Infrastructure.Data.Entities;
using System.Data.SqlTypes;
using System.Security.Cryptography;
using System.Text;

namespace Quizz.Domain.Infrastructure.Data.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly Context context;
        private readonly IMapper mapper;
        private readonly IHashingPassword hashingPassword;

        public UserRepository(Context context, IMapper mapper , IHashingPassword hashingPassword) : base()
        {
            this.context = context;
            this.mapper = mapper;
            this.hashingPassword = hashingPassword; 
        }
        public async Task<UserResponse> GetByEmailAndPassword(LoginRequest LoginRequest)
        {
            if (LoginRequest == null)
                throw new ArgumentNullException(nameof(LoginRequest));

            if (string.IsNullOrEmpty(LoginRequest.EmailAddress) || string.IsNullOrEmpty(LoginRequest.Password))
                throw new ArgumentException("Email address and password must be provided.");

            EFUser eFUser;

            if (hashingPassword.UserVerify(LoginRequest).Result == true)
            {
                eFUser = await this.context.Users
                    .AsNoTracking()
                    .Include(u => u.Role)
                    .FirstOrDefaultAsync(e => e.EmailAddress == LoginRequest.EmailAddress);
                UserResponse userResponse = mapper.Map<UserResponse>(eFUser);

                return userResponse;
            }
            else throw new ArgumentException("Email address or Password are invalid"); ;

        }

        public Task<bool> ContentIsNotAvailable(string Content)
        {
            return Task.Run(() => context.Levels.Any(f => f.Content.ToLower().Equals(Content.ToLower())));
        }

        public async Task<UserResponse> CreateUser(UserRequest createUserRequest)
        {
            if (await EmailIsNotAvailable(createUserRequest.EmailAddress))
            {
                return null;
            }

            var role = await context.Roles.FirstOrDefaultAsync(r => r.Id == createUserRequest.Role.Id);
            if (role == null)
            {
                return null;
            }
            string password = createUserRequest.ConfirmPassword;

            byte[] saltBytes = hashingPassword.GenerateSalt();
            string hashedPassword = hashingPassword.HashPassword(password, saltBytes);
            string base64Salt = Convert.ToBase64String(saltBytes);

            byte[] retrievedSaltBytes = Convert.FromBase64String(base64Salt);

            var user = new EFUser
            {
                FirstName = createUserRequest.FirstName,
                LastName = createUserRequest.LastName,
                EmailAddress = createUserRequest.EmailAddress,
                PhoneNumber = createUserRequest.PhoneNumber,
                IsActive = createUserRequest.IsActive,
                Password = base64Salt,
                ConfirmPassword = hashedPassword,    
                Salt = retrievedSaltBytes,
                Role = role
            };

            context.Users.Add(user);
            await context.SaveChangesAsync();

            var userResponse = mapper.Map<UserResponse>(user);
            return userResponse;
        }

        public UserResponse GetUserById(int id)
        { 
            var user = context.Users.FirstOrDefault(r => r.Id == id);
            if (user == null)
            {
                return null;
            }
            return mapper.Map<UserResponse>(user); 
        }

        public void UpdateToken(int? id, string token)
        {
            var user = context.Users.FirstOrDefault(r => r.Id == id);
            if (user != null && token != null)
            {
               user.Token = token;
               
                try
                {
                    context.Users.Update(user);
                    context.SaveChanges();
                }
                catch (Exception)
                {

                    throw;
                }
            }
        }
       
        public async Task<bool> EmailIsNotAvailable(string email)
        {
            return await context.Users.AnyAsync(e => e.EmailAddress == email);
        }
    }
}
