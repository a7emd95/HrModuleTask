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
    public class QuestionTypeConfiguration : IEntityTypeConfiguration<QuestionType>
    {
        public void Configure(EntityTypeBuilder<QuestionType> builder)
        {
            builder.ToTable("QuestionType");

            builder.Property(qt => qt.publicId)
                .ValueGeneratedOnAdd()
                .HasDefaultValueSql("NEWID()");

            builder.Property(qt => qt.Type)
                .IsRequired();

            builder.HasData(new QuestionType { ID = 1 , Type = "MCQ" , AnswersCapcity = 4 },
                new QuestionType { ID = 2 , Type = "YesOrNo" , AnswersCapcity = 2 },
                new QuestionType { ID = 3 , Type = "MultiSelected" , AnswersCapcity = 4 }
                );

           
        }
    }
}
