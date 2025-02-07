using Game.Model.Entities;
using Microsoft.AspNetCore.Mvc;
using Game.Repository;
using System.Runtime.CompilerServices;

namespace GameStore.Areas.Administrator.Controllers
{
    [Area("Administrator")]
    public class DanhMucSanPhamController : Controller
    {
        private DanhMucSanPhamRepository danhMucSanPhamRepo;
        public DanhMucSanPhamController()
        {
            danhMucSanPhamRepo = new DanhMucSanPhamRepository();
        }
        public IActionResult Index()
        {
            var danhMucSanPham = danhMucSanPhamRepo.GetAll().ToList();
            return View(danhMucSanPham);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(DanhMucSanPham danhMucSanPham)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    danhMucSanPhamRepo.Insert(danhMucSanPham);
                    //return RedirectToAction("Index");
                    return Redirect("/Administrator/DanhMucSanPham/Index");
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
            }
            return View(danhMucSanPham);
        }
        [HttpGet]
        public IActionResult Edit(int id) /*Tiếp nhận tham số Id*/
        {
            var producttCategory = danhMucSanPhamRepo.GetById(id);
            if (producttCategory == null)
            {
                return NotFound();

            }
            return View(producttCategory);// Truyen sang productCategory
        }
        [HttpPost]
        public IActionResult Edit(DanhMucSanPham danhMucSanPham)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    danhMucSanPhamRepo.Update(danhMucSanPham);/*Sử dụng model để tiếp nhận*/
                    return Redirect("/Administrator/DanhMucSanPham/Index");
                }
            }
            catch (Exception ex)
            {

                ModelState.AddModelError("", ex.Message);
            }
            return View(danhMucSanPham);
        }
        public IActionResult Delete(int id) // Xóa sản phẩm
        {
            danhMucSanPhamRepo.Delete(id);
            return Redirect("/Administrator/DanhMucSanPham/Index");
        }
    }
}
