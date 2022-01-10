using System;
using System.Threading;
using System.Threading.Tasks;
using GitNode.Application.Common.Interfaces;
using GitNode.Domain.Entities;
using GitNode.Domain.Enums;
using GitNode.Domain.Models.Identity;
using MediatR;

namespace GitNode.Application.Identity.Commands.GetToken
{
    public class GetTokenCommandHandler : IRequestHandler<GetTokenCommand, AuthData>
    {
        private readonly IUnitOfWork _db;
        private readonly IUserManager _userManager;

        public GetTokenCommandHandler(IUnitOfWork db, IUserManager userManager)
        {
            _db = db;
            _userManager = userManager;
        }
        
        public async Task<AuthData> Handle(GetTokenCommand request, CancellationToken cancellationToken)
        {
            var data = await _userManager.GetTokenAsync(
                request.GrantType, request.Code, request.RefreshToken, cancellationToken);
            var savedUser = await _db.Users.GetAsync(data.Id, cancellationToken);
            
            if (savedUser != null || request.GrantType == GrantType.RefreshToken)
            {
                return data;
            }

            var user = new UserEntity
            {
                Id = data.Id,
                GivenName = data.GivenName,
                Surname = data.Surname,
                Email = data.Email,
                ImageUrl = data.Picture,
                CreatedAt = DateTimeOffset.Now
            };

            _db.Users.Add(user);
            var affected = await _db.SaveChangesAsync(cancellationToken);

            if (affected == 0)
            {
                // TODO: exception type
                throw new Exception();
            }

            return data;
        }
    }
}