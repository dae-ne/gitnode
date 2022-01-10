using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using GitNode.Application.Common.Interfaces;
using GitNode.Domain.Entities;
using MediatR;

namespace GitNode.Application.Users.Queries.GetUsers
{
    public class GetUsersQueryHandler : IRequestHandler<GetUsersQuery, IEnumerable<UserEntity>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetUsersQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        
        public Task<IEnumerable<UserEntity>> Handle(GetUsersQuery request, CancellationToken cancellationToken)
        {
            return _unitOfWork.Users.GetAllAsync(cancellationToken);
        }
    }
}