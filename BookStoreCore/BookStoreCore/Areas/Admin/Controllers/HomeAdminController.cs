using BookStoreCore.Authentication;
using BookStoreCore.Models;
using BookStoreCore.AuthenticationAdmin;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Drawing;
using X.PagedList;

namespace BookStoreCore.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("admin")]
    public class HomeAdminController : Controller
    {
        QlbookstoreContext db = new QlbookstoreContext();
        [Route("")]
        [Route("Index")]

        [AuthenticationAdmin]
        public IActionResult Index()
        {
            return View();
        }

        [AuthenticationAdmin]
        [Route("danhmucsanpham")]
        public IActionResult DanhMucSanPham(int? page)
        {
            int pageSize = 8;//số sản phẩm trên 1 trang
            int pageNumber = page == null || page < 0 ? 1 : page.Value;
            var lstsanpham = db.Saches.AsNoTracking().OrderBy(x => x.Tensach);
            ViewBag.tenchude = db.Chudes.AsNoTracking().ToList();
            ViewBag.tennxb = db.Nhaxuatbans.AsNoTracking().ToList();

            PagedList<Sach> pagelst = new PagedList<Sach>(lstsanpham, pageNumber, pageSize);
            return View(pagelst);
        }
        [Route("ThemSachMoi")]
        [HttpGet]
        public IActionResult ThemSachMoi()
        {
            var maCdList = db.Chudes.Select(cd => new SelectListItem
            {
                Value = cd.MaCd.ToString(),
                Text = cd.TenChuDe // hoặc có thể sử dụng trường khác của bảng chủ đề để hiển thị
            }).ToList();

            // Gán danh sách mã chủ đề vào ViewBag
            ViewBag.MaCd = maCdList;

            var maNxbList = db.Nhaxuatbans.Select(cd => new SelectListItem
            {
                Value = cd.MaNxb.ToString(),
                Text = cd.TenNxb // hoặc có thể sử dụng trường khác của bảng chủ đề để hiển thị
            }).ToList();

            // Gán danh sách mã chủ đề vào ViewBag
            ViewBag.MaNxb = maNxbList;

            return View();
        }
        [Route("ThemSachMoi")]
        [ValidateAntiForgeryToken]
        [HttpPost]
        public IActionResult ThemSachMoi(Sach sach)
        {
            if (ModelState.IsValid)
            {
                db.Saches.Add(sach);
                db.SaveChanges();
                return RedirectToAction("DanhMucSanPham");
            }
            return View(sach);
        }



        [Route("SuaSach")]
        [HttpGet]
        public IActionResult SuaSach(int maSach)
        {
            Sach sanpham = db.Saches.Find(maSach);

            var maCdList = db.Chudes.Select(cd => new SelectListItem
            {
                Value = cd.MaCd.ToString(),
                Text = cd.TenChuDe // hoặc có thể sử dụng trường khác của bảng chủ đề để hiển thị
            }).ToList();

            // Gán danh sách mã chủ đề vào ViewBag
            ViewBag.MaCd = maCdList;

            var maNxbList = db.Nhaxuatbans.Select(cd => new SelectListItem
            {
                Value = cd.MaNxb.ToString(),
                Text = cd.TenNxb // hoặc có thể sử dụng trường khác của bảng chủ đề để hiển thị
            }).ToList();

            // Gán danh sách mã chủ đề vào ViewBag
            ViewBag.MaNxb = maNxbList;
            return View(sanpham);
        }

        [Route("SuaSach")]
        [ValidateAntiForgeryToken]
        [HttpPost]
        public IActionResult SuaSach(Sach sach)
        {
            if (ModelState.IsValid)
            {
                db.Saches.Update(sach);
                db.SaveChanges();
                return RedirectToAction("DanhMucSanPham");
            }
            return View(sach);
        }


        [Route("XoaSach")]
        [HttpGet]
        public IActionResult XoaSach(int maSach)
        {
            var sach = db.Saches.Find(maSach); // Tìm sách cần xóa từ mã sách
            if (sach == null)
            {
                return NotFound(); // Nếu không tìm thấy sách, trả về trang 404.
            }
            var tenChuDe = db.Chudes.SingleOrDefault(x => x.MaCd == sach.MaCd)?.TenChuDe;
            ViewBag.tenchude = tenChuDe;
            var tenNXB = db.Nhaxuatbans.SingleOrDefault(x => x.MaNxb == sach.MaCd)?.TenNxb;
            ViewBag.tennhaxuatban = tenNXB;
            return View(sach); // Trả về view để xác nhận việc xóa sách
        }

        [Route("XoaSach")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult XacNhanXoaSach(int maSach)
        {
            var sach = db.Saches.FirstOrDefault(x => x.Masach == maSach);
            if (sach == null)
            {
                return NotFound();
            }

            db.Saches.Remove(sach);
            db.SaveChanges();
            return RedirectToAction("DanhMucSanPham"); 
        }

        [Route("ChitietSanPham")]
        [HttpGet]
        public IActionResult ChitietSanPham(int maSach)
        {
            Sach sach = db.Saches.Find(maSach);
            var tenChuDe = db.Chudes.SingleOrDefault(x => x.MaCd == sach.MaCd)?.TenChuDe;
            ViewBag.tenchude = tenChuDe;
            var tenNXB = db.Nhaxuatbans.SingleOrDefault(x => x.MaNxb == sach.MaCd)?.TenNxb;
            ViewBag.tennhaxuatban = tenNXB;
            return View(sach);
        }


     }
}
