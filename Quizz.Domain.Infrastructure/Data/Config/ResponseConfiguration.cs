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
    public class ResponseConfiguration : IEntityTypeConfiguration<EFResponse>
    {
        public void Configure(EntityTypeBuilder<EFResponse> builder)
        {

            builder.
                HasOne(x => x.Question).
                WithMany(c => c.Responses)
                .HasPrincipalKey(k => k.Id);

        }
    }
}
