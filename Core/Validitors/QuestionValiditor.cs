using Core.Models.Question;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Validitors
{
    public class QuestionValiditor : AbstractValidator<CreateQuestionModel>
    {
        public QuestionValiditor()
        {
            RuleFor(q => q.QuestionBodyText)
                .NotEmpty().WithMessage("Question should not empty")
                .MinimumLength(3).WithMessage("So short question body");

        }
    }
}
