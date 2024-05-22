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
    public class StatusConfiguration : IEntityTypeConfiguration<EFStatus>
    {
        public void Configure(EntityTypeBuilder<EFStatus> builder)
        {
            builder
                .HasMany(c => c.Quizzes)
                .WithOne(c => c.Status)
                .HasForeignKey(f => f.StatusId);
        }
    }
}
