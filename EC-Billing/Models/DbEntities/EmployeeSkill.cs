using System.ComponentModel.DataAnnotations.Schema;

namespace Models.DbEntities
{
	public class EmployeeSkill
	{
		[Column(Order = 0)]
		[ForeignKey(nameof(Employee))]
		public int EmployeeID { get; set; }

		[Column(Order = 1)]
		[ForeignKey(nameof(Skill))]
		public int SkillID { get; set; }

		public Employee? Employee { get; set; }
		public Skill? Skill { get; set; }
	}
}
