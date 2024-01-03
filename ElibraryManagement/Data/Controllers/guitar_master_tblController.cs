using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ElibraryManagement.Data;
using ElibraryManagement.Data.Models;



namespace ElibraryManagement.Data.Controllers
{
    public class guitar_master_tblController : Controller
    {
        private MyDbContext db = new MyDbContext();

        // GET: guitar_master_tbl
        public ActionResult Index()
        {
            return View(db.guitar_master_tbls.ToList());
        }

        // GET: guitar_master_tbl/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            guitar_master_tbl guitar_master_tbl = db.guitar_master_tbls.Find(id);
            if (guitar_master_tbl == null)
            {
                return HttpNotFound();
            }
            return View(guitar_master_tbl);
        }

        // GET: guitar_master_tbl/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: guitar_master_tbl/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. 
        // Дополнительные сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,guitar_name,guitar_type,guitar_color,guitar_weight,guitar_material,number_of_strings,guitar_price,guitar_img_link,publisher_name,publish_date,guitar_description")] guitar_master_tbl guitar_master_tbl)
        {
            if (ModelState.IsValid)
            {
                db.guitar_master_tbls.Add(guitar_master_tbl);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(guitar_master_tbl);
        }

        // GET: guitar_master_tbl/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            guitar_master_tbl guitar_master_tbl = db.guitar_master_tbls.Find(id);
            if (guitar_master_tbl == null)
            {
                return HttpNotFound();
            }
            return View(guitar_master_tbl);
        }

        // POST: guitar_master_tbl/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. 
        // Дополнительные сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,guitar_name,guitar_type,guitar_color,guitar_weight,guitar_material,number_of_strings,guitar_price,guitar_img_link,publisher_name,publish_date,guitar_description")] guitar_master_tbl guitar_master_tbl)
        {
            if (ModelState.IsValid)
            {
                db.Entry(guitar_master_tbl).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(guitar_master_tbl);
        }

        // GET: guitar_master_tbl/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            guitar_master_tbl guitar_master_tbl = db.guitar_master_tbls.Find(id);
            if (guitar_master_tbl == null)
            {
                return HttpNotFound();
            }
            return View(guitar_master_tbl);
        }

        // POST: guitar_master_tbl/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            guitar_master_tbl guitar_master_tbl = db.guitar_master_tbls.Find(id);
            db.guitar_master_tbls.Remove(guitar_master_tbl);
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
