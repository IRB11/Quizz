using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Quizz.Domain.Infrastructure.Data.Entities;

namespace Quizz.Domain.Infrastructure.Data.Config
{
    public class RoleConfiguration : IEntityTypeConfiguration<EFRole>
    {
        public void Configure(EntityTypeBuilder<EFRole> builder)
        {
            builder
                .HasMany(r => r.Users)
                .WithOne(u => u.Role)
                .HasForeignKey(u => u.RoleId);

            builder.HasKey(e => e.Id);

            builder.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(50);
        }
    }
}
