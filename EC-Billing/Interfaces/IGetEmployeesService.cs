using Models.DbEntities;

namespace ECBilling.Services
{
	public interface IGetEmployeesService
	{
		Task<List<Employee>> GetEmployeesAsync();

	}
}
