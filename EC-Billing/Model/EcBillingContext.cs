using Microsoft.EntityFrameworkCore;

namespace ECBilling.Model
{
	public class EcBillingContext : DbContext
	{
		public DbSet<Employee> Employees { get; set; }

		public EcBillingContext(DbContextOptions options) : base(options)
		{

		}
	}
}
