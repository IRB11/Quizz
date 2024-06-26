using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Quizz.Domain.Infrastructure.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        }
    }
}
