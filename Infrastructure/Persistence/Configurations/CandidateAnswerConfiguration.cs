using Core.Entites;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Persistence.Configurations
{
    class CandidateAnswerConfiguration : IEntityTypeConfiguration<CandidateAnswer>
    {
        public void Configure(EntityTypeBuilder<CandidateAnswer> builder)
        {
            builder.ToTable("CandidateAnswer");

            builder.Property(ca => ca.PublicId)
                .ValueGeneratedOnAdd()
                .HasDefaultValueSql("NEWID()");

            builder.HasOne(ca => ca.InterviewExam)
                .WithMany(ie => ie.CandidateAnswers)
                .HasForeignKey(ca => ca.InterviewExamId);

            builder.HasOne(ca => ca.Question)
                .WithMany(ie => ie.CandidateAnswers)
                .HasForeignKey(ca => ca.QuestionId);



        }
    }
}
