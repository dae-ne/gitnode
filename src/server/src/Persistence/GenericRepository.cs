using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;
using GitNode.Domain.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace GitNode.Persistence
{
    internal class GenericRepository<TEntity, TDbContext, TPk> : IGenericRepository<TEntity, TPk>
        where TEntity : class
        where TDbContext : DbContext
    {
        protected readonly TDbContext Db;

        public GenericRepository(TDbContext db)
        {
            Db = db;
        }

        public TEntity Get(TPk id)
        {
            return Db.Set<TEntity>().Find(id);
        }

        public IEnumerable<TEntity> GetAll()
        {
            return Db.Set<TEntity>();
        }

        public IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate)
        {
            return Db.Set<TEntity>().Where(predicate);
        }

        public async Task<TEntity> GetAsync(TPk id, CancellationToken cancellationToken)
        {
            return await Db.Set<TEntity>().FindAsync(new object[] { id }, cancellationToken);
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync(CancellationToken cancellationToken)
        {
            return await Db.Set<TEntity>().ToListAsync(cancellationToken);
        }

        public async Task<IEnumerable<TEntity>> FindAsync(
            Expression<Func<TEntity, bool>> predicate,
            CancellationToken cancellationToken)
        {
            return await Db.Set<TEntity>().Where(predicate).ToListAsync(cancellationToken);
        }

        public void Add(TEntity entity)
        {
            Db.Set<TEntity>().Add(entity);
        }

        public void AddRange(IEnumerable<TEntity> entities)
        {
            Db.Set<TEntity>().AddRange(entities);
        }

        public void Update(TEntity entity)
        {
            Db.Set<TEntity>().Update(entity);
        }

        public void Remove(TEntity entity)
        {
            Db.Set<TEntity>().Remove(entity);
        }

        public void Remove(int id)
        {
            Db.Set<TEntity>().Remove(Db.Set<TEntity>().Find(id));
        }

        public void RemoveRange(IEnumerable<TEntity> entities)
        {
            Db.Set<TEntity>().RemoveRange(entities);
        }
    }
}