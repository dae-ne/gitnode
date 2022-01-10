namespace GitNode.Infrastructure.ExternalApis.GitHub.Repos.Responses
{
    internal class GitHubRepoResponseDto
    {
        public int Id { get; set; }
        
        public string Name { get; set; }
        
        public string Description { get; set; }
        
        public string HtmlUrl { get; set; }
        
        public bool Private { get; set; }

        public GitHubOwnerResponseDto Owner { get; set; }
    }
}
