using GitNode.Domain.Entities;
using MediatR;

namespace GitNode.Application.Accounts.Queries.GetAccount
{
    public class GetAccountQuery : IRequest<AccountEntity>
    {
        public GetAccountQuery(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}