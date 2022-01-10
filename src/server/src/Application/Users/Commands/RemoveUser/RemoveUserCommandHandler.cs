using System;
using System.Threading;
using System.Threading.Tasks;
using GitNode.Application.Common.Interfaces;
using GitNode.Domain.Entities;
using MediatR;

namespace GitNode.Application.Users.Commands.RemoveUser
{
    public class RemoveUserCommandHandler : IRequestHandler<RemoveUserCommand>
    {
        private readonly IUnitOfWork _db;
        private readonly ICurrentUserService _currentUser;

        public RemoveUserCommandHandler(IUnitOfWork db, ICurrentUserService currentUser)
        {
            _db = db;
            _currentUser = currentUser;
        }
        
        public async Task<Unit> Handle(RemoveUserCommand request, CancellationToken cancellationToken)
        {
            var user = new UserEntity
            {
                Id = _currentUser.Id,
            };

            _db.Users.Remove(user);
            var affected = await _db.SaveChangesAsync(cancellationToken);
            
            if (affected == 0)
            {
                // TODO: exception type and message
                throw new Exception();
            }
            
            return Unit.Value;
        }
    }
}