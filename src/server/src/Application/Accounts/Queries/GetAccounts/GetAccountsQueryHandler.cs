using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using GitNode.Application.Common.Interfaces;
using GitNode.Domain.Entities;
using MediatR;

namespace GitNode.Application.Accounts.Queries.GetAccounts
{
    public class GetAccountsQueryHandler : IRequestHandler<GetAccountsQuery, IEnumerable<AccountEntity>>
    {
        private readonly IUnitOfWork _db;
        private readonly ICurrentUserService _currentUser;

        public GetAccountsQueryHandler(IUnitOfWork db, ICurrentUserService currentUser)
        {
            _db = db;
            _currentUser = currentUser;
        }
        
        public Task<IEnumerable<AccountEntity>> Handle(GetAccountsQuery request, CancellationToken cancellationToken)
        {
            return _db.Accounts.GetListWithPlatformsAsync(_currentUser.Id, cancellationToken);
        }
    }
}