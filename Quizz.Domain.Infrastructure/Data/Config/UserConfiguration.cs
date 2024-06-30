using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Quizz.Domain.Infrastructure.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quizz.Domain.Infrastructure.Data.Config
{
    public class UserConfiguration
    {
        public void Configure(EntityTypeBuilder<EFUser> builder)
        {
            builder
                .HasOne(u => u.Role)
                .WithMany(r => r.Users)
                .HasForeignKey(u => u.RoleId);

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
