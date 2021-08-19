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
    class QuestionAnswerConfiguration : IEntityTypeConfiguration<QuestionAnswer>
    {
        public void Configure(EntityTypeBuilder<QuestionAnswer> builder)
        {
            builder.ToTable("QuestionAnswer");

            builder.Property(qa => qa.PublicId)
                .ValueGeneratedOnAdd()
                .HasDefaultValueSql("NEWID()");

            builder.Property(qa => qa.AnswerBodyText)
                .IsRequired();

            builder.HasOne(qa => qa.Question)
                .WithMany(q => q.QuestionAnswers)
                .HasForeignKey(qa => qa.QuestionId);
        }
    }
}
