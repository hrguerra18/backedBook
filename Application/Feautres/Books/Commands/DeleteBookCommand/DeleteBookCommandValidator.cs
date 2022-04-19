using FluentValidation;

namespace Application.Feautres.Books.Commands.DeleteBookCommand
{
    public class DeleteBookCommandValidator : AbstractValidator<DeleteBookCommand>
    {
        public DeleteBookCommandValidator()
        {
            RuleFor(b => b.Id)
                .NotEmpty().WithMessage("{PropertyName} no puede ser vacio");
        }
    }
}
