using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace K22CNT2_VuAnhDuong_2210900017_.Areas.AdminVAD.Controllers
{
    public class VADDashboardController : Controller
    {
        // GET: AdminVAD/VADDashboard
        public ActionResult Index()
        {
            if (Session["IsAdmin"] == null || !(bool)Session["IsAdmin"])
            {
                return RedirectToAction("Login", "Account", new { area = "AdminVAD" }); // Chuyển hướng về trang đăng nhập nếu không có session admin
            }

            return View();
        }
    }
}