namespace PowerKlubbAPI.Domain.Contracts.Persistence.Common;

using Entities.Common;

public interface IGenericRepository<TEntity, in TId>
	where TEntity : AuditableEntity
	where TId : struct
{
	Task<bool> ExistsByIdAsync(TId id);
	Task<IReadOnlyList<TEntity>> GetAsync();
	Task<TEntity> GetByIdAsync(TId id);

	Task<TEntity> AddAsync(TEntity model);
	Task UpdateAsync(TEntity model);
	Task DeleteAsync(TId id);
}
