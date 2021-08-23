using Core.Models.UserMangment;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Validitors
{
    public class LoginValiditor : AbstractValidator<LoginModel>
    {
        public LoginValiditor()
        {
            RuleFor(l => l.Email)
                .NotEmpty().WithMessage("Email is empty")
                .EmailAddress();

            RuleFor(l => l.Passward)
                .NotEmpty().WithMessage("Passward is empty");
               
        }
    }
}
