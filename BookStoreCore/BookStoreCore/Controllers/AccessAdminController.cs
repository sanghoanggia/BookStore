using BookStoreCore.Models;
using Microsoft.AspNetCore.Mvc;

namespace BookStoreCore.Controllers
{
    public class AccessAdminController : Controller
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
                return RedirectToAction("DanhMucSanPham", "Admin");
            }

        }

        [HttpPost]
        public IActionResult Login(Admin admin)
        {
            if (HttpContext.Session.GetString("UserName") == null)
            {
                var u = db.Admins.Where(x => x.Username.Equals(admin.Username) && x.Password.Equals(admin.Password)).FirstOrDefault();
                if (u != null)
                {
                    HttpContext.Session.SetString("UserName", u.Username.ToString());
                    return RedirectToAction("DanhMucSanPham", "Admin");
                }
            }
            return View();
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            HttpContext.Session.Remove("UserName");
            return RedirectToAction("Login", "AccessAdmin");
        }
    }
}
