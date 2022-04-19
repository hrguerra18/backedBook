using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Feautres.Books.Commands.UpdateBookCommand
{
    public class UpdateBookCommandValidator : AbstractValidator<UpdateBookCommand>
    {
        public UpdateBookCommandValidator()
        {
            RuleFor(b => b.Id).NotEmpty()
                .WithMessage("{PropertyName} no puede ser vacio");
            RuleFor(b => b.Title)
                .NotEmpty().WithMessage("{PropertyName no puede ser vacio}")
                .MaximumLength(50).WithMessage("{PropertyName no debe de exceder de {MaxLength} caracteres}");
            RuleFor(b => b.Author)
                .NotEmpty().WithMessage("{PropertyName} no puede ser vacio")
                .MaximumLength(30).WithMessage("{PropertyName} no debe de exceder de {MaxLength caracteres}");
            RuleFor(b => b.Publisher)
                .NotEmpty().WithMessage("{PropertyName} no puede ser vacio")
                .MaximumLength(50).WithMessage("{PropertyName} no debe de exceder de {MaxLength caracteres}");
            RuleFor(b => b.Genre)
                .NotEmpty().WithMessage("{PropertyName} no puede ser vacio")
                .MaximumLength(20).WithMessage("{PropertyName} no debe de exceder de {MaxLength caracteres}");
            RuleFor(b => b.Price)
                .NotEmpty().WithMessage("{PropertyName} no puede ser vacio")
                .GreaterThanOrEqualTo(1).WithMessage("{PropertyName} debe ser mayor a 0");

        }
    }
}
