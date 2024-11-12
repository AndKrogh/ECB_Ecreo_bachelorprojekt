using System.ComponentModel.DataAnnotations;

namespace Models.DbEntities
{
	public class Customer
	{
		[Key]
		public int CustomerID { get; set; }

		[Required]
		[MaxLength(255)]
		public string CustomerName { get; set; }

		public string Address { get; set; }
		public string ContactInfo { get; set; }

		public ICollection<Project> Projects { get; set; }
	}
}
