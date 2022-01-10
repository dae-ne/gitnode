using FluentValidation;
using GitNode.Domain.Enums;

namespace GitNode.Application.Identity.Commands.GetToken
{
    public class GetTokenCommandValidator : AbstractValidator<GetTokenCommand>
    {
        public GetTokenCommandValidator()
        {
            RuleFor(request => request.Code)
                .NotEmpty()
                .When(request => request.GrantType == GrantType.AuthorizationCode);
            
            RuleFor(request => request.RefreshToken)
                .NotEmpty()
                .When(request => request.GrantType == GrantType.RefreshToken);
        }
    }
}