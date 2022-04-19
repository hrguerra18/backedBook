using FluentValidation;

namespace Application.Feautres.Users.Commands.CreateUserCommand
{
    public class CreateUserCommandValidator : AbstractValidator<CreateUserCommand>
    {
        public CreateUserCommandValidator()
        {
            RuleFor(u => u.Username)
                .NotEmpty().WithMessage("{PropertyName} no puede ser vacio")
                .MaximumLength(50).WithMessage("{PropertyName} no debe exceder de {MaxLength} caracteres");
            RuleFor(u => u.Password)
                .NotEmpty().WithMessage("{PropertyName} no puede ser vacio")
                .MaximumLength(20).WithMessage("{PropertyName} no debe exceder de {MaxLength} caracteres");
        }
    }
}
