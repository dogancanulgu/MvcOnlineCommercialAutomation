using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcOnlineCommercialAutomation.Models.Classes;
namespace MvcOnlineCommercialAutomation.Controllers
{
    public class EmployeeController : Controller
    {
        // GET: Employee
        Context c = new Context();
        public ActionResult Index()
        {
            var values = c.Employees.ToList();
            return View(values);
        }
        [HttpGet]
        public ActionResult AddEmployee()
        {
            List<SelectListItem> value1 = (from x in c.Departments.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.DepartmentName,
                                               Value = x.DepartmentID.ToString()
                                           }).ToList();
            ViewBag.vls1 = value1;
            return View();
        }
        [HttpPost]
        public ActionResult AddEmployee(Employee e)
        {
            c.Employees.Add(e);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult GetEmployee(int ID)
        {
            List<SelectListItem> value1 = (from x in c.Departments.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.DepartmentName,
                                               Value = x.DepartmentID.ToString()
                                           }).ToList();
            ViewBag.vls1 = value1;
            var emp = c.Employees.Find(ID);
            return View("GetEmployee", emp);
        }
        public ActionResult UpdateEmployee(Employee e)
        {
            var empl = c.Employees.Find(e.EmployeeID);
            empl.EmployeeName = e.EmployeeName;
            empl.EmployeeSurname = e.EmployeeSurname;
            empl.EmployeePicture = e.EmployeePicture;
            empl.DepartmentID = e.DepartmentID;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}