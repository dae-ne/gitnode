using FluentValidation;

namespace GitNode.Application.Identity.Commands.RevokeToken
{
    public class RevokeTokenCommandValidator : AbstractValidator<RevokeTokenCommand>
    {
        public RevokeTokenCommandValidator()
        {
            RuleFor(request => request.Token)
                .NotEmpty();
        }
    }
}