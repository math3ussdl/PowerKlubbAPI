using PowerKlubbAPI.Domain.Entities.Common;

namespace PowerKlubbAPI.Application.Contracts.Persistence.Common;

public interface IGenericRepository<TEntity, in TId>
	where TEntity : AuditableEntity
	where TId : struct
{
	Task<bool> ExistsByIdAsync(TId id);
	IQueryable<TEntity> Get(string q);
	Task<TEntity> GetByIdAsync(TId id);
	Task<TEntity> AddAsync(TEntity model);
	Task UpdateAsync(TEntity model);
	Task DeleteAsync(TEntity model);
}
