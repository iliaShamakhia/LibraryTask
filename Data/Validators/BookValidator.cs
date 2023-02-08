using Data.DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Validators
{
    public class BookValidator : AbstractValidator<BookDTO>
    {
        public BookValidator()
        {
            RuleFor(model => model.Title)
                .NotEmpty()
                .WithMessage("Title can not be empty.");
            RuleFor(model => model.Description)
                .NotEmpty()
                .WithMessage("Description can not be empty.");
            RuleFor(model => model.ImageUrl)
                .NotEmpty()
                .WithMessage("Image Url can not be empty.");
            RuleFor(model => model.Rating)
                .GreaterThanOrEqualTo(0.0)
                .WithMessage("Rating can not be negative.");
            RuleFor(model => model.Authors)
                .NotEmpty()
                .WithMessage("Book must have at least one author");
        }
    }
}
