using Microsoft.AspNetCore.Mvc;
using Game.Model.Entities;
using Game.Repository;

namespace GameStore.Areas.Administrator.Controllers
{
    [Area("Administrator")]
    public class ChanTrangController : Controller
    {
        private ChanTrangRepository chanTrangRepo;
        public ChanTrangController()
        {
            chanTrangRepo = new ChanTrangRepository();
        }
        public IActionResult Index()
        {
            var menu = chanTrangRepo.GetAll().ToList();
            return View(menu);
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(ChanTrang chanTrang)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    chanTrangRepo.Insert(chanTrang);
                    return Redirect("/Administrator/ChanTrang/Index");
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
            }
            return View(chanTrang);
        }
        [HttpGet]
        public IActionResult Edit(int id) /*Tiếp nhận tham số Id*/
        {
            var menu = chanTrangRepo.GetById(id);
            if (menu == null)
            {
                return NotFound();

            }
            return View(menu);// Truyen sang productCategory
        }
        [HttpPost]
        public IActionResult Edit(ChanTrang chanTrang)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    chanTrangRepo.Update(chanTrang);/*Sử dụng model để tiếp nhận*/
                    return Redirect("/Administrator/ChanTrang/Index");
                }
            }
            catch (Exception ex)
            {

                ModelState.AddModelError("", ex.Message);
            }
            return View(chanTrang);
        }
        public IActionResult Delete(int id) // Xóa sản phẩm
        {
            chanTrangRepo.Delete(id);
            return Redirect("/Administrator/ChanTrang/Index");
        }
    }
}
