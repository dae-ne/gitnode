using GitNode.Domain.Interfaces.Identity;

namespace GitNode.WebApi.Api.Auth.Responses
{
    public class TokenResponseDto
    {
        private TokenResponseDto(
            string idToken,
            string refreshToken,
            uint expiresIn,
            string scope,
            string tokenType)
        {
            IdToken = idToken;
            RefreshToken = refreshToken;
            ExpiresIn = expiresIn;
            Scope = scope;
            TokenType = tokenType;
        }

        public string IdToken { get; set; }

        public string RefreshToken { get; set; }
    
        public uint ExpiresIn { get; set; }
        
        public string Scope { get; set; }
    
        public string TokenType { get; set; }

        public static TokenResponseDto FromDomain(ITokenData tokenData) =>
            new(tokenData.IdToken,
                tokenData.RefreshToken,
                tokenData.ExpiresIn,
                tokenData.Scope,
                tokenData.TokenType);
    }
}