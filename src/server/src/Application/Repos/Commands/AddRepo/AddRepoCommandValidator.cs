using FluentValidation;

namespace GitNode.Application.Repos.Commands.AddRepo
{
    public class AddRepoCommandValidator : AbstractValidator<AddRepoCommand>
    {
        public AddRepoCommandValidator()
        {
            RuleFor(r => r.Name)
                .MaximumLength(30)
                .MinimumLength(4)
                .NotEmpty();

            RuleFor(r => r.Account).NotEmpty();
        }
    }
}