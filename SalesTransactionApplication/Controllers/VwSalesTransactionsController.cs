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
    public class VwSalesTransactionsController : Controller
    {
        private SalesTransactionAppDataEntities db = new SalesTransactionAppDataEntities();

        // GET: VwSalesTransactions
        public ActionResult Index()
        {
            return View(db.VwSalesTransactions.ToList());
        }

        // GET: VwSalesTransactions/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VwSalesTransaction vwSalesTransaction = db.VwSalesTransactions.Find(id);
            if (vwSalesTransaction == null)
            {
                return HttpNotFound();
            }
            return View(vwSalesTransaction);
        }

/*
        // GET: VwSalesTransactions/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: VwSalesTransactions/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "SalesTransactionId,CustomerId,ProductId,CustomerName,ProductName,Quantity,Rate,Total,InvoiceNumber")] VwSalesTransaction vwSalesTransaction)
        {
            if (ModelState.IsValid)
            {
                db.VwSalesTransactions.Add(vwSalesTransaction);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(vwSalesTransaction);
        }

        // GET: VwSalesTransactions/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VwSalesTransaction vwSalesTransaction = db.VwSalesTransactions.Find(id);
            if (vwSalesTransaction == null)
            {
                return HttpNotFound();
            }
            return View(vwSalesTransaction);
        }

        // POST: VwSalesTransactions/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "SalesTransactionId,CustomerId,ProductId,CustomerName,ProductName,Quantity,Rate,Total,InvoiceNumber")] VwSalesTransaction vwSalesTransaction)
        {
            if (ModelState.IsValid)
            {
                db.Entry(vwSalesTransaction).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(vwSalesTransaction);
        }

        // GET: VwSalesTransactions/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VwSalesTransaction vwSalesTransaction = db.VwSalesTransactions.Find(id);
            if (vwSalesTransaction == null)
            {
                return HttpNotFound();
            }
            return View(vwSalesTransaction);
        }

        // POST: VwSalesTransactions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            VwSalesTransaction vwSalesTransaction = db.VwSalesTransactions.Find(id);
            db.VwSalesTransactions.Remove(vwSalesTransaction);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
*/

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
