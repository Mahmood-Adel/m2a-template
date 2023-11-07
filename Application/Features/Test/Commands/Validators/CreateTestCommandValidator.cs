using FluentValidation;

namespace Application.Features.Test.Commands.Validators;

public class CreateTestCommandValidator : AbstractValidator<CreateTestCommand>
{
    public CreateTestCommandValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty()
            .WithName("name");
    }
}