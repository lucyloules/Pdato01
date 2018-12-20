using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Pdato.Models;

namespace Pdato.Controllers
{
    public class DatesController : Controller
    {
        private PdatoContext db = new PdatoContext();

        // GET: Dates
        public ActionResult Index()
        {
            return View(db.Dates.ToList());
        }

        // GET: Dates/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Date date = db.Dates.Find(id);
            if (date == null)
            {
                return HttpNotFound();
            }
            return View(date);
        }

        // GET: Dates/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Dates/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "DateId,ReservationDate,ReservationTime,StateId")] Date date)
        {
            if (ModelState.IsValid)
            {
                db.Dates.Add(date);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(date);
        }

        // GET: Dates/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Date date = db.Dates.Find(id);
            if (date == null)
            {
                return HttpNotFound();
            }
            return View(date);
        }

        // POST: Dates/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "DateId,ReservationDate,ReservationTime,StateId")] Date date)
        {
            if (ModelState.IsValid)
            {
                db.Entry(date).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(date);
        }

        // GET: Dates/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Date date = db.Dates.Find(id);
            if (date == null)
            {
                return HttpNotFound();
            }
            return View(date);
        }

        // POST: Dates/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Date date = db.Dates.Find(id);
            db.Dates.Remove(date);
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
