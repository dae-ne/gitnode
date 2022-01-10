using System;
using System.Threading;
using System.Threading.Tasks;
using GitNode.Application.Common.Interfaces;
using GitNode.Domain.Entities;
using MediatR;

namespace GitNode.Application.Repos.Queries.GetRepo
{
    public class GetRepoQueryHandler : IRequestHandler<GetRepoQuery, RepoEntity>
    {
        private readonly IUnitOfWork _db;
        private readonly ICurrentUserService _currentUser;

        public GetRepoQueryHandler(IUnitOfWork db, ICurrentUserService currentUser)
        {
            _db = db;
            _currentUser = currentUser;
        }
        
        public async Task<RepoEntity> Handle(GetRepoQuery request, CancellationToken cancellationToken)
        {
            var repository = await _db.Repos.GetWithAccountAsync(
                request.Id,
                _currentUser.Id,
                cancellationToken);

            if (repository == null)
            {
                // TODO: exception type and message
                throw new Exception();
            }
            
            return repository;
        }
    }
}