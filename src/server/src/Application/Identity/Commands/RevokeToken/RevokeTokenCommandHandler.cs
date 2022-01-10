using System.Threading;
using System.Threading.Tasks;
using GitNode.Application.Common.Interfaces;
using MediatR;

namespace GitNode.Application.Identity.Commands.RevokeToken
{
    public class RevokeTokenCommandHandler : IRequestHandler<RevokeTokenCommand>
    {
        private readonly IUserManager _userManager;

        public RevokeTokenCommandHandler(IUserManager userManager)
        {
            _userManager = userManager;
        }
        
        public async Task<Unit> Handle(RevokeTokenCommand request, CancellationToken cancellationToken)
        {
            // TODO: exception when token was not revoked
            await _userManager.RevokeTokenAsync(request.Token, cancellationToken);
            return Unit.Value;
        }
    }
}