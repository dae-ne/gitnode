using System.Security.Claims;
using GitNode.Application.Common.Interfaces;
using Microsoft.AspNetCore.Http;

namespace GitNode.WebApi.Services
{
    internal class CurrentUserService : ICurrentUserService
    {
        private readonly IHttpContextAccessor _contextAccessor;

        public CurrentUserService(IHttpContextAccessor contextAccessor)
        {
            _contextAccessor = contextAccessor;
        }
        
        public string Id => User.FindFirstValue(ClaimTypes.NameIdentifier);
        
        public string Email => User.FindFirstValue(ClaimTypes.Email);
        
        public string GivenName => User.FindFirstValue(ClaimTypes.GivenName);
        
        public string Surname => User.FindFirstValue(ClaimTypes.Surname);
        
        public string Name => $"{GivenName} {Surname}".Trim();

        public string Picture => User.FindFirstValue("picture");

        private ClaimsPrincipal User => _contextAccessor.HttpContext?.User;
    }
}