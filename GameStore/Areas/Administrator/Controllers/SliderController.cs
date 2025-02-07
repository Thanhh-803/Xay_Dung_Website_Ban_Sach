using Microsoft.AspNetCore.Mvc;
using Game.Model.Entities;
using Game.Repository;

namespace GameStore.Areas.Administrator.Controllers
{
    [Area("Administrator")]
    public class SliderController : Controller
    {
        private SliderRepository sliderRepo;
        public SliderController()
        {
            sliderRepo = new SliderRepository();
        }
        public IActionResult Index()
        {
            var slider = sliderRepo.GetAll().ToList();
            return View(slider);
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Slide slide)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    sliderRepo.Insert(slide);
                    return Redirect("/Administrator/Slider/Index");
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
            }
            return View(slide);
        }
        [HttpGet]
        public IActionResult Edit(int id) /*Tiếp nhận tham số Id*/
        {
            var slider = sliderRepo.GetById(id);
            if (slider == null)
            {
                return NotFound();

            }
            return View(slider);// Truyen sang productCategory
        }
        [HttpPost]
        public IActionResult Edit(Slide slide)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    sliderRepo.Update(slide);/*Sử dụng model để tiếp nhận*/
                    return Redirect("/Administrator/Slider/Index");
                }
            }
            catch (Exception ex)
            {

                ModelState.AddModelError("", ex.Message);
            }
            return View(slide);
        }
        public IActionResult Delete(int id) // Xóa sản phẩm
        {
            sliderRepo.Delete(id);
            return Redirect("/Administrator/Slider/Index");
        }
    }
}
