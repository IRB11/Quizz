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

        public UserRepository(Context context, IMapper mapper) : base()
        {
            this.context = context;
            this.mapper = mapper;
        }
        public async Task<UserResponse> GetByEmailAndPassword(LoginRequest LoginRequest)
        {
            if (LoginRequest == null)
                throw new ArgumentNullException(nameof(LoginRequest));

            if (string.IsNullOrEmpty(LoginRequest.EmailAddress) || string.IsNullOrEmpty(LoginRequest.Password))
                throw new ArgumentException("Email address and password must be provided.");

            EFUser eFUser;

            if (UserVerify(LoginRequest).Result == true)
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

            byte[] saltBytes = GenerateSalt();
            string hashedPassword = HashPassword(password, saltBytes);
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
        static byte[] GenerateSalt()
        {
            using (var rng = new RNGCryptoServiceProvider())
            {
                byte[] salt = new byte[16]; // Adjust the size based on your security requirements
                rng.GetBytes(salt);
                return salt;
            }
        }
        static string HashPassword(string password, byte[] salt)
        {
            using (var sha256 = new SHA256Managed())
            {
                byte[] passwordBytes = Encoding.UTF8.GetBytes(password);
                byte[] saltedPassword = new byte[passwordBytes.Length + salt.Length];

                // Concatenate password and salt
                Buffer.BlockCopy(passwordBytes, 0, saltedPassword, 0, passwordBytes.Length);
                Buffer.BlockCopy(salt, 0, saltedPassword, passwordBytes.Length, salt.Length);

                // Hash the concatenated password and salt
                byte[] hashedBytes = sha256.ComputeHash(saltedPassword);

                // Concatenate the salt and hashed password for storage
                byte[] hashedPasswordWithSalt = new byte[hashedBytes.Length + salt.Length];
                Buffer.BlockCopy(salt, 0, hashedPasswordWithSalt, 0, salt.Length);
                Buffer.BlockCopy(hashedBytes, 0, hashedPasswordWithSalt, salt.Length, hashedBytes.Length);

                return Convert.ToBase64String(hashedPasswordWithSalt);
            }
        }
        public async Task<bool> UserVerify(LoginRequest verify)
        {

            // In a real scenario, you would retrieve these values from your database
            var user = context.Users.Where(x => x.EmailAddress == verify.EmailAddress).Select(x => x).FirstOrDefault();

            string storedHashedPassword = user.ConfirmPassword;// "hashed_password_from_database";
            //string storedSalt = user.Salt; //"salt_from_database";
            byte[] storedSaltBytes = user.Salt;
            string enteredPassword = verify.Password; //"user_entered_password";

            // Convert the stored salt and entered password to byte arrays
            // byte[] storedSaltBytes = Convert.FromBase64String(user.Salt);
            byte[] enteredPasswordBytes = Encoding.UTF8.GetBytes(enteredPassword);

            // Concatenate entered password and stored salt
            byte[] saltedPassword = new byte[enteredPasswordBytes.Length + storedSaltBytes.Length];
            Buffer.BlockCopy(enteredPasswordBytes, 0, saltedPassword, 0, enteredPasswordBytes.Length);
            Buffer.BlockCopy(storedSaltBytes, 0, saltedPassword, enteredPasswordBytes.Length, storedSaltBytes.Length);

            // Hash the concatenated value
            string enteredPasswordHash = HashPassword(enteredPassword, storedSaltBytes);

            // Compare the entered password hash with the stored hash
            if (enteredPasswordHash == storedHashedPassword)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public async Task<bool> EmailIsNotAvailable(string email)
        {
            return await context.Users.AnyAsync(e => e.EmailAddress == email);
        }
    }
}
