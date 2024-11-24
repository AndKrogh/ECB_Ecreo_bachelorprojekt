using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models.DbEntities
{
	public class Project
	{
		[Key]
		public int ProjectID { get; set; }

		[ForeignKey(nameof(Customer))]
		public int CustomerID { get; set; }

		public string? Requirements { get; set; }
		public string? Description { get; set; }

		public Customer? Customer { get; set; }
		public ICollection<ProjectTask>? ProjectTasks { get; set; }
	}
}
