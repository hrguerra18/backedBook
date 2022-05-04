using FluentValidation;

namespace Application.Feautres.Authenticate.Command.RegisterCommand
{
    public class RegisterCommandValidator : AbstractValidator<RegisterCommand>
    {
        public RegisterCommandValidator()
        {
            RuleFor(u => u.UserName)
               .NotEmpty().WithMessage("{PropertyName} no puede ser vacio")
               .MaximumLength(50).WithMessage("{PropertyName} no debe exceder de {MaxLength} caracteres");
            RuleFor(u => u.Password)
                .NotEmpty().WithMessage("{PropertyName} no puede ser vacio")
                .MaximumLength(20).WithMessage("{PropertyName} no debe exceder de {MaxLength} caracteres");
            RuleFor(u => u.Email)
               .NotEmpty().WithMessage("{PropertyName} no puede ser vacio")
               .EmailAddress().WithMessage("{PropertyName} debe ser una direccion de email valida")
               .MaximumLength(100).WithMessage("{PropertyName} no debe exceder de {MaxLength} caracteres");
            RuleFor(u => u.Name)
           .NotEmpty().WithMessage("{PropertyName} no puede ser vacio")
           .MaximumLength(50).WithMessage("{PropertyName} no debe exceder de {MaxLength} caracteres");
            RuleFor(u => u.Surname)
           .NotEmpty().WithMessage("{PropertyName} no puede ser vacio")
           .MaximumLength(50).WithMessage("{PropertyName} no debe exceder de {MaxLength} caracteres");
            RuleFor(u => u.ConfirmPassword)
               .NotEmpty().WithMessage("{PropertyName} no puede ser vacio")
               .MaximumLength(20).WithMessage("{PropertyName} no debe exceder de {MaxLength} caracteres")
               .Equal(p => p.Password).WithMessage("{PropertyName} debe ser igual a Password");
        }
    }
}
