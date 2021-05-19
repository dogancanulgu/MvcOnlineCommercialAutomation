using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcOnlineCommercialAutomation.Models.Classes;

namespace MvcOnlineCommercialAutomation.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        Context c = new Context();
        public ActionResult Index()
        {
            var products = c.Products.Where(x=>x.Status==true).ToList();
            return View(products);
        }
        [HttpGet]
        public ActionResult NewProduct()
        {
            List<SelectListItem> value1 = (from x in c.Categories.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.CategoryName,
                                               Value = x.CategoryID.ToString()
                                           }).ToList();
            ViewBag.vls1 = value1;
            return View();
        }
        [HttpPost]
        public ActionResult NewProduct(Product p)
        {
            c.Products.Add(p);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult DeleteProduct(int ID)
        {
            var value = c.Products.Find(ID);
            value.Status = false;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult GetProduct(int ID)
        {
            List<SelectListItem> value1 = (from x in c.Categories.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.CategoryName,
                                               Value = x.CategoryID.ToString()
                                           }).ToList();
            ViewBag.vls1 = value1;
            var valueproduct = c.Products.Find(ID);
            return View("GetProduct", valueproduct);
        }
        public ActionResult UpdateProduct(Product p)
        {
            var prd = c.Products.Find(p.ProductID);
            prd.PurchasePrice = p.PurchasePrice;
            prd.Status = p.Status;
            prd.CategoryID = p.CategoryID;
            prd.Brand = p.Brand;
            prd.SellPrice = p.SellPrice;
            prd.Stock = p.Stock;
            prd.ProductName = p.ProductName;
            prd.ProductPicture = p.ProductPicture;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult ProductList()
        {
            var values = c.Products.ToList();
            return View(values);
        }
    }
}