using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Quizz.Domain.Infrastructure.Data.Entities;

namespace Quizz.Domain.Infrastructure.Data.Config
{
    public class CandidateResponseConfiguration : IEntityTypeConfiguration<EFCandidateResponse>
    {
        public void Configure(EntityTypeBuilder<EFCandidateResponse> builder)
        {
            builder.HasKey(e => e.Id);

            builder.Property(e => e.Content)
                  .IsRequired()
                  .HasMaxLength(150);

            builder.Property(e => e.Open_Response_Text)
                  .HasMaxLength(500);

            builder.Property(e => e.Explanation)
                  .HasMaxLength(500); 

            builder.Property(e => e.Comment)
                  .HasMaxLength(500);
        }
    }
}
