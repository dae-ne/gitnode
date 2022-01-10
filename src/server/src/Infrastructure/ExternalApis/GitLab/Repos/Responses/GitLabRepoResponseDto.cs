namespace GitNode.Infrastructure.ExternalApis.GitLab.Repos.Responses
{
    internal class GitLabRepoResponseDto
    {
        public int Id { get; set; }
        
        public string Path { get; set; }
        
        public string Description { get; set; }
        
        public string WebUrl { get; set; }
        
        public string Visibility { get; set; }

        public GitLabOwnerResponseDto Owner { get; set; }
    }
}
