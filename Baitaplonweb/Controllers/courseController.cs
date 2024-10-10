using Baitaplonweb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Baitaplonweb.Controllers
{
    public class courseController : Controller
    {
        // GET: course
        public ActionResult course()
        {
            QuanLyKhoaHocEntities1 db = new QuanLyKhoaHocEntities1();
                List<KhoaHoc> Danhsach = db.KhoaHoc.ToList();

            return View(Danhsach);
        }
    }
}