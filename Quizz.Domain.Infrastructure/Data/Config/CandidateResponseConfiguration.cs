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
    public class CandidateResponseConfiguration : IEntityTypeConfiguration<EFCandidateResponse>
    {
        public void Configure(EntityTypeBuilder<EFCandidateResponse> builder)
        {
        }
    }
}
