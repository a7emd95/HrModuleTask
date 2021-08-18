using Core.Models.Candidate;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Validitors
{
    public class CandidateValiditor : AbstractValidator<CreateCandidateModel>
    {
        public CandidateValiditor()
        {
            RuleFor(c => c.Name)
                .NotEmpty().WithMessage("Name Must Not Be Empty")
                .MinimumLength(3).WithMessage("Name Must Be At Least 3 Characters");

            RuleFor(c => c.Email)
                .NotEmpty().WithMessage("Email Must Not Be Empty")
                .EmailAddress().WithMessage("Not Valid Email");
                
                
        }
    }
}
