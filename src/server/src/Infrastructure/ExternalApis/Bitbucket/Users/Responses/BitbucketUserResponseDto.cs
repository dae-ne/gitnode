using GitNode.Infrastructure.ExternalApis.Bitbucket.Common;

namespace GitNode.Infrastructure.ExternalApis.Bitbucket.Users.Responses
{
    internal class BitbucketUserResponseDto
    {
        public string AccountId { get; set; }
        
        public string Username { get; set; }
        
        public BitbucketLinksResponseDto Links { get; set; }
        
        public string Nickname { get; set; }
    }
}
