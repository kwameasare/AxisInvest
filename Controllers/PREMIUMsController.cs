using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Invest.Models;

namespace Invest.Controllers
{
    public class PREMIUMsController : Controller
    {
        private Model1 db = new Model1();

        // GET: PREMIUMs
        public ActionResult Index()
        {
            return View(db.PREMIUMs.ToList());
        }

        // GET: PREMIUMs/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PREMIUM pREMIUM = db.PREMIUMs.Find(id);
            if (pREMIUM == null)
            {
                return HttpNotFound();
            }
            return View(pREMIUM);
        }

        // GET: PREMIUMs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PREMIUMs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PremiumID,AccountID,ProductID,PaymentDate,PremiumAmount")] PREMIUM pREMIUM)
        {
            if (ModelState.IsValid)
            {
                db.PREMIUMs.Add(pREMIUM);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(pREMIUM);
        }

        // GET: PREMIUMs/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PREMIUM pREMIUM = db.PREMIUMs.Find(id);
            if (pREMIUM == null)
            {
                return HttpNotFound();
            }
            return View(pREMIUM);
        }

        // POST: PREMIUMs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PremiumID,AccountID,ProductID,PaymentDate,PremiumAmount")] PREMIUM pREMIUM)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pREMIUM).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(pREMIUM);
        }

        // GET: PREMIUMs/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PREMIUM pREMIUM = db.PREMIUMs.Find(id);
            if (pREMIUM == null)
            {
                return HttpNotFound();
            }
            return View(pREMIUM);
        }

        // POST: PREMIUMs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            PREMIUM pREMIUM = db.PREMIUMs.Find(id);
            db.PREMIUMs.Remove(pREMIUM);
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
    }
}
