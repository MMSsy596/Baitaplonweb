using Baitaplonweb.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace Baitaplonweb.Controllers
{
    public class HomeController : Controller
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
        private HomeViewModel GetHomeViewModel()
        {
            using (QuanLyKhoaHocEntities1 db = new QuanLyKhoaHocEntities1())
            {
                var danhSachKhoaHoc = db.KhoaHoc.ToList();
                List<GiaoVien> danhSachGiaoVien = db.GiaoVien.AsNoTracking().ToList();
                var danhSachNguoiDangKy = db.NguoiDangKy.ToList();
                List<account> accounts = db.account.ToList();
                return new HomeViewModel
                {
                    DanhSachKhoaHoc = danhSachKhoaHoc,
                    DanhSachGiaoVien = danhSachGiaoVien,
                    DanhSachNguoiDangKy = danhSachNguoiDangKy,
                    accounts = accounts

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
            return View();
        }

        // ViewModel mới cho Home
        public class HomeViewModel
        {
            public List<KhoaHoc> DanhSachKhoaHoc { get; set; }
            public List<GiaoVien> DanhSachGiaoVien { get; set; }
            public List<NguoiDangKy> DanhSachNguoiDangKy { get; set; } // Thêm danh sách người đăng ký
            public List<account> accounts { get; set; }
        }
    }
}
