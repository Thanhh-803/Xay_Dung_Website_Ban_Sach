using Game.Model.Entities;
using Game.Repository;
using Microsoft.AspNetCore.Mvc;

namespace GameStore.Controllers 
{ 
    public class DanhMucController : Controller
    {
        private DanhMucSanPhamRepository danhMucSanPhamRepo;
        private SanPhamRepository sanPhamRepo;
        public DanhMucController() 
        { 
            sanPhamRepo= new SanPhamRepository();
            danhMucSanPhamRepo = new DanhMucSanPhamRepository();
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult DanhMucSanPham(int Id)
        {
            var danhMuc = danhMucSanPhamRepo.GetAll().OrderByDescending(p => p.Id).ToList();
            var product = sanPhamRepo.GetAll().Where(p => p.CategoryId == Id).ToList();
            var tupleModel = new Tuple<List<DanhMucSanPham>, List<SanPham>>(danhMuc, product);
            return View(tupleModel);
        }
    }
}
