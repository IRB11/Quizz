using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Quizz.Domain.Infrastructure.Data.Entities;

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
                .WithMany(t => t.Questions)
                .HasForeignKey(q => q.TechnologyId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasOne(q => q.Technology)
                .WithMany(t => t.Questions)
                .HasForeignKey(q => q.TechnologyId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
