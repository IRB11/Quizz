using Microsoft.EntityFrameworkCore;
using Quizz.Domain.Infrastructure.Data.Entities;

namespace Quizz.Domain.Infrastructure.Data
{
    public class Context : DbContext
    {
        public DbSet<EFCandidate> Candidates { get; set; }
        public DbSet<EFUser> Users { get; set; }
        public DbSet<EFQuiz> Quizzes { get; set; }
        public DbSet<EFQuestion> Questions { get; set; }
        public DbSet<EFResponse> Responses { get; set; }
        public DbSet<EFTechnology> Technologies { get; set; }
        public DbSet<EFLevel> Levels { get; set; }
        public DbSet<EFRole> Roles { get; set; }
        public DbSet<EFStatus> Statuses { get; set; }
        public DbSet<EFQuiz_Question> QuizQuestions { get; set; }
        public DbSet<EFCandidateResponse> CandidateResponses { get; set; }
        public Context(DbContextOptions<Context> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.ApplyConfigurationsFromAssembly(typeof(Context).Assembly);
        }
    }
}
