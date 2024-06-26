﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Quizz.Domain.Infrastructure.Data;

#nullable disable

namespace Quizz.Domain.Infrastructure.Data.Migrations
{
    [DbContext(typeof(Context))]
    [Migration("20240626094111_Change candidate strint Id to int Id")]
    partial class ChangecandidatestrintIdtointId
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
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
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("AgentId");

                    b.ToTable("Candidates");
                });

            modelBuilder.Entity("Quizz.Domain.Infrastructure.Data.Entities.EFCandidateResponse", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Comment")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Content")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Explanation")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Is_Skipped")
                        .HasColumnType("bit");

                    b.Property<string>("Open_Response_Text")
                        .HasColumnType("nvarchar(max)");

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
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.HasIndex("AdminId");

                    b.ToTable("Levels");
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
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("EFQuizId")
                        .HasColumnType("int");

                    b.Property<bool>("IsValid")
                        .HasColumnType("bit");

                    b.Property<int>("LevelId")
                        .HasColumnType("int");

                    b.Property<int>("TechnologyId")
                        .HasColumnType("int");

                    b.Property<string>("Type")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("AdminId");

                    b.HasIndex("EFQuizId");

                    b.HasIndex("LevelId");

                    b.HasIndex("TechnologyId");

                    b.ToTable("Questions");
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
                        .HasColumnType("nvarchar(max)");

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
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Result")
                        .HasPrecision(18, 2)
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("StatusId")
                        .HasColumnType("int");

                    b.Property<int>("TechnologyId")
                        .HasColumnType("int");

                    b.Property<string>("URL")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("AdminId");

                    b.HasIndex("AgentId");

                    b.HasIndex("CandidateId");

                    b.HasIndex("StatusId");

                    b.HasIndex("TechnologyId");

                    b.ToTable("Quizzes");
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
                });

            modelBuilder.Entity("Quizz.Domain.Infrastructure.Data.Entities.EFResponse", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Content")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("QuestionId")
                        .HasColumnType("int");

                    b.Property<bool>("isCorrect")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.HasIndex("QuestionId");

                    b.ToTable("Responses");
                });

            modelBuilder.Entity("Quizz.Domain.Infrastructure.Data.Entities.EFRole", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("Quizz.Domain.Infrastructure.Data.Entities.EFStatus", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Status")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Statuses");
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
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("AdminId");

                    b.ToTable("Technologies");
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

                    b.HasOne("Quizz.Domain.Infrastructure.Data.Entities.EFQuiz", null)
                        .WithMany("Questions")
                        .HasForeignKey("EFQuizId");

                    b.HasOne("Quizz.Domain.Infrastructure.Data.Entities.EFLevel", "Level")
                        .WithMany()
                        .HasForeignKey("LevelId")
                        .OnDelete(DeleteBehavior.Cascade)
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

            modelBuilder.Entity("Quizz.Domain.Infrastructure.Data.Entities.EFQuestion", b =>
                {
                    b.Navigation("Responses");
                });

            modelBuilder.Entity("Quizz.Domain.Infrastructure.Data.Entities.EFQuiz", b =>
                {
                    b.Navigation("Questions");

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
