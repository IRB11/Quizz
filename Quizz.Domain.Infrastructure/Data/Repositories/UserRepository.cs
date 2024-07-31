using AutoMapper;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using Quizz.Domain.Core.Dto;
using Quizz.Domain.Core.Entities;
using Quizz.Domain.Core.Interfaces;
using Quizz.Domain.Core.Interfaces.IUser;
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
                eFUser = await context.Users
                    .AsNoTracking()
                    .Include(u => u.Role)
                    .FirstOrDefaultAsync(e => e.EmailAddress == LoginRequest.EmailAddress);
                UserResponse userResponse = mapper.Map<UserResponse>(eFUser);

                return userResponse;
            }
            else throw new ArgumentException("Email address or Password are invalid"); ;

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
       
        public async Task<bool> EmailAlreadyExist(string email)
        {
            return await context.Users.AnyAsync(e => e.EmailAddress == email);
        }

        public async Task<UserResponse> Add(UserRequest request)
        {
            if (await EmailAlreadyExist(request.EmailAddress))
            {
                return null;
            }

            var role = await context.Roles.FirstOrDefaultAsync(r => r.Id == request.Role.Id);
            if (role == null)
            {
                return null;
            }
            string password = request.ConfirmPassword;

            byte[] saltBytes = hashingPassword.GenerateSalt();
            string hashedPassword = hashingPassword.HashPassword(password, saltBytes);
            string base64Salt = Convert.ToBase64String(saltBytes);

            byte[] retrievedSaltBytes = Convert.FromBase64String(base64Salt);

            var user = new EFUser
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                EmailAddress = request.EmailAddress,
                PhoneNumber = request.PhoneNumber,
                IsActive = request.IsActive,
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

        public async Task<bool> Delete(UserRequest request)
        {
            if (await context.Users.AnyAsync(u => u.Id == request.Id))
            {
                EFUser eFUser = mapper.Map<EFUser>(request);
                context.Users.Remove(eFUser);
                context.SaveChanges();
                return true;
            }
            else return false;
        }

        public async Task<List<UserResponse>> getAll()
        {
            var efUsers = await context.Users.Include(r => r.Role).ToListAsync();
            var users = mapper.Map<List<UserResponse>>(efUsers);
            return users;
        }

        public async Task<UserResponse> GetById(int id)
        {
            var user = await context.Users.Include(r => r.Role).FirstOrDefaultAsync(r => r.Id == id);
            if (user == null)
            {
                return null;
            }
            return mapper.Map<UserResponse>(user);
        }

        public async Task<UserResponse> Update(UserRequest request)
        {
            EFUser eFUser = mapper.Map<EFUser>(request);
            UserResponse userResponse = new UserResponse();

            try
            {
                // Récupérez l'entité existante avec la propriété de navigation incluse
                EFUser existingUser =  await context.Users.Include(r => r.Role).SingleOrDefaultAsync(u => u.Id == request.Id);

                if (existingUser == null)
                {
                    userResponse.Id = -1;
                    userResponse.FirstName = "User not found.";
                    return userResponse;
                }

                // Appliquez les modifications nécessaires
                existingUser.FirstName = request.FirstName;
                existingUser.LastName = request.LastName;
                existingUser.EmailAddress = request.EmailAddress;
                existingUser.PhoneNumber = request.PhoneNumber;
                existingUser.IsActive = request.IsActive;
                existingUser.Role.Id = (int)request.Role.Id;
                existingUser.Role.Name = request.Role.Name;
                await context.SaveChangesAsync();

                userResponse = mapper.Map<UserResponse>(eFUser);
            }
            catch (Exception ex)
            {
                // Gestion des exceptions et initialisation de la réponse
                userResponse.Id = -1;
                userResponse.FirstName = $"An error occurred: {ex.Message}";
            }

            return userResponse;
        }

        public Task<bool> UserIsUsed(UserRequest userRequest)
        {
            return Task.Run(async () => 
            await context.Questions.AnyAsync(q => q.AdminId == userRequest.Id)
            || await context.Levels.AnyAsync(l => l.AdminId == userRequest.Id)
            || await context.Technologies.AnyAsync(t => t.AdminId == userRequest.Id)
            || await context.Quizzes.AnyAsync(qz => qz.AdminId == userRequest.Id)
            || await context.Quizzes.AnyAsync(qz => qz.AgentId == userRequest.Id)
            || await context.Candidates.AnyAsync(c => c.AgentId == userRequest.Id)
            );
        }

        public Task<bool> IdIsNotAvailable(int id)
        {
            return Task.Run(() => context.Users.Any(f => f.Id == id));
        }

        public async Task<List<UserResponse>> GetUsersByRolesId(int roleId)
        {
            var efUsers = await context.Users.Where(u => u.RoleId == roleId).Include(r => r.Role).ToListAsync();
            var users = mapper.Map<List<UserResponse>>(efUsers);
            Console.WriteLine(users + " userssssssssssssssssssss" );
            return users;
        }
    }
}
