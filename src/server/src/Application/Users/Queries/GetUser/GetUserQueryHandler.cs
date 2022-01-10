using System;
using System.Threading;
using System.Threading.Tasks;
using GitNode.Application.Common.Interfaces;
using GitNode.Domain.Entities;
using MediatR;

namespace GitNode.Application.Users.Queries.GetUser
{
    public class GetUserQueryHandler : IRequestHandler<GetUserQuery, UserEntity>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetUserQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        
        public async Task<UserEntity> Handle(GetUserQuery request, CancellationToken cancellationToken)
        {
            var user = await _unitOfWork.Users.GetAsync(request.Id, cancellationToken);

            if (user == null)
            {
                // TODO: exception type
                throw new Exception($"User with ID {request.Id} doesn't exist");
            }
            
            return user;
        }
    }
}