using K22CNT2_VuAnhDuong_2210900017_.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace K22CNT2_VuAnhDuong_2210900017_.Areas.AdminVAD.Controllers
{
    public class AccountController : Controller
    {
        // GET: AdminVAD/Account/Login
        cuahangdoannhanhEntities db = new cuahangdoannhanhEntities();
        public ActionResult Login()
        {
            return View();
        }

        // POST: AdminVAD/Account/Login
        [HttpPost]
  
        public ActionResult Login(string username, string password)
        {
            // Kiểm tra xem user có tồn tại trong cơ sở dữ liệu với tên đăng nhập và mật khẩu
            var user = db.QUAN_TRI.FirstOrDefault(u => u.Tai_khoan == username);

            if (user != null && user.Mat_khau == password)
            {
                // Nếu tên đăng nhập và mật khẩu đúng, lưu session và chuyển hướng đến trang quản trị
                Session["IsAdmin"] = true;
                return RedirectToAction("Index", "VADDashboard", new { area = "AdminVAD" });
            }
            else
            {
                // Nếu tên đăng nhập hoặc mật khẩu không đúng
                ViewBag.ErrorMessage = "Tên đăng nhập hoặc mật khẩu không đúng!";
                return View();
            }
        }
        public ActionResult Logout()
        {
            // Xóa session IsAdmin
            Session["IsAdmin"] = null;

            // Hoặc nếu bạn muốn xóa toàn bộ session
            // Session.Clear();

            // Chuyển hướng về trang chủ hoặc trang đăng nhập
            return RedirectToAction("Index", "Home", new { area = "" });
        }

    }
}