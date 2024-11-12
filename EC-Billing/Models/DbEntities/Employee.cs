using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Models.DbEntities
{
	public class Employee
	{
		[Key]
		public int EmployeeID { get; set; }

		[Required]
		[MaxLength(50)]
		public string FirstName { get; set; }

		[Required]
		[MaxLength(50)]
		public string LastName { get; set; }

		public string Title { get; set; }
		public string Department { get; set; }
		public bool Availability { get; set; }
		public int VacationDays { get; set; }

		[DisplayName("Name")]
		public string FullName
		{
			get { return FirstName + " " + LastName; }
		}

		public SkillCard SkillCard { get; set; }

		public ICollection<EmployeeTask> EmployeeTasks { get; set; }
		public ICollection<EmployeeSkill> EmployeeSkills { get; set; }
		public ICollection<Project> Projects { get; set; }
	}
}
