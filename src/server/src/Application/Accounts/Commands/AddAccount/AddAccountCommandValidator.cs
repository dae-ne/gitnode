using FluentValidation;

namespace GitNode.Application.Accounts.Commands.AddAccount
{
    public class AddAccountCommandValidator : AbstractValidator<AddAccountCommand>
    {
        public AddAccountCommandValidator()
        {
            RuleFor(x => x.Code).NotEmpty();
        }
    }
}