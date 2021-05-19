using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcOnlineCommercialAutomation.Models.Classes;

namespace MvcOnlineCommercialAutomation.Controllers
{
    public class SalesController : Controller
    {
        // GET: Sales
        Context c = new Context();
        public ActionResult Index()
        {
            var values = c.SalesTransactions.ToList();
            return View(values);
        }
        [HttpGet]
        public ActionResult NewSales()
        {
            List<SelectListItem> value1 = (from x in c.Products.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.ProductName,
                                               Value = x.ProductID.ToString()
                                           }).ToList();
            List<SelectListItem> value2 = (from x in c.Currents.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.CurrentName + " " + x.CurrentSurname,
                                               Value = x.CurrentID.ToString()
                                           }).ToList();
            List<SelectListItem> value3 = (from x in c.Employees.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.EmployeeName + " " + x.EmployeeSurname,
                                               Value = x.EmployeeID.ToString()
                                           }).ToList();

            ViewBag.vls1 = value1;
            ViewBag.vls2 = value2;
            ViewBag.vls3 = value3;
            return View();
        }
        [HttpPost]
        public ActionResult NewSales(SalesTransaction s)
        {
            s.Date = DateTime.Parse(DateTime.Now.ToShortDateString());
            c.SalesTransactions.Add(s);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult GetSales(int ID)
        {
            List<SelectListItem> value1 = (from x in c.Products.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.ProductName,
                                               Value = x.ProductID.ToString()
                                           }).ToList();
            List<SelectListItem> value2 = (from x in c.Currents.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.CurrentName + " " + x.CurrentSurname,
                                               Value = x.CurrentID.ToString()
                                           }).ToList();
            List<SelectListItem> value3 = (from x in c.Employees.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.EmployeeName + " " + x.EmployeeSurname,
                                               Value = x.EmployeeID.ToString()
                                           }).ToList();

            ViewBag.vls1 = value1;
            ViewBag.vls2 = value2;
            ViewBag.vls3 = value3;
            var value = c.SalesTransactions.Find(ID);
            return View("GetSales", value);
        }
        public ActionResult UpdateSales(SalesTransaction p)
        {
            var value = c.SalesTransactions.Find(p.SalesID);
            value.CurrentID = p.CurrentID;
            value.Amount = p.Amount;
            value.Price = p.Price;
            value.EmployeeID = p.EmployeeID;
            value.Date = p.Date;
            value.TotalPrice = p.TotalPrice;
            value.ProductID = p.ProductID;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult DetailSales(int ID)
        {
            var values = c.SalesTransactions.Where(x => x.SalesID == ID).ToList();
            return View(values);

        }
    }
}