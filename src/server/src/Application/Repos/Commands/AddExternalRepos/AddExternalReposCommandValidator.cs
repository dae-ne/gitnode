using FluentValidation;

namespace GitNode.Application.Repos.Commands.AddExternalRepos
{
    public class AddExternalReposCommandValidator : AbstractValidator<AddExternalReposCommand>
    {
        public AddExternalReposCommandValidator()
        {
            RuleFor(r => r.Account).NotEmpty();
            
            RuleFor(r => r.OriginIds).NotNull();
            
            RuleForEach(model => model.OriginIds)
                .NotEmpty()
                .WithMessage("Please fill all items");
        }
    }
}