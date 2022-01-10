using GitNode.Application.Common.Exceptions;
using GitNode.Application.Common.Interfaces;
using GitNode.Domain.Enums;

namespace GitNode.Application.Common.Base
{
    public abstract class PlatformHandlerBase
    {
        private readonly IApiProvider _api;

        protected PlatformHandlerBase(IApiProvider api)
        {
            _api = api;
        }

        public IPlatformApi GetPlatformApi(Platform platform) => platform switch
        {
            Platform.GitHub => _api.GitHub,
            Platform.Bitbucket => _api.Bitbucket,
            Platform.GitLab => _api.GitLab,
            _ => throw new UnknownPlatformException($"{platform} is not a valid platform name.")
        };
    }
}