namespace GitNode.Infrastructure.ExternalApis.GitHub.Repos.Requests
{
    internal class UpdateRepoGitHubRequestDto : CreateRepoGitHubRequestDto
    {
        public UpdateRepoGitHubRequestDto(string name, string description, bool @private) :
            base(name, description, @private)
        {
            
        }
    }
}