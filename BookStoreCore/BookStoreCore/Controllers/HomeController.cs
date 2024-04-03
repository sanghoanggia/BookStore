using BookStoreCore.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using X.PagedList;
using System.Linq;

namespace BookStoreCore.Controllers
{
    public class HomeController : Controller
    {
        QlbookstoreContext db = new QlbookstoreContext();
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }


         public IActionResult Index(int? page)
	{
		int pageSize = 5;
		int pageNumber = page ?? 1;

		// Tính tổng số lượng sách đã bán cho mỗi cuốn sách
		var sáchBánChạy = db.Saches
							.Select(s => new
							{
								Sach = s,
								SoLuongBan = s.Chitietdonhangs.Sum(ct => ct.Soluong ?? 0) // Tính tổng số lượng sách bán
							})
							.OrderByDescending(x => x.SoLuongBan) // Sắp xếp giảm dần theo số lượng sách bán
							.Select(x => x.Sach) // Chọn lại chỉ sách				
							.AsNoTracking();

		var lst = sáchBánChạy.ToPagedList(pageNumber, pageSize); // Phân trang cho danh sách sách bán chạy

		return View(lst);
	}




	    public IActionResult SachTheoChuDe(int machude, int? page)
        {
            int pageSize = 6;
            int pageNumber = page == null ? 1 : page.Value;
            var listsanpham = db.Saches.AsNoTracking().Where(x => x.MaCd == machude).OrderBy(x => x.Tensach);
            PagedList<Sach> lst = new PagedList<Sach>(listsanpham, pageNumber, pageSize);
            ViewBag.machude = machude;
            return View(lst);

        }

		public IActionResult NhaXuatBan(int maNXB, int? page)
		{
			int pageSize = 6;
			int pageNumber = page == null ? 1 : page.Value;
			var listsanpham = db.Saches.AsNoTracking().Where(x => x.MaNxb == maNXB).OrderBy(x => x.Tensach);
			PagedList<Sach> lst = new PagedList<Sach>(listsanpham, pageNumber, pageSize);
			ViewBag.maNXB = maNXB;
			return View(lst);

		}


		public IActionResult ChiTietSach(int maSach)
		{
			var sanPham = db.Saches.SingleOrDefault(x => x.Masach == maSach);
			ViewBag.maSach = maSach ;
			return View(sanPham);
		}



		public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }


        [Route("AddAddresx")]
        [HttpGet]
        public IActionResult AddAddresx(int maKhachHang)

        {
            String usernamee = HttpContext.Session.GetString("UserName");
            var khachhang = db.Khachhangs.SingleOrDefault(x => x.TaiKhoan == usernamee);
            maKhachHang = khachhang.MaKh;
            /*		 usernamee = HttpContext.Session.GetString("UserName");*/
            /*		Khachhang khachhang = db.Khachhangs.SingleOrDefault(x=>x.TaiKhoan.ToString() == usernamee);*/
            Khachhang khachhang1 = db.Khachhangs.SingleOrDefault(x => x.MaKh == maKhachHang);

            return View(khachhang1);
        }

        [Route("AddAddresx")]
        [ValidateAntiForgeryToken]
        [HttpPost]
        public IActionResult AddAddresx(Khachhang khachhang)
        {
            if (ModelState.IsValid)
            {
                db.Khachhangs.Update(khachhang);
                db.SaveChanges();
                return RedirectToAction("Index","Cart");
            }
            return View(khachhang);
        }

    }
}
