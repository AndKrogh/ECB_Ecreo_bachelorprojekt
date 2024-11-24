using Microsoft.EntityFrameworkCore;
using Models.DbEntities;

namespace ECBilling.Services
{
	public class GetEmployeesService : IGetEmployeesService
	{

		private readonly EcBillingContext _context;

		public GetEmployeesService(EcBillingContext context)
		{
			_context = context;
		}

		public async Task<List<Employee>> GetEmployeesAsync()
		{
			return await _context.Employees.ToListAsync();
		}

	}
}
