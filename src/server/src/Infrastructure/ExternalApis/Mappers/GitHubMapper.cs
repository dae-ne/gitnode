using GitNode.Domain.Models.Platforms;
using GitNode.Infrastructure.ExternalApis.GitHub.Auth.Responses;
using GitNode.Infrastructure.ExternalApis.GitHub.Repos.Responses;
using GitNode.Infrastructure.ExternalApis.GitHub.Users.Responses;
using GitNode.Infrastructure.ExternalApis.Interfaces;

namespace GitNode.Infrastructure.ExternalApis.Mappers
{
    internal class GitHubMapper : IGitHubMapper
    {
        public Repo Map(GitHubRepoResponseDto model) => new()
        {
            Id = model.Id,
            Name = model.Name,
            Description = model.Description,
            Url = model.HtmlUrl,
            Private = model.Private,
            Owner = new Owner
            {
                Id = model.Owner.Id.ToString(),
                Login = model.Owner.Login
            }
        };
        
        public User Map(GitHubUserResponseDto model) => new()
        {
            Id = model.Id.ToString(),
            Login = model.Login,
            Name = model.Name,
            Url = model.HtmlUrl,
        };

        public Token Map(GitHubTokenResponseDto model) => new()
        {
            AccessToken = model.AccessToken
        };
    }
}
