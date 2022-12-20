using Microsoft.EntityFrameworkCore;
using PowerKlubbAPI.Application.Contracts.Persistence.Common;
using PowerKlubbAPI.Application.Extensions;
using PowerKlubbAPI.Domain.Entities.Common;
using PowerKlubbAPI.Infrastructure.Persistence.Context;

namespace PowerKlubbAPI.Infrastructure.Persistence.Repositories.Common;

public class GenericRepository<T, TId> : IGenericRepository<T, TId>
	where T : AuditableEntity
	where TId : struct
{
	private readonly ApiContext _context;

	public GenericRepository(ApiContext context)
	{
		_context = context;
	}
	
	public async Task<bool> ExistsByIdAsync(TId id)
	{
		var entity = await GetByIdAsync(id);
		return entity is not null;
	}

	public IQueryable<T> Get(string q)
	{
		var query = _context.Set<T>().AsQueryable();
		return query.SearchByAnyField(q);
	}

	public async Task<T> GetByIdAsync(TId id)
	{
		return await _context.Set<T>().FindAsync(id);
	}

	public async Task<T> AddAsync(T model)
	{
		await _context.AddAsync(model);
		await _context.SaveChangesAsync();
		return model;
	}

	public async Task UpdateAsync(T model)
	{
		_context.Entry(model).State = EntityState.Modified;
		await _context.SaveChangesAsync();
	}

	public async Task DeleteAsync(T model)
	{
		_context.Set<T>().Remove(model);
		await _context.SaveChangesAsync();
	}
}
