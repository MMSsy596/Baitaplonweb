using Baitaplonweb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using static Baitaplonweb.Controllers.AccountController;

namespace Baitaplonweb.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        public ActionResult Index()
        {
            using (QuanLyKhoaHocEntities1 db = new QuanLyKhoaHocEntities1())
            {
                ViewBag.Accounts = db.account.ToList();
                ViewBag.KhoaHocs = db.KhoaHoc.ToList();
                ViewBag.GiaoViens = db.GiaoVien.ToList();
                ViewBag.NguoiDangKies = db.NguoiDangKy.ToList();
                ViewBag.DanhSachDangKi = db.DangKyKhoaHoc.ToList();
            }

            return View();
        }
        public ActionResult Edit(string username)
        {
            using (var db = new QuanLyKhoaHocEntities1())
            {
                var account = db.account.Find(username);
                if (account == null)
                {
                    return HttpNotFound();
                }
                return View(account);
            }
        }

        [HttpPost]
        public ActionResult Edit(account account)
        {
            if (ModelState.IsValid)
            {
                using (var db = new QuanLyKhoaHocEntities1())
                {
                    db.Entry(account).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                }
                return RedirectToAction("Index");
            }
            return View(account);
        }

        public ActionResult Delete(string  username)
        {
            using (var db = new QuanLyKhoaHocEntities1())
            {
                var account = db.account.Find(username);
                if (account == null)
                {
                    return HttpNotFound();
                }
                return View(account);
            }
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(string username)
        {
            using (var db = new QuanLyKhoaHocEntities1())
            {
                var account = db.account.Find(username);
                db.account.Remove(account);
                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        // GET: Admin/DeleteGiaoVien/5
        public ActionResult DeleteGiaoVien(int id)
        {
            using (var db = new QuanLyKhoaHocEntities1())
            {
                var giaovien = db.GiaoVien.Find(id);
                if (giaovien == null)
                {
                    return HttpNotFound();
                }
                return View(giaovien);
            }
        }

        [HttpPost, ActionName("DeleteGiaoVien")]
        public ActionResult DeleteGiaoVienConfirmed(int id)
        {
            using (var db = new QuanLyKhoaHocEntities1())
            {
                var giaovien = db.GiaoVien.Find(id);
                db.GiaoVien.Remove(giaovien);
                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }



        public ActionResult EditGiaoVien(int id)
        {
            using (var db = new QuanLyKhoaHocEntities1())
            {
                var giaovien = db.GiaoVien.Find(id);
                if (giaovien == null)
                {
                    return HttpNotFound();
                }
                return View(giaovien);
            }
        }

        [HttpPost]
        public ActionResult EditGiaoVien(GiaoVien giaovien)
        {
            if (ModelState.IsValid)
            {
                using (var db = new QuanLyKhoaHocEntities1())
                {
                    db.Entry(giaovien).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                }
                return RedirectToAction("Index");
            }
            return View(giaovien);
        }




        public ActionResult EditKhoaHoc(int id)
        {
            using (var db = new QuanLyKhoaHocEntities1())
            {
                var khoahoc = db.KhoaHoc.Find(id);
                if (khoahoc == null)
                {
                    return HttpNotFound();
                }
                return View(khoahoc);
            }
        }

        [HttpPost]
        public ActionResult EditKhoaHoc(KhoaHoc khoahoc)
        {
            if (ModelState.IsValid)
            {
                using (var db = new QuanLyKhoaHocEntities1())
                {
                    db.Entry(khoahoc).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                }
                return RedirectToAction("Index");
            }
            return View(khoahoc);
        }

        public ActionResult DeleteKhoaHoc(int id)
        {
            using (var db = new QuanLyKhoaHocEntities1())
            {
                var khoahoc = db.KhoaHoc.Find(id);
                if (khoahoc == null)
                {
                    return HttpNotFound();
                }
                return View(khoahoc);
            }
        }

        [HttpPost, ActionName("DeleteKhoaHoc")]
        public ActionResult DeleteKhoaHocConfirmed(int id)
        {
            using (var db = new QuanLyKhoaHocEntities1())
            {
                var khoahoc = db.KhoaHoc.Find(id);
                db.KhoaHoc.Remove(khoahoc);
                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }


        public ActionResult EditNguoiDangKy(int id)
        {
            using (var db = new QuanLyKhoaHocEntities1())
            {
                var nguoidangky = db.NguoiDangKy.Find(id);
                if (nguoidangky == null)
                {
                    return HttpNotFound();
                }
                return View(nguoidangky);
            }
        }

        [HttpPost]
        public ActionResult EditNguoiDangKy(NguoiDangKy nguoidangky)
        {
            if (ModelState.IsValid)
            {
                using (var db = new QuanLyKhoaHocEntities1())
                {
                    db.Entry(nguoidangky).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                }
                return RedirectToAction("Index");
            }
            return View(nguoidangky);
        }

        public ActionResult DeleteNguoiDangKy(int id)
        {
            using (var db = new QuanLyKhoaHocEntities1())
            {
                var nguoidangky = db.NguoiDangKy.Find(id);
                if (nguoidangky == null)
                {
                    return HttpNotFound();
                }
                return View(nguoidangky);
            }
        }

        [HttpPost, ActionName("DeleteNguoiDangKy")]
        public ActionResult DeleteNguoiDangKyConfirmed(int id)
        {
            using (var db = new QuanLyKhoaHocEntities1())
            {
                var nguoidangky = db.NguoiDangKy.Find(id);
                db.NguoiDangKy.Remove(nguoidangky);
                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }

    }
}