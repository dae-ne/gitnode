using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using GitNode.Application.Common.Base;
using GitNode.Application.Common.Interfaces;
using GitNode.Domain.Models.Platforms;
using MediatR;

namespace GitNode.Application.Repos.Queries.GetExternalRepos
{
    public class GetExternalReposQueryHandler :
        PlatformHandlerBase,
        IRequestHandler<GetExternalReposQuery, IEnumerable<Repo>>
    {
        private readonly IUnitOfWork _db;
        private readonly ICurrentUserService _currentUser;
        private readonly ICryptography _cryptography;

        public GetExternalReposQueryHandler(
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
        
        public async Task<IEnumerable<Repo>> Handle(
            GetExternalReposQuery request,
            CancellationToken cancellationToken)
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
            return repos;
        }
    }
}