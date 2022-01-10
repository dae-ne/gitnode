namespace GitNode.WebApi.Api.Repos.Requests
{
    public class UpdateRepoRequestDto
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public bool Private { get; set; }
    }
}