using Microsoft.AspNetCore.Mvc;
using Game.Model.Entities;
using Game.Repository;
using System.Data;

namespace GameStore.Controllers
{
    public class SanPhamController : Controller
    {
        private SanPhamRepository sanPhamRepo;
        private DanhMucSanPhamRepository danhMucSanPhamRepo;
        public SanPhamController()
        {
            sanPhamRepo = new SanPhamRepository();
            danhMucSanPhamRepo = new DanhMucSanPhamRepository();
        }
        public IActionResult Index(int Id)
        {
            var danhMuc = danhMucSanPhamRepo.GetAll().OrderByDescending(p => p.Id).ToList();
            var product = sanPhamRepo.GetAll().OrderByDescending(p => p.Id).ToList();// Cập nhật cuối cùng sẽ sử dụng ỎderByDescending
            

            var tupleModel = new Tuple<List<DanhMucSanPham>, List<SanPham>>(danhMuc, product);
            return View(tupleModel);
        }
        
    }
}
