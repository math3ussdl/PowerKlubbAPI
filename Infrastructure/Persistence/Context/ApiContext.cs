using Microsoft.EntityFrameworkCore;
using PowerKlubbAPI.Domain.Entities;
using PowerKlubbAPI.Domain.Entities.Common;

namespace PowerKlubbAPI.Infrastructure.Persistence.Context;

public class ApiContext : DbContext
{
	public ApiContext(DbContextOptions<ApiContext> options) : base(options)
	{
	}

	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApiContext).Assembly);
	}
	
	public override Task<int> SaveChangesAsync(
		CancellationToken cancellationToken = default)
	{
		foreach (var entry in ChangeTracker.Entries<AuditableEntity>())
		{
			entry.Entity.UpdatedAt = DateTime.Now;

			if (entry.State == EntityState.Added)
			{
				entry.Entity.CreatedAt = DateTime.Now;
			}
		}

		return base.SaveChangesAsync(cancellationToken);
	}

	public DbSet<User> Users { get; set; }
}
