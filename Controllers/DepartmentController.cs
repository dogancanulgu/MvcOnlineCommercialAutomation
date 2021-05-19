using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcOnlineCommercialAutomation.Models.Classes;

namespace MvcOnlineCommercialAutomation.Controllers
{
    public class DepartmentController : Controller
    {
        // GET: Departman
        Context c = new Context();
        public ActionResult Index()
        {
            var values = c.Departments.Where(x => x.Status == true).ToList();
            return View(values);
        }
        [HttpGet]
        public ActionResult AddDepartment()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddDepartment(Department d)
        {
            c.Departments.Add(d);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult DeleteDepartment(int ID)
        {
            var dep = c.Departments.Find(ID);
            dep.Status = false;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public  ActionResult GetDepartment(int ID)
        {
            var dpt = c.Departments.Find(ID);
            return View("GetDepartment", dpt);
        }
        public ActionResult UpdateDepartment(Department p)
        {
            var dept = c.Departments.Find(p.DepartmentID);
            dept.DepartmentName = p.DepartmentName;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult DetailDepartment(int ID)
        {
            var values = c.Employees.Where(x => x.DepartmentID == ID).ToList();
            var dpt = c.Departments.Where(x => x.DepartmentID == ID).Select(y => y.DepartmentName).FirstOrDefault();
            ViewBag.d = dpt;
            return View(values);
        }
        public ActionResult DepartmentEmployeeSales (int ID)
        {
            var values = c.SalesTransactions.Where(x => x.EmployeeID == ID).ToList();
            var emp = c.Employees.Where(x => x.EmployeeID == ID).Select(y => y.EmployeeName +" "+ y.EmployeeSurname).FirstOrDefault();
            ViewBag.demp = emp;
            return View(values);
        }
    }
}