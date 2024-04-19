using Microsoft.AspNetCore.Mvc;
using WorkingWithMultipleTable_Prod.Data;
using WorkingWithMultipleTable_Prod.Models.ViewModel;

namespace WorkingWithMultipleTable_Prod.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly ApplicationContext _context;

        public EmployeeController(ApplicationContext context)
        {
            this._context =context;
        }
        public IActionResult Index()
        {
            // ek view m sirf ek hi model k data ko dikha sakte hai
            // is liye mulitple model k data ko view karane k liye merge model ya join model ka use 
            // karte hai, merge model ka uske liye hum ViewModel banate hai

            // This is using Merge Model
            //EmployeeDepatmentListViewModel emp = new EmployeeDepatmentListViewModel();
            //var empData=_context.Employees.ToList();
            //var depData =_context.Departments.ToList();
            //emp.employees = empData;
            //emp.departments=depData;
            //return View(emp);


            // From SQL raw data query
            //EmployeeDepatmentListViewModel emp = new EmployeeDepatmentListViewModel();
            //var empData=_context.Employees.FromSqlRaw(Select * from Employees).ToList();
            //var depData =_context.Departments.FromSqlRaw(Select * from Departments).ToList();
            //emp.employees = empData;
            //emp.departments=depData;
            //return View(emp);


            // This is using Join Model

            var data = (from e in _context.Employees
                       join d in _context.Departments
                       on e.DepartmentId equals d.DepartmentId
                       select new EmployeeDepartmentSummaryViewModel
                       { 
                           EmployeeId = e.EmployeeId,
                           FirstName = e.FirstName,
                           MiddleName = e.MiddleName,
                           LastName = e.LastName,
                           Gender = e.Gender,
                           DepartmentCode=d.DepartmentCode,
                           DepartmentName=d.DepartmentName,
                       }).ToList();
                       
            return View(data);
        }
    }
}
