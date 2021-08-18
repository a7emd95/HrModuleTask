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
                .NotEmpty().WithMessage("Title Shouldn't Be Empty")
                .NotNull()
                .MinimumLength(2).WithMessage("Title Should Be More Than 2 Characters")
                .MaximumLength(100).WithMessage("Title Should Be Less Than 100 Characters");        
        }
    }
}
