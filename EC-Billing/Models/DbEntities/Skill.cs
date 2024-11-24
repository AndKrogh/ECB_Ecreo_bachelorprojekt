using System.ComponentModel.DataAnnotations;

namespace Models.DbEntities
{
	public class Skill
	{
		[Key]
		public int SkillID { get; set; }

		[Required]
		[MaxLength(100)]
		public string? SkillName { get; set; }

		public ICollection<EmployeeSkill>? EmployeeSkills { get; set; }
	}
}
