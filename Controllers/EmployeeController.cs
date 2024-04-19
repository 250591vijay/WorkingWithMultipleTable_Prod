using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
            /////////************Merge Model EmployeeDepatmentListViewModel(View Model) *************************///////////

            // ek view m sirf ek hi model k data ko dikha sakte hai
            // is liye mulitple model k data ko view karane k liye    merge model ya join model ka use 
            // karte hai, merge model ka uske liye hum ViewModel banate hai

            // This is using Merge Model
            //EmployeeDepatmentListViewModel emp = new EmployeeDepatmentListViewModel();
            //var empData=_context.Employees.ToList();
            //var depData =_context.Departments.ToList();
            //emp.employees = empData;
            //emp.departments=depData;
            //return View(emp);


            // From SQL raw data query use FromSqlRaw ()
            //EmployeeDepatmentListViewModel emp = new EmployeeDepatmentListViewModel();
            //var empData=_context.Employees.FromSqlRaw(Select * from Employees).ToList();
            //var depData =_context.Departments.FromSqlRaw(Select * from Departments).ToList();
            //emp.employees = empData;
            //emp.departments=depData;
            //return View(emp);

            //Using store Procedure to get data by using merge model
            //EmployeeDepatmentListViewModel emp = new EmployeeDepatmentListViewModel();
            //var empdata = _context.Employees.FromSqlRaw("exec GetEmployees");
            //var depdata = _context.Departments.FromSqlRaw("exec GetDepartments");

            /////////************Join Model EmployeeDepartmentSummaryViewModels(View Model)*************************///////////

            // This is using Join Model
            // var data = (from e in _context.Employees
            //           join d in _context.Departments
            //           on e.DepartmentId equals d.DepartmentId
            //           select new EmployeeDepartmentSummaryViewModel
            //           { 
            //               EmployeeId = e.EmployeeId,
            //               FirstName = e.FirstName,
            //               MiddleName = e.MiddleName,
            //               LastName = e.LastName,
            //               Gender = e.Gender,
            //               DepartmentCode=d.DepartmentCode,
            //               DepartmentName=d.DepartmentName,
            //           }).ToList();           
            // return View(data);

            // Using Join Model and use FromSqlRaw ()
            // is query s object ja raha hai
            //var data = _context.EmployeeDepartmentSummaryViewModels.FromSqlRaw("select e.EmployeeId, e.FirstName, e.MiddleName,e.LastName,e.Gender,d.DepartmentId, d.DepartmentCode,                                                                       d.DepartmentName from Employees e join Departments d  on e.DepartmentId =d.DepartmentId");

            //Using store Procedure to get data by using join model

            var result = _context.EmployeeDepartmentSummaryViewModels.FromSqlRaw("exec GetEmployeeDepartmentList").ToList();

            return View(result);
        }
    }
}
