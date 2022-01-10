using FluentValidation;

namespace GitNode.Application.Repos.Commands.UpdateRepo
{
    public class UpdateRepoCommandValidator : AbstractValidator<UpdateRepoCommand>
    {
        public UpdateRepoCommandValidator()
        {
            RuleFor(r => r.Id).NotEmpty();
            
            RuleFor(r => r.Name)
                .MaximumLength(30)
                .MinimumLength(4)
                .NotEmpty();
        }
    }
}