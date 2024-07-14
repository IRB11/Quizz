

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
                new EFTechnology { Id = 2, Name = "Technology2", AdminId = 2 },
                new EFTechnology { Id = 3, Name = "Technology3", AdminId = 2 }
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
                    Content = "What is the output of the following code snippet in Python: print(2 ** 3)?",
                    Type = "Multiple Choice",
                    IsValid = true,
                    AdminId = 1,
                    LevelId = 1,
                    TechnologyId = 1,
                },
                new EFQuestion
                {
                    Id = 2,
                    Content = "Explain the difference between 'let' and 'var' in JavaScript.",
                    Type = "Short Answer",
                    IsValid = true,
                    AdminId = 1,
                    LevelId = 2,
                    TechnologyId = 2,
                },
                new EFQuestion
                {
                    Id = 3,
                    Content = "How do you create a class in Java?",
                    Type = "Short Answer",
                    IsValid = true,
                    AdminId = 1,
                    LevelId = 2,
                    TechnologyId = 2,
                },
                new EFQuestion
                {
                    Id = 4,
                    Content = "What is the time complexity of binary search?",
                    Type = "Short Answer",
                    IsValid = true,
                    AdminId = 1,
                    LevelId = 2,
                    TechnologyId = 2,
                },
                new EFQuestion
                {
                    Id = 5,
                    Content = "What is a closure in JavaScript?",
                    Type = "Short Answer",
                    IsValid = true,
                    AdminId = 1,
                    LevelId = 3,
                    TechnologyId = 3,
                },
                new EFQuestion
                {
                    Id = 6,
                    Content = "Describe the concept of polymorphism in Object-Oriented Programming.",
                    Type = "Short Answer",
                    IsValid = true,
                    AdminId = 1,
                    LevelId = 3,
                    TechnologyId = 3,
                },
                new EFQuestion
                {
                    Id = 7,
                    Content = "What is the difference between an abstract class and an interface in C#?",
                    Type = "Short Answer",
                    IsValid = true,
                    AdminId = 1,
                    LevelId = 3,
                    TechnologyId = 3,
                },
                new EFQuestion
                {
                    Id = 8,
                    Content = "What is the purpose of the 'using' statement in C#?",
                    Type = "Short Answer",
                    IsValid = true,
                    AdminId = 1,
                    LevelId = 1,
                    TechnologyId = 1,
                },
                new EFQuestion
                {
                    Id = 9,
                    Content = "Explain the concept of dependency injection.",
                    Type = "Short Answer",
                    IsValid = true,
                    AdminId = 1,
                    LevelId = 2,
                    TechnologyId = 2,
                },
                new EFQuestion
                {
                    Id = 10,
                    Content = "What is the difference between a stack and a queue?",
                    Type = "Short Answer",
                    IsValid = true,
                    AdminId = 1,
                    LevelId = 2,
                    TechnologyId = 2,
                },
                new EFQuestion
                {
                    Id = 11,
                    Content = "What is the purpose of the 'yield' keyword in Python?",
                    Type = "Short Answer",
                    IsValid = true,
                    AdminId = 1,
                    LevelId = 1,
                    TechnologyId = 1,
                },
                new EFQuestion
                {
                    Id = 12,
                    Content = "Explain the concept of recursion.",
                    Type = "Short Answer",
                    IsValid = true,
                    AdminId = 1,
                    LevelId = 2,
                    TechnologyId = 2,
                },
                new EFQuestion
                {
                    Id = 13,
                    Content = "What is the difference between a list and a tuple in Python?",
                    Type = "Short Answer",
                    IsValid = true,
                    AdminId = 1,
                    LevelId = 2,
                    TechnologyId = 2,
                },
                new EFQuestion
                {
                    Id = 14,
                    Content = "What is the purpose of the 'final' keyword in Java?",
                    Type = "Short Answer",
                    IsValid = true,
                    AdminId = 1,
                    LevelId = 3,
                    TechnologyId = 3,
                },
                new EFQuestion
                {
                    Id = 15,
                    Content = "Explain the concept of inheritance in Object-Oriented Programming.",
                    Type = "Short Answer",
                    IsValid = true,
                    AdminId = 1,
                    LevelId = 3,
                    TechnologyId = 3,
                },
                new EFQuestion
                {
                    Id = 16,
                    Content = "What is the difference between an array and a linked list?",
                    Type = "Short Answer",
                    IsValid = true,
                    AdminId = 1,
                    LevelId = 1,
                    TechnologyId = 1,
                },
                new EFQuestion
                {
                    Id = 17,
                    Content = "What is the purpose of the 'this' keyword in JavaScript?",
                    Type = "Short Answer",
                    IsValid = true,
                    AdminId = 1,
                    LevelId = 2,
                    TechnologyId = 2,
                },
                new EFQuestion
                {
                    Id = 18,
                    Content = "Explain the concept of encapsulation in Object-Oriented Programming.",
                    Type = "Short Answer",
                    IsValid = true,
                    AdminId = 1,
                    LevelId = 2,
                    TechnologyId = 2,
                },
                new EFQuestion
                {
                    Id = 19,
                    Content = "What is the difference between a synchronous and an asynchronous function?",
                    Type = "Short Answer",
                    IsValid = true,
                    AdminId = 1,
                    LevelId = 3,
                    TechnologyId = 3,
                },
                new EFQuestion
                {
                    Id = 20,
                    Content = "What is the purpose of the 'super' keyword in Java?",
                    Type = "Short Answer",
                    IsValid = true,
                    AdminId = 1,
                    LevelId = 3,
                    TechnologyId = 3,
                },
                new EFQuestion
                {
                    Id = 21,
                    Content = "What is the difference between a class and an object?",
                    Type = "Short Answer",
                    IsValid = true,
                    AdminId = 1,
                    LevelId = 1,
                    TechnologyId = 1,
                },
                new EFQuestion
                {
                    Id = 22,
                    Content = "Explain the concept of abstraction in Object-Oriented Programming.",
                    Type = "Short Answer",
                    IsValid = true,
                    AdminId = 1,
                    LevelId = 2,
                    TechnologyId = 2,
                },
                new EFQuestion
                {
                    Id = 23,
                    Content = "What is the purpose of the 'finally' block in exception handling?",
                    Type = "Short Answer",
                    IsValid = true,
                    AdminId = 1,
                    LevelId = 2,
                    TechnologyId = 2,
                },
                new EFQuestion
                {
                    Id = 24,
                    Content = "What is the difference between a primary key and a foreign key in a database?",
                    Type = "Short Answer",
                    IsValid = true,
                    AdminId = 1,
                    LevelId = 3,
                    TechnologyId = 3,
                },
                new EFQuestion
                {
                    Id = 25,
                    Content = "Explain the concept of normalization in database design.",
                    Type = "Short Answer",
                    IsValid = true,
                    AdminId = 1,
                    LevelId = 3,
                    TechnologyId = 3,
                },
                new EFQuestion
                {
                    Id = 26,
                    Content = "What is the purpose of the 'static' keyword in Java?",
                    Type = "Short Answer",
                    IsValid = true,
                    AdminId = 1,
                    LevelId = 1,
                    TechnologyId = 1,
                },
                new EFQuestion
                {
                    Id = 27,
                    Content = "Explain the concept of method overloading in Java.",
                    Type = "Short Answer",
                    IsValid = true,
                    AdminId = 1,
                    LevelId = 2,
                    TechnologyId = 2,
                },
                new EFQuestion
                {
                    Id = 28,
                    Content = "What is the difference between a GET and a POST request in HTTP?",
                    Type = "Short Answer",
                    IsValid = true,
                    AdminId = 1,
                    LevelId = 2,
                    TechnologyId = 2,
                },
                new EFQuestion
                {
                    Id = 29,
                    Content = "What is the purpose of the 'volatile' keyword in Java?",
                    Type = "Short Answer",
                    IsValid = true,
                    AdminId = 1,
                    LevelId = 3,
                    TechnologyId = 3,
                },
                new EFQuestion
                {
                    Id = 30,
                    Content = "Explain the concept of a RESTful API.",
                    Type = "Short Answer",
                    IsValid = true,
                    AdminId = 1,
                    LevelId = 3,
                    TechnologyId = 3,
                },
                new EFQuestion
                {
                    Id = 31,
                    Content = "What is the difference between a thread and a process?",
                    Type = "Short Answer",
                    IsValid = true,
                    AdminId = 1,
                    LevelId = 1,
                    TechnologyId = 1,
                },
                new EFQuestion
                {
                    Id = 32,
                    Content = "Explain the concept of a lambda expression in Java.",
                    Type = "Short Answer",
                    IsValid = true,
                    AdminId = 1,
                    LevelId = 2,
                    TechnologyId = 2,
                },
                new EFQuestion
                {
                    Id = 33,
                    Content = "What is the purpose of the 'transient' keyword in Java?",
                    Type = "Short Answer",
                    IsValid = true,
                    AdminId = 1,
                    LevelId = 2,
                    TechnologyId = 2,
                },
                new EFQuestion
                {
                    Id = 34,
                    Content = "What is the difference between a constructor and a method?",
                    Type = "Short Answer",
                    IsValid = true,
                    AdminId = 1,
                    LevelId = 3,
                    TechnologyId = 3,
                },
                new EFQuestion
                {
                    Id = 35,
                    Content = "Explain the concept of a binary tree.",
                    Type = "Short Answer",
                    IsValid = true,
                    AdminId = 1,
                    LevelId = 3,
                    TechnologyId = 3,
                },
                new EFQuestion
                {
                    Id = 36,
                    Content = "What is the purpose of the 'synchronized' keyword in Java?",
                    Type = "Short Answer",
                    IsValid = true,
                    AdminId = 1,
                    LevelId = 1,
                    TechnologyId = 1,
                },
                new EFQuestion
                {
                    Id = 37,
                    Content = "Explain the concept of a hash table.",
                    Type = "Short Answer",
                    IsValid = true,
                    AdminId = 1,
                    LevelId = 2,
                    TechnologyId = 2,
                },
                new EFQuestion
                {
                    Id = 38,
                    Content = "What is the difference between a stack and a heap?",
                    Type = "Short Answer",
                    IsValid = true,
                    AdminId = 1,
                    LevelId = 2,
                    TechnologyId = 2,
                },
                new EFQuestion
                {
                    Id = 39,
                    Content = "What is the purpose of the 'finalize' method in Java?",
                    Type = "Short Answer",
                    IsValid = true,
                    AdminId = 1,
                    LevelId = 3,
                    TechnologyId = 3,
                },
                new EFQuestion
                {
                    Id = 40,
                    Content = "Explain the concept of a linked list.",
                    Type = "Short Answer",
                    IsValid = true,
                    AdminId = 1,
                    LevelId = 3,
                    TechnologyId = 3,
                },
                new EFQuestion
                {
                    Id = 41,
                    Content = "What is the output of the following code snippet in Python: print(3 ** 2)?",
                    Type = "Multiple Choice",
                    IsValid = true,
                    AdminId = 1,
                    LevelId = 1,
                    TechnologyId = 1,
                },
                new EFQuestion
                {
                    Id = 42,
                    Content = "What is the difference between 'const' and 'let' in JavaScript?",
                    Type = "Multiple Choice",
                    IsValid = true,
                    AdminId = 1,
                    LevelId = 2,
                    TechnologyId = 2,
                },
                new EFQuestion
                {
                    Id = 43,
                    Content = "How do you create an interface in Java?",
                    Type = "Multiple Choice",
                    IsValid = true,
                    AdminId = 1,
                    LevelId = 2,
                    TechnologyId = 2,
                },
                new EFQuestion
                {
                    Id = 44,
                    Content = "What is the time complexity of quicksort?",
                    Type = "Multiple Choice",
                    IsValid = true,
                    AdminId = 1,
                    LevelId = 2,
                    TechnologyId = 2,
                },
                new EFQuestion
                {
                    Id = 45,
                    Content = "What is a promise in JavaScript?",
                    Type = "Multiple Choice",
                    IsValid = true,
                    AdminId = 1,
                    LevelId = 3,
                    TechnologyId = 3,
                },
                new EFQuestion
                {
                    Id = 46,
                    Content = "Describe the concept of inheritance in Object-Oriented Programming.",
                    Type = "Multiple Choice",
                    IsValid = true,
                    AdminId = 1,
                    LevelId = 3,
                    TechnologyId = 3,
                },
                new EFQuestion
                {
                    Id = 47,
                    Content = "What is the difference between a class and an interface in C#?",
                    Type = "Multiple Choice",
                    IsValid = true,
                    AdminId = 1,
                    LevelId = 3,
                    TechnologyId = 3,
                },
                new EFQuestion
                {
                    Id = 48,
                    Content = "What is the purpose of the 'await' keyword in C#?",
                    Type = "Multiple Choice",
                    IsValid = true,
                    AdminId = 1,
                    LevelId = 1,
                    TechnologyId = 1,
                },
                new EFQuestion
                {
                    Id = 49,
                    Content = "Explain the concept of inversion of control.",
                    Type = "Multiple Choice",
                    IsValid = true,
                    AdminId = 1,
                    LevelId = 2,
                    TechnologyId = 2,
                },
                new EFQuestion
                {
                    Id = 50,
                    Content = "What is the difference between a binary tree and a binary search tree?",
                    Type = "Multiple Choice",
                    IsValid = true,
                    AdminId = 1,
                    LevelId = 2,
                    TechnologyId = 2,
                },
                new EFQuestion
                {
                    Id = 51,
                    Content = "What is the purpose of the 'yield' keyword in C#?",
                    Type = "Multiple Choice",
                    IsValid = true,
                    AdminId = 1,
                    LevelId = 1,
                    TechnologyId = 1,
                },
                new EFQuestion
                {
                    Id = 52,
                    Content = "Explain the concept of memoization.",
                    Type = "Multiple Choice",
                    IsValid = true,
                    AdminId = 1,
                    LevelId = 2,
                    TechnologyId = 2,
                },
                new EFQuestion
                {
                    Id = 53,
                    Content = "What is the difference between a dictionary and a list in Python?",
                    Type = "Multiple Choice",
                    IsValid = true,
                    AdminId = 1,
                    LevelId = 2,
                    TechnologyId = 2,
                },
                new EFQuestion
                {
                    Id = 54,
                    Content = "What is the purpose of the 'final' keyword in C++?",
                    Type = "Multiple Choice",
                    IsValid = true,
                    AdminId = 1,
                    LevelId = 3,
                    TechnologyId = 3,
                },
                new EFQuestion
                {
                    Id = 55,
                    Content = "Explain the concept of polymorphism in Object-Oriented Programming.",
                    Type = "Multiple Choice",
                    IsValid = true,
                    AdminId = 1,
                    LevelId = 3,
                    TechnologyId = 3,
                },
                new EFQuestion
                {
                    Id = 56,
                    Content = "What is the difference between an array and a list in Java?",
                    Type = "Multiple Choice",
                    IsValid = true,
                    AdminId = 1,
                    LevelId = 1,
                    TechnologyId = 1,
                },
                new EFQuestion
                {
                    Id = 57,
                    Content = "What is the purpose of the 'this' keyword in Java?",
                    Type = "Multiple Choice",
                    IsValid = true,
                    AdminId = 1,
                    LevelId = 2,
                    TechnologyId = 2,
                },
                new EFQuestion
                {
                    Id = 58,
                    Content = "Explain the concept of encapsulation in Object-Oriented Programming.",
                    Type = "Multiple Choice",
                    IsValid = true,
                    AdminId = 1,
                    LevelId = 2,
                    TechnologyId = 2,
                },
                new EFQuestion
                {
                    Id = 59,
                    Content = "What is the difference between a synchronous and an asynchronous function?",
                    Type = "Multiple Choice",
                    IsValid = true,
                    AdminId = 1,
                    LevelId = 3,
                    TechnologyId = 3,
                },
                new EFQuestion
                {
                    Id = 60,
                    Content = "What is the purpose of the 'super' keyword in Python?",
                    Type = "Multiple Choice",
                    IsValid = true,
                    AdminId = 1,
                    LevelId = 3,
                    TechnologyId = 3,
                }, new EFQuestion
                {
                    Id = 61,
                    Content = "What is the output of the following code snippet in JavaScript: console.log(2 + 2 * 2)?",
                    Type = "Multiple Choice",
                    IsValid = true,
                    AdminId = 1,
                    LevelId = 1,
                    TechnologyId = 1,
                },
                new EFQuestion
                {
                    Id = 62,
                    Content = "What is the purpose of the 'map' function in JavaScript?",
                    Type = "Multiple Choice",
                    IsValid = true,
                    AdminId = 1,
                    LevelId = 2,
                    TechnologyId = 2,
                },
                new EFQuestion
                {
                    Id = 63,
                    Content = "What is the time complexity of the merge sort algorithm?",
                    Type = "Multiple Choice",
                    IsValid = true,
                    AdminId = 1,
                    LevelId = 3,
                    TechnologyId = 3,
                },
                new EFQuestion
                {
                    Id = 64,
                    Content = "What is the output of the following code snippet in Python: print('Hello' + 'World')?",
                    Type = "Multiple Choice",
                    IsValid = true,
                    AdminId = 1,
                    LevelId = 1,
                    TechnologyId = 1,
                },
                new EFQuestion
                {
                    Id = 65,
                    Content = "What is the purpose of the 'filter' function in JavaScript?",
                    Type = "Multiple Choice",
                    IsValid = true,
                    AdminId = 1,
                    LevelId = 2,
                    TechnologyId = 2,
                },
                new EFQuestion
                {
                    Id = 66,
                    Content = "What is the time complexity of the bubble sort algorithm?",
                    Type = "Multiple Choice",
                    IsValid = true,
                    AdminId = 1,
                    LevelId = 3,
                    TechnologyId = 3,
                },
                new EFQuestion
                {
                    Id = 67,
                    Content = "What is the output of the following code snippet in Java: System.out.println(10 / 3);?",
                    Type = "Multiple Choice",
                    IsValid = true,
                    AdminId = 1,
                    LevelId = 1,
                    TechnologyId = 1,
                },
                new EFQuestion
                {
                    Id = 68,
                    Content = "What is the purpose of the 'reduce' function in JavaScript?",
                    Type = "Multiple Choice",
                    IsValid = true,
                    AdminId = 1,
                    LevelId = 2,
                    TechnologyId = 2,
                },
                new EFQuestion
                {
                    Id = 69,
                    Content = "What is the time complexity of the insertion sort algorithm?",
                    Type = "Multiple Choice",
                    IsValid = true,
                    AdminId = 1,
                    LevelId = 3,
                    TechnologyId = 3,
                },
                new EFQuestion
                {
                    Id = 70,
                    Content = "What is the output of the following code snippet in Python: print(5 // 2)?",
                    Type = "Multiple Choice",
                    IsValid = true,
                    AdminId = 1,
                    LevelId = 1,
                    TechnologyId = 1,
                },
                new EFQuestion
                {
                    Id = 71,
                    Content = "What is the purpose of the 'find' function in JavaScript?",
                    Type = "Multiple Choice",
                    IsValid = true,
                    AdminId = 1,
                    LevelId = 2,
                    TechnologyId = 2,
                },
                new EFQuestion
                {
                    Id = 72,
                    Content = "What is the time complexity of the selection sort algorithm?",
                    Type = "Multiple Choice",
                    IsValid = true,
                    AdminId = 1,
                    LevelId = 3,
                    TechnologyId = 3,
                },
                new EFQuestion
                {
                    Id = 73,
                    Content = "What is the output of the following code snippet in Java: System.out.println(5 % 2);?",
                    Type = "Multiple Choice",
                    IsValid = true,
                    AdminId = 1,
                    LevelId = 1,
                    TechnologyId = 1,
                },
                new EFQuestion
                {
                    Id = 74,
                    Content = "What is the purpose of the 'every' function in JavaScript?",
                    Type = "Multiple Choice",
                    IsValid = true,
                    AdminId = 1,
                    LevelId = 2,
                    TechnologyId = 2,
                },
                new EFQuestion
                {
                    Id = 75,
                    Content = "What is the time complexity of the quicksort algorithm?",
                    Type = "Multiple Choice",
                    IsValid = true,
                    AdminId = 1,
                    LevelId = 3,
                    TechnologyId = 3,
                },
                new EFQuestion
                {
                    Id = 76,
                    Content = "What is the output of the following code snippet in Python: print(2 ** 3)?",
                    Type = "Multiple Choice",
                    IsValid = true,
                    AdminId = 1,
                    LevelId = 1,
                    TechnologyId = 1,
                },
                new EFQuestion
                {
                    Id = 77,
                    Content = "What is the purpose of the 'some' function in JavaScript?",
                    Type = "Multiple Choice",
                    IsValid = true,
                    AdminId = 1,
                    LevelId = 2,
                    TechnologyId = 2,
                },
                new EFQuestion
                {
                    Id = 78,
                    Content = "What is the time complexity of the heap sort algorithm?",
                    Type = "Multiple Choice",
                    IsValid = true,
                    AdminId = 1,
                    LevelId = 3,
                    TechnologyId = 3,
                }, new EFQuestion
                {
                    Id = 79,
                    Content = "What is the purpose of the 'map' function in JavaScript?",
                    Type = "Multiple Choice",
                    IsValid = true,
                    AdminId = 1,
                    LevelId = 2,
                    TechnologyId = 2,
                },
                new EFQuestion
                {
                    Id = 80,
                    Content = "What is the output of the following code snippet in Python: print(5 // 2)?",
                    Type = "Multiple Choice",
                    IsValid = true,
                    AdminId = 1,
                    LevelId = 1,
                    TechnologyId = 1,
                },
                new EFQuestion
                {
                    Id = 81,
                    Content = "What is the time complexity of the merge sort algorithm?",
                    Type = "Multiple Choice",
                    IsValid = true,
                    AdminId = 1,
                    LevelId = 3,
                    TechnologyId = 3,
                },
                new EFQuestion
                {
                    Id = 82,
                    Content = "What is the purpose of the 'filter' function in JavaScript?",
                    Type = "Multiple Choice",
                    IsValid = true,
                    AdminId = 1,
                    LevelId = 2,
                    TechnologyId = 2,
                },
                new EFQuestion
                {
                    Id = 83,
                    Content = "What is the output of the following code snippet in Python: print(7 % 3)?",
                    Type = "Multiple Choice",
                    IsValid = true,
                    AdminId = 1,
                    LevelId = 1,
                    TechnologyId = 1,
                },
                new EFQuestion
                {
                    Id = 84,
                    Content = "What is the time complexity of the bubble sort algorithm?",
                    Type = "Multiple Choice",
                    IsValid = true,
                    AdminId = 1,
                    LevelId = 3,
                    TechnologyId = 3,
                },
                new EFQuestion
                {
                    Id = 85,
                    Content = "What is the purpose of the 'reduce' function in JavaScript?",
                    Type = "Multiple Choice",
                    IsValid = true,
                    AdminId = 1,
                    LevelId = 2,
                    TechnologyId = 2,
                },
                new EFQuestion
                {
                    Id = 86,
                    Content = "What is the output of the following code snippet in Python: print(10 ** 2)?",
                    Type = "Multiple Choice",
                    IsValid = true,
                    AdminId = 1,
                    LevelId = 1,
                    TechnologyId = 1,
                },
                new EFQuestion
                {
                    Id = 87,
                    Content = "What is the time complexity of the insertion sort algorithm?",
                    Type = "Multiple Choice",
                    IsValid = true,
                    AdminId = 1,
                    LevelId = 3,
                    TechnologyId = 3,
                },
                new EFQuestion
                {
                    Id = 88,
                    Content = "What is the purpose of the 'find' function in JavaScript?",
                    Type = "Multiple Choice",
                    IsValid = true,
                    AdminId = 1,
                    LevelId = 2,
                    TechnologyId = 2,
                },
                new EFQuestion
                {
                    Id = 89,
                    Content = "What is the output of the following code snippet in Python: print(9 // 2)?",
                    Type = "Multiple Choice",
                    IsValid = true,
                    AdminId = 1,
                    LevelId = 1,
                    TechnologyId = 1,
                },
                new EFQuestion
                {
                    Id = 90,
                    Content = "What is the time complexity of the selection sort algorithm?",
                    Type = "Multiple Choice",
                    IsValid = true,
                    AdminId = 1,
                    LevelId = 3,
                    TechnologyId = 3,
                },
                new EFQuestion
                {
                    Id = 91,
                    Content = "What is the purpose of the 'every' function in JavaScript?",
                    Type = "Multiple Choice",
                    IsValid = true,
                    AdminId = 1,
                    LevelId = 2,
                    TechnologyId = 2,
                },
                new EFQuestion
                {
                    Id = 92,
                    Content = "What is the output of the following code snippet in Python: print(8 % 3)?",
                    Type = "Multiple Choice",
                    IsValid = true,
                    AdminId = 1,
                    LevelId = 1,
                    TechnologyId = 1,
                },
                new EFQuestion
                {
                    Id = 93,
                    Content = "What is the time complexity of the quicksort algorithm?",
                    Type = "Multiple Choice",
                    IsValid = true,
                    AdminId = 1,
                    LevelId = 3,
                    TechnologyId = 3,
                },
                new EFQuestion
                {
                    Id = 94,
                    Content = "What is the purpose of the 'some' function in JavaScript?",
                    Type = "Multiple Choice",
                    IsValid = true,
                    AdminId = 1,
                    LevelId = 2,
                    TechnologyId = 2,
                },
                new EFQuestion
                {
                    Id = 95,
                    Content = "What is the output of the following code snippet in Python: print(6 // 2)?",
                    Type = "Multiple Choice",
                    IsValid = true,
                    AdminId = 1,
                    LevelId = 1,
                    TechnologyId = 1,
                },
                new EFQuestion
                {
                    Id = 96,
                    Content = "What is the time complexity of the radix sort algorithm?",
                    Type = "Multiple Choice",
                    IsValid = true,
                    AdminId = 1,
                    LevelId = 3,
                    TechnologyId = 3,
                },
                new EFQuestion
                {
                    Id = 97,
                    Content = "What is the purpose of the 'forEach' function in JavaScript?",
                    Type = "Multiple Choice",
                    IsValid = true,
                    AdminId = 1,
                    LevelId = 2,
                    TechnologyId = 2,
                },
                new EFQuestion
                {
                    Id = 98,
                    Content = "What is the purpose of the 'map' function in JavaScript?",
                    Type = "Multiple Choice",
                    IsValid = true,
                    AdminId = 1,
                    LevelId = 2,
                    TechnologyId = 1,
                },
                new EFQuestion
                {
                    Id = 99,
                    Content = "What is the purpose of the 'filter' function in JavaScript?",
                    Type = "Multiple Choice",
                    IsValid = true,
                    AdminId = 1,
                    LevelId = 2,
                    TechnologyId = 1,
                },
                new EFQuestion
                {
                    Id = 100,
                    Content = "What is the purpose of the 'reduce' function in JavaScript?",
                    Type = "Multiple Choice",
                    IsValid = true,
                    AdminId = 1,
                    LevelId = 2,
                    TechnologyId = 1,
                },
                new EFQuestion
                {
                    Id = 101,
                    Content = "What is the purpose of the 'find' function in JavaScript?",
                    Type = "Multiple Choice",
                    IsValid = true,
                    AdminId = 1,
                    LevelId = 2,
                    TechnologyId = 1,
                },
                new EFQuestion
                {
                    Id = 102,
                    Content = "What is the purpose of the 'some' function in JavaScript?",
                    Type = "Multiple Choice",
                    IsValid = true,
                    AdminId = 1,
                    LevelId = 2,
                    TechnologyId = 1,
                },
                new EFQuestion
                {
                    Id = 103,
                    Content = "What is the purpose of the 'every' function in JavaScript?",
                    Type = "Multiple Choice",
                    IsValid = true,
                    AdminId = 1,
                    LevelId = 2,
                    TechnologyId = 1,
                },
                new EFQuestion
                {
                    Id = 104,
                    Content = "What is the purpose of the 'includes' function in JavaScript?",
                    Type = "Multiple Choice",
                    IsValid = true,
                    AdminId = 1,
                    LevelId = 2,
                    TechnologyId = 1,
                },
                new EFQuestion
                {
                    Id = 105,
                    Content = "What is the purpose of the 'indexOf' function in JavaScript?",
                    Type = "Multiple Choice",
                    IsValid = true,
                    AdminId = 1,
                    LevelId = 2,
                    TechnologyId = 1,
                },
                new EFQuestion
                {
                    Id = 106,
                    Content = "What is the purpose of the 'push' function in JavaScript?",
                    Type = "Multiple Choice",
                    IsValid = true,
                    AdminId = 1,
                    LevelId = 2,
                    TechnologyId = 1,
                },
                new EFQuestion
                {
                    Id = 107,
                    Content = "What is the purpose of the 'pop' function in JavaScript?",
                    Type = "Multiple Choice",
                    IsValid = true,
                    AdminId = 1,
                    LevelId = 2,
                    TechnologyId = 1,
                },
                new EFQuestion
                {
                    Id = 108,
                    Content = "What is the purpose of the 'shift' function in JavaScript?",
                    Type = "Multiple Choice",
                    IsValid = true,
                    AdminId = 1,
                    LevelId = 2,
                    TechnologyId = 1,
                },
                new EFQuestion
                {
                    Id = 109,
                    Content = "What is the purpose of the 'unshift' function in JavaScript?",
                    Type = "Multiple Choice",
                    IsValid = true,
                    AdminId = 1,
                    LevelId = 2,
                    TechnologyId = 1,
                },
                new EFQuestion
                {
                    Id = 110,
                    Content = "What is the purpose of the 'slice' function in JavaScript?",
                    Type = "Multiple Choice",
                    IsValid = true,
                    AdminId = 1,
                    LevelId = 2,
                    TechnologyId = 1,
                },
                new EFQuestion
                {
                    Id = 111,
                    Content = "What is the purpose of the 'splice' function in JavaScript?",
                    Type = "Multiple Choice",
                    IsValid = true,
                    AdminId = 1,
                    LevelId = 2,
                    TechnologyId = 1,
                },
                new EFQuestion
                {
                    Id = 112,
                    Content = "What is the purpose of the 'concat' function in JavaScript?",
                    Type = "Multiple Choice",
                    IsValid = true,
                    AdminId = 1,
                    LevelId = 2,
                    TechnologyId = 1,
                },
                new EFQuestion
                {
                    Id = 113,
                    Content = "What is the purpose of the 'join' function in JavaScript?",
                    Type = "Multiple Choice",
                    IsValid = true,
                    AdminId = 1,
                    LevelId = 2,
                    TechnologyId = 1,
                },
                new EFQuestion
                {
                    Id = 114,
                    Content = "What is the purpose of the 'reverse' function in JavaScript?",
                    Type = "Multiple Choice",
                    IsValid = true,
                    AdminId = 1,
                    LevelId = 2,
                    TechnologyId = 1,
                },
                new EFQuestion
                {
                    Id = 115,
                    Content = "What is the purpose of the 'sort' function in JavaScript?",
                    Type = "Multiple Choice",
                    IsValid = true,
                    AdminId = 1,
                    LevelId = 2,
                    TechnologyId = 1,
                },
                new EFQuestion
                {
                    Id = 116,
                    Content = "What is the purpose of the 'toString' function in JavaScript?",
                    Type = "Multiple Choice",
                    IsValid = true,
                    AdminId = 1,
                    LevelId = 2,
                    TechnologyId = 1,
                },
                new EFQuestion
                {
                    Id = 117,
                    Content = "What is the purpose of the 'map' function in JavaScript?",
                    Type = "Multiple Choice",
                    IsValid = true,
                    AdminId = 1,
                    LevelId = 3,
                    TechnologyId = 1,
                },
                new EFQuestion
                {
                    Id = 118,
                    Content = "What is the purpose of the 'filter' function in JavaScript?",
                    Type = "Multiple Choice",
                    IsValid = true,
                    AdminId = 1,
                    LevelId = 3,
                    TechnologyId = 1,
                },
                new EFQuestion
                {
                    Id = 119,
                    Content = "What is the purpose of the 'reduce' function in JavaScript?",
                    Type = "Multiple Choice",
                    IsValid = true,
                    AdminId = 1,
                    LevelId = 3,
                    TechnologyId = 1,
                },
                new EFQuestion
                {
                    Id = 120,
                    Content = "What is the purpose of the 'find' function in JavaScript?",
                    Type = "Multiple Choice",
                    IsValid = true,
                    AdminId = 1,
                    LevelId = 3,
                    TechnologyId = 1,
                },
                new EFQuestion
                {
                    Id = 121,
                    Content = "What is the purpose of the 'map' function in JavaScript?",
                    Type = "Multiple Choice",
                    IsValid = true,
                    AdminId = 1,
                    LevelId = 3,
                    TechnologyId = 1,
                },
                new EFQuestion
                {
                    Id = 122,
                    Content = "What is the purpose of the 'filter' function in JavaScript?",
                    Type = "Multiple Choice",
                    IsValid = true,
                    AdminId = 1,
                    LevelId = 3,
                    TechnologyId = 1,
                },
                new EFQuestion
                {
                    Id = 123,
                    Content = "What is the purpose of the 'reduce' function in JavaScript?",
                    Type = "Multiple Choice",
                    IsValid = true,
                    AdminId = 1,
                    LevelId = 3,
                    TechnologyId = 1,
                },
                new EFQuestion
                {
                    Id = 124,
                    Content = "What is the purpose of the 'find' function in JavaScript?",
                    Type = "Multiple Choice",
                    IsValid = true,
                    AdminId = 1,
                    LevelId = 3,
                    TechnologyId = 1,
                },
                new EFQuestion
                {
                    Id = 125,
                    Content = "What is the purpose of the 'forEach' function in JavaScript?",
                    Type = "Multiple Choice",
                    IsValid = true,
                    AdminId = 1,
                    LevelId = 3,
                    TechnologyId = 1,
                },
                new EFQuestion
                {
                    Id = 126,
                    Content = "What is the purpose of the 'some' function in JavaScript?",
                    Type = "Multiple Choice",
                    IsValid = true,
                    AdminId = 1,
                    LevelId = 3,
                    TechnologyId = 1,
                },
                new EFQuestion
                {
                    Id = 127,
                    Content = "What is the purpose of the 'every' function in JavaScript?",
                    Type = "Multiple Choice",
                    IsValid = true,
                    AdminId = 1,
                    LevelId = 3,
                    TechnologyId = 1,
                },
                new EFQuestion
                {
                    Id = 128,
                    Content = "What is the purpose of the 'concat' function in JavaScript?",
                    Type = "Multiple Choice",
                    IsValid = true,
                    AdminId = 1,
                    LevelId = 3,
                    TechnologyId = 1,
                },
                new EFQuestion
                {
                    Id = 129,
                    Content = "What is the purpose of the 'slice' function in JavaScript?",
                    Type = "Multiple Choice",
                    IsValid = true,
                    AdminId = 1,
                    LevelId = 3,
                    TechnologyId = 1,
                },
                new EFQuestion
                {
                    Id = 130,
                    Content = "What is the purpose of the 'splice' function in JavaScript?",
                    Type = "Multiple Choice",
                    IsValid = true,
                    AdminId = 1,
                    LevelId = 3,
                    TechnologyId = 1,
                },
                new EFQuestion
                {
                    Id = 131,
                    Content = "What is the purpose of the 'indexOf' function in JavaScript?",
                    Type = "Multiple Choice",
                    IsValid = true,
                    AdminId = 1,
                    LevelId = 3,
                    TechnologyId = 1,
                },
                new EFQuestion
                {
                    Id = 132,
                    Content = "What is the purpose of the 'lastIndexOf' function in JavaScript?",
                    Type = "Multiple Choice",
                    IsValid = true,
                    AdminId = 1,
                    LevelId = 3,
                    TechnologyId = 1,
                },
                new EFQuestion
                {
                    Id = 133,
                    Content = "What is the purpose of the 'includes' function in JavaScript?",
                    Type = "Multiple Choice",
                    IsValid = true,
                    AdminId = 1,
                    LevelId = 3,
                    TechnologyId = 1,
                },
                new EFQuestion
                {
                    Id = 134,
                    Content = "What is the purpose of the 'join' function in JavaScript?",
                    Type = "Multiple Choice",
                    IsValid = true,
                    AdminId = 1,
                    LevelId = 3,
                    TechnologyId = 1,
                },
                new EFQuestion
                {
                    Id = 135,
                    Content = "What is the purpose of the 'reverse' function in JavaScript?",
                    Type = "Multiple Choice",
                    IsValid = true,
                    AdminId = 1,
                    LevelId = 3,
                    TechnologyId = 1,
                },
                new EFQuestion
                {
                    Id = 136,
                    Content = "What is the purpose of the 'sort' function in JavaScript?",
                    Type = "Multiple Choice",
                    IsValid = true,
                    AdminId = 1,
                    LevelId = 3,
                    TechnologyId = 1,
                },
                new EFQuestion
                {
                    Id = 137,
                    Content = "What is the purpose of the 'push' function in JavaScript?",
                    Type = "Multiple Choice",
                    IsValid = true,
                    AdminId = 1,
                    LevelId = 3,
                    TechnologyId = 1,
                },
                new EFQuestion
                {
                    Id = 138,
                    Content = "What is the purpose of the 'pop' function in JavaScript?",
                    Type = "Multiple Choice",
                    IsValid = true,
                    AdminId = 1,
                    LevelId = 3,
                    TechnologyId = 1,
                },
                new EFQuestion
                {
                    Id = 139,
                    Content = "What is the purpose of the 'shift' function in JavaScript?",
                    Type = "Multiple Choice",
                    IsValid = true,
                    AdminId = 1,
                    LevelId = 3,
                    TechnologyId = 1,
                },
                new EFQuestion
                {
                    Id = 140,
                    Content = "What is the purpose of the 'unshift' function in JavaScript?",
                    Type = "Multiple Choice",
                    IsValid = true,
                    AdminId = 1,
                    LevelId = 3,
                    TechnologyId = 1,
                }
            );
            builder.Entity<EFResponse>().HasData(
                new EFResponse
                {
                    Id = 1,
                    Content = "8",
                    IsCorrect = true,
                    QuestionId = 1
                },
                new EFResponse
                {
                    Id = 2,
                    Content = "6",
                    IsCorrect = false,
                    QuestionId = 1
                },
                new EFResponse
                {
                    Id = 3,
                    Content = "4",
                    IsCorrect = false,
                    QuestionId = 1
                },
                new EFResponse
                {
                    Id = 4,
                    Content = "2",
                    IsCorrect = false,
                    QuestionId = 1
                },
                new EFResponse
                {
                    Id = 5,
                    Content = "let is block-scoped, var is function-scoped",
                    IsCorrect = true,
                    QuestionId = 2
                },
                new EFResponse
                {
                    Id = 6,
                    Content = "Both are block-scoped",
                    IsCorrect = false,
                    QuestionId = 2
                },
                new EFResponse
                {
                    Id = 7,
                    Content = "Both are function-scoped",
                    IsCorrect = false,
                    QuestionId = 2
                },
                new EFResponse
                {
                    Id = 8,
                    Content = "let is function-scoped, var is block-scoped",
                    IsCorrect = false,
                    QuestionId = 2
                },
                new EFResponse
                {
                    Id = 9,
                    Content = "class MyClass { }",
                    IsCorrect = true,
                    QuestionId = 3
                },
                new EFResponse
                {
                    Id = 10,
                    Content = "function MyClass() { }",
                    IsCorrect = false,
                    QuestionId = 3
                },
                new EFResponse
                {
                    Id = 11,
                    Content = "MyClass = class { }",
                    IsCorrect = false,
                    QuestionId = 3
                },
                new EFResponse
                {
                    Id = 12,
                    Content = "class = MyClass { }",
                    IsCorrect = false,
                    QuestionId = 3
                },
                new EFResponse
                {
                    Id = 13,
                    Content = "O(log n)",
                    IsCorrect = true,
                    QuestionId = 4
                },
                new EFResponse
                {
                    Id = 14,
                    Content = "O(n)",
                    IsCorrect = false,
                    QuestionId = 4
                },
                new EFResponse
                {
                    Id = 15,
                    Content = "O(n log n)",
                    IsCorrect = false,
                    QuestionId = 4
                },
                new EFResponse
                {
                    Id = 16,
                    Content = "O(1)",
                    IsCorrect = false,
                    QuestionId = 4
                },
                new EFResponse
                {
                    Id = 17,
                    Content = "A closure is a function that retains access to its lexical scope, even when the function is executed outside that scope.",
                    IsCorrect = true,
                    QuestionId = 5
                },
                new EFResponse
                {
                    Id = 18,
                    Content = "A closure is a function that does not have access to its lexical scope.",
                    IsCorrect = false,
                    QuestionId = 5
                },
                new EFResponse
                {
                    Id = 19,
                    Content = "A closure is a function that can only be executed within its lexical scope.",
                    IsCorrect = false,
                    QuestionId = 5
                },
                new EFResponse
                {
                    Id = 20,
                    Content = "A closure is a function that cannot access variables outside its lexical scope.",
                    IsCorrect = false,
                    QuestionId = 5
                },
                new EFResponse
                {
                    Id = 21,
                    Content = "Polymorphism is the ability of an object to take on many forms.",
                    IsCorrect = true,
                    QuestionId = 6
                },
                new EFResponse
                {
                    Id = 22,
                    Content = "Polymorphism is the ability of a function to take on many forms.",
                    IsCorrect = false,
                    QuestionId = 6
                },
                new EFResponse
                {
                    Id = 23,
                    Content = "Polymorphism is the ability of a variable to take on many forms.",
                    IsCorrect = false,
                    QuestionId = 6
                },
                new EFResponse
                {
                    Id = 24,
                    Content = "Polymorphism is the ability of a class to take on many forms.",
                    IsCorrect = false,
                    QuestionId = 6
                },
                new EFResponse
                {
                    Id = 25,
                    Content = "An abstract class can have implementations for some of its members, but an interface cannot.",
                    IsCorrect = true,
                    QuestionId = 7
                },
                new EFResponse
                {
                    Id = 26,
                    Content = "An interface can have implementations for some of its members, but an abstract class cannot.",
                    IsCorrect = false,
                    QuestionId = 7
                },
                new EFResponse
                {
                    Id = 27,
                    Content = "Both an abstract class and an interface can have implementations for some of their members.",
                    IsCorrect = false,
                    QuestionId = 7
                },
                new EFResponse
                {
                    Id = 28,
                    Content = "Neither an abstract class nor an interface can have implementations for any of their members.",
                    IsCorrect = false,
                    QuestionId = 7
                },
                new EFResponse
                {
                    Id = 29,
                    Content = "The 'using' statement ensures that IDisposable objects are properly disposed of.",
                    IsCorrect = true,
                    QuestionId = 8
                },
                new EFResponse
                {
                    Id = 30,
                    Content = "The 'using' statement is used to import namespaces.",
                    IsCorrect = false,
                    QuestionId = 8
                },
                new EFResponse
                {
                    Id = 31,
                    Content = "The 'using' statement is used to define a scope for variables.",
                    IsCorrect = false,
                    QuestionId = 8
                },
                new EFResponse
                {
                    Id = 32,
                    Content = "The 'using' statement is used to create new instances of classes.",
                    IsCorrect = false,
                    QuestionId = 8
                },
                new EFResponse
                {
                    Id = 33,
                    Content = "Dependency injection is a design pattern that allows a class to receive its dependencies from an external source.",
                    IsCorrect = true,
                    QuestionId = 9
                },
                new EFResponse
                {
                    Id = 34,
                    Content = "Dependency injection is a design pattern that allows a class to create its own dependencies.",
                    IsCorrect = false,
                    QuestionId = 9
                },
                new EFResponse
                {
                    Id = 35,
                    Content = "Dependency injection is a design pattern that allows a class to inherit its dependencies.",
                    IsCorrect = false,
                    QuestionId = 9
                },
                new EFResponse
                {
                    Id = 36,
                    Content = "Dependency injection is a design pattern that allows a class to share its dependencies with other classes.",
                    IsCorrect = false,
                    QuestionId = 9
                },
                new EFResponse
                {
                    Id = 37,
                    Content = "A stack is a LIFO (Last In, First Out) data structure, while a queue is a FIFO (First In, First Out) data structure.",
                    IsCorrect = true,
                    QuestionId = 10
                },
                new EFResponse
                {
                    Id = 38,
                    Content = "A stack is a FIFO (First In, First Out) data structure, while a queue is a LIFO (Last In, First Out) data structure.",
                    IsCorrect = false,
                    QuestionId = 10
                },
                new EFResponse
                {
                    Id = 39,
                    Content = "Both a stack and a queue are LIFO (Last In, First Out) data structures.",
                    IsCorrect = false,
                    QuestionId = 10
                },
                new EFResponse
                {
                    Id = 40,
                    Content = "Both a stack and a queue are FIFO (First In, First Out) data structures.",
                    IsCorrect = false,
                    QuestionId = 10
                },
                new EFResponse
                {
                    Id = 41,
                    Content = "The 'yield' keyword is used to create a generator function.",
                    IsCorrect = true,
                    QuestionId = 11
                },
                new EFResponse
                {
                    Id = 42,
                    Content = "The 'yield' keyword is used to return a value from a function.",
                    IsCorrect = false,
                    QuestionId = 11
                },
                new EFResponse
                {
                    Id = 43,
                    Content = "The 'yield' keyword is used to break out of a loop.",
                    IsCorrect = false,
                    QuestionId = 11
                },
                new EFResponse
                {
                    Id = 44,
                    Content = "The 'yield' keyword is used to define a variable.",
                    IsCorrect = false,
                    QuestionId = 11
                },
                new EFResponse
                {
                    Id = 45,
                    Content = "Recursion is a process in which a function calls itself.",
                    IsCorrect = true,
                    QuestionId = 12
                },
                new EFResponse
                {
                    Id = 46,
                    Content = "Recursion is a process in which a function calls another function.",
                    IsCorrect = false,
                    QuestionId = 12
                },
                new EFResponse
                {
                    Id = 47,
                    Content = "Recursion is a process in which a function is called by another function.",
                    IsCorrect = false,
                    QuestionId = 12
                },
                new EFResponse
                {
                    Id = 48,
                    Content = "Recursion is a process in which a function is called by itself.",
                    IsCorrect = false,
                    QuestionId = 12
                },
                new EFResponse
                {
                    Id = 49,
                    Content = "A list is mutable, while a tuple is immutable.",
                    IsCorrect = true,
                    QuestionId = 13
                },
                new EFResponse
                {
                    Id = 50,
                    Content = "A list is immutable, while a tuple is mutable.",
                    IsCorrect = false,
                    QuestionId = 13
                },
                new EFResponse
                {
                    Id = 51,
                    Content = "Both a list and a tuple are mutable.",
                    IsCorrect = false,
                    QuestionId = 13
                },
                new EFResponse
                {
                    Id = 52,
                    Content = "Both a list and a tuple are immutable.",
                    IsCorrect = false,
                    QuestionId = 13
                },
                new EFResponse
                {
                    Id = 53,
                    Content = "The 'final' keyword is used to declare constants.",
                    IsCorrect = true,
                    QuestionId = 14
                },
                new EFResponse
                {
                    Id = 54,
                    Content = "The 'final' keyword is used to declare variables.",
                    IsCorrect = false,
                    QuestionId = 14
                },
                new EFResponse
                {
                    Id = 55,
                    Content = "The 'final' keyword is used to declare methods.",
                    IsCorrect = false,
                    QuestionId = 14
                },
                new EFResponse
                {
                    Id = 56,
                    Content = "The 'final' keyword is used to declare classes.",
                    IsCorrect = false,
                    QuestionId = 14
                },
                new EFResponse
                {
                    Id = 57,
                    Content = "Inheritance is a mechanism in which one class acquires the properties and behaviors of another class.",
                    IsCorrect = true,
                    QuestionId = 15
                },
                new EFResponse
                {
                    Id = 58,
                    Content = "Inheritance is a mechanism in which one class acquires the properties and behaviors of multiple classes.",
                    IsCorrect = false,
                    QuestionId = 15
                },
                new EFResponse
                {
                    Id = 59,
                    Content = "Inheritance is a mechanism in which one class acquires the properties and behaviors of itself.",
                    IsCorrect = false,
                    QuestionId = 15
                },
                new EFResponse
                {
                    Id = 60,
                    Content = "Inheritance is a mechanism in which one class acquires the properties and behaviors of an interface.",
                    IsCorrect = false,
                    QuestionId = 15
                },
                new EFResponse
                {
                    Id = 61,
                    Content = "An array has a fixed size, while a linked list can grow and shrink dynamically.",
                    IsCorrect = true,
                    QuestionId = 16
                },
                new EFResponse
                {
                    Id = 62,
                    Content = "An array can grow and shrink dynamically, while a linked list has a fixed size.",
                    IsCorrect = false,
                    QuestionId = 16
                },
                new EFResponse
                {
                    Id = 63,
                    Content = "Both an array and a linked list have a fixed size.",
                    IsCorrect = false,
                    QuestionId = 16
                },
                new EFResponse
                {
                    Id = 64,
                    Content = "Both an array and a linked list can grow and shrink dynamically.",
                    IsCorrect = false,
                    QuestionId = 16
                },
                new EFResponse
                {
                    Id = 65,
                    Content = "The 'this' keyword refers to the current instance of a class.",
                    IsCorrect = true,
                    QuestionId = 17
                },
                new EFResponse
                {
                    Id = 66,
                    Content = "The 'this' keyword refers to the parent class.",
                    IsCorrect = false,
                    QuestionId = 17
                },
                new EFResponse
                {
                    Id = 67,
                    Content = "The 'this' keyword refers to the global object.",
                    IsCorrect = false,
                    QuestionId = 17
                },
                new EFResponse
                {
                    Id = 68,
                    Content = "The 'this' keyword refers to the current function.",
                    IsCorrect = false,
                    QuestionId = 17
                },
                new EFResponse
                {
                    Id = 69,
                    Content = "Encapsulation is the process of wrapping data and methods into a single unit.",
                    IsCorrect = true,
                    QuestionId = 18
                },
                new EFResponse
                {
                    Id = 70,
                    Content = "Encapsulation is the process of hiding data and methods from other classes.",
                    IsCorrect = false,
                    QuestionId = 18
                },
                new EFResponse
                {
                    Id = 71,
                    Content = "Encapsulation is the process of inheriting data and methods from other classes.",
                    IsCorrect = false,
                    QuestionId = 18
                },
                new EFResponse
                {
                    Id = 72,
                    Content = "Encapsulation is the process of overriding data and methods from other classes.",
                    IsCorrect = false,
                    QuestionId = 18
                },
                new EFResponse
                {
                    Id = 73,
                    Content = "A synchronous function is executed sequentially, while an asynchronous function is executed concurrently.",
                    IsCorrect = true,
                    QuestionId = 19
                },
                new EFResponse
                {
                    Id = 74,
                    Content = "A synchronous function is executed concurrently, while an asynchronous function is executed sequentially.",
                    IsCorrect = false,
                    QuestionId = 19
                },
                new EFResponse
                {
                    Id = 75,
                    Content = "Both a synchronous and an asynchronous function are executed sequentially.",
                    IsCorrect = false,
                    QuestionId = 19
                },
                new EFResponse
                {
                    Id = 76,
                    Content = "Both a synchronous and an asynchronous function are executed concurrently.",
                    IsCorrect = false,
                    QuestionId = 19
                },
                new EFResponse
                {
                    Id = 77,
                    Content = "The 'super' keyword is used to call the constructor of the parent class.",
                    IsCorrect = true,
                    QuestionId = 20
                },
                new EFResponse
                {
                    Id = 78,
                    Content = "The 'super' keyword is used to call the constructor of the current class.",
                    IsCorrect = false,
                    QuestionId = 20
                },
                new EFResponse
                {
                    Id = 79,
                    Content = "The 'super' keyword is used to call the constructor of the child class.",
                    IsCorrect = false,
                    QuestionId = 20
                },
                new EFResponse
                {
                    Id = 80,
                    Content = "The 'super' keyword is used to call the constructor of the sibling class.",
                    IsCorrect = false,
                    QuestionId = 20
                },
                new EFResponse
                {
                    Id = 81,
                    Content = "9",
                    IsCorrect = true,
                    QuestionId = 41
                },
                new EFResponse
                {
                    Id = 82,
                    Content = "6",
                    IsCorrect = false,
                    QuestionId = 41
                },
                new EFResponse
                {
                    Id = 83,
                    Content = "4",
                    IsCorrect = false,
                    QuestionId = 41
                },
                new EFResponse
                {
                    Id = 84,
                    Content = "2",
                    IsCorrect = false,
                    QuestionId = 41
                },
                new EFResponse
                {
                    Id = 85,
                    Content = "const is block-scoped, let is function-scoped",
                    IsCorrect = true,
                    QuestionId = 42
                },
                new EFResponse
                {
                    Id = 86,
                    Content = "Both are block-scoped",
                    IsCorrect = false,
                    QuestionId = 42
                },
                new EFResponse
                {
                    Id = 87,
                    Content = "Both are function-scoped",
                    IsCorrect = false,
                    QuestionId = 42
                },
                new EFResponse
                {
                    Id = 88,
                    Content = "const is function-scoped, let is block-scoped",
                    IsCorrect = false,
                    QuestionId = 42
                },
                new EFResponse
                {
                    Id = 89,
                    Content = "interface MyInterface { }",
                    IsCorrect = true,
                    QuestionId = 43
                },
                new EFResponse
                {
                    Id = 90,
                    Content = "function MyInterface() { }",
                    IsCorrect = false,
                    QuestionId = 43
                },
                new EFResponse
                {
                    Id = 91,
                    Content = "MyInterface = interface { }",
                    IsCorrect = false,
                    QuestionId = 43
                },
                new EFResponse
                {
                    Id = 92,
                    Content = "interface = MyInterface { }",
                    IsCorrect = false,
                    QuestionId = 43
                },
                new EFResponse
                {
                    Id = 93,
                    Content = "O(n log n)",
                    IsCorrect = true,
                    QuestionId = 44
                },
                new EFResponse
                {
                    Id = 94,
                    Content = "O(n)",
                    IsCorrect = false,
                    QuestionId = 44
                },
                new EFResponse
                {
                    Id = 95,
                    Content = "O(log n)",
                    IsCorrect = false,
                    QuestionId = 44
                },
                new EFResponse
                {
                    Id = 96,
                    Content = "O(1)",
                    IsCorrect = false,
                    QuestionId = 44
                },
                new EFResponse
                {
                    Id = 97,
                    Content = "A promise is an object that represents the eventual completion or failure of an asynchronous operation.",
                    IsCorrect = true,
                    QuestionId = 45
                },
                new EFResponse
                {
                    Id = 98,
                    Content = "A promise is an object that represents the immediate completion or failure of an asynchronous operation.",
                    IsCorrect = false,
                    QuestionId = 45
                },
                new EFResponse
                {
                    Id = 99,
                    Content = "A promise is an object that represents the eventual completion or failure of a synchronous operation.",
                    IsCorrect = false,
                    QuestionId = 45
                },
                new EFResponse
                {
                    Id = 100,
                    Content = "A promise is an object that represents the immediate completion or failure of a synchronous operation.",
                    IsCorrect = false,
                    QuestionId = 45
                },
                new EFResponse
                {
                    Id = 101,
                    Content = "Inheritance is a mechanism in which one class acquires the properties and behaviors of another class.",
                    IsCorrect = true,
                    QuestionId = 46
                },
                new EFResponse
                {
                    Id = 102,
                    Content = "Inheritance is a mechanism in which one class acquires the properties and behaviors of multiple classes.",
                    IsCorrect = false,
                    QuestionId = 46
                },
                new EFResponse
                {
                    Id = 103,
                    Content = "Inheritance is a mechanism in which one class acquires the properties and behaviors of itself.",
                    IsCorrect = false,
                    QuestionId = 46
                },
                new EFResponse
                {
                    Id = 104,
                    Content = "Inheritance is a mechanism in which one class acquires the properties and behaviors of an interface.",
                    IsCorrect = false,
                    QuestionId = 46
                },
                new EFResponse
                {
                    Id = 105,
                    Content = "An abstract class can have implementations for some of its members, but an interface cannot.",
                    IsCorrect = true,
                    QuestionId = 47
                },
                new EFResponse
                {
                    Id = 106,
                    Content = "An interface can have implementations for some of its members, but an abstract class cannot.",
                    IsCorrect = false,
                    QuestionId = 47
                },
                new EFResponse
                {
                    Id = 107,
                    Content = "Both an abstract class and an interface can have implementations for some of their members.",
                    IsCorrect = false,
                    QuestionId = 47
                },
                new EFResponse
                {
                    Id = 108,
                    Content = "Neither an abstract class nor an interface can have implementations for any of their members.",
                    IsCorrect = false,
                    QuestionId = 47
                },
                new EFResponse
                {
                    Id = 109,
                    Content = "The 'await' keyword is used to pause the execution of an asynchronous method until the awaited task completes.",
                    IsCorrect = true,
                    QuestionId = 48
                },
                new EFResponse
                {
                    Id = 110,
                    Content = "The 'await' keyword is used to pause the execution of a synchronous method until the awaited task completes.",
                    IsCorrect = false,
                    QuestionId = 48
                },
                new EFResponse
                {
                    Id = 111,
                    Content = "The 'await' keyword is used to pause the execution of an asynchronous method until the awaited task starts.",
                    IsCorrect = false,
                    QuestionId = 48
                },
                new EFResponse
                {
                    Id = 112,
                    Content = "The 'await' keyword is used to pause the execution of a synchronous method until the awaited task starts.",
                    IsCorrect = false,
                    QuestionId = 48
                },
                new EFResponse
                {
                    Id = 113,
                    Content = "Inversion of control is a design principle in which the control of objects or portions of a program is transferred to a container or framework.",
                    IsCorrect = true,
                    QuestionId = 49
                },
                new EFResponse
                {
                    Id = 114,
                    Content = "Inversion of control is a design principle in which the control of objects or portions of a program is transferred to the main method.",
                    IsCorrect = false,
                    QuestionId = 49
                },
                new EFResponse
                {
                    Id = 115,
                    Content = "Inversion of control is a design principle in which the control of objects or portions of a program is transferred to a class.",
                    IsCorrect = false,
                    QuestionId = 49
                },
                new EFResponse
                {
                    Id = 116,
                    Content = "Inversion of control is a design principle in which the control of objects or portions of a program is transferred to a function.",
                    IsCorrect = false,
                    QuestionId = 49
                },
                new EFResponse
                {
                    Id = 117,
                    Content = "A binary tree is a tree data structure in which each node has at most two children, while a binary search tree is a binary tree with the additional property that the left child is less than the parent and the right child is greater than the parent.",
                    IsCorrect = true,
                    QuestionId = 50
                },
                new EFResponse
                {
                    Id = 118,
                    Content = "A binary tree is a tree data structure in which each node has at most two children, while a binary search tree is a binary tree with the additional property that the left child is greater than the parent and the right child is less than the parent.",
                    IsCorrect = false,
                    QuestionId = 50
                },
                new EFResponse
                {
                    Id = 119,
                    Content = "A binary tree is a tree data structure in which each node has at most three children, while a binary search tree is a binary tree with the additional property that the left child is less than the parent and the right child is greater than the parent.",
                    IsCorrect = false,
                    QuestionId = 50
                },
                new EFResponse
                {
                    Id = 120,
                    Content = "A binary tree is a tree data structure in which each node has at most three children, while a binary search tree is a binary tree with the additional property that the left child is greater than the parent and the right child is less than the parent.",
                    IsCorrect = false,
                    QuestionId = 50
                },
                new EFResponse
                {
                    Id = 121,
                    Content = "The 'yield' keyword is used to create a generator function.",
                    IsCorrect = true,
                    QuestionId = 51
                },
                new EFResponse
                {
                    Id = 122,
                    Content = "The 'yield' keyword is used to return a value from a function.",
                    IsCorrect = false,
                    QuestionId = 51
                },
                new EFResponse
                {
                    Id = 123,
                    Content = "The 'yield' keyword is used to break out of a loop.",
                    IsCorrect = false,
                    QuestionId = 51
                },
                new EFResponse
                {
                    Id = 124,
                    Content = "The 'yield' keyword is used to define a variable.",
                    IsCorrect = false,
                    QuestionId = 51
                },
                new EFResponse
                {
                    Id = 125,
                    Content = "Memoization is an optimization technique used to speed up function calls by storing the results of expensive function calls and returning the cached result when the same inputs occur again.",
                    IsCorrect = true,
                    QuestionId = 52
                },
                new EFResponse
                {
                    Id = 126,
                    Content = "Memoization is an optimization technique used to slow down function calls by storing the results of expensive function calls and returning the cached result when the same inputs occur again.",
                    IsCorrect = false,
                    QuestionId = 52
                },
                new EFResponse
                {
                    Id = 127,
                    Content = "Memoization is an optimization technique used to speed up function calls by storing the results of inexpensive function calls and returning the cached result when the same inputs occur again.",
                    IsCorrect = false,
                    QuestionId = 52
                },
                new EFResponse
                {
                    Id = 128,
                    Content = "Memoization is an optimization technique used to slow down function calls by storing the results of inexpensive function calls and returning the cached result when the same inputs occur again.",
                    IsCorrect = false,
                    QuestionId = 52
                },
                new EFResponse
                {
                    Id = 129,
                    Content = "A dictionary is a collection of key-value pairs, while a list is an ordered collection of elements.",
                    IsCorrect = true,
                    QuestionId = 53
                },
                new EFResponse
                {
                    Id = 130,
                    Content = "A dictionary is an ordered collection of elements, while a list is a collection of key-value pairs.",
                    IsCorrect = false,
                    QuestionId = 53
                },
                new EFResponse
                {
                    Id = 131,
                    Content = "Both a dictionary and a list are collections of key-value pairs.",
                    IsCorrect = false,
                    QuestionId = 53
                },
                new EFResponse
                {
                    Id = 132,
                    Content = "Both a dictionary and a list are ordered collections of elements.",
                    IsCorrect = false,
                    QuestionId = 53
                },
                new EFResponse
                {
                    Id = 133,
                    Content = "The 'final' keyword is used to declare constants.",
                    IsCorrect = true,
                    QuestionId = 54
                },
                new EFResponse
                {
                    Id = 134,
                    Content = "The 'final' keyword is used to declare variables.",
                    IsCorrect = false,
                    QuestionId = 54
                },
                new EFResponse
                {
                    Id = 135,
                    Content = "The 'final' keyword is used to declare methods.",
                    IsCorrect = false,
                    QuestionId = 54
                },
                new EFResponse
                {
                    Id = 136,
                    Content = "The 'final' keyword is used to declare classes.",
                    IsCorrect = false,
                    QuestionId = 54
                },
                new EFResponse
                {
                    Id = 137,
                    Content = "Polymorphism is the ability of an object to take on many forms.",
                    IsCorrect = true,
                    QuestionId = 55
                },
                new EFResponse
                {
                    Id = 138,
                    Content = "Polymorphism is the ability of a function to take on many forms.",
                    IsCorrect = false,
                    QuestionId = 55
                },
                new EFResponse
                {
                    Id = 139,
                    Content = "Polymorphism is the ability of a variable to take on many forms.",
                    IsCorrect = false,
                    QuestionId = 55
                },
                new EFResponse
                {
                    Id = 140,
                    Content = "Polymorphism is the ability of a class to take on many forms.",
                    IsCorrect = false,
                    QuestionId = 55
                },
                new EFResponse
                {
                    Id = 141,
                    Content = "An array has a fixed size, while a list can grow and shrink dynamically.",
                    IsCorrect = true,
                    QuestionId = 56
                },
                new EFResponse
                {
                    Id = 142,
                    Content = "An array can grow and shrink dynamically, while a list has a fixed size.",
                    IsCorrect = false,
                    QuestionId = 56
                },
                new EFResponse
                {
                    Id = 143,
                    Content = "Both an array and a list have a fixed size.",
                    IsCorrect = false,
                    QuestionId = 56
                },
                new EFResponse
                {
                    Id = 144,
                    Content = "Both an array and a list can grow and shrink dynamically.",
                    IsCorrect = false,
                    QuestionId = 56
                },
                new EFResponse
                {
                    Id = 145,
                    Content = "The 'this' keyword refers to the current instance of a class.",
                    IsCorrect = true,
                    QuestionId = 57
                },
                new EFResponse
                {
                    Id = 146,
                    Content = "The 'this' keyword refers to the parent class.",
                    IsCorrect = false,
                    QuestionId = 57
                },
                new EFResponse
                {
                    Id = 147,
                    Content = "The 'this' keyword refers to the global object.",
                    IsCorrect = false,
                    QuestionId = 57
                },
                new EFResponse
                {
                    Id = 148,
                    Content = "The 'this' keyword refers to the current function.",
                    IsCorrect = false,
                    QuestionId = 57
                },
                new EFResponse
                {
                    Id = 149,
                    Content = "Encapsulation is the process of wrapping data and methods into a single unit.",
                    IsCorrect = true,
                    QuestionId = 58
                },
                new EFResponse
                {
                    Id = 150,
                    Content = "Encapsulation is the process of hiding data and methods from other classes.",
                    IsCorrect = false,
                    QuestionId = 58
                },
                new EFResponse
                {
                    Id = 151,
                    Content = "Encapsulation is the process of inheriting data and methods from other classes.",
                    IsCorrect = false,
                    QuestionId = 58
                },
                new EFResponse
                {
                    Id = 152,
                    Content = "Encapsulation is the process of overriding data and methods from other classes.",
                    IsCorrect = false,
                    QuestionId = 58
                },
                new EFResponse
                {
                    Id = 153,
                    Content = "A synchronous function is executed sequentially, while an asynchronous function is executed concurrently.",
                    IsCorrect = true,
                    QuestionId = 59
                },
                new EFResponse
                {
                    Id = 154,
                    Content = "A synchronous function is executed concurrently, while an asynchronous function is executed sequentially.",
                    IsCorrect = false,
                    QuestionId = 59
                },
                new EFResponse
                {
                    Id = 155,
                    Content = "Both a synchronous and an asynchronous function are executed sequentially.",
                    IsCorrect = false,
                    QuestionId = 59
                },
                new EFResponse
                {
                    Id = 156,
                    Content = "Both a synchronous and an asynchronous function are executed concurrently.",
                    IsCorrect = false,
                    QuestionId = 59
                },
                new EFResponse
                {
                    Id = 157,
                    Content = "The 'super' keyword is used to call the constructor of the parent class.",
                    IsCorrect = true,
                    QuestionId = 60
                },
                new EFResponse
                {
                    Id = 158,
                    Content = "The 'super' keyword is used to call the constructor of the current class.",
                    IsCorrect = false,
                    QuestionId = 60
                },
                new EFResponse
                {
                    Id = 159,
                    Content = "The 'super' keyword is used to call the constructor of the child class.",
                    IsCorrect = false,
                    QuestionId = 60
                },
                new EFResponse
                {
                    Id = 160,
                    Content = "The 'super' keyword is used to call the constructor of the sibling class.",
                    IsCorrect = false,
                    QuestionId = 60
                },
                 new EFResponse
                 {
                     Id = 161,
                     Content = "6",
                     IsCorrect = true,
                     QuestionId = 61
                 },
                new EFResponse
                {
                    Id = 162,
                    Content = "8",
                    IsCorrect = false,
                    QuestionId = 61
                },
                new EFResponse
                {
                    Id = 163,
                    Content = "4",
                    IsCorrect = false,
                    QuestionId = 61
                },
                new EFResponse
                {
                    Id = 164,
                    Content = "2",
                    IsCorrect = false,
                    QuestionId = 61
                },
                new EFResponse
                {
                    Id = 165,
                    Content = "To create a new array with the results of calling a provided function on every element in the calling array.",
                    IsCorrect = true,
                    QuestionId = 62
                },
                new EFResponse
                {
                    Id = 166,
                    Content = "To filter elements from an array.",
                    IsCorrect = false,
                    QuestionId = 62
                },
                new EFResponse
                {
                    Id = 167,
                    Content = "To reduce the array to a single value.",
                    IsCorrect = false,
                    QuestionId = 62
                },
                new EFResponse
                {
                    Id = 168,
                    Content = "To find an element in the array.",
                    IsCorrect = false,
                    QuestionId = 62
                },
                new EFResponse
                {
                    Id = 169,
                    Content = "O(n log n)",
                    IsCorrect = true,
                    QuestionId = 63
                },
                new EFResponse
                {
                    Id = 170,
                    Content = "O(n)",
                    IsCorrect = false,
                    QuestionId = 63
                },
                new EFResponse
                {
                    Id = 171,
                    Content = "O(log n)",
                    IsCorrect = false,
                    QuestionId = 63
                },
                new EFResponse
                {
                    Id = 172,
                    Content = "O(1)",
                    IsCorrect = false,
                    QuestionId = 63
                },
                new EFResponse
                {
                    Id = 173,
                    Content = "HelloWorld",
                    IsCorrect = true,
                    QuestionId = 64
                },
                new EFResponse
                {
                    Id = 174,
                    Content = "Hello World",
                    IsCorrect = false,
                    QuestionId = 64
                },
                new EFResponse
                {
                    Id = 175,
                    Content = "Hello+World",
                    IsCorrect = false,
                    QuestionId = 64
                },
                new EFResponse
                {
                    Id = 176,
                    Content = "HelloWorld",
                    IsCorrect = false,
                    QuestionId = 64
                },
                new EFResponse
                {
                    Id = 177,
                    Content = "To create a new array with all elements that pass the test implemented by the provided function.",
                    IsCorrect = true,
                    QuestionId = 65
                },
                new EFResponse
                {
                    Id = 178,
                    Content = "To map elements from an array.",
                    IsCorrect = false,
                    QuestionId = 65
                },
                new EFResponse
                {
                    Id = 179,
                    Content = "To reduce the array to a single value.",
                    IsCorrect = false,
                    QuestionId = 65
                },
                new EFResponse
                {
                    Id = 180,
                    Content = "To find an element in the array.",
                    IsCorrect = false,
                    QuestionId = 65
                },
                new EFResponse
                {
                    Id = 181,
                    Content = "O(n^2)",
                    IsCorrect = true,
                    QuestionId = 66
                },
                new EFResponse
                {
                    Id = 182,
                    Content = "O(n log n)",
                    IsCorrect = false,
                    QuestionId = 66
                },
                new EFResponse
                {
                    Id = 183,
                    Content = "O(log n)",
                    IsCorrect = false,
                    QuestionId = 66
                },
                new EFResponse
                {
                    Id = 184,
                    Content = "O(1)",
                    IsCorrect = false,
                    QuestionId = 66
                },
                new EFResponse
                {
                    Id = 185,
                    Content = "3",
                    IsCorrect = true,
                    QuestionId = 67
                },
                new EFResponse
                {
                    Id = 186,
                    Content = "3.33",
                    IsCorrect = false,
                    QuestionId = 67
                },
                new EFResponse
                {
                    Id = 187,
                    Content = "3.0",
                    IsCorrect = false,
                    QuestionId = 67
                },
                new EFResponse
                {
                    Id = 188,
                    Content = "3.333",
                    IsCorrect = false,
                    QuestionId = 67
                },
                new EFResponse
                {
                    Id = 189,
                    Content = "To apply a function against an accumulator and each element in the array to reduce it to a single value.",
                    IsCorrect = true,
                    QuestionId = 68
                },
                new EFResponse
                {
                    Id = 190,
                    Content = "To map elements from an array.",
                    IsCorrect = false,
                    QuestionId = 68
                },
                new EFResponse
                {
                    Id = 191,
                    Content = "To filter elements from an array.",
                    IsCorrect = false,
                    QuestionId = 68
                },
                new EFResponse
                {
                    Id = 192,
                    Content = "To find an element in the array.",
                    IsCorrect = false,
                    QuestionId = 68
                },
                new EFResponse
                {
                    Id = 193,
                    Content = "O(n^2)",
                    IsCorrect = true,
                    QuestionId = 69
                },
                new EFResponse
                {
                    Id = 194,
                    Content = "O(n log n)",
                    IsCorrect = false,
                    QuestionId = 69
                },
                new EFResponse
                {
                    Id = 195,
                    Content = "O(log n)",
                    IsCorrect = false,
                    QuestionId = 69
                },
                new EFResponse
                {
                    Id = 196,
                    Content = "O(1)",
                    IsCorrect = false,
                    QuestionId = 69
                },
                new EFResponse
                {
                    Id = 197,
                    Content = "2",
                    IsCorrect = true,
                    QuestionId = 70
                },
                new EFResponse
                {
                    Id = 198,
                    Content = "2.5",
                    IsCorrect = false,
                    QuestionId = 70
                },
                new EFResponse
                {
                    Id = 199,
                    Content = "3",
                    IsCorrect = false,
                    QuestionId = 70
                },
                new EFResponse
                {
                    Id = 200,
                    Content = "3.5",
                    IsCorrect = false,
                    QuestionId = 70
                },
                new EFResponse
                {
                    Id = 201,
                    Content = "To return the value of the first element in the array that satisfies the provided testing function.",
                    IsCorrect = true,
                    QuestionId = 71
                },
                new EFResponse
                {
                    Id = 202,
                    Content = "To map elements from an array.",
                    IsCorrect = false,
                    QuestionId = 71
                },
                new EFResponse
                {
                    Id = 203,
                    Content = "To filter elements from an array.",
                    IsCorrect = false,
                    QuestionId = 71
                },
                new EFResponse
                {
                    Id = 204,
                    Content = "To reduce the array to a single value.",
                    IsCorrect = false,
                    QuestionId = 71
                },
                new EFResponse
                {
                    Id = 205,
                    Content = "O(n^2)",
                    IsCorrect = true,
                    QuestionId = 72
                },
                new EFResponse
                {
                    Id = 206,
                    Content = "O(n log n)",
                    IsCorrect = false,
                    QuestionId = 72
                },
                new EFResponse
                {
                    Id = 207,
                    Content = "O(log n)",
                    IsCorrect = false,
                    QuestionId = 72
                },
                new EFResponse
                {
                    Id = 208,
                    Content = "O(1)",
                    IsCorrect = false,
                    QuestionId = 72
                },
                new EFResponse
                {
                    Id = 209,
                    Content = "1",
                    IsCorrect = true,
                    QuestionId = 73
                },
                new EFResponse
                {
                    Id = 210,
                    Content = "2",
                    IsCorrect = false,
                    QuestionId = 73
                },
                new EFResponse
                {
                    Id = 211,
                    Content = "3",
                    IsCorrect = false,
                    QuestionId = 73
                },
                new EFResponse
                {
                    Id = 212,
                    Content = "4",
                    IsCorrect = false,
                    QuestionId = 73
                },
                new EFResponse
                {
                    Id = 213,
                    Content = "To test whether all elements in the array pass the test implemented by the provided function.",
                    IsCorrect = true,
                    QuestionId = 74
                },
                new EFResponse
                {
                    Id = 214,
                    Content = "To map elements from an array.",
                    IsCorrect = false,
                    QuestionId = 74
                },
                new EFResponse
                {
                    Id = 215,
                    Content = "To filter elements from an array.",
                    IsCorrect = false,
                    QuestionId = 74
                },
                new EFResponse
                {
                    Id = 216,
                    Content = "To reduce the array to a single value.",
                    IsCorrect = false,
                    QuestionId = 74
                },
                new EFResponse
                {
                    Id = 217,
                    Content = "O(n log n)",
                    IsCorrect = true,
                    QuestionId = 75
                },
                new EFResponse
                {
                    Id = 218,
                    Content = "O(n)",
                    IsCorrect = false,
                    QuestionId = 75
                },
                new EFResponse
                {
                    Id = 219,
                    Content = "O(log n)",
                    IsCorrect = false,
                    QuestionId = 75
                },
                new EFResponse
                {
                    Id = 220,
                    Content = "O(1)",
                    IsCorrect = false,
                    QuestionId = 75
                },
                new EFResponse
                {
                    Id = 221,
                    Content = "8",
                    IsCorrect = true,
                    QuestionId = 76
                },
                new EFResponse
                {
                    Id = 222,
                    Content = "6",
                    IsCorrect = false,
                    QuestionId = 76
                },
                new EFResponse
                {
                    Id = 223,
                    Content = "4",
                    IsCorrect = false,
                    QuestionId = 76
                },
                new EFResponse
                {
                    Id = 224,
                    Content = "2",
                    IsCorrect = false,
                    QuestionId = 76
                },
                new EFResponse
                {
                    Id = 225,
                    Content = "To test whether at least one element in the array passes the test implemented by the provided function.",
                    IsCorrect = true,
                    QuestionId = 77
                },
                new EFResponse
                {
                    Id = 226,
                    Content = "To map elements from an array.",
                    IsCorrect = false,
                    QuestionId = 77
                },
                new EFResponse
                {
                    Id = 227,
                    Content = "To filter elements from an array.",
                    IsCorrect = false,
                    QuestionId = 77
                },
                new EFResponse
                {
                    Id = 228,
                    Content = "To reduce the array to a single value.",
                    IsCorrect = false,
                    QuestionId = 77
                },
                new EFResponse
                {
                    Id = 229,
                    Content = "O(n log n)",
                    IsCorrect = true,
                    QuestionId = 78
                },
                new EFResponse
                {
                    Id = 230,
                    Content = "O(n)",
                    IsCorrect = false,
                    QuestionId = 78
                },
                new EFResponse
                {
                    Id = 231,
                    Content = "O(log n)",
                    IsCorrect = false,
                    QuestionId = 78
                },
                new EFResponse
                {
                    Id = 232,
                    Content = "O(1)",
                    IsCorrect = false,
                    QuestionId = 78
                },
                new EFResponse
                {
                    Id = 233,
                    Content = "It creates a new array with the results of calling a provided function on every element in the calling array.",
                    IsCorrect = true,
                    QuestionId = 79
                },
                new EFResponse
                {
                    Id = 234,
                    Content = "It creates a new array with all elements that pass the test implemented by the provided function.",
                    IsCorrect = false,
                    QuestionId = 79
                },
                new EFResponse
                {
                    Id = 235,
                    Content = "It executes a reducer function on each element of the array, resulting in a single output value.",
                    IsCorrect = false,
                    QuestionId = 79
                },
                new EFResponse
                {
                    Id = 236,
                    Content = "It returns the first element in the array that satisfies the provided testing function.",
                    IsCorrect = false,
                    QuestionId = 79
                },
                new EFResponse
                {
                    Id = 237,
                    Content = "2",
                    IsCorrect = true,
                    QuestionId = 80
                },
                new EFResponse
                {
                    Id = 238,
                    Content = "2.5",
                    IsCorrect = false,
                    QuestionId = 80
                },
                new EFResponse
                {
                    Id = 239,
                    Content = "3",
                    IsCorrect = false,
                    QuestionId = 80
                },
                new EFResponse
                {
                    Id = 240,
                    Content = "1",
                    IsCorrect = false,
                    QuestionId = 80
                },
                new EFResponse
                {
                    Id = 241,
                    Content = "O(n log n)",
                    IsCorrect = true,
                    QuestionId = 81
                },
                new EFResponse
                {
                    Id = 242,
                    Content = "O(n)",
                    IsCorrect = false,
                    QuestionId = 81
                },
                new EFResponse
                {
                    Id = 243,
                    Content = "O(log n)",
                    IsCorrect = false,
                    QuestionId = 81
                },
                new EFResponse
                {
                    Id = 244,
                    Content = "O(1)",
                    IsCorrect = false,
                    QuestionId = 81
                },
                new EFResponse
                {
                    Id = 245,
                    Content = "It creates a new array with all elements that pass the test implemented by the provided function.",
                    IsCorrect = true,
                    QuestionId = 82
                },
                new EFResponse
                {
                    Id = 246,
                    Content = "It creates a new array with the results of calling a provided function on every element in the calling array.",
                    IsCorrect = false,
                    QuestionId = 82
                },
                new EFResponse
                {
                    Id = 247,
                    Content = "It executes a reducer function on each element of the array, resulting in a single output value.",
                    IsCorrect = false,
                    QuestionId = 82
                },
                new EFResponse
                {
                    Id = 248,
                    Content = "It returns the first element in the array that satisfies the provided testing function.",
                    IsCorrect = false,
                    QuestionId = 82
                },
                new EFResponse
                {
                    Id = 249,
                    Content = "1",
                    IsCorrect = true,
                    QuestionId = 83
                },
                new EFResponse
                {
                    Id = 250,
                    Content = "2",
                    IsCorrect = false,
                    QuestionId = 83
                },
                new EFResponse
                {
                    Id = 251,
                    Content = "3",
                    IsCorrect = false,
                    QuestionId = 83
                },
                new EFResponse
                {
                    Id = 252,
                    Content = "4",
                    IsCorrect = false,
                    QuestionId = 83
                },
                new EFResponse
                {
                    Id = 253,
                    Content = "O(n^2)",
                    IsCorrect = true,
                    QuestionId = 84
                },
                new EFResponse
                {
                    Id = 254,
                    Content = "O(n log n)",
                    IsCorrect = false,
                    QuestionId = 84
                },
                new EFResponse
                {
                    Id = 255,
                    Content = "O(n)",
                    IsCorrect = false,
                    QuestionId = 84
                },
                new EFResponse
                {
                    Id = 256,
                    Content = "O(log n)",
                    IsCorrect = false,
                    QuestionId = 84
                },
                new EFResponse
                {
                    Id = 257,
                    Content = "It executes a reducer function on each element of the array, resulting in a single output value.",
                    IsCorrect = true,
                    QuestionId = 85
                },
                new EFResponse
                {
                    Id = 258,
                    Content = "It creates a new array with the results of calling a provided function on every element in the calling array.",
                    IsCorrect = false,
                    QuestionId = 85
                },
                new EFResponse
                {
                    Id = 259,
                    Content = "It creates a new array with all elements that pass the test implemented by the provided function.",
                    IsCorrect = false,
                    QuestionId = 85
                },
                new EFResponse
                {
                    Id = 260,
                    Content = "It returns the first element in the array that satisfies the provided testing function.",
                    IsCorrect = false,
                    QuestionId = 85
                },
                new EFResponse
                {
                    Id = 261,
                    Content = "100",
                    IsCorrect = true,
                    QuestionId = 86
                },
                new EFResponse
                {
                    Id = 262,
                    Content = "10",
                    IsCorrect = false,
                    QuestionId = 86
                },
                new EFResponse
                {
                    Id = 263,
                    Content = "20",
                    IsCorrect = false,
                    QuestionId = 86
                },
                new EFResponse
                {
                    Id = 264,
                    Content = "50",
                    IsCorrect = false,
                    QuestionId = 86
                },
                new EFResponse
                {
                    Id = 265,
                    Content = "O(n^2)",
                    IsCorrect = true,
                    QuestionId = 87
                },
                new EFResponse
                {
                    Id = 266,
                    Content = "O(n log n)",
                    IsCorrect = false,
                    QuestionId = 87
                },
                new EFResponse
                {
                    Id = 267,
                    Content = "O(n)",
                    IsCorrect = false,
                    QuestionId = 87
                },
                new EFResponse
                {
                    Id = 268,
                    Content = "O(log n)",
                    IsCorrect = false,
                    QuestionId = 87
                },
                new EFResponse
                {
                    Id = 269,
                    Content = "It returns the first element in the array that satisfies the provided testing function.",
                    IsCorrect = true,
                    QuestionId = 88
                },
                new EFResponse
                {
                    Id = 270,
                    Content = "It creates a new array with the results of calling a provided function on every element in the calling array.",
                    IsCorrect = false,
                    QuestionId = 88
                },
                new EFResponse
                {
                    Id = 271,
                    Content = "It creates a new array with all elements that pass the test implemented by the provided function.",
                    IsCorrect = false,
                    QuestionId = 88
                },
                new EFResponse
                {
                    Id = 272,
                    Content = "It executes a reducer function on each element of the array, resulting in a single output value.",
                    IsCorrect = false,
                    QuestionId = 88
                },
                new EFResponse
                {
                    Id = 273,
                    Content = "4",
                    IsCorrect = true,
                    QuestionId = 89
                },
                new EFResponse
                {
                    Id = 274,
                    Content = "4.5",
                    IsCorrect = false,
                    QuestionId = 89
                },
                new EFResponse
                {
                    Id = 275,
                    Content = "5",
                    IsCorrect = false,
                    QuestionId = 89
                },
                new EFResponse
                {
                    Id = 276,
                    Content = "3",
                    IsCorrect = false,
                    QuestionId = 89
                },
                new EFResponse
                {
                    Id = 277,
                    Content = "O(n^2)",
                    IsCorrect = true,
                    QuestionId = 90
                },
                new EFResponse
                {
                    Id = 278,
                    Content = "O(n log n)",
                    IsCorrect = false,
                    QuestionId = 90
                },
                new EFResponse
                {
                    Id = 279,
                    Content = "O(n)",
                    IsCorrect = false,
                    QuestionId = 90
                },
                new EFResponse
                {
                    Id = 280,
                    Content = "O(log n)",
                    IsCorrect = false,
                    QuestionId = 90
                },
                new EFResponse
                {
                    Id = 281,
                    Content = "It returns true if every element in the array satisfies the provided testing function.",
                    IsCorrect = true,
                    QuestionId = 91
                },
                new EFResponse
                {
                    Id = 282,
                    Content = "It creates a new array with the results of calling a provided function on every element in the calling array.",
                    IsCorrect = false,
                    QuestionId = 91
                },
                new EFResponse
                {
                    Id = 283,
                    Content = "It creates a new array with all elements that pass the test implemented by the provided function.",
                    IsCorrect = false,
                    QuestionId = 91
                },
                new EFResponse
                {
                    Id = 284,
                    Content = "It executes a reducer function on each element of the array, resulting in a single output value.",
                    IsCorrect = false,
                    QuestionId = 91
                },
                new EFResponse
                {
                    Id = 285,
                    Content = "4",
                    IsCorrect = true,
                    QuestionId = 92
                },
                new EFResponse
                {
                    Id = 286,
                    Content = "4.5",
                    IsCorrect = false,
                    QuestionId = 92
                },
                new EFResponse
                {
                    Id = 287,
                    Content = "5",
                    IsCorrect = false,
                    QuestionId = 92
                },
                new EFResponse
                {
                    Id = 288,
                    Content = "3",
                    IsCorrect = false,
                    QuestionId = 92
                },
                new EFResponse
                {
                    Id = 289,
                    Content = "O(n log n)",
                    IsCorrect = true,
                    QuestionId = 93
                },
                new EFResponse
                {
                    Id = 290,
                    Content = "O(n)",
                    IsCorrect = false,
                    QuestionId = 93
                },
                new EFResponse
                {
                    Id = 291,
                    Content = "O(log n)",
                    IsCorrect = false,
                    QuestionId = 93
                },
                new EFResponse
                {
                    Id = 292,
                    Content = "O(1)",
                    IsCorrect = false,
                    QuestionId = 93
                },
                new EFResponse
                {
                    Id = 293,
                    Content = "It returns true if at least one element in the array satisfies the provided testing function.",
                    IsCorrect = true,
                    QuestionId = 94
                },
                new EFResponse
                {
                    Id = 294,
                    Content = "It creates a new array with the results of calling a provided function on every element in the calling array.",
                    IsCorrect = false,
                    QuestionId = 94
                },
                new EFResponse
                {
                    Id = 295,
                    Content = "It creates a new array with all elements that pass the test implemented by the provided function.",
                    IsCorrect = false,
                    QuestionId = 94
                },
                new EFResponse
                {
                    Id = 296,
                    Content = "It executes a reducer function on each element of the array, resulting in a single output value.",
                    IsCorrect = false,
                    QuestionId = 94
                },
                new EFResponse
                {
                    Id = 297,
                    Content = "3",
                    IsCorrect = true,
                    QuestionId = 95
                },
                new EFResponse
                {
                    Id = 298,
                    Content = "3.5",
                    IsCorrect = false,
                    QuestionId = 95
                },
                new EFResponse
                {
                    Id = 299,
                    Content = "4",
                    IsCorrect = false,
                    QuestionId = 95
                },
                new EFResponse
                {
                    Id = 300,
                    Content = "2",
                    IsCorrect = false,
                    QuestionId = 95
                },
                new EFResponse
                {
                    Id = 301,
                    Content = "O(n)",
                    IsCorrect = true,
                    QuestionId = 96
                },
                new EFResponse
                {
                    Id = 302,
                    Content = "O(n log n)",
                    IsCorrect = false,
                    QuestionId = 96
                },
                new EFResponse
                {
                    Id = 303,
                    Content = "O(log n)",
                    IsCorrect = false,
                    QuestionId = 96
                },
                new EFResponse
                {
                    Id = 304,
                    Content = "O(1)",
                    IsCorrect = false,
                    QuestionId = 96
                },
                new EFResponse
                {
                    Id = 305,
                    Content = "It executes a provided function once for each array element.",
                    IsCorrect = true,
                    QuestionId = 97
                },
                new EFResponse
                {
                    Id = 306,
                    Content = "It creates a new array with the results of calling a provided function on every element in the calling array.",
                    IsCorrect = false,
                    QuestionId = 97
                },
                new EFResponse
                {
                    Id = 307,
                    Content = "It creates a new array with all elements that pass the test implemented by the provided function.",
                    IsCorrect = false,
                    QuestionId = 97
                },
                new EFResponse
                {
                    Id = 308,
                    Content = "It returns the first element in the array that satisfies the provided testing function.",
                    IsCorrect = false,
                    QuestionId = 97
                }, new EFResponse
                {
                    Id = 309,
                    Content = "It creates a new array with the results of calling a provided function on every element in the calling array.",
                    IsCorrect = true,
                    QuestionId = 98
                },
                new EFResponse
                {
                    Id = 310,
                    Content = "It executes a provided function once for each array element.",
                    IsCorrect = false,
                    QuestionId = 98
                },
                new EFResponse
                {
                    Id = 311,
                    Content = "It creates a new array with all elements that pass the test implemented by the provided function.",
                    IsCorrect = false,
                    QuestionId = 98
                },
                new EFResponse
                {
                    Id = 312,
                    Content = "It returns the first element in the array that satisfies the provided testing function.",
                    IsCorrect = false,
                    QuestionId = 98
                },
                new EFResponse
                {
                    Id = 313,
                    Content = "It creates a new array with all elements that pass the test implemented by the provided function.",
                    IsCorrect = true,
                    QuestionId = 99
                },
                new EFResponse
                {
                    Id = 314,
                    Content = "It executes a provided function once for each array element.",
                    IsCorrect = false,
                    QuestionId = 99
                },
                new EFResponse
                {
                    Id = 315,
                    Content = "It creates a new array with the results of calling a provided function on every element in the calling array.",
                    IsCorrect = false,
                    QuestionId = 99
                },
                new EFResponse
                {
                    Id = 316,
                    Content = "It returns the first element in the array that satisfies the provided testing function.",
                    IsCorrect = false,
                    QuestionId = 99
                },
                new EFResponse
                {
                    Id = 317,
                    Content = "It executes a provided function once for each array element.",
                    IsCorrect = true,
                    QuestionId = 100
                },
                new EFResponse
                {
                    Id = 318,
                    Content = "It creates a new array with the results of calling a provided function on every element in the calling array.",
                    IsCorrect = false,
                    QuestionId = 100
                },
                new EFResponse
                {
                    Id = 319,
                    Content = "It creates a new array with all elements that pass the test implemented by the provided function.",
                    IsCorrect = false,
                    QuestionId = 100
                },
                new EFResponse
                {
                    Id = 320,
                    Content = "It returns the first element in the array that satisfies the provided testing function.",
                    IsCorrect = false,
                    QuestionId = 100
                },
                new EFResponse
                {
                    Id = 321,
                    Content = "It creates a new array with the results of calling a provided function on every element in the calling array.",
                    IsCorrect = true,
                    QuestionId = 101
                },
                new EFResponse
                {
                    Id = 322,
                    Content = "It executes a provided function once for each array element.",
                    IsCorrect = false,
                    QuestionId = 101
                },
                new EFResponse
                {
                    Id = 323,
                    Content = "It creates a new array with all elements that pass the test implemented by the provided function.",
                    IsCorrect = false,
                    QuestionId = 101
                },
                new EFResponse
                {
                    Id = 324,
                    Content = "It returns the first element in the array that satisfies the provided testing function.",
                    IsCorrect = false,
                    QuestionId = 101
                },
                new EFResponse
                {
                    Id = 325,
                    Content = "It executes a provided function once for each array element.",
                    IsCorrect = true,
                    QuestionId = 102
                },
                new EFResponse
                {
                    Id = 326,
                    Content = "It creates a new array with the results of calling a provided function on every element in the calling array.",
                    IsCorrect = false,
                    QuestionId = 102
                },
                new EFResponse
                {
                    Id = 327,
                    Content = "It creates a new array with all elements that pass the test implemented by the provided function.",
                    IsCorrect = false,
                    QuestionId = 102
                },
                new EFResponse
                {
                    Id = 328,
                    Content = "It returns the first element in the array that satisfies the provided testing function.",
                    IsCorrect = false,
                    QuestionId = 102
                },
                new EFResponse
                {
                    Id = 329,
                    Content = "It creates a new array with the results of calling a provided function on every element in the calling array.",
                    IsCorrect = true,
                    QuestionId = 103
                },
                new EFResponse
                {
                    Id = 330,
                    Content = "It executes a provided function once for each array element.",
                    IsCorrect = false,
                    QuestionId = 103
                },
                new EFResponse
                {
                    Id = 331,
                    Content = "It creates a new array with all elements that pass the test implemented by the provided function.",
                    IsCorrect = false,
                    QuestionId = 103
                },
                new EFResponse
                {
                    Id = 332,
                    Content = "It returns the first element in the array that satisfies the provided testing function.",
                    IsCorrect = false,
                    QuestionId = 103
                },
                new EFResponse
                {
                    Id = 333,
                    Content = "It executes a provided function once for each array element.",
                    IsCorrect = true,
                    QuestionId = 104
                },
                new EFResponse
                {
                    Id = 334,
                    Content = "It creates a new array with the results of calling a provided function on every element in the calling array.",
                    IsCorrect = false,
                    QuestionId = 104
                },
                new EFResponse
                {
                    Id = 335,
                    Content = "It creates a new array with all elements that pass the test implemented by the provided function.",
                    IsCorrect = false,
                    QuestionId = 104
                },
                new EFResponse
                {
                    Id = 336,
                    Content = "It returns the first element in the array that satisfies the provided testing function.",
                    IsCorrect = false,
                    QuestionId = 104
                },
                new EFResponse
                {
                    Id = 337,
                    Content = "It creates a new array with the results of calling a provided function on every element in the calling array.",
                    IsCorrect = true,
                    QuestionId = 105
                },
                new EFResponse
                {
                    Id = 338,
                    Content = "It executes a provided function once for each array element.",
                    IsCorrect = false,
                    QuestionId = 105
                },
                new EFResponse
                {
                    Id = 339,
                    Content = "It creates a new array with all elements that pass the test implemented by the provided function.",
                    IsCorrect = false,
                    QuestionId = 105
                },
                new EFResponse
                {
                    Id = 340,
                    Content = "It returns the first element in the array that satisfies the provided testing function.",
                    IsCorrect = false,
                    QuestionId = 105
                },
                new EFResponse
                {
                    Id = 341,
                    Content = "It executes a provided function once for each array element.",
                    IsCorrect = true,
                    QuestionId = 106
                },
                new EFResponse
                {
                    Id = 342,
                    Content = "It creates a new array with the results of calling a provided function on every element in the calling array.",
                    IsCorrect = false,
                    QuestionId = 106
                },
                new EFResponse
                {
                    Id = 343,
                    Content = "It creates a new array with all elements that pass the test implemented by the provided function.",
                    IsCorrect = false,
                    QuestionId = 106
                },
                new EFResponse
                {
                    Id = 344,
                    Content = "It returns the first element in the array that satisfies the provided testing function.",
                    IsCorrect = false,
                    QuestionId = 106
                },
                new EFResponse
                {
                    Id = 345,
                    Content = "It executes a provided function once for each array element.",
                    IsCorrect = true,
                    QuestionId = 107
                },
                new EFResponse
                {
                    Id = 346,
                    Content = "It creates a new array with the results of calling a provided function on every element in the calling array.",
                    IsCorrect = false,
                    QuestionId = 107
                },
                new EFResponse
                {
                    Id = 347,
                    Content = "It creates a new array with all elements that pass the test implemented by the provided function.",
                    IsCorrect = false,
                    QuestionId = 107
                },
                new EFResponse
                {
                    Id = 348,
                    Content = "It returns the first element in the array that satisfies the provided testing function.",
                    IsCorrect = false,
                    QuestionId = 107
                },
                new EFResponse
                {
                    Id = 349,
                    Content = "It executes a provided function once for each array element.",
                    IsCorrect = true,
                    QuestionId = 108
                },
                new EFResponse
                {
                    Id = 350,
                    Content = "It creates a new array with the results of calling a provided function on every element in the calling array.",
                    IsCorrect = false,
                    QuestionId = 108
                },
                new EFResponse
                {
                    Id = 351,
                    Content = "It creates a new array with all elements that pass the test implemented by the provided function.",
                    IsCorrect = false,
                    QuestionId = 108
                },
                new EFResponse
                {
                    Id = 352,
                    Content = "It returns the first element in the array that satisfies the provided testing function.",
                    IsCorrect = false,
                    QuestionId = 108
                },
                new EFResponse
                {
                    Id = 353,
                    Content = "It executes a provided function once for each array element.",
                    IsCorrect = true,
                    QuestionId = 109
                },
                new EFResponse
                {
                    Id = 354,
                    Content = "It creates a new array with the results of calling a provided function on every element in the calling array.",
                    IsCorrect = false,
                    QuestionId = 109
                },
                new EFResponse
                {
                    Id = 355,
                    Content = "It creates a new array with all elements that pass the test implemented by the provided function.",
                    IsCorrect = false,
                    QuestionId = 109
                },
                new EFResponse
                {
                    Id = 356,
                    Content = "It returns the first element in the array that satisfies the provided testing function.",
                    IsCorrect = false,
                    QuestionId = 109
                },
                new EFResponse
                {
                    Id = 357,
                    Content = "It executes a provided function once for each array element.",
                    IsCorrect = true,
                    QuestionId = 110
                },
                new EFResponse
                {
                    Id = 358,
                    Content = "It creates a new array with the results of calling a provided function on every element in the calling array.",
                    IsCorrect = false,
                    QuestionId = 110
                },
                new EFResponse
                {
                    Id = 359,
                    Content = "It creates a new array with all elements that pass the test implemented by the provided function.",
                    IsCorrect = false,
                    QuestionId = 110
                },
                new EFResponse
                {
                    Id = 360,
                    Content = "It returns the first element in the array that satisfies the provided testing function.",
                    IsCorrect = false,
                    QuestionId = 110
                },
                new EFResponse
                {
                    Id = 361,
                    Content = "It executes a provided function once for each array element.",
                    IsCorrect = true,
                    QuestionId = 111
                },
                new EFResponse
                {
                    Id = 362,
                    Content = "It creates a new array with the results of calling a provided function on every element in the calling array.",
                    IsCorrect = false,
                    QuestionId = 111
                },
                new EFResponse
                {
                    Id = 363,
                    Content = "It creates a new array with all elements that pass the test implemented by the provided function.",
                    IsCorrect = false,
                    QuestionId = 111
                },
                new EFResponse
                {
                    Id = 364,
                    Content = "It returns the first element in the array that satisfies the provided testing function.",
                    IsCorrect = false,
                    QuestionId = 111
                },
                new EFResponse
                {
                    Id = 365,
                    Content = "It executes a provided function once for each array element.",
                    IsCorrect = true,
                    QuestionId = 112
                },
                new EFResponse
                {
                    Id = 366,
                    Content = "It creates a new array with the results of calling a provided function on every element in the calling array.",
                    IsCorrect = false,
                    QuestionId = 112
                },
                new EFResponse
                {
                    Id = 367,
                    Content = "It creates a new array with all elements that pass the test implemented by the provided function.",
                    IsCorrect = false,
                    QuestionId = 112
                },
                new EFResponse
                {
                    Id = 368,
                    Content = "It returns the first element in the array that satisfies the provided testing function.",
                    IsCorrect = false,
                    QuestionId = 112
                },
                new EFResponse
                {
                    Id = 369,
                    Content = "It executes a provided function once for each array element.",
                    IsCorrect = true,
                    QuestionId = 113
                },
                new EFResponse
                {
                    Id = 370,
                    Content = "It creates a new array with the results of calling a provided function on every element in the calling array.",
                    IsCorrect = false,
                    QuestionId = 113
                },
                new EFResponse
                {
                    Id = 371,
                    Content = "It creates a new array with all elements that pass the test implemented by the provided function.",
                    IsCorrect = false,
                    QuestionId = 113
                },
                new EFResponse
                {
                    Id = 372,
                    Content = "It returns the first element in the array that satisfies the provided testing function.",
                    IsCorrect = false,
                    QuestionId = 113
                },
                new EFResponse
                {
                    Id = 373,
                    Content = "It executes a provided function once for each array element.",
                    IsCorrect = true,
                    QuestionId = 114
                },
                new EFResponse
                {
                    Id = 374,
                    Content = "It creates a new array with the results of calling a provided function on every element in the calling array.",
                    IsCorrect = false,
                    QuestionId = 114
                },
                new EFResponse
                {
                    Id = 375,
                    Content = "It creates a new array with all elements that pass the test implemented by the provided function.",
                    IsCorrect = false,
                    QuestionId = 114
                },
                new EFResponse
                {
                    Id = 376,
                    Content = "It returns the first element in the array that satisfies the provided testing function.",
                    IsCorrect = false,
                    QuestionId = 114
                },
                new EFResponse
                {
                    Id = 377,
                    Content = "It executes a provided function once for each array element.",
                    IsCorrect = true,
                    QuestionId = 115
                },
                new EFResponse
                {
                    Id = 378,
                    Content = "It creates a new array with the results of calling a provided function on every element in the calling array.",
                    IsCorrect = false,
                    QuestionId = 115
                },
                new EFResponse
                {
                    Id = 379,
                    Content = "It creates a new array with all elements that pass the test implemented by the provided function.",
                    IsCorrect = false,
                    QuestionId = 115
                },
                new EFResponse
                {
                    Id = 380,
                    Content = "It returns the first element in the array that satisfies the provided testing function.",
                    IsCorrect = false,
                    QuestionId = 115
                },
                new EFResponse
                {
                    Id = 381,
                    Content = "It executes a provided function once for each array element.",
                    IsCorrect = true,
                    QuestionId = 116
                },
                new EFResponse
                {
                    Id = 382,
                    Content = "It creates a new array with the results of calling a provided function on every element in the calling array.",
                    IsCorrect = false,
                    QuestionId = 116
                },
                new EFResponse
                {
                    Id = 383,
                    Content = "It creates a new array with all elements that pass the test implemented by the provided function.",
                    IsCorrect = false,
                    QuestionId = 116
                },
                new EFResponse
                {
                    Id = 384,
                    Content = "It returns the first element in the array that satisfies the provided testing function.",
                    IsCorrect = false,
                    QuestionId = 116
                }, new EFResponse
                {
                    Id = 401,
                    Content = "It creates a new array with the results of calling a provided function on every element in the calling array.",
                    IsCorrect = true,
                    QuestionId = 121
                },
                new EFResponse
                {
                    Id = 402,
                    Content = "It executes a provided function once for each array element.",
                    IsCorrect = false,
                    QuestionId = 121
                },
                new EFResponse
                {
                    Id = 403,
                    Content = "It creates a new array with all elements that pass the test implemented by the provided function.",
                    IsCorrect = false,
                    QuestionId = 121
                },
                new EFResponse
                {
                    Id = 404,
                    Content = "It returns the first element in the array that satisfies the provided testing function.",
                    IsCorrect = false,
                    QuestionId = 121
                },
                new EFResponse
                {
                    Id = 405,
                    Content = "It creates a new array with all elements that pass the test implemented by the provided function.",
                    IsCorrect = true,
                    QuestionId = 122
                },
                new EFResponse
                {
                    Id = 406,
                    Content = "It executes a provided function once for each array element.",
                    IsCorrect = false,
                    QuestionId = 122
                },
                new EFResponse
                {
                    Id = 407,
                    Content = "It creates a new array with the results of calling a provided function on every element in the calling array.",
                    IsCorrect = false,
                    QuestionId = 122
                },
                new EFResponse
                {
                    Id = 408,
                    Content = "It returns the first element in the array that satisfies the provided testing function.",
                    IsCorrect = false,
                    QuestionId = 122
                },
                new EFResponse
                {
                    Id = 409,
                    Content = "It creates a new array with the results of calling a provided function on every element in the calling array.",
                    IsCorrect = true,
                    QuestionId = 123
                },
                new EFResponse
                {
                    Id = 410,
                    Content = "It executes a provided function once for each array element.",
                    IsCorrect = false,
                    QuestionId = 123
                },
                new EFResponse
                {
                    Id = 411,
                    Content = "It creates a new array with all elements that pass the test implemented by the provided function.",
                    IsCorrect = false,
                    QuestionId = 123
                },
                new EFResponse
                {
                    Id = 412,
                    Content = "It returns the first element in the array that satisfies the provided testing function.",
                    IsCorrect = false,
                    QuestionId = 123
                },
                new EFResponse
                {
                    Id = 413,
                    Content = "It creates a new array with all elements that pass the test implemented by the provided function.",
                    IsCorrect = true,
                    QuestionId = 124
                },
                new EFResponse
                {
                    Id = 414,
                    Content = "It executes a provided function once for each array element.",
                    IsCorrect = false,
                    QuestionId = 124
                },
                new EFResponse
                {
                    Id = 415,
                    Content = "It creates a new array with the results of calling a provided function on every element in the calling array.",
                    IsCorrect = false,
                    QuestionId = 124
                },
                new EFResponse
                {
                    Id = 416,
                    Content = "It returns the first element in the array that satisfies the provided testing function.",
                    IsCorrect = false,
                    QuestionId = 124
                },
                new EFResponse
                {
                    Id = 417,
                    Content = "It executes a provided function once for each array element.",
                    IsCorrect = true,
                    QuestionId = 125
                },
                new EFResponse
                {
                    Id = 418,
                    Content = "It creates a new array with the results of calling a provided function on every element in the calling array.",
                    IsCorrect = false,
                    QuestionId = 125
                },
                new EFResponse
                {
                    Id = 419,
                    Content = "It creates a new array with all elements that pass the test implemented by the provided function.",
                    IsCorrect = false,
                    QuestionId = 125
                },
                new EFResponse
                {
                    Id = 420,
                    Content = "It returns the first element in the array that satisfies the provided testing function.",
                    IsCorrect = false,
                    QuestionId = 125
                },
                new EFResponse
                {
                    Id = 421,
                    Content = "It creates a new array with all elements that pass the test implemented by the provided function.",
                    IsCorrect = true,
                    QuestionId = 126
                },
                new EFResponse
                {
                    Id = 422,
                    Content = "It executes a provided function once for each array element.",
                    IsCorrect = false,
                    QuestionId = 126
                },
                new EFResponse
                {
                    Id = 423,
                    Content = "It creates a new array with the results of calling a provided function on every element in the calling array.",
                    IsCorrect = false,
                    QuestionId = 126
                },
                new EFResponse
                {
                    Id = 424,
                    Content = "It returns the first element in the array that satisfies the provided testing function.",
                    IsCorrect = false,
                    QuestionId = 126
                },
                new EFResponse
                {
                    Id = 425,
                    Content = "It creates a new array with the results of calling a provided function on every element in the calling array.",
                    IsCorrect = true,
                    QuestionId = 127
                },
                new EFResponse
                {
                    Id = 426,
                    Content = "It executes a provided function once for each array element.",
                    IsCorrect = false,
                    QuestionId = 127
                },
                new EFResponse
                {
                    Id = 427,
                    Content = "It creates a new array with all elements that pass the test implemented by the provided function.",
                    IsCorrect = false,
                    QuestionId = 127
                },
                new EFResponse
                {
                    Id = 428,
                    Content = "It returns the first element in the array that satisfies the provided testing function.",
                    IsCorrect = false,
                    QuestionId = 127
                },
                new EFResponse
                {
                    Id = 429,
                    Content = "It creates a new array with all elements that pass the test implemented by the provided function.",
                    IsCorrect = true,
                    QuestionId = 128
                },
                new EFResponse
                {
                    Id = 430,
                    Content = "It executes a provided function once for each array element.",
                    IsCorrect = false,
                    QuestionId = 128
                },
                new EFResponse
                {
                    Id = 431,
                    Content = "It creates a new array with the results of calling a provided function on every element in the calling array.",
                    IsCorrect = false,
                    QuestionId = 128
                },
                new EFResponse
                {
                    Id = 432,
                    Content = "It returns the first element in the array that satisfies the provided testing function.",
                    IsCorrect = false,
                    QuestionId = 128
                },
                new EFResponse
                {
                    Id = 433,
                    Content = "It creates a new array with the results of calling a provided function on every element in the calling array.",
                    IsCorrect = true,
                    QuestionId = 129
                },
                new EFResponse
                {
                    Id = 434,
                    Content = "It executes a provided function once for each array element.",
                    IsCorrect = false,
                    QuestionId = 129
                },
                new EFResponse
                {
                    Id = 435,
                    Content = "It creates a new array with all elements that pass the test implemented by the provided function.",
                    IsCorrect = false,
                    QuestionId = 129
                },
                new EFResponse
                {
                    Id = 436,
                    Content = "It returns the first element in the array that satisfies the provided testing function.",
                    IsCorrect = false,
                    QuestionId = 129
                },
                new EFResponse
                {
                    Id = 437,
                    Content = "It creates a new array with all elements that pass the test implemented by the provided function.",
                    IsCorrect = true,
                    QuestionId = 130
                },
                new EFResponse
                {
                    Id = 438,
                    Content = "It executes a provided function once for each array element.",
                    IsCorrect = false,
                    QuestionId = 130
                },
                new EFResponse
                {
                    Id = 439,
                    Content = "It creates a new array with the results of calling a provided function on every element in the calling array.",
                    IsCorrect = false,
                    QuestionId = 130
                },
                new EFResponse
                {
                    Id = 440,
                    Content = "It returns the first element in the array that satisfies the provided testing function.",
                    IsCorrect = false,
                    QuestionId = 130
                },
                new EFResponse
                {
                    Id = 441,
                    Content = "It creates a new array with the results of calling a provided function on every element in the calling array.",
                    IsCorrect = true,
                    QuestionId = 131
                },
                new EFResponse
                {
                    Id = 442,
                    Content = "It executes a provided function once for each array element.",
                    IsCorrect = false,
                    QuestionId = 131
                },
                new EFResponse
                {
                    Id = 443,
                    Content = "It creates a new array with all elements that pass the test implemented by the provided function.",
                    IsCorrect = false,
                    QuestionId = 131
                },
                new EFResponse
                {
                    Id = 444,
                    Content = "It returns the first element in the array that satisfies the provided testing function.",
                    IsCorrect = false,
                    QuestionId = 131
                },
                new EFResponse
                {
                    Id = 445,
                    Content = "It creates a new array with all elements that pass the test implemented by the provided function.",
                    IsCorrect = true,
                    QuestionId = 132
                },
                new EFResponse
                {
                    Id = 446,
                    Content = "It executes a provided function once for each array element.",
                    IsCorrect = false,
                    QuestionId = 132
                },
                new EFResponse
                {
                    Id = 447,
                    Content = "It creates a new array with the results of calling a provided function on every element in the calling array.",
                    IsCorrect = false,
                    QuestionId = 132
                },
                new EFResponse
                {
                    Id = 448,
                    Content = "It returns the first element in the array that satisfies the provided testing function.",
                    IsCorrect = false,
                    QuestionId = 132
                },
                new EFResponse
                {
                    Id = 449,
                    Content = "It creates a new array with the results of calling a provided function on every element in the calling array.",
                    IsCorrect = true,
                    QuestionId = 133
                },
                new EFResponse
                {
                    Id = 450,
                    Content = "It executes a provided function once for each array element.",
                    IsCorrect = false,
                    QuestionId = 133
                },
                new EFResponse
                {
                    Id = 451,
                    Content = "It creates a new array with all elements that pass the test implemented by the provided function.",
                    IsCorrect = false,
                    QuestionId = 133
                },
                new EFResponse
                {
                    Id = 452,
                    Content = "It returns the first element in the array that satisfies the provided testing function.",
                    IsCorrect = false,
                    QuestionId = 133
                },
                new EFResponse
                {
                    Id = 453,
                    Content = "It creates a new array with all elements that pass the test implemented by the provided function.",
                    IsCorrect = true,
                    QuestionId = 134
                },
                new EFResponse
                {
                    Id = 454,
                    Content = "It executes a provided function once for each array element.",
                    IsCorrect = false,
                    QuestionId = 134
                },
                new EFResponse
                {
                    Id = 455,
                    Content = "It creates a new array with the results of calling a provided function on every element in the calling array.",
                    IsCorrect = false,
                    QuestionId = 134
                },
                new EFResponse
                {
                    Id = 456,
                    Content = "It returns the first element in the array that satisfies the provided testing function.",
                    IsCorrect = false,
                    QuestionId = 134
                },
                new EFResponse
                {
                    Id = 457,
                    Content = "It creates a new array with the results of calling a provided function on every element in the calling array.",
                    IsCorrect = true,
                    QuestionId = 135
                },
                new EFResponse
                {
                    Id = 458,
                    Content = "It executes a provided function once for each array element.",
                    IsCorrect = false,
                    QuestionId = 135
                },
                new EFResponse
                {
                    Id = 459,
                    Content = "It creates a new array with all elements that pass the test implemented by the provided function.",
                    IsCorrect = false,
                    QuestionId = 135
                },
                new EFResponse
                {
                    Id = 460,
                    Content = "It returns the first element in the array that satisfies the provided testing function.",
                    IsCorrect = false,
                    QuestionId = 135
                },
                new EFResponse
                {
                    Id = 461,
                    Content = "It creates a new array with all elements that pass the test implemented by the provided function.",
                    IsCorrect = true,
                    QuestionId = 136
                },
                new EFResponse
                {
                    Id = 462,
                    Content = "It executes a provided function once for each array element.",
                    IsCorrect = false,
                    QuestionId = 136
                },
                new EFResponse
                {
                    Id = 463,
                    Content = "It creates a new array with the results of calling a provided function on every element in the calling array.",
                    IsCorrect = false,
                    QuestionId = 136
                },
                new EFResponse
                {
                    Id = 464,
                    Content = "It returns the first element in the array that satisfies the provided testing function.",
                    IsCorrect = false,
                    QuestionId = 136
                },
                new EFResponse
                {
                    Id = 465,
                    Content = "It creates a new array with the results of calling a provided function on every element in the calling array.",
                    IsCorrect = true,
                    QuestionId = 137
                },
                new EFResponse
                {
                    Id = 466,
                    Content = "It executes a provided function once for each array element.",
                    IsCorrect = false,
                    QuestionId = 137
                },
                new EFResponse
                {
                    Id = 467,
                    Content = "It creates a new array with all elements that pass the test implemented by the provided function.",
                    IsCorrect = false,
                    QuestionId = 137
                },
                new EFResponse
                {
                    Id = 468,
                    Content = "It returns the first element in the array that satisfies the provided testing function.",
                    IsCorrect = false,
                    QuestionId = 137
                },
                new EFResponse
                {
                    Id = 469,
                    Content = "It creates a new array with all elements that pass the test implemented by the provided function.",
                    IsCorrect = true,
                    QuestionId = 138
                },
                new EFResponse
                {
                    Id = 470,
                    Content = "It executes a provided function once for each array element.",
                    IsCorrect = false,
                    QuestionId = 138
                },
                new EFResponse
                {
                    Id = 471,
                    Content = "It creates a new array with the results of calling a provided function on every element in the calling array.",
                    IsCorrect = false,
                    QuestionId = 138
                },
                new EFResponse
                {
                    Id = 472,
                    Content = "It returns the first element in the array that satisfies the provided testing function.",
                    IsCorrect = false,
                    QuestionId = 138
                },
                new EFResponse
                {
                    Id = 473,
                    Content = "It creates a new array with the results of calling a provided function on every element in the calling array.",
                    IsCorrect = true,
                    QuestionId = 139
                },
                new EFResponse
                {
                    Id = 474,
                    Content = "It executes a provided function once for each array element.",
                    IsCorrect = false,
                    QuestionId = 139
                },
                new EFResponse
                {
                    Id = 475,
                    Content = "It creates a new array with all elements that pass the test implemented by the provided function.",
                    IsCorrect = false,
                    QuestionId = 139
                },
                new EFResponse
                {
                    Id = 476,
                    Content = "It returns the first element in the array that satisfies the provided testing function.",
                    IsCorrect = false,
                    QuestionId = 139
                },
                new EFResponse
                {
                    Id = 477,
                    Content = "It creates a new array with the results of calling a provided function on every element in the calling array.",
                    IsCorrect = true,
                    QuestionId = 140
                },
                new EFResponse
                {
                    Id = 478,
                    Content = "It executes a provided function once for each array element.",
                    IsCorrect = false,
                    QuestionId = 140
                },
                new EFResponse
                {
                    Id = 479,
                    Content = "It creates a new array with all elements that pass the test implemented by the provided function.",
                    IsCorrect = false,
                    QuestionId = 140
                },
                new EFResponse
                {
                    Id = 480,
                    Content = "It returns the first element in the array that satisfies the provided testing function.",
                    IsCorrect = false,
                    QuestionId = 140
                },
                 new EFResponse
                 {
                     Id = 481,
                     Content = "A class is a blueprint for creating objects.",
                     IsCorrect = true,
                     QuestionId = 21
                 },
                 new EFResponse
                 {
                     Id = 482,
                     Content = "An object is an instance of a class.",
                     IsCorrect = true,
                     QuestionId = 21
                 },
                 new EFResponse
                 {
                     Id = 483,
                     Content = "Classes define properties and methods.",
                     IsCorrect = true,
                     QuestionId = 21
                 },
                 new EFResponse
                 {
                     Id = 484,
                     Content = "Objects hold specific data and can perform actions.",
                     IsCorrect = true,
                     QuestionId = 21
                 },
                 new EFResponse
                 {
                     Id = 485,
                     Content = "Abstraction is the concept of hiding the complex implementation details.",
                     IsCorrect = true,
                     QuestionId = 22
                 },
                 new EFResponse
                 {
                     Id = 486,
                     Content = "It focuses on exposing only the necessary parts.",
                     IsCorrect = true,
                     QuestionId = 22
                 },
                 new EFResponse
                 {
                     Id = 487,
                     Content = "Abstraction helps in reducing programming complexity.",
                     IsCorrect = true,
                     QuestionId = 22
                 },
                 new EFResponse
                 {
                     Id = 488,
                     Content = "It is achieved using abstract classes and interfaces.",
                     IsCorrect = true,
                     QuestionId = 22
                 },
                 new EFResponse
                 {
                     Id = 489,
                     Content = "The 'finally' block is used to execute important code such as closing resources.",
                     IsCorrect = true,
                     QuestionId = 23
                 },
                 new EFResponse
                 {
                     Id = 490,
                     Content = "It always executes, regardless of whether an exception was thrown or not.",
                     IsCorrect = true,
                     QuestionId = 23
                 },
                 new EFResponse
                 {
                     Id = 491,
                     Content = "It is used to perform cleanup operations.",
                     IsCorrect = true,
                     QuestionId = 23
                 },
                 new EFResponse
                 {
                     Id = 492,
                     Content = "The 'finally' block can be used with try-catch blocks.",
                     IsCorrect = true,
                     QuestionId = 23
                 },
                 new EFResponse
                 {
                     Id = 493,
                     Content = "A primary key uniquely identifies each record in a table.",
                     IsCorrect = true,
                     QuestionId = 24
                 },
                 new EFResponse
                 {
                     Id = 494,
                     Content = "A foreign key is a field in one table that uniquely identifies a row of another table.",
                     IsCorrect = true,
                     QuestionId = 24
                 },
                 new EFResponse
                 {
                     Id = 495,
                     Content = "Primary keys enforce entity integrity.",
                     IsCorrect = true,
                     QuestionId = 24
                 },
                 new EFResponse
                 {
                     Id = 496,
                     Content = "Foreign keys enforce referential integrity.",
                     IsCorrect = true,
                     QuestionId = 24
                 },
                 new EFResponse
                 {
                     Id = 497,
                     Content = "Normalization is the process of organizing data to reduce redundancy.",
                     IsCorrect = true,
                     QuestionId = 25
                 },
                 new EFResponse
                 {
                     Id = 498,
                     Content = "It involves dividing a database into two or more tables and defining relationships between them.",
                     IsCorrect = true,
                     QuestionId = 25
                 },
                 new EFResponse
                 {
                     Id = 499,
                     Content = "Normalization improves data integrity.",
                     IsCorrect = true,
                     QuestionId = 25
                 },
                 new EFResponse
                 {
                     Id = 500,
                     Content = "It helps in efficient data retrieval.",
                     IsCorrect = true,
                     QuestionId = 25
                 },
                 new EFResponse
                 {
                     Id = 501,
                     Content = "The 'static' keyword is used to indicate that a member belongs to the class, rather than instances of the class.",
                     IsCorrect = true,
                     QuestionId = 26
                 },
                 new EFResponse
                 {
                     Id = 502,
                     Content = "Static members are shared among all instances of the class.",
                     IsCorrect = true,
                     QuestionId = 26
                 },
                 new EFResponse
                 {
                     Id = 503,
                     Content = "Static methods can be called without creating an instance of the class.",
                     IsCorrect = true,
                     QuestionId = 26
                 },
                 new EFResponse
                 {
                     Id = 504,
                     Content = "Static variables are initialized only once, at the start of the execution.",
                     IsCorrect = true,
                     QuestionId = 26
                 },
                 new EFResponse
                 {
                     Id = 505,
                     Content = "Method overloading allows a class to have more than one method with the same name.",
                     IsCorrect = true,
                     QuestionId = 27
                 },
                 new EFResponse
                 {
                     Id = 506,
                     Content = "Overloaded methods must have different parameter lists.",
                     IsCorrect = true,
                     QuestionId = 27
                 },
                 new EFResponse
                 {
                     Id = 507,
                     Content = "It is a way to achieve polymorphism.",
                     IsCorrect = true,
                     QuestionId = 27
                 },
                 new EFResponse
                 {
                     Id = 508,
                     Content = "Overloading improves code readability and reusability.",
                     IsCorrect = true,
                     QuestionId = 27
                 },
                 new EFResponse
                 {
                     Id = 509,
                     Content = "GET requests are used to retrieve data from a server.",
                     IsCorrect = true,
                     QuestionId = 28
                 },
                 new EFResponse
                 {
                     Id = 510,
                     Content = "POST requests are used to send data to a server to create/update a resource.",
                     IsCorrect = true,
                     QuestionId = 28
                 },
                 new EFResponse
                 {
                     Id = 511,
                     Content = "GET requests can be cached and bookmarked.",
                     IsCorrect = true,
                     QuestionId = 28
                 },
                 new EFResponse
                 {
                     Id = 512,
                     Content = "POST requests are not cached and cannot be bookmarked.",
                     IsCorrect = true,
                     QuestionId = 28
                 },
                 new EFResponse
                 {
                     Id = 513,
                     Content = "The 'volatile' keyword is used to indicate that a variable's value may be changed by different threads.",
                     IsCorrect = true,
                     QuestionId = 29
                 },
                 new EFResponse
                 {
                     Id = 514,
                     Content = "It ensures that the value of the variable is always read from the main memory.",
                     IsCorrect = true,
                     QuestionId = 29
                 },
                 new EFResponse
                 {
                     Id = 515,
                     Content = "Volatile variables are not cached thread-locally.",
                     IsCorrect = true,
                     QuestionId = 29
                 },
                 new EFResponse
                 {
                     Id = 516,
                     Content = "It is used to prevent memory consistency errors.",
                     IsCorrect = true,
                     QuestionId = 29
                 },
                 new EFResponse
                 {
                     Id = 517,
                     Content = "A RESTful API is an API that conforms to the constraints of REST architecture.",
                     IsCorrect = true,
                     QuestionId = 30
                 },
                 new EFResponse
                 {
                     Id = 518,
                     Content = "It uses standard HTTP methods like GET, POST, PUT, DELETE.",
                     IsCorrect = true,
                     QuestionId = 30
                 },
                 new EFResponse
                 {
                     Id = 519,
                     Content = "RESTful APIs are stateless and cacheable.",
                     IsCorrect = true,
                     QuestionId = 30
                 },
                 new EFResponse
                 {
                     Id = 520,
                     Content = "They use URIs to access resources.",
                     IsCorrect = true,
                     QuestionId = 30
                 },
                 new EFResponse
                 {
                     Id = 521,
                     Content = "A process is an independent program in execution.",
                     IsCorrect = true,
                     QuestionId = 31
                 },
                 new EFResponse
                 {
                     Id = 522,
                     Content = "A thread is a smaller unit of a process that can be executed independently.",
                     IsCorrect = true,
                     QuestionId = 31
                 },
                 new EFResponse
                 {
                     Id = 523,
                     Content = "Processes have separate memory spaces.",
                     IsCorrect = true,
                     QuestionId = 31
                 },
                 new EFResponse
                 {
                     Id = 524,
                     Content = "Threads share the same memory space within a process.",
                     IsCorrect = true,
                     QuestionId = 31
                 },
                 new EFResponse
                 {
                     Id = 525,
                     Content = "A lambda expression is a concise way to represent an anonymous function.",
                     IsCorrect = true,
                     QuestionId = 32
                 },
                 new EFResponse
                 {
                     Id = 526,
                     Content = "It provides a clear and concise way to implement a single method interface.",
                     IsCorrect = true,
                     QuestionId = 32
                 },
                 new EFResponse
                 {
                     Id = 527,
                     Content = "Lambda expressions are used primarily to define the inline implementation of a functional interface.",
                     IsCorrect = true,
                     QuestionId = 32
                 },
                 new EFResponse
                 {
                     Id = 528,
                     Content = "They help in writing more readable and maintainable code.",
                     IsCorrect = true,
                     QuestionId = 32
                 },
                 new EFResponse
                 {
                     Id = 529,
                     Content = "The 'transient' keyword is used to indicate that a field should not be serialized.",
                     IsCorrect = true,
                     QuestionId = 33
                 },
                 new EFResponse
                 {
                     Id = 530,
                     Content = "Transient fields are not included in the serialized form of an object.",
                     IsCorrect = true,
                     QuestionId = 33
                 },
                 new EFResponse
                 {
                     Id = 531,
                     Content = "It is used to prevent sensitive data from being serialized.",
                     IsCorrect = true,
                     QuestionId = 33
                 },
                 new EFResponse
                 {
                     Id = 532,
                     Content = "Transient fields are initialized with default values during deserialization.",
                     IsCorrect = true,
                     QuestionId = 33
                 },
                 new EFResponse
                 {
                     Id = 533,
                     Content = "A constructor is a special method used to initialize objects.",
                     IsCorrect = true,
                     QuestionId = 34
                 },
                 new EFResponse
                 {
                     Id = 534,
                     Content = "A method is a function defined in a class that performs a specific task.",
                     IsCorrect = true,
                     QuestionId = 34
                 },
                 new EFResponse
                 {
                     Id = 535,
                     Content = "Constructors do not have a return type.",
                     IsCorrect = true,
                     QuestionId = 34
                 },
                 new EFResponse
                 {
                     Id = 536,
                     Content = "Methods have a return type or void.",
                     IsCorrect = true,
                     QuestionId = 34
                 },
                 new EFResponse
                 {
                     Id = 537,
                     Content = "A binary tree is a tree data structure in which each node has at most two children.",
                     IsCorrect = true,
                     QuestionId = 35
                 },
                 new EFResponse
                 {
                     Id = 538,
                     Content = "The two children are referred to as the left child and the right child.",
                     IsCorrect = true,
                     QuestionId = 35
                 },
                 new EFResponse
                 {
                     Id = 539,
                     Content = "Binary trees are used in various applications such as searching and sorting.",
                     IsCorrect = true,
                     QuestionId = 35
                 },
                 new EFResponse
                 {
                     Id = 540,
                     Content = "They are the basis for binary search trees and binary heaps.",
                     IsCorrect = true,
                     QuestionId = 35
                 },
                 new EFResponse
                 {
                     Id = 541,
                     Content = "The 'synchronized' keyword is used to control the access of multiple threads to a shared resource.",
                     IsCorrect = true,
                     QuestionId = 36
                 },
                 new EFResponse
                 {
                     Id = 542,
                     Content = "It ensures that only one thread can access the resource at a time.",
                     IsCorrect = true,
                     QuestionId = 36
                 },
                 new EFResponse
                 {
                     Id = 543,
                     Content = "Synchronized methods or blocks prevent thread interference and memory consistency errors.",
                     IsCorrect = true,
                     QuestionId = 36
                 },
                 new EFResponse
                 {
                     Id = 544,
                     Content = "It is used to implement thread-safe operations.",
                     IsCorrect = true,
                     QuestionId = 36
                 },
                 new EFResponse
                 {
                     Id = 545,
                     Content = "A hash table is a data structure that maps keys to values using a hash function.",
                     IsCorrect = true,
                     QuestionId = 37
                 },
                 new EFResponse
                 {
                     Id = 546,
                     Content = "It provides efficient insertion, deletion, and lookup operations.",
                     IsCorrect = true,
                     QuestionId = 37
                 },
                 new EFResponse
                 {
                     Id = 547,
                     Content = "Hash tables handle collisions using techniques like chaining or open addressing.",
                     IsCorrect = true,
                     QuestionId = 37
                 },
                 new EFResponse
                 {
                     Id = 548,
                     Content = "They are widely used in applications requiring fast data retrieval.",
                     IsCorrect = true,
                     QuestionId = 37
                 },
                 new EFResponse
                 {
                     Id = 549,
                     Content = "A stack is a linear data structure that follows the LIFO (Last In, First Out) principle.",
                     IsCorrect = true,
                     QuestionId = 38
                 },
                 new EFResponse
                 {
                     Id = 550,
                     Content = "A heap is a specialized tree-based data structure that satisfies the heap property.",
                     IsCorrect = true,
                     QuestionId = 38
                 },
                 new EFResponse
                 {
                     Id = 551,
                     Content = "Stacks are used for static memory allocation.",
                     IsCorrect = true,
                     QuestionId = 38
                 },
                 new EFResponse
                 {
                     Id = 552,
                     Content = "Heaps are used for dynamic memory allocation.",
                     IsCorrect = true,
                     QuestionId = 38
                 },
                 new EFResponse
                 {
                     Id = 553,
                     Content = "The 'finalize' method is called by the garbage collector before an object is destroyed.",
                     IsCorrect = true,
                     QuestionId = 39
                 },
                 new EFResponse
                 {
                     Id = 554,
                     Content = "It is used to perform cleanup operations before the object is reclaimed.",
                     IsCorrect = true,
                     QuestionId = 39
                 },
                 new EFResponse
                 {
                     Id = 555,
                     Content = "The 'finalize' method is not guaranteed to be called immediately after an object becomes unreachable.",
                     IsCorrect = true,
                     QuestionId = 39
                 },

                 new EFResponse
                 {
                     Id = 556,
                     Content = "The 'map' function creates a new array populated with the results of calling a provided function on every element in the calling array.",
                     IsCorrect = true,
                     QuestionId = 117
                 },
                 new EFResponse
                 {
                     Id = 557,
                     Content = "The 'map' function does not change the original array.",
                     IsCorrect = false,
                     QuestionId = 117
                 },
                 new EFResponse
                 {
                     Id = 558,
                     Content = "The 'map' function is used to filter elements in an array.",
                     IsCorrect = false,
                     QuestionId = 117
                 },
                 new EFResponse
                 {
                     Id = 559,
                     Content = "The 'map' function is used to reduce elements in an array.",
                     IsCorrect = false,
                     QuestionId = 117
                 },
                 new EFResponse
                 {
                     Id = 560,
                     Content = "The 'filter' function creates a new array with all elements that pass the test implemented by the provided function.",
                     IsCorrect = true,
                     QuestionId = 118
                 },
                 new EFResponse
                 {
                     Id = 561,
                     Content = "The 'filter' function changes the original array.",
                     IsCorrect = false,
                     QuestionId = 118
                 },
                 new EFResponse
                 {
                     Id = 562,
                     Content = "The 'filter' function is used to map elements in an array.",
                     IsCorrect = false,
                     QuestionId = 118
                 },
                 new EFResponse
                 {
                     Id = 563,
                     Content = "The 'filter' function is used to reduce elements in an array.",
                     IsCorrect = false,
                     QuestionId = 118
                 },
                 new EFResponse
                 {
                     Id = 564,
                     Content = "The 'reduce' function executes a reducer function on each element of the array, resulting in a single output value.",
                     IsCorrect = true,
                     QuestionId = 119
                 },
                 new EFResponse
                 {
                     Id = 565,
                     Content = "The 'reduce' function creates a new array.",
                     IsCorrect = false,
                     QuestionId = 119
                 },
                 new EFResponse
                 {
                     Id = 566,
                     Content = "The 'reduce' function is used to filter elements in an array.",
                     IsCorrect = false,
                     QuestionId = 119
                 },
                 new EFResponse
                 {
                     Id = 567,
                     Content = "The 'reduce' function is used to map elements in an array.",
                     IsCorrect = false,
                     QuestionId = 119
                 },
                 new EFResponse
                 {
                     Id = 568,
                     Content = "The 'find' function returns the value of the first element in the array that satisfies the provided testing function.",
                     IsCorrect = true,
                     QuestionId = 120
                 },
                 new EFResponse
                 {
                     Id = 569,
                     Content = "The 'find' function returns a new array.",
                     IsCorrect = false,
                     QuestionId = 120
                 },
                 new EFResponse
                 {
                     Id = 570,
                     Content = "The 'find' function is used to filter elements in an array.",
                     IsCorrect = false,
                     QuestionId = 120
                 },
                 new EFResponse
                 {
                     Id = 571,
                     Content = "The 'find' function is used to map elements in an array.",
                     IsCorrect = false,
                     QuestionId = 120
                 },
                 new EFResponse
                 {
                     Id = 572,
                     Content = "The 'find' function returns the value of the first element in the array that satisfies the provided testing function.",
                     IsCorrect = true,
                     QuestionId = 120
                 },
                 new EFResponse
                 {
                     Id = 573,
                     Content = "The 'find' function returns a new array.",
                     IsCorrect = false,
                     QuestionId = 120
                 },
                 new EFResponse
                 {
                     Id = 574,
                     Content = "The 'find' function is used to filter elements in an array.",
                     IsCorrect = false,
                     QuestionId = 120
                 },
                 new EFResponse
                 {
                     Id = 575,
                     Content = "The 'find' function is used to map elements in an array.",
                     IsCorrect = false,
                     QuestionId = 120
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
