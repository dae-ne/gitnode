using FluentValidation;

namespace GitNode.Application.Repos.Queries.GetExternalRepos
{
    public class GetExternalReposQueryValidator : AbstractValidator<GetExternalReposQuery>
    {
        public GetExternalReposQueryValidator()
        {
            RuleFor(r => r.Account).NotEmpty();
        }
    }
}