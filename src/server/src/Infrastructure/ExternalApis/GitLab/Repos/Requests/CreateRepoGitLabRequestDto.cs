namespace GitNode.Infrastructure.ExternalApis.GitLab.Repos.Requests
{
    internal class CreateRepoGitLabRequestDto
    {
        public CreateRepoGitLabRequestDto(string name, string description, string visibility)
        {
            Name = name;
            Description = description;
            Visibility = visibility;
        }

        public string Name { get; set; }

        public string Description { get; set; }

        public string Visibility { get; set; }
    }
}