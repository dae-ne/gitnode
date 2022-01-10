using System;
using System.Threading;
using System.Threading.Tasks;
using GitNode.Application.Common.Interfaces;
using GitNode.Domain.Entities;
using MediatR;

namespace GitNode.Application.Users.Queries.GetAuthenticatedUser
{
    public class GetAuthenticatedUserQueryHandler : IRequestHandler<GetAuthenticatedUserQuery, UserEntity>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICurrentUserService _currentUserService;

        public GetAuthenticatedUserQueryHandler(IUnitOfWork unitOfWork, ICurrentUserService currentUserService)
        {
            _unitOfWork = unitOfWork;
            _currentUserService = currentUserService;
        }
        
        public async Task<UserEntity> Handle(GetAuthenticatedUserQuery request, CancellationToken cancellationToken)
        {
            var response = await _unitOfWork.Users.GetAsync(_currentUserService.Id, cancellationToken);

            if (response == null)
            {
                // TODO: exception type
                throw new Exception($"User with ID {_currentUserService.Id} doesn't exist");
            }
            
            return response;
        }
    }
}