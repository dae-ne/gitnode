using GitNode.Domain.Entities;
using GitNode.Domain.Enums;
using MediatR;

namespace GitNode.Application.Repos.Commands.AddRepo
{
    public class AddRepoCommand : IRequest<RepoEntity>
    {
        public AddRepoCommand(
            string name,
            string description,
            bool @private,
            string account,
            Platform platform)
        {
            Name = name;
            Description = description;
            Private = @private;
            Account = account;
            Platform = platform;
        }

        public string Name { get; set; }

        public string Description { get; set; }

        public bool Private { get; set; }
        
        public string Account { get; set; }

        public Platform Platform { get; set; }
    }
}