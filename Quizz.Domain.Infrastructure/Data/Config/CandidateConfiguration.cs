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
    public class CandidateConfiguration : IEntityTypeConfiguration<EFCandidate>
    {
        public void Configure(EntityTypeBuilder<EFCandidate> builder)
        {
            builder
                .HasOne(c => c.Agent)
                .WithMany(u => u.Candidates)
                .HasForeignKey(c => c.AgentId);


        }
    }
}
