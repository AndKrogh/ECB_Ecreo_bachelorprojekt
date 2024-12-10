using ECBilling.Services;

namespace ECBilling.Startup
{
	public static class ServiceCollectionExtensions
	{
		public static IServiceCollection AddApplicationServices(this IServiceCollection services)
		{
			// Register your interfaces and services here
			services.AddScoped<IGetEmployeesService, GetEmployeesService>();

			return services;
		}

	}
}
