using Microsoft.AspNetCore.Mvc;
using Game.Model.Entities;
using Game.Repository;

namespace GameStore.Areas.Administrator.Controllers
{
    [Area("Administrator")]
    public class MenuGroupController : Controller
    {
        private MenuGroupRepository menuGroupRepo;
        public MenuGroupController()
        {
            menuGroupRepo = new MenuGroupRepository();
        }
        public IActionResult Index()
        {
            var menuGroup = menuGroupRepo.GetAll().ToList();
            return View(menuGroup);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(MenuGroup menuGroup)
        {
            try
            {
                if(ModelState.IsValid)
                {
                    menuGroupRepo.Insert(menuGroup);
                    return Redirect("/Administrator/MenuGroup/Index");
                }
            }
            catch (Exception  ex)
            {
                ModelState.AddModelError("", ex.Message);
            }
            return View(menuGroup);
        }
        [HttpGet]
        public IActionResult Edit(int id) /*Tiếp nhận tham số Id*/
        {
            var menuGroup = menuGroupRepo.GetById(id);
            if (menuGroup == null)
            {
                return NotFound();

            }
            return View(menuGroup);// Truyen sang productCategory
        }
        [HttpPost]
        public IActionResult Edit(MenuGroup menuGroup)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    menuGroupRepo.Update(menuGroup);/*Sử dụng model để tiếp nhận*/
                    return Redirect("/Administrator/MenuGroup/Index");
                }
            }
            catch (Exception ex)
            {

                ModelState.AddModelError("", ex.Message);
            }
            return View(menuGroup);
        }
        public IActionResult Delete(int id) // Xóa sản phẩm
        {
            menuGroupRepo.Delete(id);
            return Redirect("/Administrator/MenuGroup/Index");
        }
    }
}
