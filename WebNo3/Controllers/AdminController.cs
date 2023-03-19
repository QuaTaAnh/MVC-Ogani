using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
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

		//Sửa sản phẩm
		[Route("SuaSanPham")]
		[HttpGet]
		public IActionResult SuaSanPham(string maSanPham)
		{
			ViewBag.MaChatLieu = new SelectList(db.TChatLieus.ToList(),
				"MaChatLieu", "ChatLieu");
            ViewBag.MaHangSx = new SelectList(db.THangSxes.ToList(),
                "MaHangSx", "HangSx");
            ViewBag.MaNuocSx = new SelectList(db.TQuocGia.ToList(),
                "MaNuoc", "TenNuoc");
            ViewBag.MaLoai = new SelectList(db.TLoaiSps.ToList(),
                "MaLoai", "Loai");
            ViewBag.MaDt = new SelectList(db.TLoaiDts.ToList(),
                "MaDt", "TenLoai");
            var sanpham = db.TDanhMucSps.Find(maSanPham);
			return View(sanpham);
		}

        [Route("SuaSanPham")]
        [HttpPost]
		[ValidateAntiForgeryToken]
        public IActionResult SuaSanPham(TDanhMucSp sanpham)
        {
			if (ModelState.IsValid)
			{
				db.Entry(sanpham).State = EntityState.Modified;
				db.SaveChanges();
				return RedirectToAction("Index");
			}
            return View(sanpham);
        }

        //Thêm mới sản phẩm
        [Route("ThemSanPham")]
        [HttpGet]
        public IActionResult ThemSanPham()
        {
            ViewBag.MaChatLieu = new SelectList(db.TChatLieus.ToList(),
                "MaChatLieu", "ChatLieu");
            ViewBag.MaHangSx = new SelectList(db.THangSxes.ToList(),
                "MaHangSx", "HangSx");
            ViewBag.MaNuocSx = new SelectList(db.TQuocGia.ToList(),
                "MaNuoc", "TenNuoc");
            ViewBag.MaLoai = new SelectList(db.TLoaiSps.ToList(),
                "MaLoai", "Loai");
            ViewBag.MaDt = new SelectList(db.TLoaiDts.ToList(),
                "MaDt", "TenLoai");
            return View();
        }

        [Route("ThemSanPham")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult themSanPham(TDanhMucSp sanpham)
        {
            if (ModelState.IsValid)
            {
                db.TDanhMucSps.Add(sanpham);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(sanpham);
        }
    }
}
