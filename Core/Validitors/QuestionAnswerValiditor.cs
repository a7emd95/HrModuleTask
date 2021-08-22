using Core.Models.QuestionAnswer;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Validitors
{
    public class QuestionAnswerValiditor : AbstractValidator<CreateQuestionAnswerModel>
    {
        public QuestionAnswerValiditor()
        {
            RuleFor(qa => qa.AnswerBodyText)
              .NotEmpty().WithMessage("Answer should not empty");

        }
    }
}
