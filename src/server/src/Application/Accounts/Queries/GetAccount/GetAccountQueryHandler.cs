using System;
using System.Threading;
using System.Threading.Tasks;
using GitNode.Application.Common.Interfaces;
using GitNode.Domain.Entities;
using MediatR;

namespace GitNode.Application.Accounts.Queries.GetAccount
{
    public class GetAccountQueryHandler : IRequestHandler<GetAccountQuery, AccountEntity>
    {
        private readonly IUnitOfWork _db;
        private readonly ICurrentUserService _currentUser;

        public GetAccountQueryHandler(IUnitOfWork db, ICurrentUserService currentUser)
        {
            _db = db;
            _currentUser = currentUser;
        }
        
        public async Task<AccountEntity> Handle(GetAccountQuery request, CancellationToken cancellationToken)
        {
            var response = await _db.Accounts.GetWithPlatformAsync(
                request.Id,
                _currentUser.Id,
                cancellationToken);

            if (response == null)
            {
                // TODO: exception type
                throw new Exception();
            }

            return response;
        }
    }
}