using FluentValidation;

namespace Application.Feautres.Books.Commands.CreateBookCommand
{
    public class CreateBookCommandValidator : AbstractValidator<CreateBookCommand>
    {
        public CreateBookCommandValidator()
        {
            //esto es para validar los datos
            //el propertyName es para copiar y egar en el mensaje la variable
            RuleFor(p => p.Title)
                .NotEmpty().WithMessage("{PropertyName} no puede ser vacio.")
                .MaximumLength(50).WithMessage("{PropertyName} no debe exceder de {MaxLength} caracteres");

            RuleFor(p => p.Author)
                .NotEmpty().WithMessage("{PropertyName} no puede ser vacio.")
                .MaximumLength(30).WithMessage("{PropertyName} no debe exceder de {MaxLength} caracteres");

            RuleFor(p => p.Publisher)
                .NotEmpty().WithMessage("{PropertyName} no puede ser vacio.")
                .MaximumLength(50).WithMessage("{PropertyName} no debe exceder de {MaxLength} caracteres");

            RuleFor(p => p.Genre)
                .NotEmpty().WithMessage("{PropertyName} no puede ser vacio.")
                .MaximumLength(20).WithMessage("{PropertyName} no debe exceder de {MaxLength} caracteres");

            RuleFor(p => p.Price)
                .GreaterThanOrEqualTo(1).WithMessage("{PropertyName} tiene que ser mayor a 0")
                .NotEmpty().WithMessage("{PropertyName} no puede ser vacio.");
                
        }
    }
}
