using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SalesTransactionApplication.Models;

namespace SalesTransactionApplication.Controllers
{
    public class SalesTransactionsController : Controller
    {
        private SalesTransactionAppDataEntities db = new SalesTransactionAppDataEntities();

 /*       // GET: SalesTransactions
        public ActionResult Index()
        {
            var salesTransactions = db.SalesTransactions.Include(s => s.Customer).Include(s => s.Invoice).Include(s => s.Product);
            return View(salesTransactions.ToList());
        }

        // GET: SalesTransactions/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SalesTransaction salesTransaction = db.SalesTransactions.Find(id);
            if (salesTransaction == null)
            {
                return HttpNotFound();
            }
            return View(salesTransaction);
        }
*/

        // GET: SalesTransactions/Create
        public ActionResult Create()
        {
            ViewBag.CustomerId = new SelectList(db.Customers, "CustomerId", "CustomerName");
            ViewBag.InvoiceId = new SelectList(db.Invoices, "InvoiceId", "InvoiceId");
            ViewBag.ProductId = new SelectList(db.Products, "ProductId", "ProductName");
            return View();
        }

        // POST: SalesTransactions/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "SalesTransactionId,CustomerId,ProductId,Quantity,Rate,Total,InvoiceId")] SalesTransaction salesTransaction)
        {
            if (ModelState.IsValid)
            {
                db.SalesTransactions.Add(salesTransaction);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CustomerId = new SelectList(db.Customers, "CustomerId", "CustomerName", salesTransaction.CustomerId);
            ViewBag.InvoiceId = new SelectList(db.Invoices, "InvoiceId", "InvoiceId", salesTransaction.InvoiceId);
            ViewBag.ProductId = new SelectList(db.Products, "ProductId", "ProductName", salesTransaction.ProductId);
            return View(salesTransaction);
        }

        // GET: SalesTransactions/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SalesTransaction salesTransaction = db.SalesTransactions.Find(id);
            if (salesTransaction == null)
            {
                return HttpNotFound();
            }
            ViewBag.CustomerId = new SelectList(db.Customers, "CustomerId", "CustomerName", salesTransaction.CustomerId);
            ViewBag.InvoiceId = new SelectList(db.Invoices, "InvoiceId", "InvoiceId", salesTransaction.InvoiceId);
            ViewBag.ProductId = new SelectList(db.Products, "ProductId", "ProductName", salesTransaction.ProductId);
            return View(salesTransaction);
        }

        // POST: SalesTransactions/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "SalesTransactionId,CustomerId,ProductId,Quantity,Rate,Total,InvoiceId")] SalesTransaction salesTransaction)
        {
            if (ModelState.IsValid)
            {
                db.Entry(salesTransaction).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CustomerId = new SelectList(db.Customers, "CustomerId", "CustomerName", salesTransaction.CustomerId);
            ViewBag.InvoiceId = new SelectList(db.Invoices, "InvoiceId", "InvoiceId", salesTransaction.InvoiceId);
            ViewBag.ProductId = new SelectList(db.Products, "ProductId", "ProductName", salesTransaction.ProductId);
            return View(salesTransaction);
        }

        // GET: SalesTransactions/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SalesTransaction salesTransaction = db.SalesTransactions.Find(id);
            if (salesTransaction == null)
            {
                return HttpNotFound();
            }
            return View(salesTransaction);
        }

        // POST: SalesTransactions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SalesTransaction salesTransaction = db.SalesTransactions.Find(id);
            db.SalesTransactions.Remove(salesTransaction);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        public ActionResult getRate(int productId)
        {

            var Rate = db.Products.Single(x => x.ProductId == productId);
            System.Diagnostics.Debug.WriteLine(Json(Rate));
            return Json(Rate);
        }
    }
}
