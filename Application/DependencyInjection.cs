using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace PowerKlubbAPI.Application;

public static class DependencyInjection
{
	public static IServiceCollection ConfigureApplicationServices(
		this IServiceCollection services)
	{
		services.AddAutoMapper(Assembly.GetExecutingAssembly());

		return services;
	}
}
