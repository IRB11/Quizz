using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Quizz.Domain.Infrastructure.Data.Entities;

namespace Quizz.Domain.Infrastructure.Data.Config
{
    public class LevelConfiguration : IEntityTypeConfiguration<EFLevel>
    {
        public void Configure(EntityTypeBuilder<EFLevel> builder)
        {
            builder
                .HasOne(l => l.Admin)
                .WithMany(a => a.Levels)
                .HasForeignKey(l => l.AdminId);

            builder.HasKey(e => e.Id);

            builder.Property(e => e.Content)
                .IsRequired()
                .HasMaxLength(50);                   

            builder.Property(e => e.IsActive);
        }
    }
}
