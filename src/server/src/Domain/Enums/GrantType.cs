using System;

namespace GitNode.Domain.Enums
{
    public enum GrantType
    {
        AuthorizationCode,
        RefreshToken
    }

    public static class GrantTypeUtils
    {
        private const string AuthorizationCode = "authorization_code";
        private const string RefreshToken = "refresh_token";
        private const string ErrorMessage = "Unsupported grant type";
        
        public static string ToStringValue(this GrantType grantType) => grantType switch
        {
            GrantType.AuthorizationCode => AuthorizationCode,
            GrantType.RefreshToken => RefreshToken,
            // TODO: exception type
            _ => throw new ArgumentOutOfRangeException(nameof(grantType), grantType, ErrorMessage)
        };

        public static GrantType FromString(string grantType) => grantType switch
        {
            AuthorizationCode => GrantType.AuthorizationCode,
            RefreshToken => GrantType.RefreshToken,
            // TODO: exception type
            _ => throw new ArgumentOutOfRangeException(nameof(grantType), grantType, ErrorMessage)
        };
    }
}