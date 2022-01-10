using GitNode.Domain.Interfaces.ExternalApis;

namespace GitNode.Application.Common.Interfaces
{
    public interface IPlatformApi
    {
        IAuthApi Auth { get; }
        
        IUserApi Users { get; }

        IRepoApi Repos { get; }
    }
}
