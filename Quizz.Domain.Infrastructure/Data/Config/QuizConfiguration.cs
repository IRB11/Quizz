using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Quizz.Domain.Infrastructure.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace Quizz.Domain.Infrastructure.Data.Config
{
    public class QuizConfiguration : IEntityTypeConfiguration<EFQuiz>
    {
        public void Configure(EntityTypeBuilder<EFQuiz> builder)
        {
            builder
                .HasOne(q => q.Agent)
                .WithMany(u => u.AssignedQuizzes)
                .HasForeignKey(q => q.AgentId)
                .OnDelete(DeleteBehavior.Restrict);
            builder
                .HasOne(q => q.Admin)
                .WithMany(u => u.AdministeredQuizzes)
                .HasForeignKey(q => q.AdminId)
                .OnDelete(DeleteBehavior.Restrict);

           builder
                .HasOne(q => q.Status)
                .WithMany(s => s.Quizzes)
                .HasForeignKey(q => q.StatusId);

            builder
                .HasOne(c => c.Candidate)
                .WithMany(q => q.Quizzes)
                .HasForeignKey(c => c.CandidateId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .Property(q => q.Completion)
                .HasPrecision(18, 2);
            builder
                .Property(q => q.Result)
                .HasPrecision(18,2);
        }

    }
    
}
