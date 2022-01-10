using GitNode.Domain.Enums;
using GitNode.Infrastructure.Options;

namespace GitNode.Infrastructure.Identity
{
    internal class TokenRequest
    {
        private TokenRequest(
            string grantType,
            string code,
            string refreshToken,
            string clientId,
            string clientSecret,
            string redirectUri)
        {
            GrantType = grantType;
            Code = code;
            RefreshToken = refreshToken;
            ClientId = clientId;
            ClientSecret = clientSecret;
            RedirectUri = redirectUri;
        }
        
        public string GrantType { get; }
        
        public string Code { get; }
        
        public string RefreshToken { get; }
        
        public string ClientId { get; }
        
        public string ClientSecret { get; }
        
        public string RedirectUri { get; }

        public static TokenRequest Create(
            IdentityOptions options,
            GrantType grantType,
            string code,
            string refreshToken)
        {
            return new TokenRequest(
                grantType.ToStringValue(),
                code,
                refreshToken,
                options.ClientId,
                options.ClientSecret,
                options.RedirectUri);
        }
    }
}