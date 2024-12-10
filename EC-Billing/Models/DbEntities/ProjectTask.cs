using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models.DbEntities
{
	public class ProjectTask
	{
		[Key]
		public int TaskID { get; set; }

		[ForeignKey(nameof(Project))]
		public int ProjectID { get; set; }

		public string? TaskDetail { get; set; }

		public Project? Project { get; set; }
		public ICollection<EmployeeTask>? EmployeeTasks { get; set; }
	}
}
