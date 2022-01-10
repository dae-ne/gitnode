namespace GitNode.Infrastructure.ExternalApis.GitLab.Users.Responses
{
    internal class GitLabUserResponseDto
    {
        public int Id { get; set; }
        
        public string Username { get; set; }
        
        public string WebUrl { get; set; }
        
        public string Name { get; set; }
    }
}
