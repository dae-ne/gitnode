using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using GitNode.Application.Common.Base;
using GitNode.Application.Common.Interfaces;
using GitNode.Domain.Entities;
using MediatR;

namespace GitNode.Application.Repos.Commands.AddExternalRepos
{
    public class AddExternalReposCommandHandler : PlatformHandlerBase, IRequestHandler<AddExternalReposCommand>
    {
        private readonly IUnitOfWork _db;
        private readonly ICurrentUserService _currentUser;
        private readonly ICryptography _cryptography;

        public AddExternalReposCommandHandler(
            IApiProvider api,
            IUnitOfWork db,
            ICurrentUserService currentUser,
            ICryptography cryptography) :
            base(api)
        {
            _db = db;
            _currentUser = currentUser;
            _cryptography = cryptography;
        }
        
        public async Task<Unit> Handle(AddExternalReposCommand request, CancellationToken cancellationToken)
        {
            var api = GetPlatformApi(request.Platform);
            var account = await _db.Accounts.GetWithPlatformAsync(request.Account, _currentUser.Id, cancellationToken);

            if (account == null)
            {
                // TODO: exception type
                throw new Exception();
            }

            var repos = await api.Repos.GetReposAsync(
                account.OriginId,
                _cryptography.Decrypt(account.Token),
                cancellationToken);

            var reposToSave = repos
                .Where(r => request.OriginIds.Any(id => id == r.Id) && r.Owner.Id == account.OriginId)
                .Select(r => new RepoEntity
                {
                    OriginId = r.Id,
                    Name = r.Name,
                    Description = r.Description,
                    Url = r.Url,
                    Private = r.Private,
                    AccountId = account.Id
                });
            
            _db.Repos.AddRange(reposToSave);
            var affected = await _db.SaveChangesAsync(cancellationToken);

            if (affected < 1)
            {
                // TODO: exception type
                throw new Exception();
            }
            
            return Unit.Value;
        }
    }
}