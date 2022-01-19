using System;
using System.Threading;
using System.Threading.Tasks;
using GitNode.Application.Common.Base;
using GitNode.Application.Common.Exceptions;
using GitNode.Application.Common.Interfaces;
using GitNode.Domain.Entities;
using GitNode.Domain.Enums;
using MediatR;

namespace GitNode.Application.Accounts.Commands.AddAccount
{
    public class AddAccountCommandHandler : PlatformHandlerBase, IRequestHandler<AddAccountCommand, AccountEntity>
    {
        private readonly IUnitOfWork _db;
        private readonly ICurrentUserService _currentUser;
        private readonly ICryptography _cryptography;

        public AddAccountCommandHandler(
            IUnitOfWork db,
            IApiProvider api,
            ICurrentUserService currentUser,
            ICryptography cryptography) :
            base(api)
        {
            _db = db;
            _currentUser = currentUser;
            _cryptography = cryptography;
        }

        public async Task<AccountEntity> Handle(AddAccountCommand request, CancellationToken cancellationToken)
        {
            var api = GetPlatformApi(request.Platform);
            // TODO: handle nulls
            var token = await api.Auth.GetTokenAsync(request.Code, cancellationToken);
            var user = await api.Users.GetAuthenticatedUserAsync(token.AccessToken, cancellationToken);
            var platform = await _db.Platforms.GetByNameAsync(request.Platform.ToStringValue(), cancellationToken);
            
            if (platform == null)
            {
                // TODO: exception type
                throw new UnknownPlatformException(
                    $"Server cannot find the {request.Platform} platform name in the database");
            }
            
            var account = new AccountEntity
            {
                OriginId = user.Id,
                Url = user.Url,
                AvatarUrl = user.AvatarUrl,
                UserId = _currentUser.Id,
                PlatformId = platform.Id,
                Login = user.Login,
                Token = _cryptography.Encrypt(token.AccessToken)
            };

            _db.Accounts.Add(account);
            var affected = await _db.SaveChangesAsync(cancellationToken);

            if (affected == 0)
            {
                // TODO: exception type
                throw new Exception();
            }
            
            return account;
        }
    }
}