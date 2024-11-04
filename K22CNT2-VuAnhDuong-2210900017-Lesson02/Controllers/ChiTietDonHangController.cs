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
    public class ChiTietDonHangController : Controller
    {
        private cuahangdoannhanhEntities db = new cuahangdoannhanhEntities();

        // GET: ChiTietDonHang
        public ActionResult Index()
        {
            var cHI_TIET_DON_HANG = db.CHI_TIET_DON_HANG.Include(c => c.DON_HANG).Include(c => c.SAN_PHAM);
            return View(cHI_TIET_DON_HANG.ToList());
        }

        // GET: ChiTietDonHang/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CHI_TIET_DON_HANG cHI_TIET_DON_HANG = db.CHI_TIET_DON_HANG.Find(id);
            if (cHI_TIET_DON_HANG == null)
            {
                return HttpNotFound();
            }
            return View(cHI_TIET_DON_HANG);
        }

        // GET: ChiTietDonHang/Create
        public ActionResult Create()
        {
            ViewBag.MaDH = new SelectList(db.DON_HANG, "MaDH", "TenDH");
            ViewBag.MaSP = new SelectList(db.SAN_PHAM, "MaSP", "TenSP");
            return View();
        }

        // POST: ChiTietDonHang/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaDH,MaSP,SoLuong")] CHI_TIET_DON_HANG cHI_TIET_DON_HANG)
        {
            if (ModelState.IsValid)
            {
                db.CHI_TIET_DON_HANG.Add(cHI_TIET_DON_HANG);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MaDH = new SelectList(db.DON_HANG, "MaDH", "TenDH", cHI_TIET_DON_HANG.MaDH);
            ViewBag.MaSP = new SelectList(db.SAN_PHAM, "MaSP", "TenSP", cHI_TIET_DON_HANG.MaSP);
            return View(cHI_TIET_DON_HANG);
        }

        // GET: ChiTietDonHang/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CHI_TIET_DON_HANG cHI_TIET_DON_HANG = db.CHI_TIET_DON_HANG.Find(id);
            if (cHI_TIET_DON_HANG == null)
            {
                return HttpNotFound();
            }
            ViewBag.MaDH = new SelectList(db.DON_HANG, "MaDH", "TenDH", cHI_TIET_DON_HANG.MaDH);
            ViewBag.MaSP = new SelectList(db.SAN_PHAM, "MaSP", "TenSP", cHI_TIET_DON_HANG.MaSP);
            return View(cHI_TIET_DON_HANG);
        }

        // POST: ChiTietDonHang/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaDH,MaSP,SoLuong")] CHI_TIET_DON_HANG cHI_TIET_DON_HANG)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cHI_TIET_DON_HANG).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MaDH = new SelectList(db.DON_HANG, "MaDH", "TenDH", cHI_TIET_DON_HANG.MaDH);
            ViewBag.MaSP = new SelectList(db.SAN_PHAM, "MaSP", "TenSP", cHI_TIET_DON_HANG.MaSP);
            return View(cHI_TIET_DON_HANG);
        }

        // GET: ChiTietDonHang/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CHI_TIET_DON_HANG cHI_TIET_DON_HANG = db.CHI_TIET_DON_HANG.Find(id);
            if (cHI_TIET_DON_HANG == null)
            {
                return HttpNotFound();
            }
            return View(cHI_TIET_DON_HANG);
        }

        // POST: ChiTietDonHang/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CHI_TIET_DON_HANG cHI_TIET_DON_HANG = db.CHI_TIET_DON_HANG.Find(id);
            db.CHI_TIET_DON_HANG.Remove(cHI_TIET_DON_HANG);
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
