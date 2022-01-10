using GitNode.Domain.Interfaces.Identity;

namespace GitNode.Domain.Models.Identity
{
    public class AuthData : ITokenData, IUserData
    {
        private readonly TokenData _tokenData;
        private readonly UserData _userData;

        public AuthData(TokenData tokenData, UserData userData)
        {
            _tokenData = tokenData;
            _userData = userData;
        }
        
        public AuthData(UserData userData, TokenData tokenData) : this (tokenData, userData)
        {

        }

        public string IdToken => _tokenData.IdToken;

        public string RefreshToken => _tokenData.RefreshToken;

        public uint ExpiresIn => _tokenData.ExpiresIn;

        public string Scope => _tokenData.Scope;

        public string TokenType => _tokenData.TokenType;

        public string Id => _userData.Id;

        public string Email => _userData.Email;

        public string GivenName => _userData.GivenName;

        public string Surname => _userData.Surname;

        public string Name => _userData.Name;

        public string Picture => _userData.Picture;
    }
}