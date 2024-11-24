using System.ComponentModel.DataAnnotations.Schema;

namespace Models.DbEntities
{
	public class EmployeeTask
	{
		[Column(Order = 0)]
		[ForeignKey(nameof(Employee))]
		public int EmployeeID { get; set; }

		[Column(Order = 1)]
		[ForeignKey(nameof(ProjectTask))]
		public int TaskID { get; set; }

		public DateTime AssignedDate { get; set; }
		public string? RoleInTask { get; set; }

		public Employee? Employee { get; set; }
		public ProjectTask? ProjectTask { get; set; }
	}
}
