using GitNode.Domain.Models.Platforms;
using GitNode.Infrastructure.ExternalApis.Bitbucket.Auth.Responses;
using GitNode.Infrastructure.ExternalApis.Bitbucket.Repos.Responses;
using GitNode.Infrastructure.ExternalApis.Bitbucket.Users.Responses;
using GitNode.Infrastructure.ExternalApis.Interfaces;

namespace GitNode.Infrastructure.ExternalApis.Mappers
{
    internal class BitbucketMapper : IBitbucketMapper
    {
        public Repo Map(BitbucketRepository model)
        {
            throw new System.NotImplementedException();
        }

        public Token Map(BitbucketToken model) => new()
        {
            AccessToken = model.AccessToken
        };

        public User Map(BitbucketUserResponseDto model) => new()
        {
            Id = model.AccountId,
            Login = model.Username,
            Name = model.Nickname,
            Url = model.Links.Html.Href,
        };
    }
}
