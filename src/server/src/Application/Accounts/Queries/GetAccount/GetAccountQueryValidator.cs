using FluentValidation;

namespace GitNode.Application.Accounts.Queries.GetAccount
{
    public class GetAccountQueryValidator : AbstractValidator<GetAccountQuery>
    {
        public GetAccountQueryValidator()
        {
            RuleFor(a => a.Id).NotEmpty();
        }
    }
}