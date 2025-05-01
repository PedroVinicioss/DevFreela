using DevFreela.Application.Commands.InsertProject;
using FluentValidation;

namespace DevFreela.Application.Validators
{
    public class InsertProjectValidator : AbstractValidator<InsertProjectCommand>
    {
        public InsertProjectValidator()
        {
            RuleFor(x => x.Title)
                .NotEmpty()
                    .WithMessage("Title is required")
                .MaximumLength(50)
                    .WithMessage("Title must be at most 50 characters long");

            RuleFor(x => x.Description)
                .NotEmpty()
                    .WithMessage("Description is required")
                .MaximumLength(500)
                    .WithMessage("Description must be at most 500 characters long");

            RuleFor(x => x.TotalCost)
                .GreaterThan(0)
                    .WithMessage("Total cost must be greater than 0");
        }
    }
}
