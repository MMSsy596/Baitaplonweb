using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Baitaplonweb.Models
{
    public class AccountViewModel
    {
        public List<account> accounts { get; set; }
        public List<KhoaHoc> khoaHocs1 { get; set; }
        public List<GiaoVien> giaoViens1 { get; set; }
        public List<NguoiDangKy> nguoiDangKies1 { get; set; }
    }
}