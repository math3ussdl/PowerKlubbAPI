using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PowerKlubbAPI.Application.Contracts.Application.Cryptograph;
using PowerKlubbAPI.Application.Contracts.Persistence;
using PowerKlubbAPI.Application.Contracts.Persistence.Common;
using PowerKlubbAPI.Infrastructure.Application;
using PowerKlubbAPI.Infrastructure.Persistence.Context;
using PowerKlubbAPI.Infrastructure.Persistence.Repositories;
using PowerKlubbAPI.Infrastructure.Persistence.Repositories.Common;

namespace PowerKlubbAPI.Infrastructure;

public static class DependencyInjection
{
	public static IServiceCollection ConfigureInfraServices(
		this IServiceCollection services,
		IConfiguration configuration)
	{
        #region Persistence Layer
        services.AddDbContext<ApiContext>(opts =>
		{
			opts.UseSqlServer(
				configuration.GetConnectionString("DbConnection"));
		});

		services.AddScoped(typeof(IGenericRepository<,>), typeof(GenericRepository<,>));

		services.AddScoped<IUserRepository, UserRepository>();
		#endregion

		#region Infra Layer
		// BCrypt service
		services.AddScoped<BCryptAdapter>();
		services.AddTransient<IHasher>(s => s.GetRequiredService<BCryptAdapter>());
        services.AddTransient<IHashComparer>(s => s.GetRequiredService<BCryptAdapter>());

		// JsonWebToken service
		services.AddScoped<JwtAdapter>();
		services.AddTransient<IEncrypter>(s => s.GetRequiredService<JwtAdapter>());
        services.AddTransient<IDecrypter>(s => s.GetRequiredService<JwtAdapter>());
        #endregion

        return services;
	}
}
