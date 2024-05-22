using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Quizz.Domain.Core.Entities;
using Quizz.Domain.Infrastructure.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quizz.Domain.Infrastructure.Data.Config
{
    public class QuestionConfiguration : IEntityTypeConfiguration<EFQuestion>
    {
        public void Configure(EntityTypeBuilder<EFQuestion> builder)
        {
            builder
                .HasOne(q => q.Admin)
                .WithMany(u => u.Questions)
                .HasForeignKey(q => q.AdminId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasOne(q => q.Level)
                .WithMany(l => l.Questions)
                .HasForeignKey(q => q.LevelId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasOne(q => q.Technology)
                .WithMany(t => t.Questions)
                .HasForeignKey(q => q.TechnologyId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
