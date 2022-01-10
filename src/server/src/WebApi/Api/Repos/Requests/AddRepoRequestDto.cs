namespace GitNode.WebApi.Api.Repos.Requests
{
    public class AddRepoRequestDto : UpdateRepoRequestDto
    {
        public string Account { get; set; }

        public string Platform { get; set; }
    }
}