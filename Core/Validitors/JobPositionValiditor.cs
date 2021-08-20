using Core.Models.JobPosition;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Validitors
{
    public class JobPositionValiditor : AbstractValidator<CreateJobPositionModel>
    {
        public JobPositionValiditor()
        {
            RuleFor(jb => jb.Title)
                .NotEmpty().WithMessage("Title shouldn't be empty")
                .NotNull()
                .MinimumLength(2).WithMessage("Title should be more than 2 characters")
                .MaximumLength(100).WithMessage("title should be less than 100 characters");        
        }
    }
}
