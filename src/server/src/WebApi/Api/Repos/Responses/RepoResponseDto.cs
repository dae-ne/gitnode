﻿using GitNode.Domain.Entities;
using GitNode.Domain.Models.Platforms;

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

        public int? Id { get; set; }

        public int OriginId { get; set; }
        
        public string Name { get; set; }

        public string Description { get; set; }
        
        public string Url { get; set; }

        public bool Private { get; set; }
        
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