using System.Threading;
using System.Threading.Tasks;
using GitNode.Application.Common.Base;
using GitNode.Application.Common.Interfaces;
using GitNode.Domain.Entities;
using MediatR;

namespace GitNode.Application.Repos.Commands.AddRepo
{
    public class AddRepoCommandHandler : PlatformHandlerBase, IRequestHandler<AddRepoCommand, RepoEntity>
    {
        private readonly IUnitOfWork _db;
        private readonly ICurrentUserService _currentUser;
        private readonly ICryptography _cryptography;

        public AddRepoCommandHandler(
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
        
        public async Task<RepoEntity> Handle(AddRepoCommand request, CancellationToken cancellationToken)
        {
            var processor = GetPlatformApi(request.Platform);
            var account = await _db.Accounts.GetWithPlatformAsync(request.Account, _currentUser.Id, cancellationToken);
            
            var repository = await processor.Repos.CreateRepoAsync(
                request.Name,
                request.Description,
                request.Private,
                _cryptography.Decrypt(account.Token),
                cancellationToken);

            var entity = new RepoEntity
            {
                OriginId = repository.Id,
                Name = repository.Name,
                Description = repository.Description,
                Url = repository.Url,
                Private = repository.Private,
                AccountId = account.Id
            };
            
            _db.Repos.Add(entity);
            await _db.SaveChangesAsync(cancellationToken);
            return entity;
        }
    }
}