using GitNode.Domain.Entities;
using MediatR;

namespace GitNode.Application.Users.Queries.GetAuthenticatedUser
{
    public class GetAuthenticatedUserQuery : IRequest<UserEntity>
    {

    }
}