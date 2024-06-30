﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Quizz.Domain.Infrastructure.Data;

#nullable disable

namespace Quizz.Domain.Infrastructure.Data.Migrations
{
    [DbContext(typeof(Context))]
    partial class ContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Quizz.Domain.Infrastructure.Data.Entities.EFCandidate", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("AgentId")
                        .HasColumnType("int");

                    b.Property<string>("EmailAddress")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)")
                        .HasAnnotation("EmailAddress", true);

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("PhoneNumber")
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)")
                        .HasAnnotation("Phone", true);

                    b.HasKey("Id");

                    b.HasIndex("AgentId");

                    b.ToTable("Candidates");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            AgentId = 1,
                            EmailAddress = "john.doe@example.com",
                            FirstName = "John",
                            LastName = "Doe",
                            PhoneNumber = "1234567890"
                        },
                        new
                        {
                            Id = 2,
                            AgentId = 2,
                            EmailAddress = "jane.smith@example.com",
                            FirstName = "Jane",
                            LastName = "Smith",
                            PhoneNumber = "0987654321"
                        });
                });

            modelBuilder.Entity("Quizz.Domain.Infrastructure.Data.Entities.EFCandidateResponse", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Comment")
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<string>("Explanation")
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<bool>("Is_Skipped")
                        .HasColumnType("bit");

                    b.Property<string>("Open_Response_Text")
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<int>("QuestionId")
                        .HasColumnType("int");

                    b.Property<int>("QuizId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("QuizId", "QuestionId");

                    b.ToTable("CandidateResponses");
                });

            modelBuilder.Entity("Quizz.Domain.Infrastructure.Data.Entities.EFLevel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("AdminId")
                        .HasColumnType("int");

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.HasIndex("AdminId");

                    b.ToTable("Levels");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            AdminId = 1,
                            Content = "Junior",
                            IsActive = true
                        },
                        new
                        {
                            Id = 2,
                            AdminId = 1,
                            Content = "intermediate",
                            IsActive = true
                        },
                        new
                        {
                            Id = 3,
                            AdminId = 1,
                            Content = "Senior",
                            IsActive = true
                        });
                });

            modelBuilder.Entity("Quizz.Domain.Infrastructure.Data.Entities.EFQuestion", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("AdminId")
                        .HasColumnType("int");

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<bool>("IsValid")
                        .HasColumnType("bit");

                    b.Property<int>("LevelId")
                        .HasColumnType("int");

                    b.Property<int>("TechnologyId")
                        .HasColumnType("int");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("Id");

                    b.HasIndex("AdminId");

                    b.HasIndex("TechnologyId");

                    b.ToTable("Questions");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            AdminId = 1,
                            Content = "Sample question content 1",
                            IsValid = true,
                            LevelId = 1,
                            TechnologyId = 1,
                            Type = "Multiple Choice"
                        },
                        new
                        {
                            Id = 2,
                            AdminId = 1,
                            Content = "Sample question content 2",
                            IsValid = true,
                            LevelId = 2,
                            TechnologyId = 2,
                            Type = "Short Answer"
                        },
                        new
                        {
                            Id = 3,
                            AdminId = 1,
                            Content = "Sample question content 3",
                            IsValid = true,
                            LevelId = 2,
                            TechnologyId = 2,
                            Type = "Short Answer"
                        },
                        new
                        {
                            Id = 4,
                            AdminId = 1,
                            Content = "Sample question content 4",
                            IsValid = true,
                            LevelId = 2,
                            TechnologyId = 2,
                            Type = "Short Answer"
                        });
                });

            modelBuilder.Entity("Quizz.Domain.Infrastructure.Data.Entities.EFQuiz", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("AdminId")
                        .HasColumnType("int");

                    b.Property<int>("AgentId")
                        .HasColumnType("int");

                    b.Property<int>("CandidateId")
                        .HasColumnType("int");

                    b.Property<string>("Comment")
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<decimal>("Completion")
                        .HasPrecision(18, 2)
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime>("CompletionTime")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsValid")
                        .HasColumnType("bit");

                    b.Property<int>("NumberOfQuestion")
                        .HasColumnType("int");

                    b.Property<string>("QuizzNumber")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<decimal>("Result")
                        .HasPrecision(18, 2)
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("StatusId")
                        .HasColumnType("int");

                    b.Property<int>("TechnologyId")
                        .HasColumnType("int");

                    b.Property<string>("URL")
                        .HasMaxLength(2048)
                        .HasColumnType("nvarchar(2048)");

                    b.HasKey("Id");

                    b.HasIndex("AdminId");

                    b.HasIndex("AgentId");

                    b.HasIndex("CandidateId");

                    b.HasIndex("StatusId");

                    b.HasIndex("TechnologyId");

                    b.ToTable("Quizzes");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            AdminId = 1,
                            AgentId = 1,
                            CandidateId = 1,
                            Comment = "Sample comment 1",
                            Completion = 0.5m,
                            CompletionTime = new DateTime(2024, 6, 30, 21, 40, 51, 632, DateTimeKind.Utc).AddTicks(1547),
                            IsValid = true,
                            NumberOfQuestion = 10,
                            QuizzNumber = "1",
                            Result = 0.5m,
                            StatusId = 1,
                            TechnologyId = 1,
                            URL = "https://example.com/quiz1"
                        },
                        new
                        {
                            Id = 2,
                            AdminId = 1,
                            AgentId = 2,
                            CandidateId = 2,
                            Comment = "Sample comment 2",
                            Completion = 0.5m,
                            CompletionTime = new DateTime(2024, 6, 30, 21, 40, 51, 632, DateTimeKind.Utc).AddTicks(1552),
                            IsValid = false,
                            NumberOfQuestion = 15,
                            QuizzNumber = "2",
                            Result = 0.8m,
                            StatusId = 2,
                            TechnologyId = 2,
                            URL = "https://example.com/quiz2"
                        },
                        new
                        {
                            Id = 3,
                            AdminId = 1,
                            AgentId = 2,
                            CandidateId = 2,
                            Completion = 0m,
                            CompletionTime = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            IsValid = true,
                            NumberOfQuestion = 15,
                            QuizzNumber = "3",
                            Result = 0m,
                            StatusId = 1,
                            TechnologyId = 2,
                            URL = "https://example.com/quiz2"
                        });
                });

            modelBuilder.Entity("Quizz.Domain.Infrastructure.Data.Entities.EFQuiz_Question", b =>
                {
                    b.Property<int>("QuizId")
                        .HasColumnType("int");

                    b.Property<int>("QuestionId")
                        .HasColumnType("int");

                    b.HasKey("QuizId", "QuestionId");

                    b.HasIndex("QuestionId");

                    b.ToTable("QuizQuestions");

                    b.HasData(
                        new
                        {
                            QuizId = 1,
                            QuestionId = 1
                        },
                        new
                        {
                            QuizId = 1,
                            QuestionId = 2
                        },
                        new
                        {
                            QuizId = 1,
                            QuestionId = 3
                        },
                        new
                        {
                            QuizId = 1,
                            QuestionId = 4
                        },
                        new
                        {
                            QuizId = 2,
                            QuestionId = 1
                        },
                        new
                        {
                            QuizId = 2,
                            QuestionId = 2
                        },
                        new
                        {
                            QuizId = 2,
                            QuestionId = 3
                        },
                        new
                        {
                            QuizId = 2,
                            QuestionId = 4
                        });
                });

            modelBuilder.Entity("Quizz.Domain.Infrastructure.Data.Entities.EFResponse", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<bool>("IsCorrect")
                        .HasColumnType("bit");

                    b.Property<int>("QuestionId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("QuestionId");

                    b.ToTable("Responses");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Content = " Q1 Sample response content 1",
                            IsCorrect = true,
                            QuestionId = 1
                        },
                        new
                        {
                            Id = 2,
                            Content = " Q1 Sample response content 2",
                            IsCorrect = false,
                            QuestionId = 1
                        },
                        new
                        {
                            Id = 3,
                            Content = " Q1 Sample response content 3",
                            IsCorrect = true,
                            QuestionId = 1
                        },
                        new
                        {
                            Id = 4,
                            Content = "Q1 Sample response content 4",
                            IsCorrect = false,
                            QuestionId = 1
                        },
                        new
                        {
                            Id = 5,
                            Content = " Q2 Sample response content 1",
                            IsCorrect = true,
                            QuestionId = 2
                        },
                        new
                        {
                            Id = 6,
                            Content = " Q2 Sample response content 2",
                            IsCorrect = false,
                            QuestionId = 2
                        },
                        new
                        {
                            Id = 7,
                            Content = " Q2 Sample response content 3",
                            IsCorrect = true,
                            QuestionId = 2
                        },
                        new
                        {
                            Id = 8,
                            Content = "Q2 Sample response content 4",
                            IsCorrect = false,
                            QuestionId = 2
                        },
                        new
                        {
                            Id = 9,
                            Content = " Q3 Sample response content 1",
                            IsCorrect = true,
                            QuestionId = 3
                        },
                        new
                        {
                            Id = 10,
                            Content = " Q3 Sample response content 2",
                            IsCorrect = false,
                            QuestionId = 3
                        },
                        new
                        {
                            Id = 11,
                            Content = " Q3 Sample response content 3",
                            IsCorrect = true,
                            QuestionId = 3
                        },
                        new
                        {
                            Id = 12,
                            Content = "Q3 Sample response content 4",
                            IsCorrect = false,
                            QuestionId = 3
                        },
                        new
                        {
                            Id = 13,
                            Content = "Q4 Sample response content 4",
                            IsCorrect = false,
                            QuestionId = 4
                        },
                        new
                        {
                            Id = 14,
                            Content = " Q4 Sample response content 1",
                            IsCorrect = true,
                            QuestionId = 4
                        },
                        new
                        {
                            Id = 15,
                            Content = " Q4 Sample response content 2",
                            IsCorrect = false,
                            QuestionId = 4
                        },
                        new
                        {
                            Id = 16,
                            Content = " Q4 Sample response content 3",
                            IsCorrect = true,
                            QuestionId = 4
                        });
                });

            modelBuilder.Entity("Quizz.Domain.Infrastructure.Data.Entities.EFRole", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Roles");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Admin"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Agent"
                        });
                });

            modelBuilder.Entity("Quizz.Domain.Infrastructure.Data.Entities.EFStatus", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Statuses");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Status = "active"
                        },
                        new
                        {
                            Id = 2,
                            Status = "passed"
                        },
                        new
                        {
                            Id = 3,
                            Status = "delete"
                        });
                });

            modelBuilder.Entity("Quizz.Domain.Infrastructure.Data.Entities.EFTechnology", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("AdminId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("AdminId");

                    b.ToTable("Technologies");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            AdminId = 1,
                            Name = "Technology1"
                        },
                        new
                        {
                            Id = 2,
                            AdminId = 2,
                            Name = "Technology2"
                        });
                });

            modelBuilder.Entity("Quizz.Domain.Infrastructure.Data.Entities.EFUser", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ConfirmPassword")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("EmailAddress")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.Property<byte[]>("Salt")
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("Token")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            ConfirmPassword = "hashedpassword",
                            EmailAddress = "john.doe@example.com",
                            FirstName = "John",
                            IsActive = true,
                            LastName = "Doe",
                            Password = "hashedpassword",
                            PhoneNumber = "1234567890",
                            RoleId = 1,
                            Token = "tokenvalue"
                        },
                        new
                        {
                            Id = 2,
                            ConfirmPassword = "hashedpassword",
                            EmailAddress = "jane.smith@example.com",
                            FirstName = "Jane",
                            IsActive = true,
                            LastName = "Smith",
                            Password = "hashedpassword",
                            PhoneNumber = "0987654321",
                            RoleId = 2,
                            Token = "tokenvalue"
                        });
                });

            modelBuilder.Entity("Quizz.Domain.Infrastructure.Data.Entities.EFCandidate", b =>
                {
                    b.HasOne("Quizz.Domain.Infrastructure.Data.Entities.EFUser", "Agent")
                        .WithMany("Candidates")
                        .HasForeignKey("AgentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Agent");
                });

            modelBuilder.Entity("Quizz.Domain.Infrastructure.Data.Entities.EFCandidateResponse", b =>
                {
                    b.HasOne("Quizz.Domain.Infrastructure.Data.Entities.EFQuiz_Question", "Quiz_Question")
                        .WithMany("CandidateResponses")
                        .HasForeignKey("QuizId", "QuestionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Quiz_Question");
                });

            modelBuilder.Entity("Quizz.Domain.Infrastructure.Data.Entities.EFLevel", b =>
                {
                    b.HasOne("Quizz.Domain.Infrastructure.Data.Entities.EFUser", "Admin")
                        .WithMany("Levels")
                        .HasForeignKey("AdminId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Admin");
                });

            modelBuilder.Entity("Quizz.Domain.Infrastructure.Data.Entities.EFQuestion", b =>
                {
                    b.HasOne("Quizz.Domain.Infrastructure.Data.Entities.EFUser", "Admin")
                        .WithMany("Questions")
                        .HasForeignKey("AdminId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Quizz.Domain.Infrastructure.Data.Entities.EFLevel", "Level")
                        .WithMany("Questions")
                        .HasForeignKey("TechnologyId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Quizz.Domain.Infrastructure.Data.Entities.EFTechnology", "Technology")
                        .WithMany("Questions")
                        .HasForeignKey("TechnologyId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Admin");

                    b.Navigation("Level");

                    b.Navigation("Technology");
                });

            modelBuilder.Entity("Quizz.Domain.Infrastructure.Data.Entities.EFQuiz", b =>
                {
                    b.HasOne("Quizz.Domain.Infrastructure.Data.Entities.EFUser", "Admin")
                        .WithMany("AdministeredQuizzes")
                        .HasForeignKey("AdminId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Quizz.Domain.Infrastructure.Data.Entities.EFUser", "Agent")
                        .WithMany("AssignedQuizzes")
                        .HasForeignKey("AgentId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Quizz.Domain.Infrastructure.Data.Entities.EFCandidate", "Candidate")
                        .WithMany("Quizzes")
                        .HasForeignKey("CandidateId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Quizz.Domain.Infrastructure.Data.Entities.EFStatus", "Status")
                        .WithMany("Quizzes")
                        .HasForeignKey("StatusId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Quizz.Domain.Infrastructure.Data.Entities.EFTechnology", "Technology")
                        .WithMany("Quizzes")
                        .HasForeignKey("TechnologyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Admin");

                    b.Navigation("Agent");

                    b.Navigation("Candidate");

                    b.Navigation("Status");

                    b.Navigation("Technology");
                });

            modelBuilder.Entity("Quizz.Domain.Infrastructure.Data.Entities.EFQuiz_Question", b =>
                {
                    b.HasOne("Quizz.Domain.Infrastructure.Data.Entities.EFQuestion", "Question")
                        .WithMany()
                        .HasForeignKey("QuestionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Quizz.Domain.Infrastructure.Data.Entities.EFQuiz", "Quiz")
                        .WithMany("Quiz_Questions")
                        .HasForeignKey("QuizId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Question");

                    b.Navigation("Quiz");
                });

            modelBuilder.Entity("Quizz.Domain.Infrastructure.Data.Entities.EFResponse", b =>
                {
                    b.HasOne("Quizz.Domain.Infrastructure.Data.Entities.EFQuestion", "Question")
                        .WithMany("Responses")
                        .HasForeignKey("QuestionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Question");
                });

            modelBuilder.Entity("Quizz.Domain.Infrastructure.Data.Entities.EFTechnology", b =>
                {
                    b.HasOne("Quizz.Domain.Infrastructure.Data.Entities.EFUser", "Admin")
                        .WithMany("Technologies")
                        .HasForeignKey("AdminId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Admin");
                });

            modelBuilder.Entity("Quizz.Domain.Infrastructure.Data.Entities.EFUser", b =>
                {
                    b.HasOne("Quizz.Domain.Infrastructure.Data.Entities.EFRole", "Role")
                        .WithMany("Users")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Role");
                });

            modelBuilder.Entity("Quizz.Domain.Infrastructure.Data.Entities.EFCandidate", b =>
                {
                    b.Navigation("Quizzes");
                });

            modelBuilder.Entity("Quizz.Domain.Infrastructure.Data.Entities.EFLevel", b =>
                {
                    b.Navigation("Questions");
                });

            modelBuilder.Entity("Quizz.Domain.Infrastructure.Data.Entities.EFQuestion", b =>
                {
                    b.Navigation("Responses");
                });

            modelBuilder.Entity("Quizz.Domain.Infrastructure.Data.Entities.EFQuiz", b =>
                {
                    b.Navigation("Quiz_Questions");
                });

            modelBuilder.Entity("Quizz.Domain.Infrastructure.Data.Entities.EFQuiz_Question", b =>
                {
                    b.Navigation("CandidateResponses");
                });

            modelBuilder.Entity("Quizz.Domain.Infrastructure.Data.Entities.EFRole", b =>
                {
                    b.Navigation("Users");
                });

            modelBuilder.Entity("Quizz.Domain.Infrastructure.Data.Entities.EFStatus", b =>
                {
                    b.Navigation("Quizzes");
                });

            modelBuilder.Entity("Quizz.Domain.Infrastructure.Data.Entities.EFTechnology", b =>
                {
                    b.Navigation("Questions");

                    b.Navigation("Quizzes");
                });

            modelBuilder.Entity("Quizz.Domain.Infrastructure.Data.Entities.EFUser", b =>
                {
                    b.Navigation("AdministeredQuizzes");

                    b.Navigation("AssignedQuizzes");

                    b.Navigation("Candidates");

                    b.Navigation("Levels");

                    b.Navigation("Questions");

                    b.Navigation("Technologies");
                });
#pragma warning restore 612, 618
        }
    }
}
