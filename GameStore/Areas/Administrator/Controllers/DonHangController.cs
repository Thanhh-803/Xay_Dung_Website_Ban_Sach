using Microsoft.AspNetCore.Mvc;
using Game.Model.Entities;
using Game.Repository;

namespace GameStore.Areas.Administrator.Controllers
{
    [Area("Administrator")]
    public class DonHangController : Controller
    {
        private DonHangRepository donHangRepo;
        public DonHangController() 
        { 
            donHangRepo= new DonHangRepository();
        }
        public IActionResult Index()
        {
            var donHang = donHangRepo.GetAll().ToList();
            return View(donHang);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(DonHang donHang)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    donHangRepo.Insert(donHang);
                    return Redirect("/Administrator/DonHang/Index");
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
            }
            return View(donHang);
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var donHang = donHangRepo.GetById(id);
            if(donHang == null)
            {
                NotFound();
            }
            return View(donHang);
        }
        [HttpPost]
        public IActionResult Edit(DonHang donHang)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    donHangRepo.Update(donHang);
                    return Redirect("/Administrator/DonHang/Index");
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
            }
            return View(donHang);
        }
        public IActionResult Delete(int id) 
        {
            donHangRepo.Delete(id);
            return Redirect("/Administrator/DonHang/Index");
        }
    }
}
