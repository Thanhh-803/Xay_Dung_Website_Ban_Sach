using Game.Model.Entities;
using Game.Repository;
using GameStore.Models;
using Microsoft.AspNetCore.Mvc;
using Game.Model.Entities;
using Game.Repository;
using System.Diagnostics;

namespace GameStore.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private DanhMucSanPhamRepository danhMucSanPhamRepo;
        private SanPhamRepository sanPhamRepo;
        private SliderRepository sliderRepo;
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
            danhMucSanPhamRepo = new DanhMucSanPhamRepository();
            sanPhamRepo = new SanPhamRepository();
            sliderRepo = new SliderRepository();
        }

        public IActionResult Index()
        {
            var danhMuc = danhMucSanPhamRepo.GetAll().OrderByDescending(p => p.Id).ToList();
            var newSp = sanPhamRepo.GetAll().OrderByDescending(p => p.ViewCount).ToList(); // Cập nhật cuối cùng sẽ sử dụng ỎderByDescending
            var slider = sliderRepo.GetAll().OrderByDescending(p => p.Id).ToList();
            var tupleModel = new Tuple<List<DanhMucSanPham>, List<SanPham>, List<Slide>>(danhMuc, newSp, slider);
            return View(tupleModel);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        public IActionResult Details(int id)
        {
            var product = sanPhamRepo.GetById(id);
            var relatedProduct = sanPhamRepo.GetAll().Where(p => p.CategoryId == product.CategoryId).ToList();// loc ra san pham cos id cua no
            var tupleModel = new Tuple<SanPham, List<SanPham>>(product, relatedProduct);
            return View(tupleModel);
        }
    }
}