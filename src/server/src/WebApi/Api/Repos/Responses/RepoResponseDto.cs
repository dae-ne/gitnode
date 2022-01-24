using System.ComponentModel.DataAnnotations;
using GitNode.Domain.Entities;

namespace GitNode.WebApi.Api.Repos.Responses
{
    public class RepoResponseDto
    {
        private RepoResponseDto(
            int id,
            int originId,
            string name,
            string description,
            string url,
            bool @private,
            RepoOwnerResponseDto owner)
        {
            OriginId = originId;
            Name = name;
            Description = description;
            Url = url;
            Private = @private;
            Owner = owner;
            Id = id;
        }

        [Required]
        public int Id { get; set; }

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
        public RepoOwnerResponseDto Owner { get; set; }

        public static RepoResponseDto FromDomain(RepoEntity repo) =>
            new(repo.Id,
                repo.OriginId,
                repo.Name,
                repo.Description,
                repo.Url,
                repo.Private,
                RepoOwnerResponseDto.FromDomain(repo.Account));
    }
}