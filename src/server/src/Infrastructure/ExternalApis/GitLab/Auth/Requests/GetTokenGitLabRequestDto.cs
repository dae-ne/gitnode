namespace GitNode.Infrastructure.ExternalApis.GitLab.Auth.Requests
{
    internal class GetTokenGitLabRequestDto
    {
        public GetTokenGitLabRequestDto(
            string code,
            string clientSecret,
            string clientId,
            string redirectUri)
        {
            Code = code;
            ClientSecret = clientSecret;
            ClientId = clientId;
            GrantType = "authorization_code";
            RedirectUri = redirectUri;
        }

        public string Code { get; set; }

        public string ClientSecret { get; set; }

        public string ClientId { get; set; }

        public string GrantType { get; set; }

        public string RedirectUri { get; set; }
    }
}