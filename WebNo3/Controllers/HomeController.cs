using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using WebNo3.Models;
using X.PagedList;

namespace WebNo3.Controllers
{
    public class HomeController : Controller
    {
        QlbanVaLiContext db = new QlbanVaLiContext();
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index(int? page)
        {
            //Phân trang
            int pageSize = 12;
            int pageNumber = page == null || page <=0 ? 1 : page.Value;
            var lstSanPham = db.TDanhMucSps.AsNoTracking().OrderBy(x => x.MaSp);

            PagedList<TDanhMucSp> lst = new PagedList<TDanhMucSp>(lstSanPham, pageNumber, pageSize);
            return View(lst);
        }
        public IActionResult SanPhamTheoLoai(string maloai, int page=1)
        {
            int pageSize = 8;
            int pageNumber = page;
            var lstSanPham = db.TDanhMucSps.Where(x => x.MaLoai == maloai).AsNoTracking().OrderBy(x => x.MaSp);

            PagedList<TDanhMucSp> lst = new PagedList<TDanhMucSp>(lstSanPham, pageNumber, pageSize);
            ViewBag.maloai = maloai;
            return View(lst);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}