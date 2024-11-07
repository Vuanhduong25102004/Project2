using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using K22CNT2_VuAnhDuong_2210900017_.Models;

namespace K22CNT2_VuAnhDuong_2210900017_.Controllers
{
    public class DanhMucController : Controller
    {
        private cuahangdoannhanhEntities db = new cuahangdoannhanhEntities();

        // GET: DanhMuc
        public ActionResult Index()
        {
            return View(db.DANH_MUC.ToList());
        }

        // GET: DanhMuc/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DANH_MUC dANH_MUC = db.DANH_MUC.Find(id);
            if (dANH_MUC == null)
            {
                return HttpNotFound();
            }
            return View(dANH_MUC);
        }

        // GET: DanhMuc/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: DanhMuc/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaDM,TenDM")] DANH_MUC dANH_MUC)
        {
            if (ModelState.IsValid)
            {
                db.DANH_MUC.Add(dANH_MUC);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(dANH_MUC);
        }

        // GET: DanhMuc/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DANH_MUC dANH_MUC = db.DANH_MUC.Find(id);
            if (dANH_MUC == null)
            {
                return HttpNotFound();
            }
            return View(dANH_MUC);
        }

        // POST: DanhMuc/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaDM,TenDM")] DANH_MUC dANH_MUC)
        {
            if (ModelState.IsValid)
            {
                db.Entry(dANH_MUC).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(dANH_MUC);
        }

        // GET: DanhMuc/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DANH_MUC dANH_MUC = db.DANH_MUC.Find(id);
            if (dANH_MUC == null)
            {
                return HttpNotFound();
            }
            return View(dANH_MUC);
        }

        // POST: DanhMuc/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DANH_MUC dANH_MUC = db.DANH_MUC.Find(id);
            db.DANH_MUC.Remove(dANH_MUC);
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
