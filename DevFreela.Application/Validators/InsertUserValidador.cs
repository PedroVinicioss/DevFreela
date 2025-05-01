using DevFreela.Application.Commands.InsertUser;
using FluentValidation;

namespace DevFreela.Application.Validators
{
    public class InsertUserValidador : AbstractValidator<InsertUserCommand>
    {
        public InsertUserValidador() 
        {
            RuleFor(e => e.Email)
                .NotEmpty()
                    .WithMessage("Email is required")
                .EmailAddress()
                    .WithMessage("Email is not valid");

            RuleFor(b => b.BirthDate)
                .Must(d => d < DateTime.Now.AddYears(-18))
                    .WithMessage("User must be at least 18 years old");
        }
    }
}
