using Models.DbEntities;

namespace ECBilling.Services
{
	public interface IGetEmployeesService
	{
		Task<IEnumerable<Employee>> GetEmployeesAsync();

	}
}
