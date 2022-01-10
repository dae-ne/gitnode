using GitNode.Domain.Entities;
using MediatR;

namespace GitNode.Application.Repos.Queries.GetRepo
{
    public class GetRepoQuery : IRequest<RepoEntity>
    {
        public GetRepoQuery(int id)
        {
            Id = id;
        }
        
        public int Id { get; set; }
    }
}