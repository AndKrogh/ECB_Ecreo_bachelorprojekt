//using EmployeeData.Models;
//using Microsoft.AspNetCore.Mvc;

//namespace ECBilling.Controllers
//{
//	public class EmployeeController : Controller
//	{
//		private readonly EcBillingContext _context;
//		public EmployeeController(EcBillingContext context)
//		{
//			this._context = context;
//		}
//		public IActionResult Index()
//		{
//			var employees = _context.Employees.ToList();

//			if (employees != null)
//			{

//				List<EmployeeViewModel> employeeList = new List<EmployeeViewModel>();
//				foreach (var employee in employees)
//				{
//					var EmployeeViewModel = new EmployeeViewModel()
//					{
//						EmployeeId = employee.EmployeeID,
//						FirstName = employee.FirstName,
//						LastName = employee.LastName,

//					};

//					employeeList.Add(EmployeeViewModel);
//				}
//				return View(employeeList);
//			}
//			return View();
//		}
//	}
//}
