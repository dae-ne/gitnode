using System.ComponentModel.DataAnnotations;
using GitNode.Domain.Models.Platforms;

namespace GitNode.WebApi.Api.Repos.Responses
{
    public class ExternalRepoResponseDto
    {
        private ExternalRepoResponseDto(
            int originId,
            string name,
            string description,
            string url,
            bool @private,
            string account)
        {
            OriginId = originId;
            Name = name;
            Description = description;
            Url = url;
            Private = @private;
            Account = account;
        }

        [Required]
        public int OriginId { get; set; }
        
        [Required]
        public string Name { get; set; }
        
        public string Description { get; set; }
        
        [Required]
        public string Url { get; set; }

        [Required]
        public bool Private { get; set; }
        
        [Required]
        public string Account { get; set; }
        
        public static ExternalRepoResponseDto FromDomain(Repo repo) =>
            new(repo.Id,
                repo.Name,
                repo.Description,
                repo.Url,
                repo.Private,
                repo.Owner.Login);
    }
}