using GitNode.Domain.Interfaces.Identity;

namespace GitNode.Domain.Models.Identity
{
    public class TokenData : ITokenData
    {
        public string IdToken { get; set; }

        public string RefreshToken { get; set; }
    
        public uint ExpiresIn { get; set; }
        
        public string Scope { get; set; }
    
        public string TokenType { get; set; }
    }
}