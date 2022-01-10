using MediatR;

namespace GitNode.Application.Identity.Commands.RevokeToken
{
    public class RevokeTokenCommand : IRequest<Unit>
    {
        public RevokeTokenCommand(string token)
        {
            Token = token;
        }
        
        public string Token { get; set; }
    }
}