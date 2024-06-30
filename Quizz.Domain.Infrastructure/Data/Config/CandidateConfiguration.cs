using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Quizz.Domain.Infrastructure.Data.Entities;

namespace Quizz.Domain.Infrastructure.Data.Config
{
    public class CandidateConfiguration : IEntityTypeConfiguration<EFCandidate>
    {
        public void Configure(EntityTypeBuilder<EFCandidate> builder)
        {
            builder
                .HasOne(c => c.Agent)
                .WithMany(u => u.Candidates)
                .HasForeignKey(c => c.AgentId);

            builder.HasKey(e => e.Id);

            builder.Property(e => e.FirstName)
                  .IsRequired()
                  .HasMaxLength(50);

            builder.Property(e => e.LastName)
                  .IsRequired()
                  .HasMaxLength(50);

            builder.Property(e => e.EmailAddress)
                  .IsRequired()
                  .HasMaxLength(255)
                  .HasAnnotation("EmailAddress", true);

            builder.Property(e => e.PhoneNumber)
                  .HasMaxLength(20)
                  .HasAnnotation("Phone", true);
        }
    }
}
