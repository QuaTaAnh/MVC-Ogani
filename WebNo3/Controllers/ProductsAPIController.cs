using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebNo3.Models;
using WebNo3.Models.ProductModels;

namespace WebNo3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsAPIController : ControllerBase
    {
        QlbanVaLiContext db = new QlbanVaLiContext();
        [HttpGet]
        public IEnumerable<Product> GetAllProducts()
        {
            var products = (from p in db.TDanhMucSps select new Product {
                MaSp = p.MaSp,
                TenSp = p.TenSp,
                MaLoai = p.MaLoai,
                AnhDaiDien = p.AnhDaiDien,
                GiaNhoNhat = p.GiaNhoNhat,
            }).ToList();
            return products;
        }

        [HttpGet("{maloai}")]
        public IEnumerable<Product> GetProductsByCategory(string maloai)
        {
            var products = (from p in db.TDanhMucSps
                            where p.MaLoai == maloai
                            select new Product
                            {
                                MaSp = p.MaSp,
                                TenSp = p.TenSp,
                                MaLoai = p.MaLoai,
                                AnhDaiDien = p.AnhDaiDien,
                                GiaNhoNhat = p.GiaNhoNhat,
                            }).ToList();
            return products;
        }
    }
}
