using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using K22CNT2_VuAnhDuong_2210900017_.Models;
using K22CNT2_VuAnhDuong_2210900017_.ModelViews;

namespace K22CNT2_VuAnhDuong_2210900017_.Areas.AdminVAD.Controllers
{
    public class VADDonHangController : Controller
    {
        private cuahangdoannhanhEntities db = new cuahangdoannhanhEntities();

        // GET: AdminVAD/VADDonHang
        public ActionResult Index()
        {
            var dON_HANG = db.DON_HANG.Include(d => d.KHACH_HANG);
            return View(dON_HANG.ToList());
        }

        // GET: AdminVAD/VADDonHang/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DON_HANG dON_HANG = db.DON_HANG.Find(id);
            if (dON_HANG == null)
            {
                return HttpNotFound();
            }
            return View(dON_HANG);
        }

        // GET: AdminVAD/VADDonHang/Create
        public ActionResult Create()
        {
            ViewBag.MaKH = new SelectList(db.KHACH_HANG, "MaKH", "Ten_KH");
            return View();
        }

        // POST: AdminVAD/VADDonHang/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaDH,TenDH,Ngay_dat,MaKH,Ten_KH,SDT,Dia_chi,Email,TrangThai")] DON_HANG dON_HANG)
        {
            if (ModelState.IsValid)
            {
                db.DON_HANG.Add(dON_HANG);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MaKH = new SelectList(db.KHACH_HANG, "MaKH", "Ten_KH", dON_HANG.MaKH);
            return View(dON_HANG);
        }

        // GET: AdminVAD/VADDonHang/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DON_HANG dON_HANG = db.DON_HANG.Find(id);
            if (dON_HANG == null)
            {
                return HttpNotFound();
            }
            ViewBag.MaKH = new SelectList(db.KHACH_HANG, "MaKH", "Ten_KH", dON_HANG.MaKH);
            // thong tin chi tiet don hang
            var donHangChiTiet = (from ct in db.CHI_TIET_DON_HANG
                                 join sp in db.SAN_PHAM on ct.MaSP equals sp.MaSP 
                                 where ct.MaDH == id
                                 select new DH_Chitiet
                                 {
                                     Id = ct.MaSP,
                                     Name = sp.TenSP,
                                     Image = sp.Image,
                                     Price = ct.DonGia,
                                     Qty = ct.SoLuong,
                                     Total = ct.ThanhTien,
                                 }).ToList();
            ViewBag.donhangChiTiet = donHangChiTiet;
            return View(dON_HANG);
        }

        // POST: AdminVAD/VADDonHang/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaDH,TenDH,Ngay_dat,MaKH,Ten_KH,SDT,Dia_chi,Email,TrangThai")] DON_HANG dON_HANG)
        {
            if (ModelState.IsValid)
            {
                var donhang = db.DON_HANG.FirstOrDefault(x=>x.MaDH == dON_HANG.MaDH);
                donhang.TrangThai = dON_HANG.TrangThai;

                db.Entry(donhang).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MaKH = new SelectList(db.KHACH_HANG, "MaKH", "Ten_KH", dON_HANG.MaKH);
            return View(dON_HANG);
        }

        // GET: AdminVAD/VADDonHang/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DON_HANG dON_HANG = db.DON_HANG.Find(id);
            if (dON_HANG == null)
            {
                return HttpNotFound();
            }
            return View(dON_HANG);
        }

        // POST: AdminVAD/VADDonHang/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            // Bắt đầu một giao dịch để đảm bảo tính toàn vẹn
            using (var transaction = db.Database.BeginTransaction())
            {
                try
                {
                    // Xóa các bản ghi chi tiết đơn hàng liên quan đến đơn hàng cần xóa
                    var chiTietDonHangs = db.CHI_TIET_DON_HANG.Where(ct => ct.MaDH == id).ToList();
                    db.CHI_TIET_DON_HANG.RemoveRange(chiTietDonHangs);

                    // Tìm và xóa bản ghi đơn hàng
                    DON_HANG dON_HANG = db.DON_HANG.Find(id);
                    db.DON_HANG.Remove(dON_HANG);

                    // Lưu thay đổi vào cơ sở dữ liệu
                    db.SaveChanges();

                    // Xác nhận giao dịch
                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    // Hủy giao dịch nếu có lỗi
                    transaction.Rollback();
                    ModelState.AddModelError("", "Không thể xóa đơn hàng do lỗi: " + ex.Message);
                    return View("Delete");
                }
            }

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
