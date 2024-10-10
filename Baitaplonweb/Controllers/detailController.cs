using Baitaplonweb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Baitaplonweb.Controllers
{
    public class detailController : Controller
    {
        // GET: detail
        public ActionResult Detail()
        {
            QuanLyKhoaHocEntities1 db = new QuanLyKhoaHocEntities1();
            List<GiaoVien> Danhsach = db.GiaoVien.ToList();
            return View(Danhsach);
        }
    }
}