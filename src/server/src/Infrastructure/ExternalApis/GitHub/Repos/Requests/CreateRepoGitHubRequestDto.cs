namespace GitNode.Infrastructure.ExternalApis.GitHub.Repos.Requests
{
    internal class CreateRepoGitHubRequestDto
    {
        public CreateRepoGitHubRequestDto(string name, string description, bool @private)
        {
            Name = name;
            Description = description;
            Private = @private;
        }

        public string Name { get; set; }

        public string Description { get; set; }

        public bool Private { get; set; }
    }
}