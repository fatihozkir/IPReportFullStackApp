using SharedKernel.Core.Base;
using SharedKernel.Core.Repositories.Abstract;
using SharedKernel.Application.Managers.Abstract;

namespace SharedKernel.Application.Managers.Concretes
{
    public abstract class ManagerBase<TEntity, TKey> : IManagerBase<TEntity, TKey> where TEntity : EntityBase<TKey> where TKey : notnull
    {
        protected readonly IRepositoryBase<TEntity, TKey> _repositoryBase;

        protected ManagerBase(IRepositoryBase<TEntity, TKey> repositoryBase)
        {
            _repositoryBase = repositoryBase ?? throw new ArgumentNullException(nameof(repositoryBase));
        }

        public virtual IQueryable<TEntity> GetQuery()
        {
            return _repositoryBase.GetQuery();
        }

        public virtual Task<List<TEntity>> GetAllAsync(CancellationToken cancellationToken)
        {
            return _repositoryBase.GetAllAsync(cancellationToken);
        }

        public virtual Task<TEntity?> GetByIdAsync(TKey id, CancellationToken cancellationToken)
        {
            return _repositoryBase.GetByIdAsync(id, cancellationToken);
        }

        public virtual async Task<TEntity> InsertAsync(TEntity entity, CancellationToken cancellationToken)
        {
            ArgumentNullException.ThrowIfNull(entity);
            var result =  await _repositoryBase.InsertAsync(entity, cancellationToken);
            await _repositoryBase.SaveChangesAsync(cancellationToken);
            return result;
        }

        public virtual async Task DeleteAsync(TKey id, CancellationToken cancellationToken)
        {
            await _repositoryBase.DeleteAsync(id, cancellationToken);
            await _repositoryBase.SaveChangesAsync(cancellationToken);
        }

    }
}
