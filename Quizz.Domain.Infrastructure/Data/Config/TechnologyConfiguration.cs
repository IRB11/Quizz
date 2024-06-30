using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Quizz.Domain.Infrastructure.Data.Entities;

namespace Quizz.Domain.Infrastructure.Data.Config
{
    internal class TechnologyConfiguration : IEntityTypeConfiguration<EFTechnology>
    {
        public void Configure(EntityTypeBuilder<EFTechnology> builder)
        {
            builder
                .HasOne(c => c.Admin)
                .WithMany(a => a.Technologies)
                .HasPrincipalKey(k => k.Id)
                .HasForeignKey(c => c.AdminId).OnDelete(DeleteBehavior.NoAction);

            builder.Property(e => e.Name)
                .IsRequired();

        }
    }
}
