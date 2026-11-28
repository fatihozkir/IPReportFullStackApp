namespace SharedKernel.Application.Managers.Abstract
{
    public interface IManagerBase<TEntity, TKey> where TEntity : class where TKey : notnull
    {
        IQueryable<TEntity> GetQuery();
        Task<List<TEntity>> GetAllAsync(CancellationToken cancellationToken);
        Task<TEntity?> GetByIdAsync(TKey id, CancellationToken cancellationToken);
        Task<TEntity> InsertAsync(TEntity entity, CancellationToken cancellationToken);
        Task DeleteAsync(TKey id, CancellationToken cancellationToken);
    }
}
