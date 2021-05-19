using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcOnlineCommercialAutomation.Models.Classes;

namespace MvcOnlineCommercialAutomation.Controllers
{
    public class InvoiceController : Controller
    {
        // GET: Invoice
        Context c = new Context();
        public ActionResult Index()
        {
            var list = c.Invoices.ToList();
            return View(list);
        }
        [HttpGet]
        public ActionResult AddInvoice()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddInvoice(Invoice i)
        {
            c.Invoices.Add(i);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult GetInvoice(int ID)
        {
            var invoice = c.Invoices.Find(ID);
            return View("GetInvoice", invoice);
        }
        public ActionResult UpdateInvoice(Invoice i)
        {
            var invoice = c.Invoices.Find(i.InvoiceID);
            invoice.InvoiceSerialNo = i.InvoiceSerialNo;
            invoice.InvoiceSequenceNo = i.InvoiceSequenceNo;
            invoice.Time = i.Time;
            invoice.Date = i.Date;
            invoice.Consigner = i.Consigner;
            invoice.Recipient = i.Recipient;
            invoice.TaxOffice = i.TaxOffice;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult DetailInvoice(int ID)
        {
            var values = c.InvoiceItems.Where(x => x.InvoiceID == ID).ToList();
            return View(values);
        }
        [HttpGet]
        public ActionResult NewItem()
        {
            return View();
        }
        [HttpPost]
        public ActionResult NewItem(InvoiceItem p)
        {
            c.InvoiceItems.Add(p);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}