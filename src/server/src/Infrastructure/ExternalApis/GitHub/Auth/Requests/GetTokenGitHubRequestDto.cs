namespace GitNode.Infrastructure.ExternalApis.GitHub.Auth.Requests
{
    internal class GetTokenGitHubRequestDto
    {
        public GetTokenGitHubRequestDto(string code, string clientSecret, string clientId)
        {
            Code = code;
            ClientSecret = clientSecret;
            ClientId = clientId;
        }

        public string Code { get; set; }

        public string ClientSecret { get; set; }

        public string ClientId { get; set; }
    }
}