using Microsoft.AspNetCore.Mvc;
using Game.Model.Entities;
using Game.Repository;

namespace GameStore.Areas.Administrator.Controllers
{
    [Area("Administrator")]
    public class SanPhamController : Controller
    {
        private SanPhamRepository sanPhamRepo;
        public SanPhamController()
        {
            sanPhamRepo = new SanPhamRepository();
        }
        public IActionResult Index()
        {
            var sanPham = sanPhamRepo.GetAll().ToList();
            return View(sanPham);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(SanPham sanPham)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    sanPhamRepo.Insert(sanPham);
                    return Redirect("/Administrator/SanPham/Index");
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
            }
            return View(sanPham);
        }
        [HttpGet]
        public IActionResult Edit(int id) /*Tiếp nhận tham số Id*/
        {
            var sanPham = sanPhamRepo.GetById(id);
            if (sanPham == null)
            {
                return NotFound();

            }
            return View(sanPham);// Truyen sang productCategory
        }
        [HttpPost]
        public IActionResult Edit(SanPham sanPham)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    sanPhamRepo.Update(sanPham);/*Sử dụng model để tiếp nhận*/
                    return Redirect("/Administrator/SanPham/Index");
                }
            }
            catch (Exception ex)
            {

                ModelState.AddModelError("", ex.Message);
            }
            return Redirect("/Administrator/SanPham/Index");
        }
        public IActionResult Delete(int id) // Xóa sản phẩm
        {
            sanPhamRepo.Delete(id);
            return Redirect("/Administrator/SanPham/Index");
        }
    }
}
