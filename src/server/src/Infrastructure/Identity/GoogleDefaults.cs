namespace GitNode.Infrastructure.Identity
{
    internal static class GoogleDefaults
    {
        public const string AuthenticationScheme = "GitNode.Google";

        public const string DisplayName = "Google OpenIdConnect";

        public const string DiscoveryDocument = "https://accounts.google.com/.well-known/openid-configuration";
    }
}