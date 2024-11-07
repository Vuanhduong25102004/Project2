﻿using K22CNT2_VuAnhDuong_2210900017_.Models;
using K22CNT2_VuAnhDuong_2210900017_.ModelViews;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace K22CNT2_VuAnhDuong_2210900017_.Controllers
{
    public class CartController : Controller
    {
        cuahangdoannhanhEntities dt = new cuahangdoannhanhEntities();
        // GET: Cart
        public ActionResult AddToCart(int id, string name, string image, float price, int qty = 1)
        {
            // Lấy giỏ hàng hiện tại từ Session
            var cart = Session["Cart"] as List<CartItem> ?? new List<CartItem>();

            // Kiểm tra xem sản phẩm đã có trong giỏ hàng chưa
            var existingItem = cart.FirstOrDefault(p => p.Id == id);
            if (existingItem != null)
            {
                // Nếu có rồi, tăng số lượng
                existingItem.Qty += qty;
                existingItem.Total = existingItem.Qty * existingItem.Price;
            }
            else
            {
                // Nếu chưa có, thêm mới sản phẩm vào giỏ hàng
                var newItem = new CartItem
                {
                    Id = id,
                    Name = name,
                    Image = image,
                    Price = price,
                    Qty = qty,
                    Total = price * qty
                };
                cart.Add(newItem);
            }

            // Lưu lại giỏ hàng vào Session
            Session["Cart"] = cart;

            return RedirectToAction("Index"); // Điều hướng đến trang hiển thị giỏ hàng
        }

        // Hành động hiển thị giỏ hàng
        public ActionResult Index()
        {
            var cart = Session["Cart"] as List<CartItem> ?? new List<CartItem>();
            return View(cart); // Truyền giỏ hàng vào View để hiển thị
        }

        // Hành động xóa sản phẩm khỏi giỏ hàng
        public ActionResult RemoveFromCart(int id)
        {
            var cart = Session["Cart"] as List<CartItem> ?? new List<CartItem>();

            var item = cart.FirstOrDefault(p => p.Id == id);
            if (item != null)
            {
                cart.Remove(item);
            }

            // Cập nhật lại Session giỏ hàng
            Session["Cart"] = cart;

            return RedirectToAction("Index");
        }
        // Thanh toán
        public ActionResult ThongTinThanhToan()
        {
            var cart = Session["Cart"] as List<CartItem> ?? new List<CartItem>();
            return View(cart);
        }
        public ActionResult ThanhToan(FormCollection form, int? sdt)
        {
            // Lấy thông tin khách hàng
            var ten_kh = form["Ten_KH"];
            var dia_chi = form["Dia_chi"];
            var sdt_kh = form["SDT"];
            // Tạo đơn hàng (Bảng DON_HANG)
            DON_HANG don_hang = new DON_HANG();
            DateTime dt = DateTime.Now;
            don_hang.MaDH = GetNextOrderId();
            don_hang.Ten_KH = ten_kh;
            don_hang.Dia_chi = dia_chi;
            don_hang.SDT = sdt;
            don_hang.Ngay_dat = dt.ToString("yyyy-MM-dd");


            using (var db = new cuahangdoannhanhEntities())
            {
                db.DON_HANG.Add(don_hang);
                db.SaveChanges();
            }

            return Redirect("/");


        }
        private int GetNextOrderId()
        {
            using (var db = new cuahangdoannhanhEntities())
            {
                return db.DON_HANG.Any() ? db.DON_HANG.Max(o => o.MaDH) + 1 : 1;
            }
        }
    }
}