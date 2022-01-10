using System.Collections.Generic;
using GitNode.Domain.Enums;
using GitNode.Domain.Models.Platforms;
using MediatR;

namespace GitNode.Application.Repos.Queries.GetExternalRepos
{
    public class GetExternalReposQuery : IRequest<IEnumerable<Repo>>
    {
        public GetExternalReposQuery(string account, Platform platform)
        {
            Account = account;
            Platform = platform;
        }

        public string Account { get; set; }

        public Platform Platform { get; set; }
    }
}