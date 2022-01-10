namespace GitNode.Domain.Interfaces.Identity
{
    public interface ITokenData
    {
        string IdToken { get; }

        string RefreshToken { get; }
    
        uint ExpiresIn { get; }
        
        string Scope { get; }
    
        string TokenType { get; }
    }
}