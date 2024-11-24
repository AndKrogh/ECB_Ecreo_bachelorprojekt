using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models.DbEntities
{
	public class SkillCard
	{
		[Key, ForeignKey(nameof(Employee))]
		public int EmployeeID { get; set; }

		public string? SkillsData { get; set; }

		public Employee? Employee { get; set; }
	}
}
