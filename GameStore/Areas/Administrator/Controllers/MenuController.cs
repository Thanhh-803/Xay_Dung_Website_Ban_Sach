using Microsoft.AspNetCore.Mvc;
using Game.Model.Entities;
using Game.Repository;

namespace GameStore.Areas.Administrator.Controllers
{
    [Area("Administrator")]
    public class MenuController : Controller
    {
        private MenuRepository menuRepo;
        public MenuController()
        {
            menuRepo = new MenuRepository();
        }
        public IActionResult Index()
        {
            var menu = menuRepo.GetAll().ToList();
            return View(menu);
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Menu menu)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    menuRepo.Insert(menu);
                    return Redirect("/Administrator/Menu/Index");
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
            }
            return View(menu);
        }
        [HttpGet]
        public IActionResult Edit(int id) /*Tiếp nhận tham số Id*/
        {
            var menu = menuRepo.GetById(id);
            if (menu == null)
            {
                return NotFound();

            }
            return View(menu);// Truyen sang productCategory
        }
        [HttpPost]
        public IActionResult Edit(Menu menu)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    menuRepo.Update(menu);/*Sử dụng model để tiếp nhận*/
                    return Redirect("/Administrator/Menu/Index");
                }
            }
            catch (Exception ex)
            {

                ModelState.AddModelError("", ex.Message);
            }
            return View(menu);
        }
        public IActionResult Delete(int id) // Xóa sản phẩm
        {
            menuRepo.Delete(id);
            return Redirect("/Administrator/Menu/Index");
        }
    }
}
