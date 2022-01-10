using GitNode.Domain.Entities;
using GitNode.Domain.Interfaces.Repositories;

namespace GitNode.Persistence.Repositories
{
    internal class UserRepository : GenericRepository<UserEntity, AppDbContext, string>, IUserRepository
    {
        public UserRepository(AppDbContext db) : base(db) { }
    }
}