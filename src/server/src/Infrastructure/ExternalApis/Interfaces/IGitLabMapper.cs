using GitNode.Domain.Models.Platforms;
using GitNode.Infrastructure.ExternalApis.GitLab.Auth.Responses;
using GitNode.Infrastructure.ExternalApis.GitLab.Repos.Responses;
using GitNode.Infrastructure.ExternalApis.GitLab.Users.Responses;

namespace GitNode.Infrastructure.ExternalApis.Interfaces
{
    internal interface IGitLabMapper
    {
        Repo Map(GitLabRepoResponseDto model);

        User Map(GitLabUserResponseDto model);
        
        Token Map(GitLabTokenResponseDto model);
    }
}
