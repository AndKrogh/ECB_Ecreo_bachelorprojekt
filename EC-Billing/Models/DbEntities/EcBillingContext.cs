using Microsoft.EntityFrameworkCore;

namespace Models.DbEntities
{
	public class EcBillingContext : DbContext
	{
		public DbSet<Employee> Employees { get; set; }

		public EcBillingContext(DbContextOptions options) : base(options)
		{

		}
	}
}
