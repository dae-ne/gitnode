namespace GitNode.WebApi.Api.Repos.Requests
{
    public class AddRepoRequestDto
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public bool Private { get; set; }
        
        public string Account { get; set; }

        public string Platform { get; set; }
    }
}