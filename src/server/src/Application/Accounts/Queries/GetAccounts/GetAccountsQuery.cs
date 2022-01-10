using System.Collections.Generic;
using GitNode.Domain.Entities;
using MediatR;

namespace GitNode.Application.Accounts.Queries.GetAccounts
{
    public class GetAccountsQuery : IRequest<IEnumerable<AccountEntity>>
    {
        
    }
}