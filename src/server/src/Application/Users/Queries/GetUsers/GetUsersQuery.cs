using System.Collections.Generic;
using GitNode.Domain.Entities;
using MediatR;

namespace GitNode.Application.Users.Queries.GetUsers
{
    public class GetUsersQuery : IRequest<IEnumerable<UserEntity>>
    {

    }
}