namespace GitNode.Infrastructure.ExternalApis.GitLab.Auth.Responses
{
    internal class GitLabTokenResponseDto
    {
        public string AccessToken { get; set; }

        public string RefreshToken { get; set; }
    }
}
