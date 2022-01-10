using System;
using System.Threading;
using System.Threading.Tasks;
using GitNode.Application.Common.Base;
using GitNode.Application.Common.Interfaces;
using GitNode.Domain.Enums;
using MediatR;

namespace GitNode.Application.Repos.Commands.UpdateRepo
{
    public class UpdateRepoCommandHandler : PlatformHandlerBase, IRequestHandler<UpdateRepoCommand>
    {
        private readonly IUnitOfWork _db;
        private readonly ICurrentUserService _currentUser;
        private readonly ICryptography _cryptography;

        public UpdateRepoCommandHandler(
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
        
        public async Task<Unit> Handle(UpdateRepoCommand request, CancellationToken cancellationToken)
        {
            var repo = await _db.Repos.GetWithAccountAsync(request.Id, _currentUser.Id, cancellationToken);
            var account = repo.Account;

            if (repo == null)
            {
                // TODO: exception type
                throw new Exception();
            }

            var platform = await _db.Platforms.GetAsync(account.PlatformId, cancellationToken);
            var processor = GetPlatformApi(PlatformUtils.FromString(platform.Name));
            var updatedRepo = await processor.Repos.UpdateRepoAsync(
                repo.OriginId,
                repo.Name, 
                account.Login,
                request.Name,
                request.Description,
                request.Private,
                _cryptography.Decrypt(account.Token),
                cancellationToken);

            repo.Name = updatedRepo.Name;
            repo.Description = updatedRepo.Description;
            repo.Private = updatedRepo.Private;
            
            _db.Repos.Update(repo);
            var affected = await _db.SaveChangesAsync(cancellationToken);

            if (affected != 1)
            {
                // TODO: exception type
                throw new Exception();
            }
            return Unit.Value;
        }
    }
}