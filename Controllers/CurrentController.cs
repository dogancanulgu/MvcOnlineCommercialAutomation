using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcOnlineCommercialAutomation.Models.Classes;

namespace MvcOnlineCommercialAutomation.Controllers
{
    public class CurrentController : Controller
    {
        // GET: Current
        Context c = new Context();
        public ActionResult Index()
        {
            var values = c.Currents.Where(x=>x.Status==true).ToList();
            return View(values);
        }
        [HttpGet]
        public ActionResult NewCurrent()
        {
            return View();
        }
        [HttpPost]
        public ActionResult NewCurrent(Current p)
        {
            p.Status = true;
            c.Currents.Add(p);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult DeleteCurrent(int ID)
        {
            var cur = c.Currents.Find(ID);
            cur.Status = false;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult GetCurrent(int ID)
        {
            var curr = c.Currents.Find(ID);
            return View("GetCurrent", curr);
        }
        public ActionResult UpdateCurrent(Current p)
        {
            if (!ModelState.IsValid)
            {
                return View("GetCurrent");
            }
            var crnt = c.Currents.Find(p.CurrentID);
            crnt.CurrentName = p.CurrentName;
            crnt.CurrentSurname = p.CurrentSurname;
            crnt.CurrentCity = p.CurrentCity;
            crnt.CurrentMail = p.CurrentMail;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult CustomerSales(int ID)
        {
            var values = c.SalesTransactions.Where(x => x.CurrentID == ID).ToList();
            var cr = c.Currents.Where(x => x.CurrentID == ID).Select(y => y.CurrentName + " " + y.CurrentSurname).FirstOrDefault();
            ViewBag.crr = cr;
            return View(values);
        }
    }
}