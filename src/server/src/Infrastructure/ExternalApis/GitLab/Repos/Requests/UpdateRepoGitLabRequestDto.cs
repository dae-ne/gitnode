namespace GitNode.Infrastructure.ExternalApis.GitLab.Repos.Requests
{
    internal class UpdateRepoGitLabRequestDto : CreateRepoGitLabRequestDto
    {
        public UpdateRepoGitLabRequestDto(string name, string description, string visibility) :
            base(name, description, visibility)
        {
            
        }
    }
}