using Microsoft.EntityFrameworkCore;
using Quizz.Domain.Infrastructure.Data.Entities;

namespace Quizz.Domain.Infrastructure.Data
{
    public class Context : DbContext
    {
        public DbSet<EFCandidate> Candidates { get; set; }
        public DbSet<EFUser> Users { get; set; }
        public DbSet<EFQuiz> Quizzes { get; set; }
        public DbSet<EFQuestion> Questions { get; set; }
        public DbSet<EFResponse> Responses { get; set; }
        public DbSet<EFTechnology> Technologies { get; set; }
        public DbSet<EFLevel> Levels { get; set; }
        public DbSet<EFRole> Roles { get; set; }
        public DbSet<EFStatus> Statuses { get; set; }
        public DbSet<EFQuiz_Question> QuizQuestions { get; set; }
        public DbSet<EFCandidateResponse> CandidateResponses { get; set; }
        public Context(DbContextOptions<Context> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<EFRole>().HasData(
                new EFRole { Id = 1, Name = "Admin" },
                new EFRole { Id = 2, Name = "Agent" }
            );
            builder.Entity<EFLevel>().HasData(
                new EFLevel { Id = 1, Content = "Junior", AdminId = 1, IsActive = true },
                new EFLevel { Id = 2, Content = "intermediate", AdminId = 1, IsActive = true },
                new EFLevel { Id = 3, Content = "Senior", AdminId = 1 , IsActive = true }
            );

            builder.Entity<EFTechnology>().HasData(
                new EFTechnology { Id = 1, Name = "Technology1", AdminId = 1 },
                new EFTechnology { Id = 2, Name = "Technology2", AdminId = 2 }
            );
            builder.Entity<EFStatus>().HasData(
                new EFStatus { Id = 1, Status = "active" },
                new EFStatus { Id = 2, Status = "passed" },
                new EFStatus { Id = 3, Status = "delete" }
            );
            builder.Entity<EFUser>().HasData(
                new EFUser
                {
                    Id = 1,
                    FirstName = "John",
                    LastName = "Doe",
                    EmailAddress = "john.doe@example.com",
                    Password = "hashedpassword", // Replace with actual hashed password
                    RoleId = 1, // Replace with actual role ID
                    Token = "tokenvalue", // Replace with actual token value
                    IsActive = true,
                    PhoneNumber = "1234567890",
                    ConfirmPassword = "hashedpassword", // Replace with actual hashed password
                },
                new EFUser
                {
                    Id = 2,
                    FirstName = "Jane",
                    LastName = "Smith",
                    EmailAddress = "jane.smith@example.com",
                    Password = "hashedpassword", // Replace with actual hashed password
                    RoleId = 2, // Replace with actual role ID
                    Token = "tokenvalue", // Replace with actual token value
                    IsActive = true,
                    PhoneNumber = "0987654321",
                    ConfirmPassword = "hashedpassword", // Replace with actual hashed password
                }
            );
            builder.Entity<EFCandidate>().HasData(
                new EFCandidate
                {
                    Id = 1,
                    FirstName = "John",
                    LastName = "Doe",
                    EmailAddress = "john.doe@example.com",
                    PhoneNumber = "1234567890",
                    AgentId = 1
                },
                new EFCandidate
                {
                    Id = 2,
                    FirstName = "Jane",
                    LastName = "Smith",
                    EmailAddress = "jane.smith@example.com",
                    PhoneNumber = "0987654321",
                    AgentId = 2
                }
            );
            builder.Entity<EFQuiz>().HasData(
                new EFQuiz
                {
                    Id = 1,
                    Comment = "Sample comment 1",
                    Completion = 0.5M,
                    CompletionTime = DateTime.UtcNow,
                    IsValid = true,
                    NumberOfQuestion = 10,
                    QuizzNumber = "1",
                    Result = 0.5M,
                    URL = "https://example.com/quiz1",
                    AgentId = 1,
                    AdminId = 1,
                    CandidateId = 1,
                    StatusId = 1,
                    TechnologyId = 1,
                },
                new EFQuiz
                {
                    Id = 2,
                    Comment = "Sample comment 2",
                    Completion = 0.5M,
                    CompletionTime = DateTime.UtcNow,
                    IsValid = false,
                    NumberOfQuestion = 15,
                    QuizzNumber = "2",
                    Result = 0.8M,
                    URL = "https://example.com/quiz2",
                    AgentId = 2,
                    AdminId = 1,
                    CandidateId = 2,
                    StatusId = 2,
                    TechnologyId = 2,
                },
                new EFQuiz
                {
                    Id = 3,
                    IsValid = true,
                    NumberOfQuestion = 15,
                    QuizzNumber = "3",
                    URL = "https://example.com/quiz2",
                    AgentId = 2,
                    AdminId = 1,
                    CandidateId = 2,
                    StatusId = 1,
                    TechnologyId = 2,
                }

            );
            builder.Entity<EFQuestion>().HasData(
                new EFQuestion
                {
                    Id = 1,
                    Content = "Sample question content 1",
                    Type = "Multiple Choice",
                    IsValid = true,
                    AdminId = 1,
                    LevelId = 1,
                    TechnologyId = 1,

                },
                new EFQuestion
                {
                    Id = 2,
                    Content = "Sample question content 2",
                    Type = "Short Answer",
                    IsValid = true,
                    AdminId = 1,
                    LevelId = 2,
                    TechnologyId = 2,
                },
                new EFQuestion
                {
                    Id = 3,
                    Content = "Sample question content 3",
                    Type = "Short Answer",
                    IsValid = true,
                    AdminId = 1,
                    LevelId = 2,
                    TechnologyId = 2,
                },
                new EFQuestion
                {
                    Id = 4,
                    Content = "Sample question content 4",
                    Type = "Short Answer",
                    IsValid = true,
                    AdminId = 1,
                    LevelId = 2,
                    TechnologyId = 2,
                }
            );
            builder.Entity<EFResponse>().HasData(
                new EFResponse
                {
                    Id = 1,
                    Content = " Q1 Sample response content 1",
                    IsCorrect = true,
                    QuestionId = 1
                },
                new EFResponse
                {
                    Id = 2,
                    Content = " Q1 Sample response content 2",
                    IsCorrect = false,
                    QuestionId = 1
                },
                new EFResponse
                {
                    Id = 3,
                    Content = " Q1 Sample response content 3",
                    IsCorrect = true,
                    QuestionId = 1
                },
                new EFResponse
                {
                    Id = 4,
                    Content = "Q1 Sample response content 4",
                    IsCorrect = false,
                    QuestionId = 1
                },
                new EFResponse
                {
                    Id = 5,
                    Content = " Q2 Sample response content 1",
                    IsCorrect = true,
                    QuestionId = 2
                },
                new EFResponse
                {
                    Id = 6,
                    Content = " Q2 Sample response content 2",
                    IsCorrect = false,
                    QuestionId = 2
                },
                new EFResponse
                {
                    Id = 7,
                    Content = " Q2 Sample response content 3",
                    IsCorrect = true,
                    QuestionId = 2
                },
                new EFResponse
                {
                    Id = 8,
                    Content = "Q2 Sample response content 4",
                    IsCorrect = false,
                    QuestionId = 2
                },
                new EFResponse
                {
                    Id = 9,
                    Content = " Q3 Sample response content 1",
                    IsCorrect = true,
                    QuestionId = 3
                },
                new EFResponse
                {
                    Id = 10,
                    Content = " Q3 Sample response content 2",
                    IsCorrect = false,
                    QuestionId = 3
                },
                new EFResponse
                {
                    Id = 11,
                    Content = " Q3 Sample response content 3",
                    IsCorrect = true,
                    QuestionId = 3
                },
                new EFResponse
                {
                    Id = 12,
                    Content = "Q3 Sample response content 4",
                    IsCorrect = false,
                    QuestionId = 3
                },
                new EFResponse
                {
                    Id = 13,
                    Content = "Q4 Sample response content 4",
                    IsCorrect = false,
                    QuestionId = 4
                },
                new EFResponse
                {
                    Id = 14,
                    Content = " Q4 Sample response content 1",
                    IsCorrect = true,
                    QuestionId = 4
                },
                new EFResponse
                {
                    Id = 15,
                    Content = " Q4 Sample response content 2",
                    IsCorrect = false,
                    QuestionId = 4
                },
                new EFResponse
                {
                    Id = 16,
                    Content = " Q4 Sample response content 3",
                    IsCorrect = true,
                    QuestionId = 4
                }


            );
            builder.Entity<EFQuiz_Question>().HasData(
                new EFQuiz_Question
                {
                    QuizId = 1,
                    QuestionId = 1
                },
                new EFQuiz_Question
                {
                    QuizId = 1,
                    QuestionId = 2
                },
                new EFQuiz_Question
                {
                    QuizId = 1,
                    QuestionId = 3
                },
                new EFQuiz_Question
                {
                    QuizId = 1,
                    QuestionId = 4
                },
                new EFQuiz_Question
                {
                    QuizId = 2,
                    QuestionId = 1
                },
                new EFQuiz_Question
                {
                    QuizId = 2,
                    QuestionId = 2
                },
                new EFQuiz_Question
                {
                    QuizId = 2,
                    QuestionId = 3
                },
                new EFQuiz_Question
                {
                    QuizId = 2,
                    QuestionId = 4
                }
            );

            builder.ApplyConfigurationsFromAssembly(typeof(Context).Assembly);
        }
    }
}
