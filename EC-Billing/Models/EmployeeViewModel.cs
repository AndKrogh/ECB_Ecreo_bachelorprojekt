using System.ComponentModel;

namespace EcBilling.Models
{
	public class EmployeeViewModel
	{
		public int Id { get; set; }

		[DisplayName("First Name")]
		public string FirstName { get; set; }

		[DisplayName("Last Name")]
		public string LastName { get; set; }

		public string Description { get; set; }

		public int EmployeeId { get; set; }
		public string FullName
		{
			get { return FirstName + " " + LastName; }
		}
	}
}
