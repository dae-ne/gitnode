using GitNode.Domain.Entities;
using GitNode.Domain.Models.Platforms;

namespace GitNode.WebApi.Api.Repos.Responses
{
    public class RepoResponseDto
    {
        private RepoResponseDto(
            int originId,
            string name,
            string description,
            string url,
            bool @private,
            string account,
            int? id = null)
        {
            OriginId = originId;
            Name = name;
            Description = description;
            Url = url;
            Private = @private;
            Account = account;
            Id = id;
        }

        public int? Id { get; set; }

        public int OriginId { get; set; }
        
        public string Name { get; set; }

        public string Description { get; set; }
        
        public string Url { get; set; }

        public bool Private { get; set; }
        
        public string Account { get; set; }
        
        public static RepoResponseDto FromDomain(Repo repository) =>
            new(repository.Id,
                repository.Name,
                repository.Description,
                repository.Url,
                repository.Private,
                repository.Owner.Login);

        public static RepoResponseDto FromDomain(RepoEntity repo) =>
            new(repo.OriginId,
                repo.Name,
                repo.Description,
                repo.Url,
                repo.Private,
                repo.Account.Login,
                repo.Id);
    }
}