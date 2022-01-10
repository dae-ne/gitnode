using GitNode.Domain.Entities;

namespace GitNode.Domain.Interfaces.Repositories
{
    public interface IUserRepository : IGenericRepository<UserEntity, string>
    {
        
    }
}