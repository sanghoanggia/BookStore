using BookStoreCore.Models;
    using Microsoft.AspNetCore.Mvc;
    using BookStoreCore.Repository;
    namespace BookStoreCore.ViewComponents
    {
        public class ChuDeViewComponent: ViewComponent
        {
            private readonly IChuDeRepository _chuDe;
            public ChuDeViewComponent(IChuDeRepository chuDeRepository)
            {
            _chuDe = chuDeRepository;
            }
            public IViewComponentResult Invoke()
            {
                var chude = _chuDe.GetAllChuDe().OrderBy(x => x.TenChuDe);
                return View(chude);
            }
        }
    }
