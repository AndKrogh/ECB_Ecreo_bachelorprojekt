using Microsoft.EntityFrameworkCore;
using Models.DbEntities;

public class EcBillingContext : DbContext
{
	public DbSet<Customer> Customers { get; set; }
	public DbSet<Employee> Employees { get; set; }
	public DbSet<Project> Projects { get; set; }
	public DbSet<ProjectTask> ProjectTasks { get; set; }
	public DbSet<Skill> Skills { get; set; }
	public DbSet<SkillCard> SkillCards { get; set; }
	public DbSet<EmployeeTask> EmployeeTasks { get; set; }
	public DbSet<EmployeeSkill> EmployeeSkills { get; set; }

	public EcBillingContext(DbContextOptions options) : base(options)
	{

	}

	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		modelBuilder.Entity<EmployeeSkill>()
			.HasKey(es => new { es.EmployeeID, es.SkillID });

		modelBuilder.Entity<EmployeeTask>()
			.HasKey(et => new { et.EmployeeID, et.TaskID });

		base.OnModelCreating(modelBuilder);

		// Seed data for Customers
		modelBuilder.Entity<Customer>().HasData(
			new Customer { CustomerID = 1, CustomerName = "Acme Corp", Address = "123 Elm Street", ContactInfo = "Good customer" },
			new Customer { CustomerID = 2, CustomerName = "Tech Solutions", Address = "456 Oak Avenue", ContactInfo = "Bad customer" }
		);

		// Seed data for Employees
		modelBuilder.Entity<Employee>().HasData(
			new Employee { EmployeeID = 1, FirstName = "John", LastName = "Doe", Title = "Project Manager", Department = "IT", Availability = true, VacationDays = 15 },
			new Employee { EmployeeID = 2, FirstName = "Jane", LastName = "Smith", Title = "Developer", Department = "Engineering", Availability = true, VacationDays = 10 }
		);

		// Seed data for Projects
		modelBuilder.Entity<Project>().HasData(
			new Project { ProjectID = 1, CustomerID = 1, Requirements = "Build CRM system", Description = "A custom CRM for Acme Corp" },
			new Project { ProjectID = 2, CustomerID = 2, Requirements = "E-commerce website", Description = "Online store for Tech Solutions" }
		);

		// Seed data for Tasks
		modelBuilder.Entity<ProjectTask>().HasData(
			new ProjectTask { TaskID = 1, ProjectID = 1, TaskDetail = "Design database schema" },
			new ProjectTask { TaskID = 2, ProjectID = 2, TaskDetail = "Develop frontend UI" }
		);

		// Seed data for Skills
		modelBuilder.Entity<Skill>().HasData(
			new Skill { SkillID = 1, SkillName = "C#" },
			new Skill { SkillID = 2, SkillName = "Blazor" }
		);

		// Seed data for SkillCards
		modelBuilder.Entity<SkillCard>().HasData(
			new SkillCard { EmployeeID = 1, SkillsData = "Project Management, Agile" },
			new SkillCard { EmployeeID = 2, SkillsData = "Backend Development, API Integration" }
		);

		// Seed data for EmployeeTask (join table)
		modelBuilder.Entity<EmployeeTask>().HasData(
			new EmployeeTask { EmployeeID = 1, TaskID = 1, AssignedDate = DateTime.Now, RoleInTask = "Lead" },
			new EmployeeTask { EmployeeID = 2, TaskID = 2, AssignedDate = DateTime.Now, RoleInTask = "Developer" }
		);

		// Seed data for EmployeeSkill (join table for many-to-many Employee and Skill relationship)
		modelBuilder.Entity<EmployeeSkill>().HasData(
			new EmployeeSkill { EmployeeID = 1, SkillID = 1 },
			new EmployeeSkill { EmployeeID = 2, SkillID = 2 }
		);
	}
}
