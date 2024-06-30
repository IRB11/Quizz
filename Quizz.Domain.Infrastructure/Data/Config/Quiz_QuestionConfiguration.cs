using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Quizz.Domain.Infrastructure.Data.Entities;

namespace Quizz.Domain.Infrastructure.Data.Config
{
    public class Quiz_QuestionConfiguration : IEntityTypeConfiguration<EFQuiz_Question>
    {
        public void Configure(EntityTypeBuilder<EFQuiz_Question> builder)
        {
            builder.HasKey(q => new { q.QuizId, q.QuestionId });

            builder
                .HasMany(qq => qq.CandidateResponses)
                .WithOne(cr => cr.Quiz_Question)
                .HasForeignKey(cr => new { cr.QuizId, cr.QuestionId })
                .HasPrincipalKey(qq => new { qq.QuizId, qq.QuestionId });

        }
    }
}
