using K22CNT2_VuAnhDuong_2210900017_.Models;
using System;
using System.Linq;
using System.Web.Mvc;
using System.Web.SessionState;

namespace K22CNT2_VuAnhDuong_2210900017_.Controllers
{
    public class VADKhachHangController : Controller
    {
        cuahangdoannhanhEntities db = new cuahangdoannhanhEntities();   
        // GET: VADKhachHang
        public ActionResult Index()
        {
            return View();
        }
        // action: dang ky
        public ActionResult dang_ky()
        {
            return View(); 
        }
        // post dang ky
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult dang_ky(FormCollection form)
        {
            try
            {
                // lay thong tin dang ky len form
                var email = form["Email"];
                var matkhau = form["MatKhau"];
                var hotenkh = form["HoTenKhachHang"];
                var dienthoai = form["DienThoai"];
                var diachi = form["DiaChi"];

                var kh = new KHACH_HANG();
                DateTime dt = DateTime.Now;
                kh.MaKH = GetNextOrderId();
                kh.Email = email;
                kh.Mat_Khau = matkhau;
                kh.Ten_KH = hotenkh;
                kh.SDT = dienthoai;
                kh.Dia_chi = diachi;
                kh.NgayDangKy = dt;
                kh.TrangThai = 0;

                db.KHACH_HANG.Add(kh);
                db.SaveChanges();

                return Redirect("/");
            }
            catch (Exception ex) 
            {
                Console.WriteLine(ex.Message);
            }

            return View();
        }

        private int GetNextOrderId()
        {
            using (var db = new cuahangdoannhanhEntities())
            {

                return db.KHACH_HANG.Any() ? db.KHACH_HANG.Max(o => o.MaKH) + 1 : 1;
            }
        }

        // get: dang nhap
        public ActionResult dang_nhap()
        {
            return View();
        }
        // post: dang nhap
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult dang_nhap(FormCollection form)
        {
            //lay thong tin tren form
            var email = form["Email"];
            var matkhau = form["MatKhau"];
            var check = db.KHACH_HANG.Where(x => x.Email.Equals(email) && x.Mat_Khau.Equals(matkhau)).FirstOrDefault();
            if (check != null)
            {
                // luu thong tin dang nhap vao session
                Session["DangNhap"] = check;
                return Redirect("/");
            }
            else
            {
                ViewBag.error = "Lỗi đăng nhập";
                return View();
            }
     
        }
        public ActionResult dang_xuat()
        {
            Session["DangNhap"] = null;
            Session.Abandon();
        
            return Redirect("/");
        }

    }
}