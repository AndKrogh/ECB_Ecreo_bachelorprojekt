using ECBilling.Services;

namespace ECBilling.Startup
{
	public static class ServiceCollectionExtensions
	{
		public static IServiceCollection AddApplicationServices(this IServiceCollection services)
		{
			services.AddScoped<IGetEmployeesService, GetEmployeesService>();

			return services;
		}

	}
}
