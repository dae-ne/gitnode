using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using GitNode.Application.Common.Interfaces;
using GitNode.Domain.Entities;
using MediatR;

namespace GitNode.Application.Repos.Queries.GetRepos
{
    public class GetReposQueryHandler : IRequestHandler<GetReposQuery, IEnumerable<RepoEntity>>
    {
        private readonly IUnitOfWork _db;
        private readonly ICurrentUserService _currentUser;

        public GetReposQueryHandler(IUnitOfWork db, ICurrentUserService currentUser)
        {
            _db = db;
            _currentUser = currentUser;
        }
        
        public Task<IEnumerable<RepoEntity>> Handle(GetReposQuery request, CancellationToken cancellationToken)
        {
            return _db.Repos.GetListWithAccountAsync(_currentUser.Id, cancellationToken);
        }
    }
}