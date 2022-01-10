using GitNode.Domain.Models.Platforms;
using GitNode.Infrastructure.ExternalApis.GitHub.Auth.Responses;
using GitNode.Infrastructure.ExternalApis.GitHub.Repos.Responses;
using GitNode.Infrastructure.ExternalApis.GitHub.Users.Responses;

namespace GitNode.Infrastructure.ExternalApis.Interfaces
{
    internal interface IGitHubMapper
    {
        Repo Map(GitHubRepoResponseDto model);
        
        Token Map(GitHubTokenResponseDto model);
        
        User Map(GitHubUserResponseDto model);
    }
}