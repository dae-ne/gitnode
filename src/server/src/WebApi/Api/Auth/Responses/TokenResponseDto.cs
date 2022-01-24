using System.ComponentModel.DataAnnotations;
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

        [Required]
        public string IdToken { get; set; }

        [Required]
        public string RefreshToken { get; set; }
    
        [Required]
        public uint ExpiresIn { get; set; }
        
        [Required]
        public string Scope { get; set; }
    
        [Required]
        public string TokenType { get; set; }

        public static TokenResponseDto FromDomain(ITokenData tokenData) =>
            new(tokenData.IdToken,
                tokenData.RefreshToken,
                tokenData.ExpiresIn,
                tokenData.Scope,
                tokenData.TokenType);
    }
}