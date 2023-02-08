using Data.DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Validators
{
    public class AuthorValidator : AbstractValidator<AuthorDTO>
    {
        public AuthorValidator()
        {
            RuleFor(model => model.Name)
                .NotEmpty()
                .WithMessage("Name can not be empty.");
            RuleFor(model => model.Surname)
                .NotEmpty()
                .WithMessage("Surname can not be empty.");
        }
    }
}
