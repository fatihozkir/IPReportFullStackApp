using Microsoft.EntityFrameworkCore;
using SharedKernel.Core.Base;
using SharedKernel.Core.Repositories.Abstract;

namespace SharedKernel.EntityFramework.Repositories.Concretes
{
    public abstract class RepositoryBase<TEntity, TKey, TDbContext> : IRepositoryBase<TEntity, TKey> where TEntity : EntityBase<TKey> where TDbContext : DbContext where TKey : notnull
    {
        private readonly TDbContext _dbContext;
        private readonly DbSet<TEntity> _dbSet;

        protected RepositoryBase(TDbContext dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
            _dbSet = _dbContext.Set<TEntity>();
        }

        public IQueryable<TEntity> GetQuery()
        {
            return _dbSet.AsQueryable();
        }

        public async Task<List<TEntity>> GetAllAsync(CancellationToken cancellationToken)
        {
            return await _dbSet.ToListAsync(cancellationToken);
        }

        public async Task<TEntity?> GetByIdAsync(TKey id, CancellationToken cancellationToken)
        {
            return await _dbSet.FindAsync([id],cancellationToken);
        }

        public async Task<TEntity> InsertAsync(TEntity entity, CancellationToken cancellationToken)
        {
            ArgumentNullException.ThrowIfNull(entity);

            await _dbSet.AddAsync(entity, cancellationToken);
            return entity;
        }

        public async Task DeleteAsync(TKey id, CancellationToken cancellationToken)
        {
            var entity = await _dbSet.FindAsync([id],cancellationToken);
            if (entity == null) throw new NullReferenceException(nameof(entity));

            _dbSet.Remove(entity);
        }

        public async Task<int> SaveChangesAsync(CancellationToken cancellationToken)
        {
            return await _dbContext.SaveChangesAsync(cancellationToken);
        }
    }
}
