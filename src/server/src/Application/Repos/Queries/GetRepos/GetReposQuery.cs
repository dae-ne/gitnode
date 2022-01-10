using System.Collections.Generic;
using GitNode.Domain.Entities;
using MediatR;

namespace GitNode.Application.Repos.Queries.GetRepos
{
    public class GetReposQuery : IRequest<IEnumerable<RepoEntity>>
    {
        
    }
}