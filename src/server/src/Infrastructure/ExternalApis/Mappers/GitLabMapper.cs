using GitNode.Domain.Models.Platforms;
using GitNode.Infrastructure.ExternalApis.GitLab.Auth.Responses;
using GitNode.Infrastructure.ExternalApis.GitLab.Repos.Responses;
using GitNode.Infrastructure.ExternalApis.GitLab.Users.Responses;
using GitNode.Infrastructure.ExternalApis.Interfaces;

namespace GitNode.Infrastructure.ExternalApis.Mappers
{
    internal class GitLabMapper : IGitLabMapper
    {
        public Repo Map(GitLabRepoResponseDto model) => new()
        {
            Id = model.Id,
            Name = model.Path,
            Description = model.Description,
            Url = model.WebUrl,
            Private = model.Visibility == "private",
            Owner = new Owner
            {
                Id = model.Owner.Id.ToString(),
                Login = model.Owner.Name
            }
        };

        public User Map(GitLabUserResponseDto model) => new()
        {
            Id = model.Id.ToString(),
            Login = model.Username,
            Name = model.Name,
            Url = model.WebUrl,
        };
        
        public Token Map(GitLabTokenResponseDto model) => new()
        {
            AccessToken = model.AccessToken,
            RefreshToken = model.RefreshToken
        };
    }
}
