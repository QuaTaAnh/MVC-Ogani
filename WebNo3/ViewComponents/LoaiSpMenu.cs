using WebNo3.Models;
using Microsoft.AspNetCore.Mvc;
using WebNo3.Repository;

namespace WebNo3.ViewComponents
{
    public class LoaiSpMenu:ViewComponent
    {
        private readonly ILoaiSpRepository _loaiSp;
        public LoaiSpMenu(ILoaiSpRepository loaiSpRepository)
        {
            _loaiSp = loaiSpRepository;
        }
        public IViewComponentResult Invoke()
        {
            var loaisp = _loaiSp.GetAllLoaiSp().OrderBy(x => x.Loai);
            return View(loaisp);
        }
    }
}
