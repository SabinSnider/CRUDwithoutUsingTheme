using CRUDwithoutScaff.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace CRUDwithoutScaff.Controllers
{
    public class EmployeeController : Controller
    {
        // GET: Employee
        public ActionResult Index()
        {

            EmployeeContext employeeContext = new EmployeeContext();
            
            List<Employee> employee = employeeContext.Employees.ToList();


            return View(employee);
        }

        public ActionResult Details(int id)
        {

            EmployeeContext employeeContext = new EmployeeContext();

            //Object reference variable "employee"
            Employee employee = employeeContext.Employees.Single(emp => emp.EmployeeId == id);


            return View(employee);
        }
    }
}