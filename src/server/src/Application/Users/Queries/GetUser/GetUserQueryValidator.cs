using FluentValidation;

namespace GitNode.Application.Users.Queries.GetUser
{
    public class GetUserQueryValidator : AbstractValidator<GetUserQuery>
    {
        public GetUserQueryValidator()
        {
            RuleFor(u => u.Id).NotEmpty();
        }
    }
}