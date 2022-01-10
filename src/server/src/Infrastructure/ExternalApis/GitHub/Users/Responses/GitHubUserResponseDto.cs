namespace GitNode.Infrastructure.ExternalApis.GitHub.Users.Responses
{
    internal class GitHubUserResponseDto
    {
        public int Id { get; set; }
        
        public string Login { get; set; }
        
        public string HtmlUrl { get; set; }
        
        public string Name { get; set; }
    }
}
