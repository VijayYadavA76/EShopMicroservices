
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Ordering.Infrastructure
{
	public static class DependencyInjection
	{
		public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
		{
			var connectionStrings = configuration.GetConnectionString("Database");

			// Add services to the container
			services.AddScoped<ISaveChangesInterceptor,AuditableEntityInterceptor>();
			services.AddScoped<ISaveChangesInterceptor,DispatchDomainEventInterceptor>();

			services.AddDbContext<ApplicationDbContext>((serviceProvider, options) =>
			{
				// Retrieve all registered interceptors
				var interceptors = serviceProvider.GetServices<ISaveChangesInterceptor>().ToArray();
				options.AddInterceptors(interceptors);
				options.UseSqlServer(connectionStrings);
			});

			//services.AddScoped<IApplicationDbContext, ApplicationDbContext>();

			return services;
		}
	}
}
