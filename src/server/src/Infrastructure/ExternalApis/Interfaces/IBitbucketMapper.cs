using GitNode.Domain.Models.Platforms;
using GitNode.Infrastructure.ExternalApis.Bitbucket.Auth.Responses;
using GitNode.Infrastructure.ExternalApis.Bitbucket.Repos.Responses;
using GitNode.Infrastructure.ExternalApis.Bitbucket.Users.Responses;

namespace GitNode.Infrastructure.ExternalApis.Interfaces
{
    internal interface IBitbucketMapper
    {
        Repo Map(BitbucketRepository model);
        
        Token Map(BitbucketToken model);
        
        User Map(BitbucketUserResponseDto model);
    }
}
