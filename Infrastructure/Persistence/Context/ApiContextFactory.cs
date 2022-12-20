using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace PowerKlubbAPI.Infrastructure.Persistence.Context;

public class ApiContextFactory : IDesignTimeDbContextFactory<ApiContext>
{
	public ApiContext CreateDbContext(string[] args)
	{
		var configuration = new ConfigurationBuilder()
			.SetBasePath(Directory.GetCurrentDirectory())
			.AddJsonFile("appsettings.json")
			.Build();
		
		var builder = new DbContextOptionsBuilder<ApiContext>();
		var connectionString = configuration.GetConnectionString("DbConnection");

		builder.UseSqlServer(connectionString);

		return new ApiContext(builder.Options);
	}
}
