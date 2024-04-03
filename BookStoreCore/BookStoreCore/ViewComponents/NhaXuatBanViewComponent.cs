using BookStoreCore.Models;
    using Microsoft.AspNetCore.Mvc;
    using BookStoreCore.Repository;
    namespace BookStoreCore.ViewComponents
    {
        public class NhaXuatBanViewComponent : ViewComponent
        {
            private readonly INhaXuatBanRepository _NXB;
            public NhaXuatBanViewComponent(INhaXuatBanRepository NXBRepository)
            {
			_NXB = NXBRepository;
            }
            public IViewComponentResult Invoke()
            {
                var tenNXB = _NXB.GetAllNXB().OrderBy(x => x.TenNxb);
                return View(tenNXB);
            }
        }
    }
