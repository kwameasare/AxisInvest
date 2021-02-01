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
    public class MEMBERsController : Controller
    {
        private Model1 db = new Model1();

        // GET: MEMBERs
        public ActionResult Index()
        {
            return View(db.MEMBERs.ToList());
        }

        // GET: MEMBERs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MEMBER mEMBER = db.MEMBERs.Find(id);
            if (mEMBER == null)
            {
                return HttpNotFound();
            }
            return View(mEMBER);
        }

        // GET: MEMBERs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MEMBERs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "AccountID,AccountNo,Othernames,Surname,DOB,CellPhone,Email,ResidentialAddress,Active")] MEMBER mEMBER)
        {
            if (ModelState.IsValid)
            {
                db.MEMBERs.Add(mEMBER);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(mEMBER);
        }

        // GET: MEMBERs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MEMBER mEMBER = db.MEMBERs.Find(id);
            if (mEMBER == null)
            {
                return HttpNotFound();
            }
            return View(mEMBER);
        }

        // POST: MEMBERs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "AccountID,AccountNo,Othernames,Surname,DOB,CellPhone,Email,ResidentialAddress,Active")] MEMBER mEMBER)
        {
            if (ModelState.IsValid)
            {
                db.Entry(mEMBER).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(mEMBER);
        }

        // GET: MEMBERs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MEMBER mEMBER = db.MEMBERs.Find(id);
            if (mEMBER == null)
            {
                return HttpNotFound();
            }
            return View(mEMBER);
        }

        // POST: MEMBERs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            MEMBER mEMBER = db.MEMBERs.Find(id);
            db.MEMBERs.Remove(mEMBER);
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
