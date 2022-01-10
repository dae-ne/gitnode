using GitNode.Domain.Entities;
using MediatR;

namespace GitNode.Application.Users.Queries.GetUser
{
    public class GetUserQuery : IRequest<UserEntity>
    {
        public GetUserQuery(string id)
        {
            Id = id;
        }
        
        public string Id { get; }
    }
}