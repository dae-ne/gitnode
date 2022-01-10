using System.Collections.Generic;
using GitNode.Domain.Enums;
using MediatR;

namespace GitNode.Application.Repos.Commands.AddExternalRepos
{
    public class AddExternalReposCommand : IRequest
    {
        public AddExternalReposCommand(
            string account,
            Platform platform,
            IEnumerable<int> originIds)
        {
            Account = account;
            Platform = platform;
            OriginIds = originIds;
        }

        public string Account { get; set; }

        public Platform Platform { get; set; }

        public IEnumerable<int> OriginIds { get; set; }
    }
}