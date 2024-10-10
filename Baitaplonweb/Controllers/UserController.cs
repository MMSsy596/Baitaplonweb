using Baitaplonweb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Baitaplonweb.Controllers
{
    public class UserController : Controller
    {
        // Phương thức chính để hiển thị trang chính
        public ActionResult Index()
        {
            var viewModel = GetHomeViewModel();

            // Xử lý tìm kiếm khóa học
            if (Request.HttpMethod == "POST")
            {
                var timKiem = Request.Form["TimKiem"];
                if (!string.IsNullOrEmpty(timKiem))
                {
                    return SearchKhoaHoc(timKiem);
                }
            }

            return View(viewModel);
        }

        // Tìm kiếm khóa học theo tên
        public ActionResult SearchKhoaHoc(string timKiem) // Thay đổi từ private sang public
        {
            using (QuanLyKhoaHocEntities1 db = new QuanLyKhoaHocEntities1())
            {
                var khoaHocTimThay = db.KhoaHoc.FirstOrDefault(kh => kh.TenKhoaHoc.Contains(timKiem));

                if (khoaHocTimThay != null)
                {
                    // Điều hướng đến trang chi tiết khóa học
                    return RedirectToAction("detail", "detail", new { id = khoaHocTimThay.KhoaHocID });
                }
                else
                {
                    // Thêm thông báo khóa học không tồn tại
                    ViewBag.ThongBao = "Khóa học không tồn tại.";
                    return View(GetHomeViewModel());
                }
            }
        }

        // Lấy danh sách khóa học, giảng viên và người đăng ký
        private UserModelView GetHomeViewModel()
        {
            using (QuanLyKhoaHocEntities1 db = new QuanLyKhoaHocEntities1())
            {
                var danhSachKhoaHoc = db.KhoaHoc.ToList();
                List<GiaoVien> danhSachGiaoVien = db.GiaoVien.AsNoTracking().ToList();
                var danhSachNguoiDangKy = db.NguoiDangKy.ToList();

                return new UserModelView
                {
                    DanhSachKhoaHoc = danhSachKhoaHoc,
                    DanhSachGiaoVien = danhSachGiaoVien,
                    DanhSachNguoiDangKy = danhSachNguoiDangKy
                };
            }
        }

        // Phương thức để hiển thị chi tiết khóa học
        public ActionResult Detail(int id)
        {
            using (QuanLyKhoaHocEntities1 db = new QuanLyKhoaHocEntities1())
            {
                var khoaHoc = db.KhoaHoc.FirstOrDefault(kh => kh.KhoaHocID == id);
                if (khoaHoc == null)
                {
                    return HttpNotFound(); // Nếu không tìm thấy khóa học
                }

                return View(khoaHoc); // Truyền thông tin khóa học vào view
            }
        }

        public ActionResult logined()
        {
            var viewModel = GetHomeViewModel();

            return View(viewModel);
        }

        // ViewModel mới cho Home
        public class UserModelView
        {
            public List<KhoaHoc> DanhSachKhoaHoc { get; set; }
            public List<GiaoVien> DanhSachGiaoVien { get; set; }
            public List<NguoiDangKy> DanhSachNguoiDangKy { get; set; } // Thêm danh sách người đăng ký
        }
    }
}