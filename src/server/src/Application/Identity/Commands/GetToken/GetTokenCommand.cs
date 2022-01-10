using GitNode.Domain.Enums;
using GitNode.Domain.Models.Identity;
using MediatR;

namespace GitNode.Application.Identity.Commands.GetToken
{
    public class GetTokenCommand : IRequest<AuthData>
    {
        public GetTokenCommand(
            string code,
            string refreshToken,
            GrantType grantType)
        {
            Code = code;
            RefreshToken = refreshToken;
            GrantType = grantType;
        }

        public string Code { get; }
        
        public string RefreshToken { get; }
        
        public GrantType GrantType { get; }
    }
}