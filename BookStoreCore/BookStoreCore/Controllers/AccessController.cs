using JetBrains.Annotations;
using Microsoft.AspNetCore.Mvc;
using BookStoreCore.Models;

namespace BookStoreCore.Controllers
{
    public class AccessController : Controller
    {
        QlbookstoreContext db = new QlbookstoreContext();

        [HttpGet]
        public IActionResult Login()
        {
            if (HttpContext.Session.GetString("UserName") == null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }

        }


        [HttpPost]
        public IActionResult Login1(string? usernameLogin, string? passwordLogin)
        {
            if (HttpContext.Session.GetString("UserName") == null)
            {
                var user = db.Khachhangs.Where(x => (x.TaiKhoan.Equals(usernameLogin) && x.MatKhau.Equals(passwordLogin))).FirstOrDefault();
               /* var admin = db.TaiKhoans.Where(x => x.TenTk.Equals(usernameLogin) && x.MatKhau.Equals(passwordLogin)).FirstOrDefault();*/
                if (user != null)
                {
                    HttpContext.Session.SetString("UserName", user.TaiKhoan.ToString());
                    return RedirectToAction("Index", "Home");
                }
              /*  if (admin != null)
                {
                    HttpContext.Session.SetString("AdminName", admin.TenTk.ToString());
                    return RedirectToAction("Index", "Admin");
                }*/

            }
            return View();
        }

        [HttpPost]
        public IActionResult Login(Khachhang user)
        {
            if (HttpContext.Session.GetString("UserName") == null)
            {
                var u = db.Khachhangs.Where(x => x.TaiKhoan.Equals(user.TaiKhoan) && x.MatKhau.Equals(user.MatKhau)).FirstOrDefault();
                if (u != null)
                {
                    HttpContext.Session.SetString("UserName", u.TaiKhoan.ToString());
                    return RedirectToAction("Index", "Home");
                }
            }
            return View();
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            HttpContext.Session.Remove("UserName");
            return RedirectToAction("Login", "Access");
        }


        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(Khachhang u)
        {
            if (ModelState.IsValid)
            {
                db.Khachhangs.Add(u);
                db.SaveChanges();
                return RedirectToAction("Login", "Access");
            }
            else
            {
                return View(u); // Trả lại view với dữ liệu đã nhập
            }

        }
    }
}
