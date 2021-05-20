using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcOnlineCommercialAutomation.Models.Classes;

namespace MvcOnlineCommercialAutomation.Controllers
{
    public class StatisticController : Controller
    {
        // GET: Statistic
        Context c = new Context();
        public ActionResult Index()
        {
            var value1 = c.Currents.Count().ToString();
            ViewBag.v1 = value1;
            var value2 = c.Products.Count().ToString();
            ViewBag.v2 = value2;
            var value3 = c.Employees.Count().ToString();
            ViewBag.v3 = value3;
            var value4 = c.Categories.Count().ToString();
            ViewBag.v4 = value4;
            var value5 = c.Products.Sum(x=>x.Stock).ToString();
            ViewBag.v5 = value5;
            var value6 = (from x in c.Products select x.Brand).Distinct().Count().ToString();
            ViewBag.v6 = value6;
            var value7 = c.Products.Count(x=>x.Stock<=20).ToString();
            ViewBag.v7 = value7;
            var value8 = (from x in c.Products orderby x.SellPrice descending select x.ProductName).FirstOrDefault();
            ViewBag.v8 = value8;
            var value9 = (from x in c.Products orderby x.SellPrice ascending select x.ProductName).FirstOrDefault();
            ViewBag.v9 = value9;
            var value10 = c.Products.Count(x => x.ProductName=="Fridge").ToString();
            ViewBag.v10 = value10;
            var value11 = c.Products.Count(x => x.ProductName == "Laptop").ToString();
            ViewBag.v11 = value11;
            var value12 = c.Products.GroupBy(X => X.Brand).OrderByDescending(z => z.Count()).Select(y => y.Key).FirstOrDefault();
            ViewBag.v12 = value12;
            var value13 = c.Products.Where(u=>u.ProductID==(c.SalesTransactions.GroupBy(x => x.ProductID).OrderByDescending(z => z.Count()).Select(y => y.Key).FirstOrDefault())).Select(k=>k.ProductName).FirstOrDefault();
            ViewBag.v13 = value13;
            var value14 = c.SalesTransactions.Sum(x => x.TotalPrice).ToString();
            ViewBag.v14 = value14;
            DateTime today = DateTime.Today;
            var value15 = c.SalesTransactions.Count(x => x.Date == today).ToString();
            ViewBag.v15 = value15;
            var value16 = c.SalesTransactions.Where(x => x.Date == today).Sum(y => y.TotalPrice).ToString();
            ViewBag.v16 = value16;
            return View();
        }
    }
}