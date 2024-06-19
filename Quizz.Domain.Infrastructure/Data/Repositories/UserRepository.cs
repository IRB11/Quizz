using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Quizz.Domain.Core.Dto;
using Quizz.Domain.Core.Interfaces;
using Quizz.Domain.Infrastructure.Data.Entities;

namespace Quizz.Domain.Infrastructure.Data.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly Context context;
        private readonly IMapper mapper;

        public UserRepository(Context context, IMapper mapper) : base()
        {
            this.context = context;
            this.mapper = mapper;
        }
        public async Task<UserResponse> GetByEmailAndPassword(LoginRequest authenticateRequest)
        {
            if (authenticateRequest == null)
                throw new ArgumentNullException(nameof(authenticateRequest));

            if (string.IsNullOrEmpty(authenticateRequest.EmailAddress) || string.IsNullOrEmpty(authenticateRequest.Password))
                throw new ArgumentException("Email address and password must be provided.");

            var eFUser = await this.context.Users
                .AsNoTracking()
                .Include(u => u.Role) 
                .FirstOrDefaultAsync(e => e.EmailAddress == authenticateRequest.EmailAddress
                                          && e.Password == authenticateRequest.Password);

            if (eFUser == null)
                return null;

            UserResponse userResponse = mapper.Map<UserResponse>(eFUser);

            return userResponse;
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

            var user = new EFUser
            {
                LastName = createUserRequest.LastName,
                EmailAddress = createUserRequest.EmailAddress,
                Password = createUserRequest.Password,
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
