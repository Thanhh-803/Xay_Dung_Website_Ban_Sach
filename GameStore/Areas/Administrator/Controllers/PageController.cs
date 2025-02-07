using Microsoft.AspNetCore.Mvc;
using Game.Model.Entities;
using Game.Repository;

namespace GameStore.Areas.Administrator.Controllers
{
    [Area("Administrator")]
    public class PageController : Controller
    {
        private PageRepository pageRepo;
        public PageController()
        {
            pageRepo= new PageRepository();
        }
        public IActionResult Index()
        {
            var page = pageRepo.GetAll().ToList();
            return View(page);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Page page)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    pageRepo.Insert(page);
                    return Redirect("/Administrator/Page/Index");
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
            }
            return View(page);
        }
        [HttpGet]
        public IActionResult Edit(int id) /*Tiếp nhận tham số Id*/
        {
            var page = pageRepo.GetById(id);
            if (page == null)
            {
                return NotFound();

            }
            return View(page);// Truyen sang productCategory
        }
        [HttpPost]
        public IActionResult Edit(Page page)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    pageRepo.Update(page);/*Sử dụng model để tiếp nhận*/
                    return Redirect("/Administrator/Page/Index");
                }
            }
            catch (Exception ex)
            {

                ModelState.AddModelError("", ex.Message);
            }
            return View(page);
        }
        public IActionResult Delete(int id) // Xóa sản phẩm
        {
            pageRepo.Delete(id);
            return Redirect("/Administrator/Page/Index");
        }
    }
}
