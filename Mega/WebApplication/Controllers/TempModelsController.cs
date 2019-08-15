using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApplication.Models;

namespace WebApplication.Controllers
{
    public class TempModelsController : Controller
    {
        private WebApplicationContext db = new WebApplicationContext();

        // GET: TempModels
        public ActionResult Index()
        {
            return View(db.TempModels.ToList());
        }

        // GET: TempModels/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TempModel tempModel = db.TempModels.Find(id);
            if (tempModel == null)
            {
                return HttpNotFound();
            }
            return View(tempModel);
        }

        // GET: TempModels/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TempModels/Create
        // Aktivieren Sie zum Schutz vor übermäßigem Senden von Angriffen die spezifischen Eigenschaften, mit denen eine Bindung erfolgen soll. Weitere Informationen 
        // finden Sie unter https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id")] TempModel tempModel)
        {
            if (ModelState.IsValid)
            {
                db.TempModels.Add(tempModel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tempModel);
        }

        // GET: TempModels/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TempModel tempModel = db.TempModels.Find(id);
            if (tempModel == null)
            {
                return HttpNotFound();
            }
            return View(tempModel);
        }

        // POST: TempModels/Edit/5
        // Aktivieren Sie zum Schutz vor übermäßigem Senden von Angriffen die spezifischen Eigenschaften, mit denen eine Bindung erfolgen soll. Weitere Informationen 
        // finden Sie unter https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id")] TempModel tempModel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tempModel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tempModel);
        }

        // GET: TempModels/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TempModel tempModel = db.TempModels.Find(id);
            if (tempModel == null)
            {
                return HttpNotFound();
            }
            return View(tempModel);
        }

        // POST: TempModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            TempModel tempModel = db.TempModels.Find(id);
            db.TempModels.Remove(tempModel);
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
