using FluentValidation;

namespace GitNode.Application.Repos.Queries.GetRepo
{
    public class GetRepositoryQueryValidator : AbstractValidator<GetRepoQuery>
    {
        public GetRepositoryQueryValidator()
        {
            RuleFor(r => r.Id).NotEmpty();
        }
    }
}