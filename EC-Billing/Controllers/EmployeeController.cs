using Microsoft.AspNetCore.Mvc;
using Models.DbEntities;

namespace ECBilling.Controllers
{
	public class EmployeeController : Controller
	{
		private readonly EcBillingContext _context;
		public EmployeeController(EcBillingContext context)
		{
			this._context = context;
		}
		public IActionResult Index()
		{
			var employees = _context.Employees.ToList();
			return View(employees);
		}
	}
}
