using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using hf.Models;

namespace hf.Controllers
{
    public class HistoricLocationController : Controller
    {
        private hfContext db = new hfContext();

        // GET: HistoricLocation
        public ActionResult Index()
        {
            return View(db.HistoricLocations.ToList());
        }

        // GET: HistoricLocation/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HistoricLocation historicLocation = db.HistoricLocations.Find(id);
            if (historicLocation == null)
            {
                return HttpNotFound();
            }
            return View(historicLocation);
        }

        // GET: HistoricLocation/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: HistoricLocation/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Description,PictureUrl,SoundUrl,UrlWebsite")] HistoricLocation historicLocation)
        {
            if (ModelState.IsValid)
            {
                db.HistoricLocations.Add(historicLocation);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(historicLocation);
        }

        // GET: HistoricLocation/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HistoricLocation historicLocation = db.HistoricLocations.Find(id);
            if (historicLocation == null)
            {
                return HttpNotFound();
            }
            return View(historicLocation);
        }

        // POST: HistoricLocation/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Description,PictureUrl,SoundUrl,UrlWebsite")] HistoricLocation historicLocation)
        {
            if (ModelState.IsValid)
            {
                db.Entry(historicLocation).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(historicLocation);
        }

        // GET: HistoricLocation/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HistoricLocation historicLocation = db.HistoricLocations.Find(id);
            if (historicLocation == null)
            {
                return HttpNotFound();
            }
            return View(historicLocation);
        }

        // POST: HistoricLocation/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            HistoricLocation historicLocation = db.HistoricLocations.Find(id);
            db.HistoricLocations.Remove(historicLocation);
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
