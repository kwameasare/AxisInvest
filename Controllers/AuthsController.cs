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
    public class AuthsController : Controller
    {
        private Model1 db = new Model1();

        // GET: Auths
        public ActionResult Index()
        {
            return View(db.Auths.ToList());
        }

        // GET: Auths/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Auth auth = db.Auths.Find(id);
            if (auth == null)
            {
                return HttpNotFound();
            }
            return View(auth);
        }

        // GET: Auths/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Auths/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "AuthID,AccountID,UserName,Pwd")] Auth auth)
        {
            if (ModelState.IsValid)
            {
                db.Auths.Add(auth);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(auth);
        }

        // GET: Auths/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Auth auth = db.Auths.Find(id);
            if (auth == null)
            {
                return HttpNotFound();
            }
            return View(auth);
        }

        // POST: Auths/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "AuthID,AccountID,UserName,Pwd")] Auth auth)
        {
            if (ModelState.IsValid)
            {
                db.Entry(auth).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(auth);
        }

        // GET: Auths/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Auth auth = db.Auths.Find(id);
            if (auth == null)
            {
                return HttpNotFound();
            }
            return View(auth);
        }

        // POST: Auths/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            Auth auth = db.Auths.Find(id);
            db.Auths.Remove(auth);
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
