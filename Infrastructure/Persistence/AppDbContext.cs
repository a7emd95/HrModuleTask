using Core.Entites;
using Infrastructure.Persistence.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Persistence
{
    public class AppDbContext : IdentityDbContext<ApplicationUser>
    {
        public AppDbContext() { }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(builder);
        }


        public virtual DbSet<JobPosition> JobPositions { get; set; }
        public virtual DbSet<Candidate> Candidates { get; set; }
        public virtual DbSet<CandidatePosition> CandidatePositons { get; set; }
        public virtual DbSet<Question> Questions { get; set; }
        public virtual DbSet<PositionQuestion> PositionQuestions { get; set; }
        public virtual DbSet<QuestionType> QuestionTypes { get; set; }
        public virtual DbSet<InterviewExam> InterviewExams { get; set; }
        public virtual DbSet<CandidateAnswer> CandidateAnswers{ get; set; }
        public virtual DbSet<QuestionAnswer> QuestionAnswers { get; set; }



    }
}
