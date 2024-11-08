using Microsoft.EntityFrameworkCore;

namespace Models.DbEntities
{
	public class EcBillingContext : DbContext
	{
		public DbSet<Employee> Employees { get; set; }

		public EcBillingContext(DbContextOptions options) : base(options)
		{

		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);

			// Seed data for Employees table
			modelBuilder.Entity<Employee>().HasData(
				new Employee { Id = 1, FirstName = "Alice", LastName = "Johnson", Description = "Senior Developer", EmployeeId = 1001 },
				new Employee { Id = 2, FirstName = "Bob", LastName = "Smith", Description = "Project Manager", EmployeeId = 1002 }
			// Add more employee records as needed
			);
		}
	}
}
