using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebNo3.Models;
using X.PagedList;

namespace WebNo3.Controllers
{
	public class AdminController : Controller
	{
		QlbanVaLiContext db = new QlbanVaLiContext();
		[Route("/admin")]
		public IActionResult Admin()
		{
			return View();
		}
		public IActionResult DanhMucSanPham(int? page)
		{
            //Phân trang
            int pageSize = 12;
            int pageNumber = page == null || page <= 0 ? 1 : page.Value;
            var lstSanPham = db.TDanhMucSps.AsNoTracking().OrderBy(x => x.MaSp);

            PagedList<TDanhMucSp> lst = new PagedList<TDanhMucSp>(lstSanPham, pageNumber, pageSize);
            return View(lst);
		}
		public IActionResult ChiTietSanPham(string maSp)
		{
			var list = db.TDanhMucSps.SingleOrDefault(x=>x.MaSp == maSp);
			return View(list);
		}
	}
}
