using BookStoreCore.Models.API;
using BookStoreCore.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using HienlthOnline.Helpers; // Thêm namespace chứa phương thức mở rộng Get

namespace BookkStore.Controllers
{
	public class CartController : Controller
	{
		QlbookstoreContext db = new QlbookstoreContext();
		private readonly ILogger<CartController> _logger;

		public CartController(ILogger<CartController> logger)
		{
			_logger = logger;
			
		}

		public List<CartItem> Carts
		{
			get
			{
				var data = HttpContext.Session.Get<List<CartItem>>("GioHang");
				if (data == null)
				{
					data = new List<CartItem>();
				}
				return data;
			}
		}
		public IActionResult Index()
		{
			return View(Carts);
		}

		public IActionResult AddToCart(int id,int SoLuong)
		{
			var myCart = Carts;
			var item = myCart.SingleOrDefault(x => x.MaSach == id);
			if (item == null) {
				var sachs = db.Saches.SingleOrDefault(x => x.Masach == id);
				item = new CartItem
				{

					MaSach = id,
					TenSach = sachs.Tensach,
					DonGia = sachs.Giaban.Value,
					SoLuong = SoLuong,
					Anh= sachs.Anhbia
				};
				myCart.Add(item);

			}
			else
			{
				item.SoLuong+= SoLuong;
			}
			HttpContext.Session.Set("GioHang",myCart);
			return RedirectToAction("Index");
		}


        public IActionResult ChiTietOrder(int id)
        {
            var item = Carts.SingleOrDefault(x => x.MaSach == id);
            if (item == null)
            {
                return NotFound(); // Trả về lỗi 404 nếu không tìm thấy mặt hàng
            }
            return View(item);
        }
        [Route("XoaSanPham")]
/*        [HttpPost]*/
        public IActionResult XoaSanPham(int maSach)
        {
            TempData["deleteMessage"] = ""; // Xóa thông báo cũ (nếu có)

            var myCart = Carts;
            var item = myCart.Find(x=>x.MaSach==maSach);
            myCart.Remove(item);
            HttpContext.Session.Set("GioHang", myCart);

            /*	HttpContext.Session.Set("GioHang", Carts);*/
            TempData["deleteMessage"] = "Xóa sản phẩm thành công.";

            return RedirectToAction("Index");
        }
        [HttpPost]
        public IActionResult UpdateCartItemQuantity(int maSach, int SoLuong)
        {
            var myCart = Carts;
            var item = myCart.SingleOrDefault(x => x.MaSach == maSach);
            if (item != null)
            {
                // Cập nhật số lượng của mặt hàng
                item.SoLuong = SoLuong;
                // Cập nhật lại session
                HttpContext.Session.Set("GioHang", myCart);
            }
            return RedirectToAction("Index");
        }

/*
        [Route("AddAddres")]
		[HttpGet]
		public IActionResult AddAddres(int maKhachHang)
			
		{
           String usernamee = HttpContext.Session.GetString("UserName");
			var khachhang = db.Khachhangs.SingleOrDefault(x => x.TaiKhoan == usernamee);
			maKhachHang = khachhang.MaKh;
            *//*		 usernamee = HttpContext.Session.GetString("UserName");*/
            /*		Khachhang khachhang = db.Khachhangs.SingleOrDefault(x=>x.TaiKhoan.ToString() == usernamee);*//*
            Khachhang khachhang1 = db.Khachhangs.SingleOrDefault(x => x.MaKh== maKhachHang);

            return View(khachhang1);
		}	
*/
	/*	[Route("AddAddres")]
		[ValidateAntiForgeryToken]
		[HttpPost]
		public IActionResult AddAddres(Khachhang khachhang)
		{
			if (ModelState.IsValid)
			{
				db.Khachhangs.Update(khachhang);
				db.SaveChanges();
				return RedirectToAction("Index");
			}
			return View(khachhang);
		}
*/

		[HttpPost]
        [Route("XoaHetGioHang")]
        public IActionResult XoaHetGioHang()
        {
            HttpContext.Session.Remove("GioHang"); // Xóa dữ liệu giỏ hàng từ Session	
            return RedirectToAction("Index"); // Chuyển hướng đến trang Index để hiển thị giỏ hàng trống
        }
     
        /// <returns></returns>
        public IActionResult Checkout()
        {
			 TempData["CheckOut"] = "";
            if (HttpContext.Session.Get("UserName") == null)
            {
                return RedirectToAction("Login","Access");
            }
            else{
				var userName = HttpContext.Session.GetString("UserName");
				var khachHang = db.Khachhangs.FirstOrDefault(x => x.TaiKhoan == userName);
				if (string.IsNullOrEmpty(khachHang.DiaChiKh))
				{


                    return RedirectToAction("AddAddresx", "Home");


                }
				else
				{
					// Lấy thông tin giỏ hàng từ Session
					var cartItems = HttpContext.Session.Get<List<CartItem>>("GioHang");

					// Kiểm tra xem giỏ hàng có dữ liệu hay không
					if (cartItems == null || cartItems.Count == 0)
					{

						// Nếu không có, chuyển hướng đến trang thông báo giỏ hàng trống
						TempData["CheckOut"] = "Giỏ Hàng Trống!";

                        return RedirectToAction("Index");
					}


					Dondathang donDatHang = new Dondathang();
					donDatHang.MaKh = khachHang.MaKh;
					donDatHang.Dathanhtoan = "No";
					donDatHang.Tinhtranggiaohang = "no";
					donDatHang.Ngaygiao = "2024-04-21";
					donDatHang.Ngaydat = "2024-03-21";

					db.Dondathangs.Add(donDatHang);
					db.SaveChanges();

					// Lấy MaDonHang mới được tạo
					int maDonHangMoi = donDatHang.MaDonHang;

					// Bước 2: Tạo các chi tiết đơn hàng từ thông tin trong giỏ hàng và lưu vào cơ sở dữ liệu
					foreach (var cartItem in cartItems)
					{																				
						Chitietdonhang chiTietDonHang = new Chitietdonhang
						{
							MaDonHang = maDonHangMoi,
							MaSach = (int)cartItem.MaSach,
							Soluong = cartItem.SoLuong,
							Dongia = cartItem.DonGia
						};
						db.Chitietdonhangs.Add(chiTietDonHang);
						TempData["CheckOut"] = "Đặt Hàng thành công.";
					}
					db.SaveChanges();

					// Sau khi thanh toán thành công, xóa thông tin giỏ hàng từ Session
					HttpContext.Session.Remove("GioHang");

					// Chuyển hướng đến trang cảm ơn hoặc trang thông báo thanh toán thành công
					return RedirectToAction("Index");
				}
			}
        }

    }
}
