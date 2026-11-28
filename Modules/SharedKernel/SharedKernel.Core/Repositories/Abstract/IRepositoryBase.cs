using SharedKernel.Core.Base;

namespace SharedKernel.Core.Repositories.Abstract
{
    public interface IRepositoryBase<TEntity, TKey> where TEntity : EntityBase<TKey> where TKey : notnull
    {
        IQueryable<TEntity> GetQuery();

        Task<List<TEntity>> GetAllAsync(CancellationToken cancellationToken);

        Task<TEntity?> GetByIdAsync(TKey id, CancellationToken cancellationToken);

        Task DeleteAsync(TKey id, CancellationToken cancellationToken);

        Task<TEntity> InsertAsync(TEntity entity, CancellationToken cancellationToken);

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
