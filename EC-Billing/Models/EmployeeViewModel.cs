using System.ComponentModel;

namespace EcBilling.Models
{
	public class EmployeeViewModel
	{
		public int Id { get; set; }

		[DisplayName("Name")]
		public string Name { get; set; }

		public string Description { get; set; }
		public int EmployeeId { get; set; }
	}
}
