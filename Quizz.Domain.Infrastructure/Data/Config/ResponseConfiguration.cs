using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Quizz.Domain.Infrastructure.Data.Entities;

namespace Quizz.Domain.Infrastructure.Data.Config
{
    public class ResponseConfiguration : IEntityTypeConfiguration<EFResponse>
    {
        public void Configure(EntityTypeBuilder<EFResponse> builder)
        {

            builder.
                HasOne(x => x.Question).
                WithMany(c => c.Responses)
                .HasPrincipalKey(k => k.Id);

            builder.HasKey(e => e.Id);

            builder.Property(e => e.Content)
                  .IsRequired()
                  .HasMaxLength(150);

            builder.Property(e => e.IsCorrect)
                  .IsRequired();

        }
    }
}
