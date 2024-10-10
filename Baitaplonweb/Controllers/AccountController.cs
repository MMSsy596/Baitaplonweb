using Baitaplonweb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using static Baitaplonweb.Controllers.HomeController;

namespace Baitaplonweb.Controllers
{
    public class AccountController : Controller
    {
        // GET: Accout
        public ActionResult Login()
        {
            return View();
        }

        public AccountViewModel AcountList()
        {
            QuanLyKhoaHocEntities1 db = new QuanLyKhoaHocEntities1();
            List<account> Danhsach = db.account.ToList();

            return new AccountViewModel
            {
                accounts = Danhsach,
            
            };
        }

        // POST: Account/Login
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                using (var db = new QuanLyKhoaHocEntities1()) // Thay 'YourDbContext' bằng tên DbContext của bạn
                {
                    var user = db.account
                                 .FirstOrDefault(u => u.username == model.Username
                                                   && u.password == model.Password);
                    if (user != null)
                    {
                        // Tạo Authentication Cookie
                        FormsAuthentication.SetAuthCookie(user.username, false);

                        // Chuyển hướng dựa trên vai trò
                        if (user.role.Trim() == "1")
                        {
                            return RedirectToAction("Index", "Admin");
                        }
                        else
                        {
                            //return RedirectToAction("Index", "Home");

                            return RedirectToAction("Logined", "User");
                        }
                    }
                    else
                    {
                        ModelState.AddModelError("", "Tên đăng nhập hoặc mật khẩu không đúng.");
                    }
                }
            }
            return View(model);
        }

        // GET: Account/Logout
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login", "Account");
        }

        public class AccountViewModel
        {
            public List<account> accounts { get; set; }
    
        }


        public ActionResult Register()
        {
            return View();
        }
    }
}