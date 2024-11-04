using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using K22CNT2_VuAnhDuong_2210900017.Models;

namespace K22CNT2_VuAnhDuong_2210900017.Controllers
{
    public class ThanhToanController : Controller
    {
        private cuahangdoannhanhEntities db = new cuahangdoannhanhEntities();

        // GET: ThanhToan
        public ActionResult Index()
        {
            var tHANH_TOAN = db.THANH_TOAN.Include(t => t.DON_HANG);
            return View(tHANH_TOAN.ToList());
        }

        // GET: ThanhToan/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            THANH_TOAN tHANH_TOAN = db.THANH_TOAN.Find(id);
            if (tHANH_TOAN == null)
            {
                return HttpNotFound();
            }
            return View(tHANH_TOAN);
        }

        // GET: ThanhToan/Create
        public ActionResult Create()
        {
            ViewBag.MaDH = new SelectList(db.DON_HANG, "MaDH", "TenDH");
            return View();
        }

        // POST: ThanhToan/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaTT,PhuongThuc,Trangthai,MaDH")] THANH_TOAN tHANH_TOAN)
        {
            if (ModelState.IsValid)
            {
                db.THANH_TOAN.Add(tHANH_TOAN);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MaDH = new SelectList(db.DON_HANG, "MaDH", "TenDH", tHANH_TOAN.MaDH);
            return View(tHANH_TOAN);
        }

        // GET: ThanhToan/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            THANH_TOAN tHANH_TOAN = db.THANH_TOAN.Find(id);
            if (tHANH_TOAN == null)
            {
                return HttpNotFound();
            }
            ViewBag.MaDH = new SelectList(db.DON_HANG, "MaDH", "TenDH", tHANH_TOAN.MaDH);
            return View(tHANH_TOAN);
        }

        // POST: ThanhToan/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaTT,PhuongThuc,Trangthai,MaDH")] THANH_TOAN tHANH_TOAN)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tHANH_TOAN).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MaDH = new SelectList(db.DON_HANG, "MaDH", "TenDH", tHANH_TOAN.MaDH);
            return View(tHANH_TOAN);
        }

        // GET: ThanhToan/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            THANH_TOAN tHANH_TOAN = db.THANH_TOAN.Find(id);
            if (tHANH_TOAN == null)
            {
                return HttpNotFound();
            }
            return View(tHANH_TOAN);
        }

        // POST: ThanhToan/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            THANH_TOAN tHANH_TOAN = db.THANH_TOAN.Find(id);
            db.THANH_TOAN.Remove(tHANH_TOAN);
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
